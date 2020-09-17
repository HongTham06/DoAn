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
    class BenhLyBO
    {
        DBAccess db = new DBAccess();

        public DataTable getDSBenhLy()
        {
            string query = "Select * from BenhLy";
            return db.getDS(query);
        }

        public DataTable getDSBenhLy(string MaBL)
        {
            string query = "Select * from BenhLy where MaBL='" + MaBL + "'";
            return db.getDS(query);
        }
    }
}
