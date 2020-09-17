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
    class NhanVienBO
    {
        DBAccess db = new DBAccess();

        public DataTable getDSNhanVien()
        {
            string query = "Select * from NhanVien";
            return db.getDS(query);
        }

        public DataTable getDSNhanVien(string MaNV)
        {
            string query = "Select * from NhanVien where MaNV='" + MaNV + "'";
            return db.getDS(query);
        }
    }
}
