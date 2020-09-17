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
    class HoaDonBO
    {
        DBAccess db = new DBAccess();

        public DataTable getDSHoaDon()
        {
            string query = "Select * from HoaDon";
            return db.getDS(query);
        }

        public DataTable getDSHoaDon(string MaHD)
        {
            string query = "Select * from HoaDon where MaHD='" + MaHD + "'";
            return db.getDS(query);
        }
    }
}
