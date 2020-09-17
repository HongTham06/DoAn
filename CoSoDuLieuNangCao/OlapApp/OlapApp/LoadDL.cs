using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OlapApp
{
    class LoadDL
    {

        LoadDatabase db = null;
        public LoadDL()
        {
            db = new LoadDatabase();
        }

        public DataTable LoadDSDB()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM DanhSachDB", CommandType.Text).Tables[0];
        }
        public DataTable Load_CD()
        {
            return db.ExecuteQueryDataSet("select * from Dim_ChuDe", CommandType.Text).Tables[0];
        }
        public DataTable Load_NXB()
        {
            return db.ExecuteQueryDataSet("select * from Dim_NhaXuatBan", CommandType.Text).Tables[0];
        }
        public DataTable Load_S()
        {
            return db.ExecuteQueryDataSet("select * from Dim_Sach", CommandType.Text).Tables[0];
        }
        public DataTable Load_CN()
        {
            return db.ExecuteQueryDataSet("select * from Dim_ChiNhanh", CommandType.Text).Tables[0];
        }
        public DataTable Load_NV()
        {
            return db.ExecuteQueryDataSet("select * from Dim_NhanVien", CommandType.Text).Tables[0];
        }
        public DataTable Load_KH()
        {
            return db.ExecuteQueryDataSet("select * from Dim_KhachHang", CommandType.Text).Tables[0];
        }
        public DataTable Load_F()
        {
            return db.ExecuteQueryDataSet("select * from FACT", CommandType.Text).Tables[0];
        }
        public DataTable Load_Time()
        {
            return db.ExecuteQueryDataSet("select * from Dim_Time", CommandType.Text).Tables[0];
        }
    }
}
