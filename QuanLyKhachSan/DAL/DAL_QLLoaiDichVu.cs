using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DAL_QLLoaiDichVu:ConText
    {
        public DataTable LayLoaiSanPham()
        {
            var nv = from p in qlks.LOAIDICHVU
                     select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Loại DV");
            dt.Columns.Add("Tên Loại DV");
            foreach (var nv1 in nv)
            {
                dt.Rows.Add(nv1.MALOAIDV, nv1.TENLOAIDV);
            }
            return dt;
        }
        public string LayMaLSP()
        {
            int ma = 0;
            var ma1 = from p in qlks.LOAIDICHVU
                      select new
                      {
                          p.MALOAIDV
                      };

            foreach (var i in ma1)
            {
                if (ma < int.Parse(i.MALOAIDV.Substring(3)))
                {
                    ma = int.Parse(i.MALOAIDV.Substring(3));
                }
            }
            if (ma < 9)
                return "LDV00" + (ma + 1).ToString();
            if (ma < 99)
                return "LDV0" + (ma + 1).ToString();
            if (ma >= 100)
                return "LDV" + (ma + 1).ToString();
            return "LDV" + (ma + 1).ToString();
        }
        public void ThemLSP(string MLSP, string TLSP)
        {
            QLKhachSanEntities chung = new QLKhachSanEntities();
            LOAIDICHVU nv = new LOAIDICHVU();
            nv.MALOAIDV = MLSP;
            nv.TENLOAIDV = TLSP;
            chung.LOAIDICHVU.Add(nv);
            chung.SaveChanges();
        }

        public void SuaLSP(string MLSP, string TLSP)
        {
            var nv = (from a in qlks.LOAIDICHVU where a.MALOAIDV == MLSP select a).SingleOrDefault();
            if (nv != null)
            {
                nv.TENLOAIDV = TLSP;
                qlks.SaveChanges();
            }
        }

        public void XoaLSP(string MLSP)
        {
            var itemToRemove = qlks.LOAIDICHVU.SingleOrDefault(x => x.MALOAIDV == MLSP); //returns a single item.

            if (itemToRemove != null)
            {
                qlks.LOAIDICHVU.Remove(itemToRemove);
                qlks.SaveChanges();
            }
        }
        public List<LOAIDICHVU> loadcbbLSP()
        {
            return qlks.LOAIDICHVU.Select(t => t).ToList<LOAIDICHVU>();
        }
        public DataTable LayLoaiSanPham2(string MLSP)
        {
            var nv = (from p in qlks.LOAIDICHVU
                      join q in qlks.DICHVU on p.MALOAIDV equals q.MALOAIDV
                      where p.MALOAIDV == MLSP
                      select new
                      {
                          q.MADV,
                          q.TENDV
                      }).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã DV");
            dt.Columns.Add("Tên DV");
            foreach (var nv1 in nv)
            {
                dt.Rows.Add(nv1.MADV, nv1.TENDV);
            }
            return dt;
        }
    }
}
