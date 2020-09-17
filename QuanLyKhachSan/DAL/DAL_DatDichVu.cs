using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;

namespace DAL
{
    public class DAL_DatDichVu:ConText
    {
        public void ThemPhieu(string MaHD, string NgayTao, string MaNV, string MaP)
        {
            QLKhachSanEntities nh = new QLKhachSanEntities();
            HOADON p = new HOADON();
            p.MAHD = MaHD;
            p.NGAYTAO = DateTime.Parse(NgayTao);
            p.MANV = MaNV;
            p.MAPHONG = MaP;
            p.THANHTIEN = 0;
            nh.HOADON.Add(p);
            nh.SaveChanges();
        }

        public void XoaPhieu(string MP)
        {
            var itemToRemove = qlks.HOADON.SingleOrDefault(x => x.MAHD == MP); //returns a single item.

            if (itemToRemove != null)
            {
                qlks.HOADON.Remove(itemToRemove);
                qlks.SaveChanges();
            }
        }
        public DataTable ThongTinBan(string MAHD)
        {
            var Thucan1 = from p in qlks.DICHVU
                          join q in qlks.CHITIETHOADON on p.MADV equals q.MADV
                          where q.MAHD == MAHD
                          select new
                          {
                              p.MADV,
                              p.TENDV,
                              p.DONGIA,
                              q.SOLUONG
                          };
            DataTable data = new DataTable();
            data.Columns.Add("Mã DV");
            data.Columns.Add("Tên DV");
            data.Columns.Add("Đơn Giá");
            data.Columns.Add("Số Lượng");
            foreach (var q in Thucan1)
            {
                data.Rows.Add(q.MADV, q.TENDV.Trim(), q.DONGIA, q.SOLUONG);
            }
            return data;
        }
        public DataTable LayDICHVU()
        {
            var p = from i in qlks.DICHVU
                    select new
                    {
                        i.MADV,
                        i.TENDV,
                        i.DONGIA,
                        i.HINHANH
                    };
            DataTable dt = new DataTable();
            dt.Columns.Add("MADV");
            dt.Columns.Add("TENDV");
            dt.Columns.Add("DONGIA");
            dt.Columns.Add("HINHANH");
            foreach (var i in p)
            {
                dt.Rows.Add(i.MADV, i.TENDV, i.DONGIA, i.HINHANH);
            }
            return dt;
        }
        public string LayMAHD()
        {
            int ma = 0;
            var ma1 = from p in qlks.HOADON
                      select new
                      {
                          p.MAHD
                      };

            foreach (var i in ma1)
            {
                if (ma < int.Parse(i.MAHD.Substring(2)))
                {
                    ma = int.Parse(i.MAHD.Substring(2));
                }
            }
            if (ma < 9)
                return "HD00" + (ma + 1).ToString();
            if (ma < 99)
                return "HD0" + (ma + 1).ToString();
            if (ma >= 100)
                return "HD" + (ma + 1).ToString();
            return "HD" + (ma + 1).ToString();
        }
        public DataTable TimKiemMenu(string txtTimKiem)
        {

            var p = from i in qlks.DICHVU
                    where i.TENDV.Contains(txtTimKiem)
                    select new
                    {
                        i.MADV,
                        i.TENDV,
                        i.DONGIA,
                        i.HINHANH
                    };
            DataTable dt = new DataTable();
            dt.Columns.Add("MADV");
            dt.Columns.Add("TENDV");
            dt.Columns.Add("DONGIA");
            dt.Columns.Add("HINHANH");
            foreach (var i in p)
            {
                dt.Rows.Add(i.MADV, i.TENDV, i.DONGIA, i.HINHANH);
            }
            return dt;
        }

        public void ThemCTPhieu(string MAHD, string MADV, int SL)
        {
            QLKhachSanEntities env = new QLKhachSanEntities();
            CHITIETHOADON nv = new CHITIETHOADON();
            nv.MAHD = MAHD;
            nv.MADV = MADV;
            nv.SOLUONG = SL;
            env.CHITIETHOADON.Add(nv);
            env.SaveChanges();
        }
        public void XoaCTPhieu(string MaHD, string MADV)
        {
            var itemToRemove = qlks.CHITIETHOADON.SingleOrDefault(x => x.MAHD == MaHD && x.MADV == MADV); //returns a single item.

            if (itemToRemove != null)
            {
                qlks.CHITIETHOADON.Remove(itemToRemove);
                qlks.SaveChanges();
            }
        }
        public void SuaCTPhieu(string MAHD, string MADV, int Soluong)
        {
            var phieu = (from a in qlks.CHITIETHOADON
                         where a.MAHD == MAHD && a.MADV == MADV
                         select a).SingleOrDefault();
            if (phieu != null)
            {
                phieu.SOLUONG = Soluong;
                qlks.SaveChanges();
            }
        }

        public string LayHA(string MADV)
        {
            string b = "";
            var Ma = (from p in qlks.DICHVU
                      where p.MADV.Trim() == MADV
                      select new
                      {
                          p.HINHANH
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.HINHANH;
            }
            return b;
        }

        public string LayTenKH(string MaPhong)
        {
            string b = "";
            var Ma = (from p in qlks.KHACHHANG join q in qlks.PHIEUDATPHONG on p.MAKH equals q.MAKH
                      where q.MAPHONG == MaPhong && q.NGAYKT==null
                      select new
                      {
                          p.TENKH
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.TENKH;
            }
            return b;
        }
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
        public string LayTenTang(string MaPhong)
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
        public string LaySDTKH(string MaPhong)
        {
            string b = "";
            var Ma = (from p in qlks.KHACHHANG
                      join q in qlks.PHIEUDATPHONG on p.MAKH equals q.MAKH
                      where q.MAPHONG == MaPhong && q.NGAYKT == null
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
    }
}
