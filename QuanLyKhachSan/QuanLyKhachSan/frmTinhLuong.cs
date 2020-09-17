using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;

namespace QuanLyKhachSan
{
    public partial class frmTinhLuong : DevExpress.XtraEditors.XtraForm
    {
        public frmTinhLuong()
        {
            InitializeComponent();
        }

        private void frmTinhLuong_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 12; i++)
            {
                cbbThang.Properties.Items.Add(i);
            }

            for (int i = 2010; i <= 2050; i++)
            {
                cbbNam.Properties.Items.Add(i);
            }

            DateTime day = System.DateTime.Now;
            cbbThang.Text = (day.Month - 1).ToString();
            cbbNam.Text = day.Year.ToString();
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            string st = "Data Source=DESKTOP-9SFBHE9; Initial Catalog=QLKhachSan; Integrated Security=True";
            SqlConnection sql = new SqlConnection(st);
            sql.Open();
            SqlCommand cmd = new SqlCommand("select * from RPChamCong where Thang ='" + cbbThang.Text + "' and Nam ='" + cbbNam.Text + "'", sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sql.Close();
            RPChamCong rp = new RPChamCong();
            rp.DataSource = dt;
            rp.DataMember = "RPChamCong";
            rp.ShowPreview();
            this.Hide();
        }
    }
}