using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace OlapApp
{
    public partial class frmLogin : Form
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        //KetNoi db = new KetNoi();
        LoadDL db = new LoadDL();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'loadDB.DanhSachDB' table. You can move, or remove it, as needed.
            this.danhSachDBTableAdapter.Fill(this.loadDB.DanhSachDB);
            this.cboDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            dt = db.LoadDSDB();
            cboDatabase.DataSource = dt;
            cboDatabase.DisplayMember = "name";
            cboDatabase.ValueMember = "name";

        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text.Trim() == "")
                {
                    MessageBox.Show("Tài khoản đăng nhập không được trống", "", MessageBoxButtons.OK);
                    txtUserName.Focus();
                    return;
                }

                KetNoi.mlogin = txtUserName.Text.Trim();
                KetNoi.password = txtPass.Text.Trim();
                if (KetNoi.Connect() == 0)
                    return;

                // 0 - trả về database hien tai
                SqlDataReader myReader;
                KetNoi.mDatabase = cboDatabase.SelectedIndex;
                KetNoi.loadDB = danhSachDBBindingSource;

                KetNoi.mloginDN = KetNoi.mlogin;
                KetNoi.passwordDN = KetNoi.password;
                string strLenh = "exec KiemTraDangNhap '" + KetNoi.mlogin + "'";

                myReader = KetNoi.ExecSqlDataReader(strLenh);
                if (myReader == null) return;
                myReader.Read();

                KetNoi.username = myReader.GetString(0);     // Lay user name
                if (Convert.IsDBNull(KetNoi.username))
                {
                    MessageBox.Show("User không đủ quyền truy cập ! Xin vui lòng xem lại cơ sở dữ liệu.", "", MessageBoxButtons.OK);
                    return;
                }
                //KetNoi.mHoten = myReader.GetString(1);
                KetNoi.mGroup = myReader.GetString(1);
                myReader.Close();
                KetNoi.conn.Close();
                MessageBox.Show("Đăng nhập thành công! ", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TrungGiang m = new TrungGiang();

                m.luuTen("TaiKhoan: " + KetNoi.username, "Nhom: " + KetNoi.mGroup);

                this.Hide();
                frmHome h = new frmHome();
                h.ShowDialog();
                this.Show();
                //new frmHome().Show();
                //this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void cboDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDatabase.SelectedValue != null)
            {
                KetNoi.database = cboDatabase.SelectedValue.ToString();
            }
        }

        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPass.Clear();
            txtUserName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
