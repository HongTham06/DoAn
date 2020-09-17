using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace DAL
{
    public class DAL_QLChamCong:ConText
    {
        public void ThemChamCong(string MaNV, string NgayLam, string Ca)
        {
            QLKhachSanEntities chung = new QLKhachSanEntities();
            CHAMCONG cc = new CHAMCONG();

            cc.MANV = MaNV;
            cc.NGAYLAM = DateTime.Parse(NgayLam);
            cc.CA = Ca;
            chung.CHAMCONG.Add(cc);
            chung.SaveChanges();
        }

        public void XoaChamCong(string MaNV, string NgayLam, string Ca)
        {
            //var itemToRemove = cc.CHAMCONG.SingleOrDefault(x => x.MANV == MaNV && x.NGAYLAM==DateTime.Parse(NgayLam) && x.CA==Ca); //returns a single item.

            //if (itemToRemove != null)
            //{
            //    cc.CHAMCONG.Remove(itemToRemove);
            //    cc.SaveChanges();
            //}

            CHAMCONG chc = new CHAMCONG();
            chc.MANV = MaNV;
            chc.NGAYLAM = DateTime.Parse(NgayLam);
            chc.CA = Ca;
            qlks.CHAMCONG.Attach(chc);
            qlks.CHAMCONG.Remove(chc);
            qlks.SaveChanges();
        }
        public DataTable LayNhanVien()
        {
            var nvs = from p in qlks.NHANVIEN
                      select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Ngày Sinh");
            foreach (var p in nvs)
            {
                dt.Rows.Add(p.MANV.Trim(), p.HOTEN.Trim(), p.NGAYSINH.ToString().Substring(0, 10));
            }
            return dt;
        }

        public DataTable LayThongTinNgayLam()
        {
            var nvs = (from p in qlks.CHAMCONG
                       join q in qlks.NHANVIEN on p.MANV equals q.MANV
                       select new
                       {
                           q.MANV,
                           q.HOTEN,
                           p.NGAYLAM,
                           p.CA
                       }).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Ngày Làm");
            dt.Columns.Add("Ca");
            foreach (var p in nvs)
            {
                dt.Rows.Add(p.MANV.Trim(), p.HOTEN.Trim(), p.NGAYLAM.ToString().Substring(0, 10), p.CA);
            }
            return dt;
        }

        public DataTable TimKiemNV(string txtTimKiem)
        {
            var tim = (from p in qlks.NHANVIEN
                       where p.HOTEN.Contains(txtTimKiem)
                       select new
                       {
                           p.MANV,
                           p.HOTEN,
                           p.NGAYSINH
                       }).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Ngày Sinh");
            foreach (var i in tim)
            {
                dt.Rows.Add(i.MANV.Trim(), i.HOTEN.Trim(), i.NGAYSINH.ToString().Substring(0, 10));
            }
            return dt;
        }

        public DataTable TimKiemCC(string cbbThang, string cbbNam, string cbbCa)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Ngày Làm");
            dt.Columns.Add("Ca");
            //Tìm Kiếm Theo Tháng
            if (cbbNam == "Tất Cả" && cbbCa == "Tất Cả")
            {
                var tim = (from p in qlks.NHANVIEN
                           join q in qlks.CHAMCONG on p.MANV equals q.MANV
                           where q.NGAYLAM.Month.ToString() == cbbThang
                           select new
                           {
                               p.MANV,
                               p.HOTEN,
                               q.NGAYLAM,
                               q.CA
                           }).ToList();
                foreach (var i in tim)
                {
                    dt.Rows.Add(i.MANV.Trim(), i.HOTEN.Trim(), i.NGAYLAM.ToString().Substring(0, 10), i.CA);
                }
            }
            //Tìm Kiếm Theo Năm
            else if (cbbThang == "Tất Cả" && cbbCa == "Tất Cả")
            {
                var tim = (from p in qlks.NHANVIEN
                           join q in qlks.CHAMCONG on p.MANV equals q.MANV
                           where q.NGAYLAM.Year.ToString() == cbbNam
                           select new
                           {
                               p.MANV,
                               p.HOTEN,
                               q.NGAYLAM,
                               q.CA
                           }).ToList();
                foreach (var i in tim)
                {
                    dt.Rows.Add(i.MANV.Trim(), i.HOTEN.Trim(), i.NGAYLAM.ToString().Substring(0, 10), i.CA);
                }
            }
            //Tìm Kiếm Theo Ca
            else if (cbbThang == "Tất Cả" && cbbNam == "Tất Cả")
            {
                var tim = (from p in qlks.NHANVIEN
                           join q in qlks.CHAMCONG on p.MANV equals q.MANV
                           where q.CA == cbbCa
                           select new
                           {
                               p.MANV,
                               p.HOTEN,
                               q.NGAYLAM,
                               q.CA
                           }).ToList();
                foreach (var i in tim)
                {
                    dt.Rows.Add(i.MANV.Trim(), i.HOTEN.Trim(), i.NGAYLAM.ToString().Substring(0, 10), i.CA);
                }
            }
            //Tìm Kiếm Theo Tháng, Năm
            else if (cbbNam != "Tất Cả" && cbbThang != "Tất Cả" && cbbCa == "Tất Cả")
            {
                var tim = (from p in qlks.NHANVIEN
                           join q in qlks.CHAMCONG on p.MANV equals q.MANV
                           where q.NGAYLAM.Month.ToString() == cbbThang && q.NGAYLAM.Year.ToString() == cbbNam
                           select new
                           {
                               p.MANV,
                               p.HOTEN,
                               q.NGAYLAM,
                               q.CA
                           }).ToList();
                foreach (var i in tim)
                {
                    dt.Rows.Add(i.MANV.Trim(), i.HOTEN.Trim(), i.NGAYLAM.ToString().Substring(0, 10), i.CA);
                }
            }
            //Tìm Kiếm Theo Tháng, Ca
            else if (cbbThang != "Tất Cả" && cbbNam == "Tất Cả" && cbbCa != "Tất Cả")
            {
                var tim = (from p in qlks.NHANVIEN
                           join q in qlks.CHAMCONG on p.MANV equals q.MANV
                           where q.NGAYLAM.Month.ToString() == cbbThang && q.CA == cbbCa
                           select new
                           {
                               p.MANV,
                               p.HOTEN,
                               q.NGAYLAM,
                               q.CA
                           }).ToList();
                foreach (var i in tim)
                {
                    dt.Rows.Add(i.MANV.Trim(), i.HOTEN.Trim(), i.NGAYLAM.ToString().Substring(0, 10), i.CA);
                }
            }
            //Tìm Kiếm Theo Năm, Ca
            else if (cbbThang == "Tất Cả" && cbbNam != "Tất Cả" && cbbCa != "Tất Cả")
            {
                var tim = (from p in qlks.NHANVIEN
                           join q in qlks.CHAMCONG on p.MANV equals q.MANV
                           where q.NGAYLAM.Year.ToString() == cbbNam && q.CA == cbbCa
                           select new
                           {
                               p.MANV,
                               p.HOTEN,
                               q.NGAYLAM,
                               q.CA
                           }).ToList();
                foreach (var i in tim)
                {
                    dt.Rows.Add(i.MANV.Trim(), i.HOTEN.Trim(), i.NGAYLAM.ToString().Substring(0, 10), i.CA);
                }
            }
            //Tìm Kiếm Theo Tháng, Năm, Ca
            else
            {
                var tim = (from p in qlks.NHANVIEN
                           join q in qlks.CHAMCONG on p.MANV equals q.MANV
                           where q.NGAYLAM.Month.ToString() == cbbThang && q.NGAYLAM.Year.ToString() == cbbNam && q.CA == cbbCa
                           select new
                           {
                               p.MANV,
                               p.HOTEN,
                               q.NGAYLAM,
                               q.CA
                           }).ToList();
                foreach (var i in tim)
                {
                    dt.Rows.Add(i.MANV.Trim(), i.HOTEN.Trim(), i.NGAYLAM.ToString().Substring(0, 10), i.CA);
                }
            }
            return dt;
        }
    }
}
