using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;


namespace DAL
{
    public class DAL_QLTaiKhoan:ConText
    {
        public DataTable LayThongTin()
        {
            var nv = from p in qlks.TAIKHOAN
                     join q in qlks.NHANVIEN on p.MANV equals q.MANV
                     select new
                     {
                         p.MANV,
                         q.HOTEN,
                         p.TENDN,
                         p.TRANGTHAI
                     };
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Nhân Viên");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Tên Đăng Nhập");
            dt.Columns.Add("Trạng Thái");
            foreach (var TD in nv)
            {
                dt.Rows.Add(TD.MANV.ToString(), TD.HOTEN.ToString(), TD.TENDN.ToString().ToString(), TD.TRANGTHAI.ToString());
            }
            return dt;
        }
        public List<NHANVIEN> LoadDT()
        {
            return qlks.NHANVIEN.Select(t => t).ToList<NHANVIEN>();
        }
        public void ThemTK(string MNV, string TDN, string MK, string TT)
        {
            QLKhachSanEntities chung = new QLKhachSanEntities();
            TAIKHOAN td = new TAIKHOAN();
            td.MANV = MNV;
            td.TENDN = TDN;
            td.MATKHAU = MK;
            td.TRANGTHAI = TT;
            chung.TAIKHOAN.Add(td);
            chung.SaveChanges();
        }

        public void XoaTK(string TDN)
        {
            var itemToRemove = qlks.TAIKHOAN.SingleOrDefault(x => x.TENDN == TDN); //returns a single item.

            if (itemToRemove != null)
            {
                qlks.TAIKHOAN.Remove(itemToRemove);
                qlks.SaveChanges();
            }
        }

        public void SuaTK(string MNV, string TDN, string MK, string TT)
        {
            var td = (from a in qlks.TAIKHOAN where a.TENDN == TDN select a).SingleOrDefault();
            if (td != null)
            {
                td.MATKHAU = MK;
                td.TRANGTHAI = TT;
                qlks.SaveChanges();
            }
        }

        public void SuaTK2(string MNV, string TDN, string TT)
        {
            var td = (from a in qlks.TAIKHOAN where a.TENDN == TDN select a).SingleOrDefault();
            if (td != null)
            {
                td.TRANGTHAI = TT;
                qlks.SaveChanges();
            }
        }
        public string LayMK(string tdn)
        {
            string b = "";
            var Ma = (from p in qlks.TAIKHOAN
                      where p.TENDN.Trim() == tdn
                      select new
                      {
                          p.MATKHAU
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.MATKHAU;
            }
            return b;
        }

        public string MaHoa(string MK)
        {
            string str = "";
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(MK);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            str = hasPass.Substring(0, 15);
            return str;
        }
        //========================================== CT__QUYEN ===================================================
        public void ThemQTK(string TDN, string MQ, string CT)
        {
            QLKhachSanEntities chung = new QLKhachSanEntities();
            CTQUYEN td = new CTQUYEN();
            td.TENDN = TDN;
            td.MAQUYEN = MQ;
            td.CHUTHICH = CT;
            chung.CTQUYEN.Add(td);
            chung.SaveChanges();
        }
        public DataTable LayQ(string tdn)
        {
            //string b = "";
            //var Ma = (from p in qlks.TAIKHOAN join q in qlks.CTQUYEN on p.TENDN equals q.TENDN
            //          where p.TENDN.Trim() == tdn
            //          select new
            //          {
            //              q.MAQUYEN
            //          }).ToList();
            //if (Ma.Count() != 0)
            //{
            //    foreach (var a in Ma)
            //        b = a.MAQUYEN;
            //}
            //return b;

            var nv = from p in qlks.TAIKHOAN
                     join q in qlks.CTQUYEN on p.TENDN equals q.TENDN
                     where q.TENDN == tdn
                     select new
                     {
                         q.MAQUYEN
                     };
            DataTable dt = new DataTable();
            dt.Columns.Add("QUYEN");
            foreach (var TD in nv)
            {
                dt.Rows.Add(TD.MAQUYEN.ToString());
            }
            return dt;
        }
    }
}
