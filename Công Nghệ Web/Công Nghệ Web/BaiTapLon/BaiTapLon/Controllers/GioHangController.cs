using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaiTapLon.Models;
using System.Data.SqlClient;
namespace BaiTapLon.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/

        QLSMphoneDataContext db = new QLSMphoneDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public List<item> laygiohang()
        {
            List<item> lstGH = Session["gh"] as List<item>;
            if (lstGH == null)
            {
                lstGH = new List<item>();
                Session["gh"] = lstGH;
            }
            return lstGH;

        }
        public ActionResult ThemGioHang(string ms)
        {
            List<item> lst = laygiohang();
            item a = lst.FirstOrDefault(t => t.masp == ms);
            if (a == null)
            {
                item s = new item(ms);
                lst.Add(s);
            }
            return RedirectToAction("XemGioHang");
        }
        public ActionResult XemGioHang()
        {
            List<item> lstGioHang = laygiohang();
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.tongsoluong = tongsoluong();
            ViewBag.tongtien = tongtien();
            return View(lstGioHang);
        }
        public ActionResult Chitiet(string mi)
        {
            List<item> lst = laygiohang();
            item a = lst.FirstOrDefault(t => t.masp == mi);
            return View(a);
        }
        public int tongsoluong()
        {
            int tongsl = 0;
            List<item> listitem = Session["gh"] as List<item>;
            if (listitem != null)
            {
                tongsl = listitem.Sum(t => t.soluong);
            }
            return tongsl;
        }
        public ActionResult Xoa1SP(string mi)
        {
            //lấy giỏ hàng
            List<item> lst = laygiohang();
            //int m = int.Parse(mi);
            item a = lst.FirstOrDefault(t => t.masp == mi);
            if (a != null)
            {
                lst.RemoveAll(t => t.masp == mi);
            }
            if (lst.Count == 0)
                RedirectToAction("Index", "Home");
            return RedirectToAction("XemGioHang");
        }
        public double tongtien()
        {
            float tong = 0;
            List<item> lstGioHang = Session["gh"] as List<item>;
            if (lstGioHang != null) 
            {
                tong = lstGioHang.Sum(n => n.thanhtien);
            }
            return tong;
        }

        [HttpGet]
        public ActionResult DatHang1()
        {
            if (Session["TAIKHOAN"] != null || Session["TAIKHOAN"].ToString() == "")
           
            {
                return RedirectToAction("DatHang", "GoiHang");
            }

            if (Session["XemGioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<item> lstGioHang = laygiohang();
            ViewBag.tongsoluong = tongsoluong();
            ViewBag.tongtien = tongtien();
            return View(lstGioHang);
        }
        public ActionResult DatHang(FormCollection col)
        {
            DONDATHANG ddh = new DONDATHANG();
            KHACHHANG kh = (KHACHHANG)Session["TAIKHOAN"];
            List<item> gh = laygiohang();
            ddh.MAKH = kh.MAKH;
            ddh.NGAYDAT = DateTime.Now;
            var ngayGiao = String.Format("{0:MM/dd/yyyy}", col["NGAYGIAO"]);
            ddh.NGAYGIAO = DateTime.Parse(ngayGiao);
            ddh.TINHTRANGGIAOHANG = false;
            ddh.DATHANHTOAN = false;
            foreach (var it in gh)
            {
                CTDATHANG ctdh = new CTDATHANG();
                ctdh.MADH = ddh.MADH;
                ctdh.MASANPHAM = it.masp;
                ctdh.SOLUONG = it.soluong;
                ctdh.DONGIA = it.gia;
                db.CTDATHANGs.InsertOnSubmit(ctdh);
            }
            db.SubmitChanges();
            Session["GioHang"] = null;
            return RedirectToAction("xanhandonhang","GioHang");
        }
        public ActionResult xacnhandonhang()
        {
            return View();
        }
        public ActionResult xoatoanbogiohang()
        {
            List<item> lstgiohang = laygiohang();
            lstgiohang.Clear();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult capnhatgiohang(string imasp,FormCollection f)
        {
            //lấy giỏi hàng trong sesion
            List<item> lstgoihnag = laygiohang();
            //kiểm tra xem sp đã tồn tai trong gio hang chưa
            item sp = lstgoihnag.SingleOrDefault(n => n.masp == imasp);
            if (sp != null)
            {
                sp.soluong=int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("XemGioHang");
        }
    }
}
