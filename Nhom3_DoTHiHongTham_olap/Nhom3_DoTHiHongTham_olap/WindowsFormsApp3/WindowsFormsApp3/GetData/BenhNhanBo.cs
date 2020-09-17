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
    class BenhNhanBo
    {
        DBAccess db = new DBAccess();

        public DataTable getDSBenhNhan()
        {
            string query = "Select * from BenhNhan";
            return db.getDS(query);
        }

        public DataTable getDSBenhNhan(string MaBN)
        {
            string query = "Select * from BenhNhan where MaBN='" + MaBN + "'";
            return db.getDS(query);
        }
    }
}
