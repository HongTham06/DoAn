using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using System.Data;
namespace DAL
{
    public class DAL_QLNhanVien:ConText
    {
        public DataTable LayNhanVien()
        {
            var nv = from p in qlks.NHANVIEN
                     select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã NV");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Giới Tính");
            dt.Columns.Add("Ngày Sinh");
            dt.Columns.Add("Địa Chỉ");
            dt.Columns.Add("SĐT");
            dt.Columns.Add("Lương CB");
            foreach (var nv1 in nv)
            {
                dt.Rows.Add(nv1.MANV, nv1.HOTEN, nv1.GIOITINH, nv1.NGAYSINH.ToString().Substring(0, 10), nv1.DIACHI, nv1.SDT, nv1.LUONGCB);
            }
            return dt;
        }
        public string LayMaNV()
        {
            int ma = 0;
            var ma1 = from p in qlks.NHANVIEN
                      select new
                      {
                          p.MANV
                      };

            foreach (var i in ma1)
            {
                if (ma < int.Parse(i.MANV.Substring(2)))
                {
                    ma = int.Parse(i.MANV.Substring(2));
                }
            }
            if (ma < 9)
                return "NV00" + (ma + 1).ToString();
            if (ma < 99)
                return "NV0" + (ma + 1).ToString();
            if (ma >= 100)
                return "NV" + (ma + 1).ToString();
            return "NV" + (ma + 1).ToString();
        }
        public int KTTuoi(DateTime ngaynhap)
        {
            if (ngaynhap.AddYears(18) > DateTime.Now)
                return 0;
            else if (ngaynhap.AddYears(18) == DateTime.Now)
            {
                if (ngaynhap.Month > DateTime.Now.Month)
                    return 0;
                else if (ngaynhap.Month == DateTime.Now.Month)
                {
                    if (ngaynhap.Day >= DateTime.Now.Day)
                        return 0;
                    else
                        return 1;
                }
                else
                    return 1;
            }
            else
                return 1;
        }
        public void ThemNV(string MNV, string HT, string GT, string NS, string DC, string SDT, string LCB)
        {
            QLKhachSanEntities chung = new QLKhachSanEntities();
            NHANVIEN nv = new NHANVIEN();
            nv.MANV = MNV;
            nv.HOTEN = HT;
            nv.GIOITINH = GT;
            nv.NGAYSINH = DateTime.Parse(NS);
            nv.DIACHI = DC;
            nv.SDT = SDT;
            nv.LUONGCB = int.Parse(LCB);
            chung.NHANVIEN.Add(nv);
            chung.SaveChanges();
        }

        public void SuaNV(string MNV, string HT, string GT, string NS, string DC, string SDT, string LCB)
        {
            var nv = (from a in qlks.NHANVIEN where a.MANV == MNV select a).SingleOrDefault();
            if (nv != null)
            {
                nv.HOTEN = HT;
                nv.GIOITINH = GT;
                nv.NGAYSINH = DateTime.Parse(NS);
                nv.DIACHI = DC;
                nv.SDT = SDT;
                nv.LUONGCB = int.Parse(LCB);
                qlks.SaveChanges();
            }
        }

