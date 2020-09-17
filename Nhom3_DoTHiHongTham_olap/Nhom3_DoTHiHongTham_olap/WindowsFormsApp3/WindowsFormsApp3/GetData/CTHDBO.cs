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
    class CTHDBO
    {
        DBAccess db = new DBAccess();

        public DataTable getDSCTHD()
        {
            string query = "Select * from CTHD";
            return db.getDS(query);
        }

        public DataTable getDSBenhNhan(string MaHD)
        {
            string query = "Select * from CTHD where MaHD='" + MaHD + "'";
            return db.getDS(query);
        }
    }
}
