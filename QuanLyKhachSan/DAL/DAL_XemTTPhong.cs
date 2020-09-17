using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DevExpress.XtraEditors;
using System.Drawing;

namespace DAL
{
    public class DAL_XemTTPhong:ConText
    {
        public int TimSoTang()
        {
            var tim = from p in qlks.TANG
                      select p;
            return tim.Count();
        }
        public void LayHinhAnh(string MP, PictureEdit PicThucAn)
        {
            var hinhAnh = from h in qlks.PHONG
                          where h.MAPHONG == MP
                          select h;
            foreach (var item in hinhAnh)
            {
                try
                {
                    if (item.HINHANH.Trim() != "No Image")
                        PicThucAn.Image = Image.FromFile(item.HINHANH);
                    else
                        PicThucAn.Image = Image.FromFile("NhaTrangLuxury.png");
                }
                catch
                {
                    PicThucAn.Image = Image.FromFile("NhaTrangLuxury.png");
                }
            }
        }
        public string LayTenKH(string MaPhong)
        {
            string b = "";
            var Ma = (from p in qlks.PHONG
                      join q in qlks.PHIEUDATPHONG on p.MAPHONG equals q.MAPHONG
                      where p.MAPHONG.Trim() == MaPhong && q.NGAYKT == null
                      select new
                      {
                          q.MAKH
                      }).ToList();
            var Ma2 = (from p in Ma
                       join q in qlks.KHACHHANG on p.MAKH equals q.MAKH
                       select new
                       {
                           q.TENKH
                       }).ToList();
            if (Ma2.Count() != 0)
            {
                foreach (var a in Ma2)
                    b = a.TENKH;
                return b;
            }
            return "Chưa Có Khách Thuê!";
        }

        public string LayTThai(string MaPhong)
        {
            string b = "";
            var Ma = (from p in qlks.PHONG
                      where p.MAPHONG.Trim() == MaPhong
                      select new
                      {
                          p.TRANGTHAI
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.TRANGTHAI;
            }
            return b;
        }

        public string LayDCKH(string MaPhong)
        {
            string b = "";
            var Ma = (from p in qlks.PHONG
                      join q in qlks.PHIEUDATPHONG on p.MAPHONG equals q.MAPHONG
                      where p.MAPHONG.Trim() == MaPhong && q.NGAYKT == null
                      select new
                      {
                          q.MAKH
                      }).ToList();
            var Ma2 = (from p in Ma
                       join q in qlks.KHACHHANG on p.MAKH equals q.MAKH
                       select new
                       {
                           q.DIACHI
                       }).ToList();
            if (Ma2.Count() != 0)
            {
                foreach (var a in Ma2)
                    b = a.DIACHI;
                return b;
            }
            return "Chưa Có Khách Thuê!";
        }

        public string LaySDTKH(string MaPhong)
        {
            string b = "";
            var Ma = (from p in qlks.PHONG
                      join q in qlks.PHIEUDATPHONG on p.MAPHONG equals q.MAPHONG
                      where p.MAPHONG.Trim() == MaPhong && q.NGAYKT==null
                      select new
                      {
                          q.MAKH
                      }).ToList();
            var Ma2 = (from p in Ma
                       join q in qlks.KHACHHANG on p.MAKH equals q.MAKH
                       select new
                       {
                           q.SDT
                       }).ToList();
            if (Ma2.Count() != 0)
            {
                foreach (var a in Ma2)
                    b = a.SDT;
            }
            return b;
        }
        public DataTable layTTT2(string MaPhong)
        {
            var m = from p in qlks.PHONG
                    join q in qlks.HOADON on p.MAPHONG equals q.MAPHONG
                    where p.MAPHONG == MaPhong && q.THANHTIEN==0
                    select new
                    {
                        q.MAHD
                    };

            var c = from a in qlks.CHITIETHOADON
                    join b in m on a.MAHD equals b.MAHD
                    select new
                    {
                        a.MADV,
                        a.SOLUONG
                    };
            var s = from v in c
                    join n in qlks.DICHVU on v.MADV equals n.MADV
                    select new
                    {
                        n.TENDV,
                        v.SOLUONG,
                        Tien = v.SOLUONG*n.DONGIA
                    };
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên Vật Dụng");
            dt.Columns.Add("Số Lượng");
            dt.Columns.Add("Thành Tiền");
            foreach (var l in s)
            {
                dt.Rows.Add(l.TENDV, l.SOLUONG,l.Tien);
            }
            return dt;
        }

        public string LayMaPhieu(string MaPhong)
        {
            string b = "";
            var Ma = (from p in qlks.HOADON
                      where p.MAPHONG == MaPhong && p.THANHTIEN ==0
                      select new
                      {
                          p.MAHD
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.MAHD;
            }
            return b;
        }
        public bool KTTonTaiHoaDon(string maphong)
        {
            var Ma = (from p in qlks.HOADON
                      where p.MAPHONG == maphong && p.THANHTIEN == 0
                      select new
                      {
                          p.MAHD
                      }).ToList();
            if (Ma.Count() != 0)
            {
                return true;
            }
            return false;
        }
    }
}
