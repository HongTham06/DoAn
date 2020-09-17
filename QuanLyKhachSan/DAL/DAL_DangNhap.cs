using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;

namespace DAL
{
    public class DAL_DangNhap:ConText
    {
        public int LayTaiKhoan(string user, string password)
        {
            password = MaHoa(password);
            var tk = (from x in qlks.TAIKHOAN
                      where x.TENDN.Trim() == user && x.MATKHAU.Trim() == password
                      select x).ToList();
            int a = tk.Count();
            return a;
        }

        public string LayTenNV(string user, string password)
        {
            password = MaHoa(password);
            string b = "";
            var Tennv = (from p in qlks.NHANVIEN
                         join q in qlks.TAIKHOAN on p.MANV equals q.MANV
                         where q.TENDN.Trim() == user && q.MATKHAU.Trim() == password
                         select new
                         {
                             p.HOTEN
                         }).ToList();
            if (Tennv.Count() != 0)
            {
                foreach (var a in Tennv)
                    b = a.HOTEN;
            }
            return b;
        }
        public string LayMaNV(string user, string password)
        {
            password = MaHoa(password);
            string b = "";
            var Tennv = (from p in qlks.TAIKHOAN
                         where p.TENDN.Trim() == user && p.MATKHAU.Trim() == password
                         select new
                         {
                             p.MANV
                         }).ToList();
            if (Tennv.Count() != 0)
            {
                foreach (var a in Tennv)
                    b = a.MANV;
            }
            return b;
        }

        public string LayTrangThai(string user, string password)
        {
            string b = "";
            password = MaHoa(password);
            var Tennv = (from p in qlks.TAIKHOAN
                         where p.TENDN.Trim() == user && p.MATKHAU.Trim() == password
                         select new
                         {
                             p.TRANGTHAI
                         }).ToList();
            if (Tennv.Count() != 0)
            {
                foreach (var a in Tennv)
                    b = a.TRANGTHAI;
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
    }
}
