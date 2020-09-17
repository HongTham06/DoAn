using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp3
{
    public partial class frmChart : Form
    {
        public frmChart()
        {
            InitializeComponent();
        }
        private void fillChart()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-0TNC6UA;Initial Catalog=QL_YTE_DIM;User ID=sa;Password=sa123");
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select SL,NgayBan from fact", con);
            adapt.Fill(ds);
            chart1.DataSource = ds;
            //set the member of the chart data source used to data bind to the X-values of the series  
            chart1.Series["Fact"].XValueMember = "SL";
            //set the member columns of the chart data source used to data bind to the X-values of the series  
            chart1.Series["Fact"].YValueMembers = "NgayBan";
            chart1.Titles.Add("Fact Chart");
            con.Close();

        }
        private void frmChart_Load(object sender, EventArgs e)
        {
            fillChart();
        }
    }
}
