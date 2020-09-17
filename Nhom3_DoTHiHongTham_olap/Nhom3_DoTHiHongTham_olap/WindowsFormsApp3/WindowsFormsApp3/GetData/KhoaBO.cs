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
    class KhoaBO
    {
        DBAccess db = new DBAccess();
        public DataTable getDSKhoa()
        {
            string query = "Select * from Khoa";
            return db.getDS(query);
        }

        public DataTable getDSKhoa(string Makhoa)
        {
            string query = "Select * from Khoa where MaKhoa='" + Makhoa + "'";
            return db.getDS(query);
        }
        public bool ThemKhoa(Khoa kh)
        {
            string[] param = { "@MaKhoa", "@TenKhoa" };
            object[] values = { kh.MaKhoa, kh.TenKhoa };
            string query = "Insert into Khoa(MaKhoa,TenKhoa) values (@MaKhoa,@TenKhoa)";
            return db.ExecuteNonQueryPara(query, param, values);
        }

        public bool SuaKhoa(Khoa kh)
        {
            string[] param = { "@MaKhoa", "@TenKhoa" };
            object[] values = { kh.MaKhoa, kh.TenKhoa };
            string query = "Update Khoa set TenKhoa=@TenKhoa where MaKhoa=@MaKhoa";
            return db.ExecuteNonQueryPara(query, param, values);
        }

        public bool XoaKhoa(Khoa kh)
        {
            string[] param = { "@MaKhoa", "@TenKhoa" };
            object[] values = { kh.MaKhoa, kh.TenKhoa };
            string query = "Delete from Khoa where MaKhoa=@MaKhoa ";
            return db.ExecuteNonQueryPara(query, param, values);
        }
    }
}
