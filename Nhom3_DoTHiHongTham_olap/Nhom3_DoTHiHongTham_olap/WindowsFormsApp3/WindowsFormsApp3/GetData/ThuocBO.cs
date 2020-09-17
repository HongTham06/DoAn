using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WindowsFormsApp3.DataAccess;
using WindowsFormsApp3.Class;

namespace WindowsFormsApp3.GetData
{
    class ThuocBO
    {
        DBAccess db = new DBAccess();

        public DataTable getDSThuoc()
        {
            string query = "Select * from Thuoc";
            return db.getDS(query);
        }
        public bool kiemTraThuoc(string TenThuoc)
        {
            return db.kiemTraTonTai2(TenThuoc);
        }
        public DataTable getDSThuoc(string TenThuoc)
        {
            string query = "Select * from Thuoc where TenThuoc='" + TenThuoc + "'";
            return db.getDS(query);
        }
        public bool ThemThuoc(Thuoc th)
        {
            string[] param = { "@TenThuoc","@DVT" , "@DonGia"};
            object[] values = { th.TenThuoc,th.DVT,th.DonGia };
            string query = "Insert into Thuoc(TenThuoc,DVT,DonGia) values (@TenThuoc,@DVT,@DonGia)";
            return db.ExecuteNonQueryPara(query, param, values);
        }

        public bool SuaThuoc(Thuoc th)
        {
            string[] param = { "@TenThuoc", "@DVT", "@DonGia" };
            object[] values = { th.TenThuoc, th.DVT, th.DonGia };
            string query = "Update Thuoc set DonGia=@DonGia ,DVT=@DVT where TenThuoc=@TenThuoc";
            return db.ExecuteNonQueryPara(query, param, values);
        }

        public bool XoaThuoc(Thuoc th)
        {
            string[] param = { "@TenThuoc", "@DVT", "@DonGia" };
            object[] values = { th.TenThuoc, th.DVT, th.DonGia };
            string query = "Delete from Thuoc where TenThuoc=@TenThuoc ";
            return db.ExecuteNonQueryPara(query, param, values);
        }
    }
}
