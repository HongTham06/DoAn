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
    class GiuongBenhBO
    {
        DBAccess db = new DBAccess();

        public DataTable getDSGiuongBenh()
        {
            string query = "Select * from GiuongBenh";
            return db.getDS(query);
        }

        public DataTable getDSGiuongBenh(string MaGB)
        {
            string query = "Select * from GiuongBenh where MaGB='" + MaGB + "'";
            return db.getDS(query);
        }
    }
}
