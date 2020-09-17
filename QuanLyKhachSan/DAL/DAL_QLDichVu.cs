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
    public class DAL_QLDichVu:ConText
    {
        public DataTable LayDICHVU()
        {
            var nv = (from p in qlks.DICHVU
                      join q in qlks.LOAIDICHVU on p.MALOAIDV equals q.MALOAIDV
                      select new
                      {
                          p.MADV,
                          p.TENDV,
                          p.DVT,
                          p.DONGIA,
                          q.TENLOAIDV
                      }).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Dịch Vụ");
            dt.Columns.Add("Tên Dịch Vụ");
            dt.Columns.Add("ĐVT");
            dt.Columns.Add("Đơn Giá");
            dt.Columns.Add("Loại DV");
            foreach (var TD in nv)
            {
                dt.Rows.Add(TD.MADV, TD.TENDV, TD.DVT, TD.DONGIA.ToString(), TD.TENLOAIDV);
            }
            return dt;
        }

        public void ThemSP(string MSP, string TSP, string DVT, string DGN, string MLSP, string HA)
        {
            QLKhachSanEntities chung = new QLKhachSanEntities();
            DICHVU td = new DICHVU();
            td.MADV = MSP;
            td.TENDV = TSP;
            td.DVT = DVT;
            td.DONGIA = int.Parse(DGN);
            td.MALOAIDV = MLSP;
            td.HINHANH = HA;
            chung.DICHVU.Add(td);
            chung.SaveChanges();
        }

        public void XoaSP(string MSP)
        {
            var itemToRemove = qlks.DICHVU.SingleOrDefault(x => x.MADV == MSP); //returns a single item.

            if (itemToRemove != null)
            {
                qlks.DICHVU.Remove(itemToRemove);
                qlks.SaveChanges();
            }
        }

        public void SuaSP(string MSP, string TSP, string DVT, string DGN, string MLSP, string HA)
        {
            var td = (from a in qlks.DICHVU where a.MADV == MSP select a).SingleOrDefault();
            if (td != null)
            {
                td.TENDV = TSP;
                td.DVT = DVT;
                td.DONGIA = int.Parse(DGN);
                td.MALOAIDV = MLSP;
                td.HINHANH = HA;
                qlks.SaveChanges();
            }
        }

        public string LayMaSP()
        {
            int ma = 0;
            var ma1 = from p in qlks.DICHVU
                      select new
                      {
                          p.MADV
                      };

            foreach (var i in ma1)
            {
                if (ma < int.Parse(i.MADV.Substring(2)))
                {
                    ma = int.Parse(i.MADV.Substring(2));
                }
            }
            if (ma < 9)
                return "DV00" + (ma + 1).ToString();
            if (ma < 99)
                return "DV0" + (ma + 1).ToString();
            if (ma >= 100)
                return "DV" + (ma + 1).ToString();
            return "DV" + (ma + 1).ToString();
        }
        public void LayHinhAnh(string MSP, PictureEdit PicThucAn)
        {
            var hinhAnh = from h in qlks.DICHVU
                          where h.MADV == MSP
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
        public List<LOAIDICHVU> loadcbbLSP()
        {
            return qlks.LOAIDICHVU.Select(t => t).ToList<LOAIDICHVU>();
        }
        public string LayLinkHA(string MSP)
        {
            string b = "";
            var Ma = (from p in qlks.DICHVU
                      where p.MADV == MSP
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
    }
}
