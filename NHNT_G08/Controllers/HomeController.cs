using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NHNT_G08.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NHNT_G08.Controllers
{
    public class HomeController : Controller
    {
        private readonly NHNTContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(NHNTContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        //public IActionResult Index(int? pageIndex)
        //{
        //    ViewBag.TenDangNhap = HttpContext.Session.GetString("tenDangNhap");
        //    int pageSize = 12;
        //    var listPhong = _context.tblPhong.Where(p=> string.Equals(p.trangThaiBaiDang, "Duyệt")).ToList();
        //    LaySoSaoTrungBinh(listPhong);
        //    LayThongTinNguoiDang(listPhong);
        //    LayHinhAnhPhong(listPhong);
        //    return View(Pagination<Phong>.Create(listPhong, pageIndex ?? 1, pageSize));
        //}

        [HttpGet]
        [Route("/ChiTietPhong/{id:int}")]
        public IActionResult ChiTietPhong(int id)
        {
            var phong = _context.tblPhong.First(p => p.maPhong == id);
            var maTaiKhoan = Convert.ToInt32(HttpContext.Session.GetString("maTaiKhoan"));
            phong.soSaoTrungBinh = LayDanhGiaPhongTheoID(id,maTaiKhoan);
            var listAnh = LayHinhAnhPhongTheoID(id);
            if ( listAnh.Count != 0 )
            {
                phong.tenAnh = new List<string>();
                phong.tenAnh.AddRange(listAnh);
            }
                
            return View(phong);
        }

        [HttpPost]
        public bool DanhGiaBaiDang([FromForm] int soSao, [FromForm] int maPhong, [FromForm] int maTaiKhoan)
        {
            try
            {
                var checkDanhGia = _context.tblDanhGiaPhong.FirstOrDefault(p => p.maPhong == maPhong && p.maTaiKhoan == maTaiKhoan);
                
            if (checkDanhGia != null)
            {
                    checkDanhGia.soSao = soSao;
                _context.Update(checkDanhGia);
            }
            else
            {
                    DanhGiaPhong danhGiaPhong = new DanhGiaPhong();
                    danhGiaPhong.maPhong = maPhong;
                    danhGiaPhong.maTaiKhoan = maTaiKhoan;
                    danhGiaPhong.soSao = soSao;
                _context.tblDanhGiaPhong.Add(danhGiaPhong);
            }
            _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IActionResult Index(string search, int? pageIndex)
        {
            ViewBag.TenDangNhap = HttpContext.Session.GetString("tenDangNhap");
            int pageSize = 3;
            var listPhong = _context.tblPhong.Where(p => string.Equals(p.trangThaiBaiDang, "Duyệt")).ToList();
            if (!string.IsNullOrEmpty(search))
            {
                listPhong = listPhong.Where(p => p.diaChi.ToUpper().Contains(search.ToUpper())).ToList();
            }
            LaySoSaoTrungBinh(listPhong);
            LayThongTinNguoiDang(listPhong);
            LayHinhAnhPhong(listPhong);
            return View(Pagination<Phong>.Create(listPhong, pageIndex ?? 1, pageSize));
        }

        public IActionResult SortByPrice(int? pageIndex)
        {
            ViewBag.TenDangNhap = HttpContext.Session.GetString("tenDangNhap");
            int pageSize = 3;
            var listPhong = _context.tblPhong.Where(p => string.Equals(p.trangThaiBaiDang, "Duyệt")).OrderBy(p => p.giaPhong).ToList();
            LaySoSaoTrungBinh(listPhong);
            LayThongTinNguoiDang(listPhong);
            LayHinhAnhPhong(listPhong);
            return View("Index", Pagination<Phong>.Create(listPhong, pageIndex ?? 1, pageSize));
        }
        // join 2 bảng
        public IActionResult haiBang()
        {
            var query = from a in _context.tblTaiKhoan
                        join b in _context.tblDmTaiKhoan on a.maDmTaiKhoan equals b.maDmTaiKhoan
                        select new
                        {
                            ma = a.maTaiKhoan, // Thay thế Field1 bằng tên trường bạn muốn lấy từ TableA
                            Ten = a.tenDangNhap,
                            Tenloaitk = b.tenLoaiTK // Thay thế Field2 bằng tên trường bạn muốn lấy từ TableB
                        };

            // Bây giờ, query chứa kết quả của phép nối
            // Bạn có thể sử dụng kết quả này để trả về dưới dạng JSON hoặc sử dụng trong view

            return Json(query.ToList());
        }

        List<Phong> LayThongTinNguoiDang(List<Phong> listPhong)
        {
            foreach (var phong in listPhong)
            {
                var taiKhoan = _context.tblTaiKhoan.First(p => p.maTaiKhoan == phong.maTaiKhoan);
                phong.tenNguoiDang = taiKhoan.hoTenNguoiDung;
            }
            return listPhong;
        }

        List<Phong> LaySoSaoTrungBinh(List<Phong> listPhong)
        {
            var listDanhGia = _context.tblDanhGiaPhong.GroupBy(t => new { ID = t.maPhong })
                                       .Select(g => new
                                       {
                                           Count = g.Count(),
                                           Average = g.Average(p => p.soSao),
                                           ID = g.Key.ID
                                       });

            foreach (var item in listPhong)
            {
                var danhGiaPhong = listDanhGia.FirstOrDefault(p => p.ID == item.maPhong);
                if (danhGiaPhong != null)
                {
                    item.soSaoTrungBinh = (float)danhGiaPhong.Average;
                    item.soLuotDanhGia = danhGiaPhong.Count;
                }
                else continue;
            }
            return listPhong;
        }

        List<Phong> LayHinhAnhPhong(List<Phong> listPhong)
        {
            foreach (var phong in listPhong)
            {
                var listAnh = _context.tblHinhAnh.Where(p=>p.maPhong == phong.maPhong).Select(p => p.duongDan).ToList();
                
                if(listAnh.Count != 0)
                {
                    phong.tenAnh = new List<string>();
                    phong.tenAnh.AddRange(listAnh);
                }                
            }
            return listPhong;
        }

        List<string> LayHinhAnhPhongTheoID(int id)
        { 
            return _context.tblHinhAnh.Where(p => p.maPhong == id).Select(p=> p.duongDan).ToList(); ;
        }

        int LayDanhGiaPhongTheoID(int id, int maTaiKhoan)
        {
            return _context.tblDanhGiaPhong.Where(p => p.maPhong == id && p.maTaiKhoan == maTaiKhoan).Select(p=> p.soSao).FirstOrDefault();
        }
    }
}
