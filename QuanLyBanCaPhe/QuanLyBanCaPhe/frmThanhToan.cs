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
    public partial class frmThanhToan : Form
    {
        DBConnect conn = new DBConnect("QL_CAPHE");
        public frmTrangChinh main;
        public SqlDataAdapter da;
        public DataSet ds = new DataSet();
        public int IndexBan;
        public frmThanhToan(string ban, frmTrangChinh main)
        {
            InitializeComponent();
            setBan(int.Parse(ban));
            setTrangChinh(main);
            Load_CT(IndexBan);
            txtMaBan.Text = IndexBan + "";
            txtMaBan.ReadOnly = true;
            txtTongThanhTien.ReadOnly = true;
            TinhTongThanhTien();
        }

        private void lstViewChiTietHD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Xác nhận hoàn tất thanh toán: Tiền dư: " + tinhTienThua(), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if (IndexBan != -1)
                {
                    if (main.t.BackColor == Color.Aqua)
                    {
                        main.t.BackColor = Color.Transparent;
                        string[] ban = main.t.Text.Split(' ');
                        string str = "UPDATE BAN SET TINHTRANG = N'TRỐNG' WHERE MABAN = " + ban[1];
                        conn.openConnection();
                        SqlCommand sm = new SqlCommand(str, conn.con);
                        sm.ExecuteNonQuery();
                        lstViewChiTietHD.Items.Clear();
                        main.HideButton(false);
                        main.Enabled = true;
                        this.Hide();
                    }
                }
            }
        }

        private float tinhTienThua()
        {
            return int.Parse(txtTienNhan.Text) - int.Parse(txtTongThanhTien.Text) - int.Parse(txtTongThanhTien.Text) * float.Parse(txtKhuyetMai.Text);
        }

        private void Load_CT(int ban)
        {
            if (!ktBanTrong(ban))
            {
                string str = "SELECT TOP(1) MAHD FROM HOADON WHERE MABAN = " + ban + " ORDER BY MAHD DESC";
                string ma = conn.getDataScaler(str);
                str = "SELECT * FROM CHITIETHOADON WHERE MAHD = " + ma;
                da = conn.getSqlDataAdapter(str, "CHITIETHD");
                da.Fill(ds, "CHITIETHD");
                lstViewChiTietHD.Items.Clear();
                foreach (DataRow i in ds.Tables["CHITIETHD"].Rows)
                {
                    ListViewItem t = new ListViewItem(i["MANUOC"].ToString());
                    t.Name = i["MANUOC"].ToString();
                    if (conn.checkExist("NUOCPHACHE", "MANPC", i["MANUOC"].ToString()))
                        str = "SELECT TENNPC FROM NUOCPHACHE WHERE MANPC = '" + i["MANUOC"].ToString() + "'";
                    else
                        str = "SELECT TENNGK FROM NUOCGIAIKHAT WHERE MANGK = '" + i["MANUOC"].ToString() + "'";
                    string ten = conn.getDataScaler(str);
                    t.SubItems.Add(ten);
                    t.SubItems.Add(i["SOLUONG"].ToString());
                    string[] dg = i["DONGIA"].ToString().Split('.');
                    int sl = Convert.ToInt32(i["SOLUONG"].ToString());
                    int dongia = Convert.ToInt32(dg[0]);
                    t.SubItems.Add(dg[0]);
                    int tongtien = sl * dongia;
                    t.SubItems.Add(tongtien.ToString());
                    lstViewChiTietHD.Items.Add(t);
                }
                ds.Tables["CHITIETHD"].Clear();
            }
        }

        private bool ktBanTrong(int ban)
        {
            string str = "SELECT TINHTRANG FROM BAN WHERE MABAN = " + ban;
            string tinhtrang = conn.getDataScaler(str);
            if (tinhtrang.Equals("TRỐNG"))
            {
                return true;
            }
            return false;
        }

        private void TinhTongThanhTien()
        {
            int tong = 0;
            foreach (ListViewItem i in lstViewChiTietHD.Items)
            {
                tong += int.Parse(i.SubItems[4].Text);
            }
            txtTongThanhTien.Text = tong + "";
        }

        private void setReadOnly()
        {
            txtMaBan.ReadOnly = true;
        }

        private void txtTienNhan_Leave(object sender, EventArgs e)
        {
            Control t = (Control)sender;
            if (txtTienNhan.Text.Trim().Length == 0 && !IsNumber(txtTienNhan.Text))
                this.errorProvider1.SetError(t, "Bạn phải nhập số tiền");
            else
            {
                this.errorProvider1.Clear();
            }
        }

        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private void txtTienNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control t = (Control)sender;
            if (IsNumber(txtTienNhan.Text))
                this.errorProvider1.SetError(t, "Bạn phải nhập số tiền");
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            main.Enabled = true;
            this.Hide();
        }

        private void frmThanhToan_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Enabled = true;
            this.Hide();
        }

        public void setBan(int ban)
        {
            IndexBan = ban;
        }

        public void setTrangChinh(frmTrangChinh main)
        {
            this.main = main;
        }

        private void txtKhuyetMai_Leave(object sender, EventArgs e)
        {
            Control t = (Control)sender;
            if (!IsNumber(txtTienNhan.Text))
                this.errorProvider1.SetError(t, "Nhập số lượng khuyến mãi. Không có thì mặc định là 0");
            else if (txtTienNhan.Text.Trim().Length == 0)
                txtKhuyetMai.Text = 0 + "";
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {

        }

    }
}
