using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaiTapLon.Models;
using System.Data.SqlClient;
using PagedList;
using PagedList.Mvc; 

namespace BaiTapLon.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

         QLSMphoneDataContext db = new QLSMphoneDataContext();
         private List<SANPHAM> LaySP(int count)
         {
             return db.SANPHAMs.OrderByDescending(a => a.MASANPHAM).Take(count).ToList();
         }
         public ActionResult Index(int? page)
        {
            
            int pageSize = 9;
            int pageNum = (page ?? 1);
            var spmoi = LaySP(35);
            var sp = db.SANPHAMs.ToList();
            ViewData["SANPHAM"] = sp;

            return View(spmoi.ToPagedList(pageNum, pageSize));
          
        }
        public ActionResult hienthichitiet(string ms)
        {
            List<SANPHAM> lst = db.SANPHAMs.ToList();

            SANPHAM s = lst.FirstOrDefault(t => t.MASANPHAM == ms);
            return View(s);
        }
        public ActionResult loadnhasanxuat()
        {
            List<NHASANXUAT> list = db.NHASANXUATs.ToList();
            return PartialView(list);
        }
        public ActionResult loaddienthoaitheonhasanxuat(string dt)
        {
            List<SANPHAM> list = db.SANPHAMs.ToList();
            List<SANPHAM> lst = list.Where(t => t.MANSX == dt).ToList();
            return View(lst);
        }
        [HttpPost]
        public ActionResult TimKiem(FormCollection c)
        {
            var tukhoa = c["txtSearch"];
            List<SANPHAM> lst = db.SANPHAMs.ToList();
            List<SANPHAM> lst2 = lst.Where(t => t.TENSANPHAM.Contains(tukhoa) == true).ToList();
            return View(lst2);
        }

    }
}
