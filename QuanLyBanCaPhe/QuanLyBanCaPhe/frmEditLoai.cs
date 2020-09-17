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
    public partial class frmEditLoai : Form
    {
        DBConnect conn = new DBConnect("QL_CAPHE");
        frmTrangChinh main = new frmTrangChinh();
        public SqlDataAdapter da;
        public DataSet ds = new DataSet();
        public frmEditLoai(frmTrangChinh main)
        {
            InitializeComponent();
            this.main = main;
            Load_LoaiDoUong();
            txtMaLoai.ReadOnly = true;
            txtTenLoai.ReadOnly = true;
            setAnNut(true);
        }

        private void cbLoaiDoUong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ds.Tables["NUOCPHACHE"] != null)
            {
                ds.Tables["NUOCPHACHE"].Clear();
            }
            else if (cbLoaiDoUong.SelectedIndex == -1)
            {
                txtMaLoai.Text = "";
                txtTenLoai.Text = "";
            }
            else
            {
                txtMaLoai.Text = cbLoaiDoUong.SelectedValue.ToString();
                txtTenLoai.Text = cbLoaiDoUong.Text;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
            txtMaLoai.ReadOnly = false;
            txtTenLoai.ReadOnly = false;
            txtMaLoai.Focus();
            setAnNut(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn xóa loại nước này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                string str = "DELETE LOAI WHERE MALOAI = '" + txtMaLoai.Text + "'";
                conn.openConnection();
                SqlCommand sm = new SqlCommand(str, conn.con);
                int i = sm.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Xóa nước loại thành công!");
                }
            }
            setAnNut(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaLoai.ReadOnly = false;
            txtTenLoai.ReadOnly = false;
            txtMaLoai.Focus();
            setAnNut(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!conn.checkExist("LOAI", "MALOAI", txtMaLoai.Text))
            {
                string str = "INSERT INTO LOAI VALUES ('" + txtMaLoai.Text + "', N'" + txtTenLoai.Text + "')";
                conn.openConnection();
                SqlCommand sm = new SqlCommand(str, conn.con);
                DialogResult dlr = MessageBox.Show("Bạn muốn thêm loại nước mới này không?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    int i = sm.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Thêm nước giải khát mới thành công!");
                    }
                    setText();
                    setAnNut(true);
                }
            }
            else
            {
                string str = "UPDATE LOAI SET TENLOAI = N'" + txtTenLoai.Text + "' WHERE MALOAI = '" + txtMaLoai.Text + "'";
                conn.openConnection();
                SqlCommand sm = new SqlCommand(str, conn.con);
                DialogResult dlr = MessageBox.Show("Bạn muốn cập nhật loại nước này không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    int i = sm.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Cập nhật nước giải khát thành công!");
                    }
                    setText();
                    setAnNut(true);
                }
            }
            if (ds.Tables["LOAI"] != null)
            {
                //cbLoaiDoUong.Items.Clear();
                ds.Tables["LOAI"].Clear();
            }
            Load_LoaiDoUong();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setText();
            setAnNut(true);
        }
        private void Load_LoaiDoUong()
        {
            string str = "SELECT * FROM LOAI";
            da = conn.getSqlDataAdapter(str, "LOAI");
            da.Fill(ds, "LOAI");
            cbLoaiDoUong.DataSource = ds.Tables["LOAI"];
            cbLoaiDoUong.DisplayMember = "TENLOAI";
            cbLoaiDoUong.ValueMember = "MALOAI";
            cbLoaiDoUong.SelectedIndex = -1;
        }

        private void setText()
        {
            txtMaLoai.ReadOnly = true;
            txtTenLoai.ReadOnly = true;
        }

        private void frmEditLoai_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                main.Enabled= true;
                main.ds.Tables["LOAI"].Clear();
                main.Load_LoaiDoUong();
                this.Hide();
            }
        }

        private void setAnNut(bool k)
        {
            btnThem.Visible = k;
            btnXoa.Visible = k;
            btnSua.Visible = k;
            btnLuu.Visible = !k;
            btnHuy.Visible = !k;
        }

    }
}
