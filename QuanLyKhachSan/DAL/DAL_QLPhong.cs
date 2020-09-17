using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DAL
{
    public class DAL_QLPhong:ConText
    {
        public List<TANG> loadcbbTang()
        {
            return qlks.TANG.Select(t => t).ToList<TANG>();
        }
        public int TimSoTang()
        {
            var tim = from p in qlks.TANG
                      select p;
            return tim.Count();
        }
        public void ThemP(string MP, string TP, string DT, string DG, string MT,string TT, string HA)
        {
            QLKhachSanEntities chung = new QLKhachSanEntities();
            PHONG td = new PHONG();
            td.MAPHONG = MP;
            td.TENPHONG = TP;
            td.DIENTICH = DT;
            td.DONGIA = int.Parse(DG);
            td.MAKV = MT;
            td.TRANGTHAI = TT;
            td.HINHANH = HA;
            chung.PHONG.Add(td);
            chung.SaveChanges();
        }

        public void XoaP(string MP)
        {
            var itemToRemove = qlks.PHONG.SingleOrDefault(x => x.MAPHONG == MP); //returns a single item.

            if (itemToRemove != null)
            {
                qlks.PHONG.Remove(itemToRemove);
                qlks.SaveChanges();
            }
        }

        public void SuaP(string MP, string TP, string DT, string DG, string MT, string TT, string HA)
        {
            var td = (from a in qlks.PHONG where a.MAPHONG == MP select a).SingleOrDefault();
            if (td != null)
            {
                td.TENPHONG = TP;
                td.DIENTICH = DT;
                td.DONGIA = int.Parse(DG);
                td.MAKV = MT;
                td.TRANGTHAI = TT;
                td.HINHANH = HA;
                qlks.SaveChanges();
            }
        }

        public string LayMaP()
        {
            int ma = 0;
            var ma1 = from p in qlks.PHONG
                      select new
                      {
                          p.MAPHONG
                      };

            foreach (var i in ma1)
            {
                if (ma < int.Parse(i.MAPHONG.Substring(2)))
                {
                    ma = int.Parse(i.MAPHONG.Substring(2));
                }
            }
            if (ma < 9)
                return "P00" + (ma + 1).ToString();
            if (ma < 99)
                return "P0" + (ma + 1).ToString();
            if (ma >= 100)
                return "P" + (ma + 1).ToString();
            return "P" + (ma + 1).ToString();
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
        public void LayHinhAnh3(string link, PictureEdit PicThucAn)
        {

            try
            {
                PicThucAn.Image = Image.FromFile(link);
            }
            catch
            {
                PicThucAn.Image = Image.FromFile("NhaTrangLuxury.png");
            }

        }
    }
}
