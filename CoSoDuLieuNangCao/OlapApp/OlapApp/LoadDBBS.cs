using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace OlapApp
{
    class LoadDBBS
    {
        string str = @"Data Source=ASUS;Initial Catalog=BS_Fahasa;User ID=sa;Password=sa2012";
        SqlConnection conn = null;
        SqlCommand comm = null;
        SqlDataAdapter da = null;
        private DataSet dset;

        public DataSet Dset
        {
            get { return dset; }
            set { dset = value; }
        }
        public LoadDBBS()
        {
           
            conn = new SqlConnection(str);
            comm = conn.CreateCommand();

        }
         public void Connect(ref string state)
         {//kiểm tra kết nối, nếu kết nối thành công thì trạng thái là "Open"
             // ngược lại là "Closed"
             if (conn.State == ConnectionState.Open)
                 conn.Close();
             try { conn.Open(); }
             catch { }
             state = conn.State.ToString();
         }
        public DataSet ExecuteQueryDataSet(string strSQl, CommandType ct, params SqlParameter[] p)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText = strSQl;
            comm.CommandType = ct;
            da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error, params SqlParameter[] param)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.Parameters.Clear();
            comm.CommandText = strSQL;
            comm.CommandType = ct;

            foreach (SqlParameter p in param)
                comm.Parameters.Add(p);
            try
            {
                comm.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return f;
        }
        public bool ThemCD(ref string err, string maCD, string tenCD)

        {
            return MyExecuteNonQuery("themCD", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaCD", maCD),
                new SqlParameter("@TenCD", tenCD));

        }
        public bool SuaCD(ref string err, string maSP, string tenSP)
        {
            return MyExecuteNonQuery("SuaCD", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MaCD", maSP),
                new SqlParameter("@TenCD", tenSP));
        }
        public bool XoaCD(ref string err, string maSP)
        {
            return MyExecuteNonQuery("XoaCD", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaCD", maSP));
        }
    }

}
