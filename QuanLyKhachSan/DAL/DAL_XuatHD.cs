using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_XuatHD:ConText
    {
        public int TongTienDV(string maHD)
        {
            int t = 0;
            var tt = from x in qlks.CHITIETHOADON
                     join y in qlks.DICHVU on x.MADV equals y.MADV
                     where x.MAHD == maHD
                     select new
                     {
                         tong = x.SOLUONG * y.DONGIA
                     };
            foreach (var c in tt)
            {
                t += int.Parse(c.tong.ToString());
            }
            return t;
        }
        public int SoNgay(DateTime a, DateTime b)
        {
            TimeSpan v = a - b;
            return v.Days;
        }
        public int LayNgay(string maphong)
        {
            int t = 0;
            var tt = from x in qlks.PHIEUDATPHONG                    
                     where x.MAPHONG == maphong && x.NGAYKT == null
                     select new
                     {
                         x.NGAYBD
                     };
            foreach (var c in tt)
            {
                t = SoNgay(DateTime.Now, DateTime.Parse(c.NGAYBD.ToString()));
            }
            return t;
        }
        public int TongTienPhong(string maphong)
        {
            int t = 0;
            var ngay = LayNgay(maphong);
            var tt = from x in qlks.PHIEUDATPHONG
                     join y in qlks.PHONG on x.MAPHONG equals y.MAPHONG
                     where x.MAPHONG == maphong && x.NGAYKT==null
                     select new
                     {
                         tong = ngay * y.DONGIA
                     };
            foreach (var c in tt)
            {
                t += int.Parse(c.tong.ToString());
            }
            return t;
        }
        public string LayTenKH(string MaPhong)
        {
            string b = "";
            var Ma = (from p in qlks.KHACHHANG
                      join q in qlks.PHIEUDATPHONG on p.MAKH equals q.MAKH
                      where q.MAPHONG == MaPhong && q.NGAYKT == null
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
        public string LayTenTang(string MaPhong)
        {
            string b = "";
            var Ma = (from p in qlks.PHONG
                      join q in qlks.TANG on p.MAKV equals q.MAKV
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
        public string Tach(string tach3)
        {
            string Ktach = "";
            if (tach3.Equals("000"))
                return "";
            if (tach3.Length == 3)
            {
                string tr = tach3.Trim().Substring(0, 1).ToString().Trim();
                string ch = tach3.Trim().Substring(1, 1).ToString().Trim();
                string dv = tach3.Trim().Substring(2, 1).ToString().Trim();
                if (tr.Equals("0") && ch.Equals("0"))
                    Ktach = " không trăm lẻ " + Chu(dv.ToString().Trim()) + " ";
                if (!tr.Equals("0") && ch.Equals("0") && dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm ";
                if (!tr.Equals("0") && ch.Equals("0") && !dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm lẻ " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (tr.Equals("0") && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm mười " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("0"))
                    Ktach = " không trăm mười ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("5"))
                    Ktach = " không trăm mười lăm ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười " + Chu(dv.Trim()).Trim() + " ";

                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười lăm ";

            }
            return Ktach;
        }

        public string Donvi(string so)
        {
            string Kdonvi = "";

            if (so.Equals("1"))
                Kdonvi = "";
            if (so.Equals("2"))
                Kdonvi = "nghìn";
            if (so.Equals("3"))
                Kdonvi = "triệu";
            if (so.Equals("4"))
                Kdonvi = "tỷ";
            if (so.Equals("5"))
                Kdonvi = "nghìn tỷ";
            if (so.Equals("6"))
                Kdonvi = "triệu tỷ";
            if (so.Equals("7"))
                Kdonvi = "tỷ tỷ";

            return Kdonvi;
        }

        public string Chu(string gNumber)
        {
            string result = "";
            switch (gNumber)
            {
                case "0":
                    result = "không";
                    break;
                case "1":
                    result = "một";
                    break;
                case "2":
                    result = "hai";
                    break;
                case "3":
                    result = "ba";
                    break;
                case "4":
                    result = "bốn";
                    break;
                case "5":
                    result = "năm";
                    break;
                case "6":
                    result = "sáu";
                    break;
                case "7":
                    result = "bảy";
                    break;
                case "8":
                    result = "tám";
                    break;
                case "9":
                    result = "chín";
                    break;
            }
            return result;
        }

        public string So_chu(double gNum)
        {
            if (gNum == 0)
                return "Không đồng";

            string lso_chu = "";
            string tach_mod = "";
            string tach_conlai = "";
            double Num = Math.Round(gNum, 0);
            string gN = Convert.ToString(Num);
            int m = Convert.ToInt32(gN.Length / 3);
            int mod = gN.Length - m * 3;
            string dau = "[+]";

            if (gNum < 0)
                dau = "[-]";
            dau = "";

            // Tach hang lon nhat
            if (mod.Equals(1))
                tach_mod = "00" + Convert.ToString(Num.ToString().Trim().Substring(0, 1)).Trim();
            if (mod.Equals(2))
                tach_mod = "0" + Convert.ToString(Num.ToString().Trim().Substring(0, 2)).Trim();
            if (mod.Equals(0))
                tach_mod = "000";
            // Tach hang con lai sau mod :
            if (Num.ToString().Length > 2)
                tach_conlai = Convert.ToString(Num.ToString().Trim().Substring(mod, Num.ToString().Length - mod)).Trim();

            ///don vi hang mod
            int im = m + 1;
            if (mod > 0)
                lso_chu = Tach(tach_mod).ToString().Trim() + " " + Donvi(im.ToString().Trim());
            /// Tach 3 trong tach_conlai

            int i = m;
            int _m = m;
            int j = 1;
            string tach3 = "";
            string tach3_ = "";

            while (i > 0)
            {
                tach3 = tach_conlai.Trim().Substring(0, 3).Trim();
                tach3_ = tach3;
                lso_chu = lso_chu.Trim() + " " + Tach(tach3.Trim()).Trim();
                m = _m + 1 - j;
                if (!tach3_.Equals("000"))
                    lso_chu = lso_chu.Trim() + " " + Donvi(m.ToString().Trim()).Trim();
                tach_conlai = tach_conlai.Trim().Substring(3, tach_conlai.Trim().Length - 3);

                i = i - 1;
                j = j + 1;
            }
            if (lso_chu.Trim().Substring(0, 1).Equals("k"))
                lso_chu = lso_chu.Trim().Substring(10, lso_chu.Trim().Length - 10).Trim();
            if (lso_chu.Trim().Substring(0, 1).Equals("l"))
                lso_chu = lso_chu.Trim().Substring(2, lso_chu.Trim().Length - 2).Trim();
            if (lso_chu.Trim().Length > 0)
                lso_chu = dau.Trim() + " " + lso_chu.Trim().Substring(0, 1).Trim().ToUpper() + lso_chu.Trim().Substring(1, lso_chu.Trim().Length - 1).Trim() + " đồng chẵn.";
            return lso_chu.ToString().Trim();
        }
        public void SuaTTHoaDon(string MaPhieu, int TT)
        {
            var td = (from a in qlks.HOADON where a.MAHD == MaPhieu select a).SingleOrDefault();
            if (td != null)
            {
                td.THANHTIEN =TT;
                qlks.SaveChanges();
            }
        }
        public void SuaNgayKetThuc(string MaPhieu, string ngaykt)
        {
            var td = (from a in qlks.PHIEUDATPHONG where a.MAPHIEUDAT == MaPhieu select a).SingleOrDefault();
            if (td != null)
            {
                td.NGAYKT = DateTime.Parse(ngaykt);
                qlks.SaveChanges();
            }
        }
        public void SuaTrangThaiPhong(string maphong)
        {
            var td = (from a in qlks.PHONG where a.MAPHONG == maphong select a).SingleOrDefault();
            if (td != null)
            {
                td.TRANGTHAI ="Trống";
                qlks.SaveChanges();
            }
        }
        public string LayMaPhieuDat(string MaPhong)
        {
            string b = "";
            var Ma = (from p in qlks.PHONG
                      join q in qlks.PHIEUDATPHONG on p.MAPHONG equals q.MAPHONG
                      where p.MAPHONG == MaPhong && q.NGAYKT==null
                      select new
                      {
                          q.MAPHIEUDAT
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.MAPHIEUDAT;
            }
            return b;
        }
        public string LayTenNV(string MaHD)
        {
            string b = "";
            var Ma = (from p in qlks.HOADON
                      join q in qlks.NHANVIEN on p.MANV equals q.MANV
                      where p.MAHD == MaHD
                      select new
                      {
                          q.HOTEN
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.HOTEN;
            }
            return b;
        }
    }
}
