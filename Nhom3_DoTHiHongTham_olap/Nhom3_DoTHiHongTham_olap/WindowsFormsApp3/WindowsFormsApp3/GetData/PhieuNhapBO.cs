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
    class PhieuNhapBO
    {
        DBAccess db = new DBAccess();

        public DataTable getDSPhieuNhap()
        {
            string query = "Select * from PhieuNhap";
            return db.getDS(query);
        }

        public DataTable getDSPhieuNhap(string MaPN)
        {
            string query = "Select * from PhieuNhap where MaPN='" + MaPN + "'";
            return db.getDS(query);
        }
    }
}
