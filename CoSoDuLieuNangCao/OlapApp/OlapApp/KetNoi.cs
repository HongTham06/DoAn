using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OlapApp
{
    class KetNoi
    {
        public static SqlConnection conn = new SqlConnection();
        //public static SqlCommand sqlcmd;
        public static String connstr;
        public static String servername = "ASUS";
        public static String username = "";
        public static String mlogin = "";
        public static String password = "";
        public static String database = "";
        public static String mloginDN = "";
        public static String passwordDN = "";
        public static String mGroup = "";
        public static String mHoten = "";
        public static int checkDangNhap = 0;
        public static int mDatabase = 0; // xác định database
        public static BindingSource loadDB = new BindingSource();
        public static int Connect()
        {
            if (KetNoi.conn != null && KetNoi.conn.State == ConnectionState.Open)
                KetNoi.conn.Close();
            try
            {
                KetNoi.connstr = "Data Source=" + KetNoi.servername + ";Initial Catalog=" +
                      KetNoi.database + ";User ID=" +
                      KetNoi.mlogin + ";password=" + KetNoi.password;
                KetNoi.conn.ConnectionString = KetNoi.connstr;
                KetNoi.conn.Open();
                
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }
        public static SqlDataReader ExecSqlDataReader(String strLenh)
        {
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, KetNoi.conn);
            sqlcmd.CommandType = CommandType.Text;
            if (KetNoi.conn.State == ConnectionState.Closed) KetNoi.conn.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader(); return myreader;
            }
            catch (SqlException ex)
            {
                KetNoi.conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static DataTable ExecSqlDataTable(String cmd, string connstr)
        {
            DataTable dt = new DataTable();
            if (KetNoi.conn.State == ConnectionState.Closed) KetNoi.conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static int ExecSqlNonQuery(String strlenh)
        {
            SqlCommand Sqlcmd = new SqlCommand(strlenh, conn);
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 600;// 10 phut 
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sqlcmd.ExecuteNonQuery(); conn.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Error converting data type varchar to int"))
                    MessageBox.Show("Bạn format Cell lại cột \"Ngày Thi\" qua kiểu Number hoặc mở File Excel.");
                else MessageBox.Show(ex.Message);
                conn.Close();
                return ex.State; // trang thai lỗi gởi từ RAISERROR trong SQL Server qua
            }
        }

        public void openConnection()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        public void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        public void disposeConnection()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Dispose();
        }

        public DataTable loadDataTable(string strSQL)
        {
            openConnection();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
    }
}