        public void XoaNV(string MNV)
        {
            var itemToRemove = qlks.NHANVIEN.SingleOrDefault(x => x.MANV == MNV); //returns a single item.

            if (itemToRemove != null)
            {
                qlks.NHANVIEN.Remove(itemToRemove);
                qlks.SaveChanges();
            }
        }
        public DataTable LoadDiaChi()
        {
            var dc = from p in qlks.NHANVIEN group p by p.DIACHI into g select new { dc = g.Key };
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
            dt.Columns.Add("Mã NV");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Phái");
            dt.Columns.Add("Ngày Sinh");
            dt.Columns.Add("Địa Chỉ");
            dt.Columns.Add("SĐT");
            dt.Columns.Add("Lương CB");
            try
            {
                if (cbbDC == "Tất Cả" && cbbGT == "Tất Cả")
                {
                    try
                    {
                        var tim = (from p in qlks.NHANVIEN
                                   where p.HOTEN.Contains(txtTKiem)
                                   select new
                                   {
                                       p.MANV,
                                       p.HOTEN,
                                       p.GIOITINH,
                                       p.NGAYSINH,
                                       p.DIACHI,
                                       p.SDT,
                                       p.LUONGCB
                                   }).ToList();


                        foreach (var i in tim)
                        {
                            dt.Rows.Add(i.MANV.Trim(), i.HOTEN.Trim(), i.GIOITINH.Trim(), i.NGAYSINH.ToString().Substring(0, 10), i.DIACHI.Trim(), i.SDT.Trim(), i.LUONGCB.ToString());
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
                        var tim = (from p in qlks.NHANVIEN
                                   where p.HOTEN.Contains(txtTKiem) && p.GIOITINH.Trim() == cbbGT
                                   select new
                                   {
                                       p.MANV,
                                       p.HOTEN,
                                       p.GIOITINH,
                                       p.NGAYSINH,
                                       p.DIACHI,
                                       p.SDT,
                                       p.LUONGCB
                                   }).ToList();

                        foreach (var i in tim)
                        {
                            dt.Rows.Add(i.MANV.Trim(), i.HOTEN.Trim(), i.GIOITINH.Trim(), i.NGAYSINH.ToString().Substring(0, 10), i.DIACHI.Trim(), i.SDT.Trim(), i.LUONGCB.ToString());
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
                        var tim = (from p in qlks.NHANVIEN
                                   where p.HOTEN.Contains(txtTKiem) && p.DIACHI == cbbDC
                                   select new
                                   {
                                       p.MANV,
                                       p.HOTEN,
                                       p.GIOITINH,
                                       p.NGAYSINH,
                                       p.DIACHI,
                                       p.SDT,
                                       p.LUONGCB
                                   }).ToList();
                        foreach (var i in tim)
                        {
                            dt.Rows.Add(i.MANV.Trim(), i.HOTEN.Trim(), i.GIOITINH.Trim(), i.NGAYSINH.ToString().Substring(0, 10), i.DIACHI.Trim(), i.SDT.Trim(), i.LUONGCB.ToString());
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
                        var tim = (from p in qlks.NHANVIEN
                                   where p.HOTEN.Contains(txtTKiem) && p.DIACHI == cbbDC && p.GIOITINH == cbbGT
                                   select new
                                   {
                                       p.MANV,
                                       p.HOTEN,
                                       p.GIOITINH,
                                       p.NGAYSINH,
                                       p.DIACHI,
                                       p.SDT,
                                       p.LUONGCB
                                   }).ToList();

                        foreach (var i in tim)
                        {
                            dt.Rows.Add(i.MANV.Trim(), i.HOTEN.Trim(), i.GIOITINH.Trim(), i.NGAYSINH.ToString().Substring(0, 10), i.DIACHI.Trim(), i.SDT.Trim(), i.LUONGCB.ToString());
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
        public string LayCaLam(string manv)
        {
            DateTime day = System.DateTime.Now;
            string b = "";
            var ds = (from p in qlks.NHANVIEN
                      join q in qlks.CHAMCONG on p.MANV equals q.MANV
                      where p.MANV == manv && q.NGAYLAM.Month == day.Month && q.NGAYLAM.Year == day.Year
                      select new
                      {
                          p.MANV
                      }).ToList();
            b = "Tổng Ca Tháng " + day.Month + ": " + ds.Count().ToString() + " Ca";
            return b;
        }
        public string LayLuong(string manv, int Luongcb)
        {
            DateTime day = System.DateTime.Now;
            int tien = 0;
            string b = "";
            var ds = (from p in qlks.NHANVIEN
                      join q in qlks.CHAMCONG on p.MANV equals q.MANV
                      where p.MANV == manv && q.NGAYLAM.Month == day.Month && q.NGAYLAM.Year == day.Year
                      select new
                      {
                          p.MANV
                      }).ToList();
            tien = ds.Count() * Luongcb;
            b = "Tổng Lương: " + string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", tien);
            return b;
        }
    }
}
