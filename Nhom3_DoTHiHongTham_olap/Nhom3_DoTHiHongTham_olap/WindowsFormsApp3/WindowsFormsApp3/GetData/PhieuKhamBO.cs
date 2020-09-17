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
    class PhieuKhamBO
    {
        DBAccess db = new DBAccess();

        public DataTable getDSPhieuKham()
        {
            string query = "Select * from PhieuKham";
            return db.getDS(query);
        }

        public DataTable getDSPhieuKham(string MaPK)
        {
            string query = "Select * from PhieuKham where MaPK='" + MaPK + "'";
            return db.getDS(query);
        }
    }
}
