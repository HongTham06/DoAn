using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaiTapLon.Models;
using System.Data.SqlClient;
namespace BaiTapLon.Controllers
{
    public class TrangKhachHangController : Controller
    {
        //
        // GET: /TrangKhachHang/

        QLSMphoneDataContext db = new QLSMphoneDataContext();

            public ActionResult DangKy()
            {
                return View();
            }
            [HttpPost]
            public ActionResult XLDangKy(FormCollection c, KHACHHANG kh)
            {
                var hoTenKH = c["txtHoTen"];
                var tenDangNhap = c["txtTenDangNhap"];
                var matKhau = c["txtMK"];

                kh.TENKH = hoTenKH;
                kh.TAIKHOAN = tenDangNhap;
                kh.MATKHAU = matKhau;

                db.KHACHHANGs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return RedirectToAction("DangNhap");
            }
            public ActionResult DangNhap()
            {
                return View();
            }

            [HttpPost]
            //public ActionResult DangNhap(FormCollection c)
            //{
            //    var tenDangNhap = c["txtTenDangNhap"];
            //    var matKhau = c["txtMK"];
            //    KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(x => x.TAIKHOAN == tenDangNhap && x.MATKHAU == matKhau);
            //    if (kh != null)
            //    {

            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //        return RedirectToAction("DangNhap");
            //}
            public ActionResult DangNhap(FormCollection collection)
            {


                var tendn = collection["TAIKHOAN"];
                var mk = collection["MATKHAU"];
                if (String.IsNullOrEmpty(tendn))
                    ViewData["Loi"] = "Bạn phải nhập tên đăng nhập";
                else if (String.IsNullOrEmpty(mk))
                {
                    ViewData["Loi1"] = "Bạn phải nhập mật khẩu";
                }
                else
                {
                    KHACHHANG tk = db.KHACHHANGs.SingleOrDefault(n => n.TAIKHOAN.Equals(tendn) && n.MATKHAU.Equals(mk));
                    if (tk != null)
                    {
                        //if (tk.Quyen == true)//Admin
                        //{
                        //    @Session["TK"] = tk.TenDN;
                        //    @Session["quyen"] = 1;
                        //    return RedirectToAction("Home", "Admin/HomeAdmin/");
                        //}
                        //if (tk.Quyen == false || tk.Quyen == null)
                        //{
                            @Session["quyen"] = null;
                            @Session["TK"] = tk.TAIKHOAN;
                            return RedirectToAction("Index", "Home");
                        //}
                    }
                    else
                    {
                        ViewData["Loi2"] = "Tên đăng nhâp hoặc mật khẩu không đúng";
                    }
                }

                return View();
            }
          
            public ActionResult DangXuat()
            {
                @Session["TK"] = null;
                return Redirect("/");

            }
        }
    }

