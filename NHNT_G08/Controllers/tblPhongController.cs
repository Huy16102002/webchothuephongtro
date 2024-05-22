using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHNT_G08.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NHNT_G08.Controllers
{
    public class tblPhongController : Controller
    {
        private readonly NHNTContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public tblPhongController(NHNTContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        [HttpGet]
        [Route("/ChiTietPhong/{id:int}")]
        public IActionResult ChiTietPhong(int id)
        {
            var phong = _context.tblPhong.First(p => p.maPhong == id);
            var maTaiKhoan = Convert.ToInt32(HttpContext.Session.GetString("maTaiKhoan"));
            phong.soSaoTrungBinh = LayDanhGiaPhongTheoID(id, maTaiKhoan);
            var listAnh = LayHinhAnhPhongTheoID(id);
            if (listAnh.Count != 0)
            {
                phong.tenAnh = new List<string>();
                phong.tenAnh.AddRange(listAnh);
            }

            return View(phong);
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
            int pageSize = 5;
            var listPhong = _context.tblPhong.Where(p => string.Equals(p.trangThaiBaiDang, "Duyệt")).OrderBy(p => p.giaPhong).ToList();
            LaySoSaoTrungBinh(listPhong);
            LayThongTinNguoiDang(listPhong);
            LayHinhAnhPhong(listPhong);
            return View("Index", Pagination<Phong>.Create(listPhong, pageIndex ?? 1, pageSize));
        }
        public IActionResult HienP()
        {
            var query = from a in _context.tblPhong
                        
                        select new
                        {
                            ma = a.maPhong, 
                            tenP = a.tenPhong,
                            diaC =a.diaChi
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
                var listAnh = _context.tblHinhAnh.Where(p => p.maPhong == phong.maPhong).Select(p => p.duongDan).ToList();

                if (listAnh.Count != 0)
                {
                    phong.tenAnh = new List<string>();
                    phong.tenAnh.AddRange(listAnh);
                }
            }
            return listPhong;
        }

        List<string> LayHinhAnhPhongTheoID(int id)
        {
            return _context.tblHinhAnh.Where(p => p.maPhong == id).Select(p => p.duongDan).ToList(); ;
        }

        int LayDanhGiaPhongTheoID(int id, int maTaiKhoan)
        {
            return _context.tblDanhGiaPhong.Where(p => p.maPhong == id && p.maTaiKhoan == maTaiKhoan).Select(p => p.soSao).FirstOrDefault();
        }
    }
}
