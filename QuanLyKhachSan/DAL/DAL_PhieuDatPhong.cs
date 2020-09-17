using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_PhieuDatPhong:ConText
    {
        public string LayTenPhong(string MaPhong)
        {
            string b = "";
            var Ma = (from p in qlks.PHONG
                      where p.MAPHONG == MaPhong
                      select new
                      {
                          p.TENPHONG
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.TENPHONG;
            }
            return b;
        }
        public string LayDienTich(string MaPhong)
        {
            string b = "";
            var Ma = (from p in qlks.PHONG
                      where p.MAPHONG == MaPhong
                      select new
                      {
                          p.DIENTICH
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.DIENTICH;
            }
            return b;
        }
        public string LayGiaPhong(string MaPhong)
        {
            string b = "";
            var Ma = (from p in qlks.PHONG
                      where p.MAPHONG == MaPhong
                      select new
                      {
                          p.DONGIA
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.DONGIA.ToString();
            }
            return b;
        }
        public string LayTang(string MaPhong)
        {
            string b = "";
            var Ma = (from p in qlks.PHONG join q in qlks.TANG on p.MAKV equals q.MAKV
                      where p.MAPHONG == MaPhong
                      select new
                      {
                          q.TENKV
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.TENKV;
            }
            return b;
        }

        public string LayMaPD()
        {
            int ma = 0;
            var ma1 = from p in qlks.PHIEUDATPHONG
                      select new
                      {
                          p.MAPHIEUDAT
                      };

            foreach (var i in ma1)
            {
                if (ma < int.Parse(i.MAPHIEUDAT.Substring(2)))
                {
                    ma = int.Parse(i.MAPHIEUDAT.Substring(2));
                }
            }
            if (ma < 9)
                return "PD00" + (ma + 1).ToString();
            if (ma < 99)
                return "PD0" + (ma + 1).ToString();
            if (ma >= 100)
                return "PD" + (ma + 1).ToString();
            return "PD" + (ma + 1).ToString();
        }
        //================================= Khách Hàng ========================================
        public List<KHACHHANG> loadcbbKH()
        {
            return qlks.KHACHHANG.Select(t => t).ToList<KHACHHANG>();
        }
        public string LayMaKH(string SDT)
        {
            string b = "";
            var Ma = (from p in qlks.KHACHHANG
                      where p.SDT == SDT
                      select new
                      {
                          p.MAKH
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.MAKH;
            }
            return b;
        }      
        public string LayDCKH(string MaKH)
        {
            string b = "";
            var Ma = (from p in qlks.KHACHHANG
                      where p.MAKH == MaKH
                      select new
                      {
                          p.DIACHI
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.DIACHI;
            }
            return b;
        }
        public string LaySDTKH(string MaKH)
        {
            string b = "";
            var Ma = (from p in qlks.KHACHHANG
                      where p.MAKH == MaKH
                      select new
                      {
                          p.SDT
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.SDT;
            }
            return b;
        }
        public string LayGTKH(string MaKH)
        {
            string b = "";
            var Ma = (from p in qlks.KHACHHANG
                      where p.MAKH == MaKH
                      select new
                      {
                          p.GIOITINH
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.GIOITINH;
            }
            return b;
        }

        public void ThemPD(string MPD, string MKH, string MNV, string MP, string NgayLap, string NgayBD)
        {
            QLKhachSanEntities chung = new QLKhachSanEntities();
            PHIEUDATPHONG td = new PHIEUDATPHONG();
            td.MAPHIEUDAT = MPD;
            td.MAKH = MKH;
            td.MANV = MNV;
            td.MAPHONG = MP;
            td.NGAYLAP = DateTime.Parse(NgayLap);
            td.NGAYBD = DateTime.Parse(NgayBD);
            chung.PHIEUDATPHONG.Add(td);
            chung.SaveChanges();
        }

        public void SuaTrangThaiP(string MP)
        {
            var td = (from a in qlks.PHONG where a.MAPHONG == MP select a).SingleOrDefault();
            if (td != null)
            {
                td.TRANGTHAI = "Đã Đặt";
                qlks.SaveChanges();
            }
        }
    }
}
