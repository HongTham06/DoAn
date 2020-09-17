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
    public partial class frmTrangChinh : Form
    {
        DBConnect conn = new DBConnect("QL_CAPHE");
        public SqlDataAdapter da;
        public DataSet ds = new DataSet();
        int IndexBan = -1;
        bool order = true;
        string[] ban;
        public Button t;
        public frmTrangChinh()
        {
            InitializeComponent();
            HideButton(false);
            setLuuHuyNuoc(false);
            btnThemLoai.Visible = false;
        }

        private void frmTrangChinh_Load(object sender, EventArgs e)
        {
            if (ds.Tables["TAIKHOANNV"] != null)
            {
                DataRow dr = ds.Tables["TAIKHOANNV"].Rows[0];
                label1.Text = dr["TENTK"].ToString();
            }
            
            setEnableMenu(false);
            tabControl2.TabPages.Remove(tpChiTietKhoHang);
            tabControl2.TabPages.Remove(tpCongThuc);
            Load_LoaiDoUong();
            Load_Menu_GiaiKhat();
            Load_Button();
        }

        private void tpChiTietKhoHang_Click(object sender, EventArgs e)
        {

        }



        private void QLKHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnThemLoai.Visible = false;
            if (ds.Tables["KHONUOCGIAIKHAT"] != null)
                ds.Tables["KHONUOCGIAIKHAT"].Clear();
            if (ds.Tables["NGUYENLIEU"] != null)
                ds.Tables["NGUYENLIEU"].Clear();
            if (ds.Tables["CONGTHUC"] != null)
                ds.Tables["CONGTHUC"].Clear();
            setEnableMenu(false);
            setEnableCTCongThuc(true);
            if (tabControl1.TabPages.Contains(tpThucDon) && tabControl2.TabPages.Contains(tpHoaDon))
            {
                tabControl1.Visible = false;
                tabControl2.Location = new Point(45, 24);
                this.Size = new Size(1002, 664);
                this.StartPosition = FormStartPosition.CenterScreen;
                tabControl2.TabPages.Remove(tpHoaDon);
                tabControl3.TabPages.Remove(tpGiaiKhat);
                tabControl2.TabPages.Add(tpChiTietKhoHang);
            }
            else if (tabControl1.TabPages.Contains(tpThucDon) && tabControl2.TabPages.Contains(tpCongThuc))
            {
                tabControl1.Visible = false;
                tabControl2.Location = new Point(12, 24);
                this.Size = new Size(1002, 664);
                this.StartPosition = FormStartPosition.CenterScreen;
                tabControl2.TabPages.Remove(tpCongThuc);
                tabControl3.TabPages.Remove(tpGiaiKhat);
                tabControl2.TabPages.Add(tpChiTietKhoHang);
            }
            
            Load_KhoNGK();
            Load_KhoNguyenLieu();
            setReadOnlyChiTietNL(true);
            if (ds.Tables["CONGTHUC"] != null)
                ds.Tables["CONGTHUC"].Clear();
            if (!ktPhanQuyenAdmin())
            {
                btnLuuCTNL.Visible = false;
                btnHuyNL.Visible = false;
                btnThemNguyenLieu.Visible = false;
                btnCapNhatNguyenLieu.Visible = false;
                btnXoaNguyenLieu.Visible = false;
            }
            else
            {
                btnLuuCTNL.Visible = true;
                btnHuyNL.Visible = true;
                btnThemNguyenLieu.Visible = true;
                btnCapNhatNguyenLieu.Visible = true;
                btnXoaNguyenLieu.Visible = true;
            }
               
        }

        private void QLBHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setEnableMenu(false);
            btnThemLoai.Visible = false;
            setButtonThemNuocMoi(true);
            if (tabControl2.TabPages.Contains(tpChiTietKhoHang))
            {
                tabControl1.Visible = true;
                tabControl2.Location = new Point(398, 24);
                this.Size = new Size(1302, 664);
                this.StartPosition = FormStartPosition.CenterScreen;
                tabControl2.TabPages.Remove(tpChiTietKhoHang);
                tabControl2.TabPages.Add(tpHoaDon);
                tabControl3.TabPages.Add(tpGiaiKhat);
            }
            else if (tabControl2.TabPages.Contains(tpCongThuc))
            {
                tabControl1.Visible = true;
                tabControl2.Location = new Point(398, 24);
                this.Size = new Size(1302, 664);
                this.StartPosition = FormStartPosition.CenterScreen;
                tabControl2.TabPages.Remove(tpCongThuc);
                tabControl2.TabPages.Add(tpHoaDon);
                tabControl3.TabPages.Add(tpGiaiKhat);
            }
            if (ds.Tables["KHONUOCGIAIKHAT"] != null)
                ds.Tables["KHONUOCGIAIKHAT"].Clear();
            if (ds.Tables["NGUYENLIEU"] != null)
                ds.Tables["NGUYENLIEU"].Clear();
            if (ds.Tables["CONGTHUC"] != null)
                ds.Tables["CONGTHUC"].Clear();
            dgvNuocGiaiKhat.DataSource = null;
            dgvNguyenLieu.DataSource = null;
            dgvNguyenLieu.Refresh();
            dgvNuocGiaiKhat.Refresh();
            order = true;
            txtSLOrder.Visible = true;
            lbSLNPC.Visible = true;
            setLuuHuyNuoc(false);
            btnThemNuoc.Visible = true;
            
        }


        private void btnBan_Click(object sender, EventArgs e)
        {
            lstViewChiTietHD.Items.Clear();
            setEnableMenu(true);
            HideButton(true);
            t = (Button)sender;
            IndexBan = t.TabIndex;
            ban = t.Text.Split(' ');
            lstViewGiaiKhat.Items.Clear();
            if (ds.Tables["NUOCGIAIKHAT"] != null)
                ds.Tables["NUOCGIAIKHAT"].Clear();
            Load_CT(ban[1]);
            TinhTongThanhTien();
            Load_Menu_GiaiKhat();
        }

        public void HideButton(bool bol)
        {

            btnXacNhanHD.Visible = bol;
            btnThanhToan.Visible = bol;

            btnHuyHD.Visible = bol;
            btnXoaHD.Visible = bol;
        }

        private void btnXacNhanHD_Click(object sender, EventArgs e)
        {
            if (IndexBan != -1)
            {
                setEnableMenu(false);
                t.BackColor = Color.Aqua;
                HideButton(false);
                ban = t.Text.Split(' ');
                addHDMoi(ban[1]);
                string str = "UPDATE BAN SET TINHTRANG = N'USING' WHERE MABAN = " + ban[1];
                SqlCommand sm = new SqlCommand(str, conn.con);
                sm.ExecuteNonQuery();
                lstViewChiTietHD.Items.Clear();
                HideButton(false);
            }

        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            setEnableMenu(false);
            HideButton(false);
            lstViewChiTietHD.Items.Clear();
            btnThemNuoc.Visible = true;
            btnLuuNuocMoi.Visible = false;
            btnHuyThemNuoc.Visible = false;
        }

        private void setEnableMenu(bool k)
        {
            gbDanhMuc.Enabled = k;
            gbDoUong.Enabled = k;
            lstViewGiaiKhat.Enabled = k;
        }

        public void Load_LoaiDoUong()
        {
            string str = "SELECT * FROM LOAI";
            da = conn.getSqlDataAdapter(str, "LOAI");
            da.Fill(ds, "LOAI");
            cbLoaiDoUong.DataSource = ds.Tables["LOAI"];
            cbLoaiDoUong.DisplayMember = "TENLOAI";
            cbLoaiDoUong.ValueMember = "MALOAI";
            cbLoaiDoUong.SelectedIndex = -1;
        }
        private void Load_Menu_PhaChe()
        {

            string str = "SELECT MANPC, TENNPC, DONGIA FROM NUOCPHACHE WHERE NUOCPHACHE.MALOAI = '" + cbLoaiDoUong.SelectedValue + "'";
            da = conn.getSqlDataAdapter(str, "NUOCPHACHE");
            da.Fill(ds, "NUOCPHACHE");
            foreach (DataRow i in ds.Tables["NUOCPHACHE"].Rows)
            {
                ListViewItem t = new ListViewItem(i["TENNPC"].ToString());
                t.Name = i["MANPC"].ToString();
                ListViewItem.ListViewSubItem sub = new ListViewItem.ListViewSubItem(t, i["DONGIA"].ToString());
                t.SubItems.Add(sub);
                lstViewPhaChe.Items.Add(t);
            }
        }

        private void Load_Menu_GiaiKhat()
        {

            string str = "SELECT MANGK, TENNGK, DONGIA FROM NUOCGIAIKHAT";
            da = conn.getSqlDataAdapter(str, "NUOCGIAIKHAT");
            da.Fill(ds, "NUOCGIAIKHAT");
            foreach (DataRow i in ds.Tables["NUOCGIAIKHAT"].Rows)
            {
                ListViewItem t = new ListViewItem(i["TENNGK"].ToString());
                t.Name = i["MANGK"].ToString();
                ListViewItem.ListViewSubItem sub = new ListViewItem.ListViewSubItem(t, i["DONGIA"].ToString());
                t.SubItems.Add(sub);
                lstViewGiaiKhat.Items.Add(t);
            }
        }

        private void cbLoaiDoUong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ds.Tables["NUOCPHACHE"] != null)
            {
                ds.Tables["NUOCPHACHE"].Clear();
            }
            lstViewPhaChe.Items.Clear();
            Load_Menu_PhaChe();
            if (ds.Tables["CONGTHUC"] != null)
                ds.Tables["CONGTHUC"].Clear();
        }

        private void lstViewPhaChe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstViewPhaChe.SelectedItems.Count > 0)
            {
                txtMaNuocOrder.Text = lstViewPhaChe.SelectedItems[0].Name;
                txtTenNuocOrder.Text = lstViewPhaChe.SelectedItems[0].Text;
                txtDonGiaOrder.Text = lstViewPhaChe.SelectedItems[0].SubItems[1].Text;
                if (!order)
                {
                    if (ds.Tables["CONGTHUC"] != null)
                        ds.Tables["CONGTHUC"].Clear();
                    Load_CongThuc(lstViewPhaChe.SelectedItems[0].Name);
                }
            }

        }

        private void btnThemNuoc_Click(object sender, EventArgs e)
        {
            
                setLuuHuyNuoc(true);
                if (order)
                {
                    GetNuoc();
                    TinhTongThanhTien();
                    setButtonThemNuocMoi(false);
                    btnThemNuoc.Visible = true;
                }
                else
                {
                    txtMaNuocOrder.ReadOnly = false;
                    txtTenNuocOrder.ReadOnly = false;
                    txtDonGiaOrder.ReadOnly = false;
                    btnThemNuoc.Visible = false;
                    setButtonThemNuocMoi(true);

                }
            
        }

        private void GetNuoc()
        {
            
                if (!ktSoLuongNPC(Convert.ToInt32(txtSLOrder.Text), txtMaNuocOrder.Text))
                {
                    MessageBox.Show("Số lượng hiện có không đủ, xin kiểm tra lại!");
                }
                else
                {
                    ListViewItem them = new ListViewItem(txtMaNuocOrder.Text);
                    them.Name = txtMaNuocOrder.Text;
                    them.SubItems.Add(txtTenNuocOrder.Text);
                    them.SubItems.Add(txtSLOrder.Text);
                    string[] dg = txtDonGiaOrder.Text.Split('.');
                    int sl = Convert.ToInt32(txtSLOrder.Text);
                    int dongia = Convert.ToInt32(dg[0]);
                    them.SubItems.Add(dg[0]);
                    int tongtien = sl * dongia;
                    them.SubItems.Add(tongtien.ToString());
                    lstViewChiTietHD.Items.Add(them);
                }
            
            
            //}
            //catch
            //{
            //}
        }

        private void GetNuocGK()
        {
            if (!ktSoLuongNGK(Convert.ToInt32(txtSLOrderGT.Text), txtMaNuocGT.Text))
            {
                MessageBox.Show("Số lượng hiện có không đủ, xin kiểm tra lại!");
            }
            else
            {
                ListViewItem them = new ListViewItem(txtMaNuocGT.Text);
                them.Name = txtMaNuocGT.Text;
                them.SubItems.Add(txtTenNuocGT.Text);
                them.SubItems.Add(txtSLOrderGT.Text);

                string[] dg = txtDonGiaGT.Text.Split('.');
                int sl = Convert.ToInt32(txtSLOrderGT.Text);
                int dongia = Convert.ToInt32(dg[0]);
                them.SubItems.Add(dg[0]);
                int tongtien = sl * dongia;
                them.SubItems.Add(tongtien.ToString());
                lstViewChiTietHD.Items.Add(them);
            }
        }

        private void lstViewChiTietHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstViewChiTietHD.SelectedItems.Count > 0)
            {
                txtMaNuoc.Text = lstViewChiTietHD.SelectedItems[0].Name;
                txtTenNuoc.Text = lstViewChiTietHD.SelectedItems[0].SubItems[1].Text;
                txtSL.Text = lstViewChiTietHD.SelectedItems[0].SubItems[2].Text;
                txtTongTienCT.Text = lstViewChiTietHD.SelectedItems[0].SubItems[4].Text;
            }
        }

        private void TinhTongThanhTien()
        {
            int tong = 0;
            foreach (ListViewItem i in lstViewChiTietHD.Items)
            {
                tong += int.Parse(i.SubItems[4].Text);
            }
            txtTongTien.Text = tong + "";
        }

        private void suaChiTietHD()
        {
            txtSL.ReadOnly = false;
        }

        private void btnSuaChiTietHD_Click(object sender, EventArgs e)
        {
            if (lstViewChiTietHD.SelectedItems.Count > 0)
            {
                suaChiTietHD();
            }
        }

        private void btnXoaChiTietHD_Click(object sender, EventArgs e)
        {
            if (lstViewChiTietHD.SelectedItems.Count > 0)
            {
                lstViewChiTietHD.SelectedItems[0].Remove();
            }
        }

        private void btnLuuChiTietHD_Click(object sender, EventArgs e)
        {
            if (lstViewChiTietHD.SelectedItems.Count > 0)
            {
                lstViewChiTietHD.SelectedItems[0].Name = txtMaNuoc.Text;
                lstViewChiTietHD.SelectedItems[0].SubItems[1].Text = txtTenNuoc.Text;
                lstViewChiTietHD.SelectedItems[0].SubItems[2].Text = txtSL.Text;
                int sl = Convert.ToInt32(txtSL.Text);
                int dongia = Convert.ToInt32(lstViewChiTietHD.SelectedItems[0].SubItems[3].Text);
                int tong = sl * dongia;
                lstViewChiTietHD.SelectedItems[0].SubItems[4].Text = tong + "";
            }
            TinhTongThanhTien();
        }

        private bool ktBanTrong(string ban)
        {
            string str = "SELECT TINHTRANG FROM BAN WHERE MABAN = '" + ban + "'";
            string tinhtrang = conn.getDataScaler(str);
            if (tinhtrang.Equals("TRỐNG"))
            {

                return true;

            }

            return false;
        }

        private void addHDMoi(string ban)
        {
            string str = "INSERT INTO HOADON(MABAN, NGAYLAP) VALUES (" + ban + ", GETDATE())";
            conn.openConnection();
            SqlCommand sm = new SqlCommand(str, conn.con);
            sm.ExecuteNonQuery();
            str = "SELECT TOP(1) MAHD FROM HOADON WHERE MABAN = '" + ban + "' ORDER BY MAHD DESC";
            string ma = conn.getDataScaler(str);
            foreach (ListViewItem i in lstViewChiTietHD.Items)
            {
                addChiTietHDMoi(ma, i.Name, i.SubItems[2].Text);
            }
        }

        private void addChiTietHDMoi(string ban, string Manuoc, string sl)
        {
            string str = "INSERT INTO CHITIETHOADON(MAHD, MANUOC, SOLUONG) VALUES (" + ban + ",'" + Manuoc + "', " + sl + ")";
            SqlCommand sm = new SqlCommand(str, conn.con);
            sm.ExecuteNonQuery();
        }

        private string GetHD(string ban)
        {
            string ma;
            string str = "SELECT TOP(1) MAHD FROM HOADON WHERE MABAN = '" + ban + "' ORDER BY MAHD DESC";
            ma = conn.getDataScaler(str);
            return ma;
        }

        private void Load_CT(string ban)
        {
            if (!ktBanTrong(ban))
            {
                string str = "SELECT TOP(1) MAHD FROM HOADON WHERE MABAN = '" + ban + "' ORDER BY MAHD DESC";
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

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (IndexBan != -1)
            {
                if (t.BackColor == Color.Aqua)
                {
                    //t.BackColor = Color.Transparent;
                    //string[] ban = t.Text.Split(' ');
                    //string str = "UPDATE BAN SET TINHTRANG = N'TRỐNG' WHERE MABAN = " + ban[1];
                    //conn.openConnection();
                    //SqlCommand sm = new SqlCommand(str, conn.con);
                    //sm.ExecuteNonQuery();
                    //lstViewChiTietHD.Items.Clear();
                    //HideButton(false);
                    frmThanhToan tt;
                    tt = new frmThanhToan(ban[1],this);
                    this.Enabled = false;
                    tt.Show();
                }
            }
        }

        private void lstViewGiaiKhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstViewGiaiKhat.SelectedItems.Count > 0)
            {
                txtMaNuocGT.Text = lstViewGiaiKhat.SelectedItems[0].Name;
                txtTenNuocGT.Text = lstViewGiaiKhat.SelectedItems[0].Text;
                txtDonGiaGT.Text = lstViewGiaiKhat.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void btnThemNuocGT_Click(object sender, EventArgs e)
        {
            GetNuocGK();
            TinhTongThanhTien();
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            ban = t.Text.Split(' ');
            string ma = GetHD(ban[1]);
            foreach (ListViewItem i in lstViewChiTietHD.Items)
            {
                string str = "DELETE CHITIETHOADON WHERE MAHD = " + ma + " AND MANUOC = '" + i.Name + "'";
                SqlCommand sm = new SqlCommand(str, conn.con);
                sm.ExecuteNonQuery();
            }
            string sql = "DELETE HOADON WHERE MAHD = " + ma;
            SqlCommand s = new SqlCommand(sql, conn.con);
            s.ExecuteNonQuery();
            sql = "UPDATE BAN SET TINHTRANG = N'TRỐNG' WHERE MABAN = " + ban[1];
            s = new SqlCommand(sql, conn.con);
            s.ExecuteNonQuery();
            t.BackColor = Color.Transparent;
            lstViewChiTietHD.Items.Clear();
            HideButton(false);
            setEnableMenu(false);
        }

        private void Load_KhoNGK()
        {
            string str = "SELECT * FROM NUOCGIAIKHAT";
            da = conn.getSqlDataAdapter(str, "KHONUOCGIAIKHAT");
            da.Fill(ds, "KHONUOCGIAIKHAT");
            dgvNuocGiaiKhat.DataSource = ds.Tables["KHONUOCGIAIKHAT"];

        }
        private void Load_KhoNguyenLieu()
        {
            string str = "SELECT * FROM NGUYENLIEU";
            da = conn.getSqlDataAdapter(str, "NGUYENLIEU");
            da.Fill(ds, "NGUYENLIEU");
            dgvNguyenLieu.DataSource = ds.Tables["NGUYENLIEU"];
        }

        private void dgvNuocGiaiKhat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThemNguyenLieu_Click(object sender, EventArgs e)
        {
            setReadOnlyChiTietNL(false);
        }

        private void btnSuaNguyenLieu_Click(object sender, EventArgs e)
        {
            setReadOnlyChiTietNL(false);
            txtSLNL.ReadOnly = true;
            txtSLTruocNhap.ReadOnly = true;
        }

        private void btnXoaNguyenLieu_Click(object sender, EventArgs e)
        {
            if (txtGiaNL.Visible)
            {
                DialogResult dlr = MessageBox.Show("Bạn muốn xóa nước giải khát này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    string str = "DELETE NUOCGIAIKHAT WHERE MANGK = '" + txtMaNguyenLieu.Text + "'";
                    conn.openConnection();
                    SqlCommand sm = new SqlCommand(str, conn.con);
                    int i = sm.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Xóa nước giải khát thành công!");
                    }
                }
            }
            else
            {
                DialogResult dlr = MessageBox.Show("Bạn muốn xóa nguyên liệu này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    try
                    {
                        string str = "DELETE NGUYENLIEU WHERE MANGK = '" + txtMaNguyenLieu.Text + "'";
                        conn.openConnection();
                        SqlCommand sm = new SqlCommand(str, conn.con);
                        int i = sm.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Xóa nước giải khát thành công!");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Không thể xóa nguyên liệu vì có công thức liên quan đến");
                    }
                    
                }
            }
        }

        private void dgvNguyenLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvNuocGiaiKhat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            dgvNuocGiaiKhat.ReadOnly = true;
            try
            {
                txtMaNguyenLieu.Text = dgvNuocGiaiKhat.Rows[numrow].Cells[0].Value.ToString();
                txtTenNL.Text = dgvNuocGiaiKhat.Rows[numrow].Cells[1].Value.ToString();
                txtDVT.Text = dgvNuocGiaiKhat.Rows[numrow].Cells[2].Value.ToString();
                txtGiaNL.Text = dgvNuocGiaiKhat.Rows[numrow].Cells[7].Value.ToString();
                txtSLTruocNhap.Text = dgvNuocGiaiKhat.Rows[numrow].Cells[3].Value.ToString();
                txtSLNhapMoi.Text = dgvNuocGiaiKhat.Rows[numrow].Cells[4].Value.ToString();
                txtSLNL.Text = dgvNuocGiaiKhat.Rows[numrow].Cells[5].Value.ToString();
                txtGiaNhap.Text = dgvNuocGiaiKhat.Rows[numrow].Cells[6].Value.ToString();
                lbMaNL.Text = "Mã nước";
                lbTenNL.Text = "Tên nước";
                lbGia.Visible = true;
                txtGiaNL.Visible = true;
            }
            catch
            {
                
            }
        }

        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            dgvNguyenLieu.ReadOnly = true;
            try
            {
                txtMaNguyenLieu.Text = dgvNguyenLieu.Rows[numrow].Cells[0].Value.ToString();
                txtTenNL.Text = dgvNguyenLieu.Rows[numrow].Cells[1].Value.ToString();
                txtSLNL.Text = dgvNguyenLieu.Rows[numrow].Cells[5].Value.ToString();
                txtDVT.Text = dgvNguyenLieu.Rows[numrow].Cells[2].Value.ToString();
                txtSLTruocNhap.Text = dgvNguyenLieu.Rows[numrow].Cells[4].Value.ToString();
                txtSLNhapMoi.Text = dgvNguyenLieu.Rows[numrow].Cells[3].Value.ToString();
                txtGiaNhap.Text = dgvNguyenLieu.Rows[numrow].Cells[6].Value.ToString();
                lbMaNL.Text = "Mã nguyên liệu";
                lbTenNL.Text = "Tên nguyên liệu";
                lbGia.Visible = false;
                txtGiaNL.Visible = false;
            }
            catch
            {

            }
        }

        private void setReadOnlyChiTietNL(bool k)
        {
            txtMaNguyenLieu.ReadOnly = k;
            txtTenNL.ReadOnly = k;
            txtGiaNL.ReadOnly = k;
            txtSLNL.ReadOnly = k;
            txtGiaNhap.ReadOnly = k;
            txtDVT.ReadOnly = k;
            txtSLNhapMoi.ReadOnly = k;
            txtSLTruocNhap.ReadOnly = k;
            btnLuuCTNL.Visible = !k;
            btnHuyNL.Visible = !k;
            btnThemNguyenLieu.Visible = k;
            btnCapNhatNguyenLieu.Visible = k;
            btnXoaNguyenLieu.Visible = k;
        }

        private bool ktSoLuongNL(float sl, string manl)
        {
            string str = "SELECT SOLUONG FROM NGUYENLIEU WHERE MANL = '" + manl + "'";
            float slton = float.Parse(conn.getDataScaler(str));
            if (slton - sl < 0)
            {
                return false;
            }
            return true;
        }

        private bool ktSoLuongNGK(int sl, string MaNGK)
        {
            string str = "SELECT SOLUONG FROM NUOCGIAIKHAT WHERE MANGK = '" + MaNGK + "'";
            int slton = int.Parse(conn.getDataScaler(str));
            if (slton - sl< 0)
            {
                return false;
            }
            return true;
        }

        private bool ktSoLuongNPC(int sl, string MaNPC)
        {
            string str = "SELECT MANL, SOLUONG * " + sl + " AS SL FROM CONGTHUC WHERE CONGTHUC.MANPC = '" + MaNPC + "'";
            da = conn.getSqlDataAdapter(str, "CONGTHUC");
            da.Fill(ds, "KIEMTRACONGTHUC");
            foreach (DataRow i in ds.Tables["KIEMTRACONGTHUC"].Rows)
            {
                
                    if (!ktSoLuongNL(float.Parse(i["SL"].ToString()), i["MANL"].ToString()))
                    {
                        return false;
                    }
                
            }
            return true;
        }

        private void congThucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ds.Tables["KHONUOCGIAIKHAT"] != null)
                ds.Tables["KHONUOCGIAIKHAT"].Clear();
            if (ds.Tables["NGUYENLIEU"] != null)
                ds.Tables["NGUYENLIEU"].Clear();
            if (ds.Tables["CONGTHUC"] != null)
                ds.Tables["CONGTHUC"].Clear();
            if (tabControl2.TabPages.Contains(tpChiTietKhoHang))
            {
                tabControl1.Visible = true;
                tabControl2.Location = new Point(398, 24);
                this.Size = new Size(1302, 664);
                this.StartPosition = FormStartPosition.CenterScreen;
                tabControl2.TabPages.Remove(tpChiTietKhoHang);
                tabControl2.TabPages.Add(tpCongThuc);
            }
            else if (tabControl2.TabPages.Contains(tpHoaDon))
            {
                tabControl1.Visible = true;
                tabControl2.Location = new Point(398, 24);
                this.Size = new Size(1302, 664);
                this.StartPosition = FormStartPosition.CenterScreen;
                tabControl2.TabPages.Remove(tpHoaDon);
                tabControl3.TabPages.Remove(tpGiaiKhat);
                tabControl2.TabPages.Add(tpCongThuc);
            }
            setEnableMenu(true);
            order = false;
            setButtonThemNuocMoi(false);
            txtSLOrder.Visible = false;
            lbSLNPC.Visible = false;
            Load_CBNguyenLieu();
            setEnableCTCongThuc(true);
            btnLuuCongThucNL.Visible = false;
            btnHuyCTNL.Visible = false;
            cbMaNguyenLieu.SelectedIndex = -1;
            cbMaNguyenLieu.Enabled = false;
            setLuuHuyNuoc(false);
            btnThemLoai.Visible = true;
            if (!ktPhanQuyenAdmin())
            {
                btnLuuCongThucNL.Visible = false;
                btnHuyCTNL.Visible = false;
                btnThemChiTietCTNL.Visible = false;
                btnCapNhatChiTietCTNL.Visible = false;
                btnXoaCTNL.Visible = false;
                btnThemNuoc.Visible = false;
            }
            else
            {
                btnLuuCongThucNL.Visible = true;
                btnHuyCTNL.Visible = true;
                btnThemChiTietCTNL.Visible = true;
                btnCapNhatChiTietCTNL.Visible = true ;
                btnXoaCTNL.Visible = true;
                btnThemNuoc.Visible = true;
            }
        }


        private void setButtonThemNuocMoi(bool k)
        {   
            bool congthuc = false;
            if (k)
                congthuc = true;
            
            btnLuuNuocMoi.Visible = congthuc;
            
            btnHuyThemNuoc.Visible = congthuc;
        }

        private void btnLuuCTNL_Click(object sender, EventArgs e)
        {
            if (txtGiaNL.Visible)
            {
                if (!conn.checkExist("NUOCGIAIKHAT", "MANGK", txtMaNguyenLieu.Text))
                {
                    string str = "INSERT INTO NUOCGIAIKHAT(MANGK, TENNGK, DVT, SLNHAPTHEM, SLHIENTAI, DONGIA, GIABAN) VALUES ('" + txtMaNguyenLieu.Text + "', N'";
                    str += txtTenNL.Text + "', N'" + txtDVT.Text + "'," + txtSLNhapMoi.Text + "," + txtSLNL.Text + ", " + txtGiaNhap.Text + "," + txtGiaNL.Text + ")";
                    conn.openConnection();
                    SqlCommand sm = new SqlCommand(str, conn.con);
                    DialogResult dlr = MessageBox.Show("Bạn muốn thêm nước giải khát mới này không?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        int i = sm.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Thêm nước giải khát mới thành công!");
                        }
                        setReadOnlyChiTietNL(true);
                    }
                }
                else
                {
                    string str = "UPDATE NUOCGIAIKHAT SET TENNGK = N'" + txtTenNL.Text + "' , DVT = N'" + txtDVT.Text + "' , SLNHAPTHEM = " + txtSLNhapMoi.Text + " , SLHIENTAI = ";
                    str += txtSLNL.Text + " ,  DONGIA = " + txtGiaNhap.Text + " , GIABAN = " + txtGiaNL.Text + " WHERE MANGK = '" + txtMaNguyenLieu.Text + "'";
                    conn.openConnection();
                    SqlCommand sm = new SqlCommand(str, conn.con);
                    DialogResult dlr = MessageBox.Show("Bạn muốn cập nhật nước giải khát này không?", "Thông báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        int i = sm.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Cập nhật nước giải khát thành công!");
                        }
                        setReadOnlyChiTietNL(true);
                    }
                }
            }
            else
            {
                if (!conn.checkExist("NGUYENLIEU", "MANL", txtMaNguyenLieu.Text))
                {
                    string str = "INSERT INTO NGUYENLIEU(MANL,TENNL,DVT,SOLUONG, GIANGUYENLIEU) VALUES ('" + txtMaNguyenLieu.Text + "',N'" +txtTenNL.Text + "','" + txtSLNL.Text + "," + txtGiaNhap.Text + ")" ;
                    conn.openConnection();
                    SqlCommand sm = new SqlCommand(str, conn.con);
                    DialogResult dlr = MessageBox.Show("Bạn muốn thêm nguyên liệu mới này không?", "Thông báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        int i = sm.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Thêm nguyên liệu mới thành công!");
                        }

                    }
                }
                else
                {
                    string str = "UPDATE NGUYENLIEU SET TENNL = N'" + txtTenNL.Text + "' , SOLUONG = ";
                    str += txtSLNL.Text + " , DVT = N'" + txtDVT.Text + "' , SOLUONGNHAP = " + txtSLNhapMoi.Text + " WHERE MANL = '" + txtMaNguyenLieu.Text + "'";
                    conn.openConnection();
                    SqlCommand sm = new SqlCommand(str, conn.con);
                    DialogResult dlr = MessageBox.Show("Bạn muốn cập nhật nguyên liệu này không?", "Thông báo", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        int i = sm.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Cập nhật nguyên liệu thành công!");
                        }
                    }
                }
            }
            ds.Tables["NGUYENLIEU"].Clear();
            ds.Tables["KHONUOCGIAIKHAT"].Clear();
            Load_KhoNGK();
            Load_KhoNguyenLieu();
            setReadOnlyChiTietNL(true);
        }

        private void Load_CongThuc(string MaNPC)
        {
            string str = "SELECT * FROM CONGTHUC WHERE MANPC = '" + MaNPC + "'";
            da = conn.getSqlDataAdapter(str, "CONGTHUC");
            da.Fill(ds, "CONGTHUC");
            dgvCongThuc.DataSource = ds.Tables["CONGTHUC"];
        }

        private void dgvCongThuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            dgvCongThuc.ReadOnly = true;
            foreach (DataRowView i in cbMaNguyenLieu.Items)
            {
                if (dgvCongThuc.Rows[numrow].Cells[1].Value.ToString().Equals(i[0].ToString()))
                {
                    cbMaNguyenLieu.SelectedItem = i;
                }
            }
            txtMaNuocCongThuc.Text = dgvCongThuc.Rows[numrow].Cells[0].Value.ToString();
            txtDonViTinh.Text = dgvCongThuc.Rows[numrow].Cells[2].Value.ToString();
            txtSLCT.Text = dgvCongThuc.Rows[numrow].Cells[3].Value.ToString();
            
        }

        private void setEnableCTCongThuc(bool k)
        {
            txtMaNuocCongThuc.ReadOnly = k;
            cbMaNguyenLieu.Enabled = k;
            txtSLCT.ReadOnly = k;
            txtDonViTinh.ReadOnly = k;
        }

        private void Load_CBNguyenLieu()
        {
            string str = "SELECT * FROM NGUYENLIEU";
            da = conn.getSqlDataAdapter(str, "NGUYENLIEU");
            da.Fill(ds, "NGUYENLIEU");
            cbMaNguyenLieu.DataSource = ds.Tables["NGUYENLIEU"];
            cbMaNguyenLieu.DisplayMember = "TENNL";
            cbMaNguyenLieu.ValueMember = "MANL";
        }

        private void btnHuyCTNL_Click(object sender, EventArgs e)
        {
            setEnableCTCongThuc(true);
            btnCapNhatChiTietCTNL.Visible = true;
            btnThemChiTietCTNL.Visible = true;
            btnXoaCTNL.Visible = true;
            btnLuuCongThucNL.Visible = false;
            btnHuyCTNL.Visible = false;
            cbMaNguyenLieu.Enabled = false;
        }

        private void btnLuuCongThucNL_Click(object sender, EventArgs e)
        {
            if (!conn.checkExist2Khoa("CONGTHUC", "MANPC", txtMaNuocCongThuc.Text, "MANL", cbMaNguyenLieu.SelectedValue.ToString()))
            {
                string str = "INSERT INTO CONGTHUC(MANPC, MANL, DVT , SOLUONG) VALUES ('" + txtMaNuocCongThuc.Text + "', N'" + txtDonViTinh.Text + "', '" + cbMaNguyenLieu.SelectedValue.ToString() + "', " + txtSLCT.Text + ")";
                conn.openConnection();
                SqlCommand sm = new SqlCommand(str, conn.con);
                int i = sm.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Thêm chi tiết nước mới thành công!");
                }
            }
            else
            {
                string str = "UPDATE CONGTHUC SET MANL = '" + cbMaNguyenLieu.SelectedValue.ToString() + "', DVT = N'" + txtDonViTinh.Text + "' , SOLUONG = " + txtSLCT.Text + " WHERE MANPC = '" + txtMaNuocCongThuc.Text + "' AND MANL = '" + cbMaNguyenLieu.SelectedValue.ToString() + "'" ;
                conn.openConnection();
                SqlCommand sm = new SqlCommand(str, conn.con);
                int i = sm.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Cập nhật chi tiết nước mới thành công!");
                }
            }
            if (ds.Tables["CONGTHUC"] != null)
                ds.Tables["CONGTHUC"].Clear();
            Load_CongThuc(txtMaNuocCongThuc.Text);
            setEnableCTCongThuc(false);
            btnCapNhatChiTietCTNL.Visible = true;
            btnThemChiTietCTNL.Visible = true;
            btnXoaCTNL.Visible = true;
            btnLuuCongThucNL.Visible = false;
            btnHuyCTNL.Visible = false;
            cbMaNguyenLieu.Enabled = false;
        }

        private void btnXoaCTNL_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn xóa chi tiết công thức này?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                string str = "DELETE CONGTHUC WHERE MANPC = '" + txtMaNuocCongThuc.Text + "' AND MANL = '" + cbMaNguyenLieu.SelectedValue.ToString() + "'";
                conn.openConnection();
                SqlCommand sm = new SqlCommand(str, conn.con);
                int i = sm.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Xóa chi tiết nước mới thành công!");
                }
            }
        }

        private void btnCapNhatChiTietCTNL_Click(object sender, EventArgs e)
        {
            setEnableCTCongThuc(false);
            cbMaNguyenLieu.Enabled = true;
            btnLuuCongThucNL.Visible = true;
            btnHuyCTNL.Visible = true;
        }

        private void btnThemChiTietCTNL_Click(object sender, EventArgs e)
        {
            if (dgvCongThuc.RowCount == 1)
            {
                txtMaNuocCongThuc.Text = txtMaNuocOrder.Text;
            }
            setEnableCTCongThuc(false);
            btnCapNhatChiTietCTNL.Visible = false;
            cbMaNguyenLieu.Enabled = true;
            btnThemChiTietCTNL.Visible = false;
            btnXoaCTNL.Visible = false;
            btnLuuCongThucNL.Visible = true;
            btnHuyCTNL.Visible = true;
        }

        private void btnLuuNuocMoi_Click(object sender, EventArgs e)
        {
            string str = "INSERT INTO NUOCPHACHE(MANPC, TENNPC, DONGIA, MALOAI) VALUES ('" + txtMaNuocOrder.Text + "', '" +  txtTenNuocOrder.Text + "', '" + txtDonGiaOrder.Text + "', '" + cbLoaiDoUong.SelectedValue + "')";
            conn.openConnection();
            SqlCommand sm = new SqlCommand(str, conn.con);
            int i = sm.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Thêm nước mới thành công!");
            }
            if (ds.Tables["NUOCPHACHE"] != null)
            {
                ds.Tables["NUOCPHACHE"].Clear();
            }
            lstViewPhaChe.Items.Clear();
            Load_Menu_PhaChe();
            setLuuHuyNuoc(false);
        }

        private void btnHuyThemNuoc_Click(object sender, EventArgs e)
        {
            txtMaNuocOrder.ReadOnly = true;
            txtTenNuocOrder.ReadOnly = true;
            txtDonGiaOrder.ReadOnly = true;
            setLuuHuyNuoc(false);
        }

        private void cbMaNguyenLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnHuyNL_Click(object sender, EventArgs e)
        {
            setReadOnlyChiTietNL(true);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            frmDangNhap dn = new frmDangNhap();
            this.Hide();
            dn.Show();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ktPhanQuyenQuanLyShop())
            {
                frmDoanhThu dt = new frmDoanhThu(this);
                this.Enabled = false;
                dt.Show();
            }
            else
                MessageBox.Show("Bạn không thể thực hiện thao tác này!","Thông báo");
        }


        private void Load_Button()
        {
            foreach (var b in this.gbChonBan.Controls)
            {
                if (b.GetType() == typeof(Button))
                {
                    Button t = (Button)b;
                    IndexBan = t.TabIndex;
                    ban = t.Text.Split(' ');
                    if (IsNumber(ban[1]))
                    {
                        if (!ktBanTrong(ban[1]))
                        {
                            t.BackColor = Color.Aqua;
                        }
                    }

                }
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
        private void setLuuHuyNuoc(bool k)
        {
            btnThemNuoc.Visible = !k;
            btnLuuNuocMoi.Visible = k;
            btnHuyThemNuoc.Visible = k;
        }
        private bool ktPhanQuyenAdmin()
        {
            foreach (DataRow i in ds.Tables["TAIKHOANNV"].Rows)
            {
                if (i["CHUCVU"].ToString().Equals("nhanvien"))
                    return false;
            }
            return true;
        }

        private bool ktPhanQuyenQuanLyShop()
        {
            foreach (DataRow i in ds.Tables["TAIKHOANNV"].Rows)
            {
                if (i["CHUCVU"].ToString().Equals("quản lý"))
                    return true;
            }
            return false;
        }

        private void btnLuuNGKMoi_Click(object sender, EventArgs e)
        {

        }

        private void txtSLOrderGT_Leave(object sender, EventArgs e)
        {
            Control t = (Control)sender;
            if (txtSLOrder.Text.Trim().Length == 0 && !IsNumber(txtSLOrder.Text))
                this.errorProvider1.SetError(t, "Bạn phải nhập số lượng");
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void txtSLOrder_Leave(object sender, EventArgs e)
        {
            Control t = (Control)sender;
            if (txtSLOrder.Text.Trim().Length == 0 && IsNumber(txtSLOrder.Text))
                this.errorProvider1.SetError(t, "Bạn phải nhập số lượng");
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            frmEditLoai loai = new frmEditLoai(this);
            this.Enabled = false;
            loai.Show();
        }

        private bool checkUserAdmin()
        {
            foreach (DataRow i in ds.Tables["TAIKHOANNV"].Rows)
            {
                if (i["CHUCVU"].ToString().Equals("nhanvien"))
                    return false;
            }
            return true;
        }

        private void btnTamTinh_Click(object sender, EventArgs e)
        {
            if (IndexBan != -1)
            {
                if (t.BackColor == Color.Aqua)
                {
                    t.BackColor = Color.Yellow;
                }
            }
        }
        
    }
}
