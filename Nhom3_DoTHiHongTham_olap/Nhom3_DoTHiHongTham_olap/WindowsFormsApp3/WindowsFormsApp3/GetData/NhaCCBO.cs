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
    class NhaCCBO
    {
        DBAccess db = new DBAccess();

        public DataTable getDSNCC()
        {
            string query = "Select * from NCC";
            return db.getDS(query);
        }

        public DataTable getDSNCC(string MaNCC)
        {
            string query = "Select * from NCC where MaNCC='" + MaNCC + "'";
            return db.getDS(query);
        }
    }
}
