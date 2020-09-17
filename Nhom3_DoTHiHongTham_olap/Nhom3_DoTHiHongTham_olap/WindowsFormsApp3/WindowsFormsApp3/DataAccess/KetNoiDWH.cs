using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace WindowsFormsApp3.DataAccess
{
    class KetNoiDWH
    {
        SqlConnection connect;
        SqlDataAdapter da;
        SqlCommand command;

        public KetNoiDWH()
        {
            connectDB();
        }

        public void connectDB()
        {
            connect = new SqlConnection(@"Data Source=DESKTOP-0TNC6UA;Initial Catalog=QL_YTE_DIM;Integrated Security=True");
            try
            {
                connect.Open();
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
                connect.Dispose();
            }
        }

        public DataTable getDS(string sql)
        {
            DataTable table = new DataTable();
            da = new SqlDataAdapter(sql, connect);
            da.Fill(table);
            return table;
        }

        public bool ExecuteNonQueryPara(string sql, string[] parameters, object[] value)
        {
            int number = 0;
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                command = new SqlCommand(sql, connect);
                SqlParameter p;
                for (int i = 0; i < parameters.Length; i++)
                {
                    p = new SqlParameter(parameters[i], value[i]);
                    command.Parameters.Add(p);
                }
                number = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            if (number > 0)
                return true;
            else
                return false;
        }



       
        


    }
}
