using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThuVien;


namespace QuanLyBanCaPhe
{
    public partial class frmDangNhap : Form
    {
        DBConnect conn = new DBConnect("QL_CAPHE");
        frmTrangChinh main = new frmTrangChinh();
        SqlDataAdapter da;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            checkTKNV();
        }

        private void txtTK_Leave(object sender, EventArgs e)
        {
            Control t = (Control)sender;
            if (t.Text.Trim().Length == 0)
                this.errorProvider1.SetError(t, "Bạn phải nhập mã tài khoản");
            else
                this.errorProvider1.Clear();
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            Control t = (Control)sender;
            if (t.Text.Trim().Length == 0)
                this.errorProvider1.SetError(t, "Bạn phải nhập password");
            else
                this.errorProvider1.Clear();
        }

        private void checkTKNV()
        {
            string str = "SELECT * FROM TAIKHOANNV WHERE MATK = '" + txtTK.Text + "' AND MATKHAU = '" + txtPassword.Text + "'";
            if (!conn.checkExist2Khoa("TAIKHOANNV", "MATK", txtTK.Text, "MATKHAU", txtPassword.Text))
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
            }
            else
            {
                da = conn.getSqlDataAdapter(str, "TAIKHOANNV");
                da.Fill(main.ds, "TAIKHOANNV");
                main.Show();
                this.Hide();
            }
        }

    }
}
