#pragma checksum "C:\Users\phamv\Downloads\WebNC-main-20240229T142523Z-001\WebNC-main\NHNT_G08\Views\QuanLyTaiKhoan\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "bffa2090de88e644fe3da6941ec3b653d4618aa5088c7ca9cb11ee428ae2b845"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_QuanLyTaiKhoan_Index), @"mvc.1.0.view", @"/Views/QuanLyTaiKhoan/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\phamv\Downloads\WebNC-main-20240229T142523Z-001\WebNC-main\NHNT_G08\Views\_ViewImports.cshtml"
using NHNT_G08;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\phamv\Downloads\WebNC-main-20240229T142523Z-001\WebNC-main\NHNT_G08\Views\_ViewImports.cshtml"
using NHNT_G08.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"bffa2090de88e644fe3da6941ec3b653d4618aa5088c7ca9cb11ee428ae2b845", @"/Views/QuanLyTaiKhoan/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4d274438e2dc68bbc1c9db9aba67326332449e1cb3ae57ed91b9135414ebea20", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_QuanLyTaiKhoan_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<NHNT_G08.Models.TaiKhoan>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/quanlybaidang.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n");
            DefineSection("Style", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bffa2090de88e644fe3da6941ec3b653d4618aa5088c7ca9cb11ee428ae2b8454207", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
            }
            );
            WriteLiteral("\n");
            WriteLiteral(@"
<div class=""main"">
    <h1 class=""title"">Quản lý tài khoản</h1>
    <div class=""grid item"">

        <table>
            <tr>
                <th>STT</th>
                <th>Họ tên người dùng</th>
                <th>Số điện thoại</th>
                <th>Tên đăng nhập</th>
                <th>Vai trò</th>
                <th>Trạng thái tài khoản</th>
                <th>Tác vụ</th>
            </tr>

");
#nullable restore
#line 24 "C:\Users\phamv\Downloads\WebNC-main-20240229T142523Z-001\WebNC-main\NHNT_G08\Views\QuanLyTaiKhoan\Index.cshtml"
             for (int i = 1; i <= Model.Count; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <td>");
#nullable restore
#line 27 "C:\Users\phamv\Downloads\WebNC-main-20240229T142523Z-001\WebNC-main\NHNT_G08\Views\QuanLyTaiKhoan\Index.cshtml"
                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 28 "C:\Users\phamv\Downloads\WebNC-main-20240229T142523Z-001\WebNC-main\NHNT_G08\Views\QuanLyTaiKhoan\Index.cshtml"
                   Write(Model[i - 1].hoTenNguoiDung);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 29 "C:\Users\phamv\Downloads\WebNC-main-20240229T142523Z-001\WebNC-main\NHNT_G08\Views\QuanLyTaiKhoan\Index.cshtml"
                   Write(Model[i - 1].soDienThoai);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 30 "C:\Users\phamv\Downloads\WebNC-main-20240229T142523Z-001\WebNC-main\NHNT_G08\Views\QuanLyTaiKhoan\Index.cshtml"
                   Write(Model[i - 1].tenDangNhap);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 31 "C:\Users\phamv\Downloads\WebNC-main-20240229T142523Z-001\WebNC-main\NHNT_G08\Views\QuanLyTaiKhoan\Index.cshtml"
                   Write(Model[i - 1].tenLoaiTK);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td");
            BeginWriteAttribute("class", " class=\"", 891, "\"", 938, 2);
#nullable restore
#line 32 "C:\Users\phamv\Downloads\WebNC-main-20240229T142523Z-001\WebNC-main\NHNT_G08\Views\QuanLyTaiKhoan\Index.cshtml"
WriteAttributeValue("", 899, Model[i - 1].maTaiKhoan, 899, 24, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 923, "status_account", 924, 15, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 32 "C:\Users\phamv\Downloads\WebNC-main-20240229T142523Z-001\WebNC-main\NHNT_G08\Views\QuanLyTaiKhoan\Index.cshtml"
                                                                   Write(Model[i - 1].trangThai);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>\n                        <button class=\"btn btn_khoa\" data-id=\"");
#nullable restore
#line 34 "C:\Users\phamv\Downloads\WebNC-main-20240229T142523Z-001\WebNC-main\NHNT_G08\Views\QuanLyTaiKhoan\Index.cshtml"
                                                         Write(Model[i - 1].maTaiKhoan);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Khóa tài khoản</button>\n                    </td>\n                </tr>\n");
#nullable restore
#line 37 "C:\Users\phamv\Downloads\WebNC-main-20240229T142523Z-001\WebNC-main\NHNT_G08\Views\QuanLyTaiKhoan\Index.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n        </table>\n\n    </div>\n</div>\n\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    <script>\n        $(document).ready(function () {\n            $(\'.btn_khoa\').click(function () {\n\n                var id = $(this).attr(\'data-id\');\n                $.ajax({\n                    type: \"POST\",\n                    url: \"");
#nullable restore
#line 55 "C:\Users\phamv\Downloads\WebNC-main-20240229T142523Z-001\WebNC-main\NHNT_G08\Views\QuanLyTaiKhoan\Index.cshtml"
                     Write(Url.Action("khoaTaiKhoan"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                    data: {
                        id: id
                    },
                    success: function (result) {
                        console.log(result);
                        if (result == true) {
                            $('.'+id).html(""Đã khóa"");
                            alert(""Đã khóa tài khoản"");
                        }
                    }
                });
            });


           


           

        });
    </script>

");
            }
            );
            WriteLiteral("\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<NHNT_G08.Models.TaiKhoan>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
