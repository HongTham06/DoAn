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
    class BHYTBO
    {
        DBAccess db = new DBAccess();

        public DataTable getDSBHYT()
        {
            string query = "Select * from BHYTe";
            return db.getDS(query);
        }

        public DataTable getDSBHYT(string SoThe)
        {
            string query = "Select * from BHYTe where SoTheBH='" + SoThe + "'";
            return db.getDS(query);
        }
        public bool kiemTraBHYT(string SoThe)
        {
            return db.kiemTraTonTai1(SoThe);
        }

        public bool ThemBHYT(BHYT bh )
        {
            string[] param = { "@SoTheBH", "@TenChuThe"};
            object[] values = { bh.SoTheBH,bh.TenChuThe };
            string query = "Insert into BHYTe(SoTheBH,TenChuThe) values (@SoTheBH,@TenChuThe)";
            return db.ExecuteNonQueryPara(query, param, values);
        }

        public bool SuaBHYT(BHYT bh)
        {
            string[] param = { "@SoTheBH", "@TenChuThe" };
            object[] values = { bh.SoTheBH, bh.TenChuThe };
            string query = "Update BHYTe set TenChuThe=@TenChuThe where SoTheBH=@SoTheBH";
            return db.ExecuteNonQueryPara(query, param, values);
        }

        public bool XoaBHYT(BHYT bh)
        {
            string[] param = { "@SoTheBH", "@TenChuThe" };
            object[] values = { bh.SoTheBH, bh.TenChuThe };
            string query = "Delete from BHYTe where SoTheBH=@SoTheBH ";
            return db.ExecuteNonQueryPara(query, param, values);
        }
    }
}
