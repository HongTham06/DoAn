using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DAL_QLKhachHang:ConText
    {
        public DataTable LayKhachHang()
        {
            var nv = from p in qlks.KHACHHANG
                     select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã KH");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Giới Tính");
            dt.Columns.Add("Địa Chỉ");
            dt.Columns.Add("SĐT");
            foreach (var nv1 in nv)
            {
                dt.Rows.Add(nv1.MAKH, nv1.TENKH, nv1.GIOITINH, nv1.DIACHI, nv1.SDT);
            }
            return dt;
        }
        public string LayMaKH()
        {
            int ma = 0;
            var ma1 = from p in qlks.KHACHHANG
                      select new
                      {
                          p.MAKH
                      };

            foreach (var i in ma1)
            {
                if (ma < int.Parse(i.MAKH.Substring(2)))
                {
                    ma = int.Parse(i.MAKH.Substring(2));
                }
            }
            if (ma < 9)
                return "KH00" + (ma + 1).ToString();
            if (ma < 99)
                return "KH0" + (ma + 1).ToString();
            if (ma >= 100)
                return "KH" + (ma + 1).ToString();
            return "KH" + (ma + 1).ToString();
        }
        public void ThemKH(string MKH, string HT, string GT, string DC, string SDT)
        {
            QLKhachSanEntities chung = new QLKhachSanEntities();
            KHACHHANG nv = new KHACHHANG();
            nv.MAKH = MKH;
            nv.TENKH = HT;
            nv.GIOITINH = GT;
            nv.DIACHI = DC;
            nv.SDT = SDT;
            chung.KHACHHANG.Add(nv);
            chung.SaveChanges();
        }

        public void SuaKH(string MKH, string HT, string GT, string DC, string SDT)
        {
            var nv = (from a in qlks.KHACHHANG where a.MAKH == MKH select a).SingleOrDefault();
            if (nv != null)
            {
                nv.TENKH = HT;
                nv.GIOITINH = GT;
                nv.DIACHI = DC;
                nv.SDT = SDT;
                qlks.SaveChanges();
            }
        }

        public void XoaKH(string MKH)
        {
            var itemToRemove = qlks.KHACHHANG.SingleOrDefault(x => x.MAKH == MKH); //returns a single item.

            if (itemToRemove != null)
            {
                qlks.KHACHHANG.Remove(itemToRemove);
                qlks.SaveChanges();
            }
        }
        public DataTable LoadDiaChi()
        {
            var dc = from p in qlks.KHACHHANG group p by p.DIACHI into g select new { dc = g.Key };
            DataTable dt = new DataTable();
            dt.Columns.Add("Địa Chỉ");
            foreach (var i in dc)
            {
                dt.Rows.Add(i.dc);
            }
            return dt;
        }
        public DataTable Loc(string cbbDC, string cbbGT, string txtTKiem)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã KH");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Giới Tính");
            dt.Columns.Add("Địa Chỉ");
            dt.Columns.Add("SĐT");
            try
            {
                if (cbbDC == "Tất Cả" && cbbGT == "Tất Cả")
                {
                    try
                    {
                        var tim = (from p in qlks.KHACHHANG
                                   where p.TENKH.Contains(txtTKiem)
                                   select new
                                   {
                                       p.MAKH,
                                       p.TENKH,
                                       p.GIOITINH,
                                       p.DIACHI,
                                       p.SDT
                                   }).ToList();


                        foreach (var i in tim)
                        {
                            dt.Rows.Add(i.MAKH, i.TENKH, i.GIOITINH, i.DIACHI, i.SDT);
                        }
                    }
                    catch
                    {

                    }

                }
                else if (cbbDC == "Tất Cả" && cbbGT != "Tất Cả")
                {
                    try
                    {
                        var tim = (from p in qlks.KHACHHANG
                                   where p.TENKH.Contains(txtTKiem) && p.GIOITINH.Trim() == cbbGT
                                   select new
                                   {
                                       p.MAKH,
                                       p.TENKH,
                                       p.GIOITINH,
                                       p.DIACHI,
                                       p.SDT
                                   }).ToList();

                        foreach (var i in tim)
                        {
                            dt.Rows.Add(i.MAKH, i.TENKH, i.GIOITINH, i.DIACHI, i.SDT);
                        }
                    }
                    catch
                    {

                    }
                }
                else if (cbbDC != "Tất Cả" && cbbGT == "Tất Cả")
                {
                    try
                    {
                        var tim = (from p in qlks.KHACHHANG
                                   where p.TENKH.Contains(txtTKiem) && p.DIACHI == cbbDC
                                   select new
                                   {
                                       p.MAKH,
                                       p.TENKH,
                                       p.GIOITINH,
                                       p.DIACHI,
                                       p.SDT
                                   }).ToList();
                        foreach (var i in tim)
                        {
                            dt.Rows.Add(i.MAKH, i.TENKH, i.GIOITINH, i.DIACHI, i.SDT);
                        }
                    }
                    catch
                    {

                    }
                }

                else
                {
                    try
                    {
                        var tim = (from p in qlks.KHACHHANG
                                   where p.TENKH.Contains(txtTKiem) && p.DIACHI == cbbDC && p.GIOITINH == cbbGT
                                   select new
                                   {
                                       p.MAKH,
                                       p.TENKH,
                                       p.GIOITINH,
                                       p.DIACHI,
                                       p.SDT
                                   }).ToList();

                        foreach (var i in tim)
                        {
                            dt.Rows.Add(i.MAKH, i.TENKH, i.GIOITINH, i.DIACHI, i.SDT);
                        }
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
            return dt;
        }
    }
}
