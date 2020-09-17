using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThuVien
{
    public class DBConnect
    {
        private string p;

        public SqlConnection con { get; set; }
        public string strCon { get; set; }
        public DataSet dset { get; set; }
        public DBConnect()
        {
            strCon = @"Data Source=WIN8_1;Initial Catalog=QL_CAPHE;Persist Security Info=True;User ID=sa;Password=sa2012";
            
            con = new SqlConnection(strCon);
        }

        public DBConnect(string strSQL)
        {

            strCon = @"Data Source=WIN8_1;Initial Catalog=" + strSQL + ";Persist Security Info=True;User ID=sa;Password=sa2012";
            con = new SqlConnection(strCon);
            dset = new DataSet(strSQL);
            
        }


        public void openConnection() 
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
        }

        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        public void disposeConnection()
        {
            if (con.State == ConnectionState.Open)
                con.Dispose();
        }

        public int getCount(string str)
        {
            int count = 0;
            openConnection();
            SqlCommand sc = new SqlCommand(str);
            sc.Connection = con;
            count = (int)sc.ExecuteScalar();
            return count;
        }

        public bool checkExist(string Table, string KeyName, string KeyValues)
        {
            string str = "SELECT COUNT(*) FROM " + Table + " WHERE " + KeyName + " = '" + KeyValues + "'";
            openConnection();
            if (getCount(str) > 0)
                return true;
            return false;
        }

        public bool checkExist2Khoa(string Table1, string KeyName1, string KeyValues1, string KeyName2, string KeyValues2)
        {
            string str = "SELECT COUNT(*) FROM " + Table1 + " WHERE " + KeyName1 + " = '" + KeyValues1 + "' AND " + KeyName2 + "= '" + KeyValues2 + "'";
            openConnection();
            if (getCount(str) > 0)
                return true;
            return false;
        }

        public SqlDataReader getDataReader(string str)
        {
            openConnection();
            SqlCommand sm = new SqlCommand(str, con);
            SqlDataReader sd = sm.ExecuteReader();
            
            return sd;
        }

        public string getDataScaler(string str)
        {
            openConnection();
            SqlCommand sm = new SqlCommand(str, con);
            string sd = (string)sm.ExecuteScalar().ToString();
            return sd;
        }


        public DataTable getDataTable(string str, string tablename)
        {
            openConnection();
            SqlDataAdapter sda = new SqlDataAdapter(str,con);
            sda.Fill(dset, tablename);
            closeConnection();
            return dset.Tables[tablename];
        }

        public DataSet getDataSet(string str, string tablename)
        {
            openConnection();
            SqlDataAdapter sda = new SqlDataAdapter(str, con);
            sda.Fill(dset, tablename);
            closeConnection();
            return dset;
        }


        public SqlDataAdapter getSqlDataAdapter(string str, string tablename)
        {
            openConnection();
            dset = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(str, con);
            sda.Fill(dset, tablename);
            closeConnection();
            return sda;
        }

    }
}
