using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTapLon.Models
{
    public class item
    {
        QLSMphoneDataContext db = new QLSMphoneDataContext();
        public string masp { get; set; }
        public string tensp { get; set; }
        public string nhasx { get; set; }
        public string cauhinh { get; set; }
        public string tinhnang { get; set; }
        public float gia { get; set; }
        public int soluong { get; set; }
        public string hinhanh { get; set; }
        public float thanhtien
        {
            get
            {
                return gia * soluong;
            }
        }
        public item(string ms)
        {
            SANPHAM s = db.SANPHAMs.FirstOrDefault(t => t.MASANPHAM == ms);
            masp = ms;
            tensp = s.TENSANPHAM;
            nhasx = s.NHASX;
            cauhinh = s.CAUHINH;
            tinhnang = s.TINHNANGNOIBAT;
            hinhanh = s.HINHANH;
            gia = (int)s.GIABAN;
            soluong = 1;
        }
    }
}