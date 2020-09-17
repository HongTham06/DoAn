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
using QuanLyKhachSan.BSlayer;
using DAL;

namespace QuanLyKhachSan
{
    public partial class frmQLKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public frmQLKhachHang()
        {
            InitializeComponent();
        }
        DAL_QLKhachHang nv = new DAL_QLKhachHang();
        BLThongBao bltb = new BLThongBao();
        public string KT { get; set; }
        bool them;
        public void Loaddata()
        {
            cbbDiaChi.Properties.Items.Clear();
            cbbDiaChi.Properties.Items.Add("Tất Cả");
            foreach (DataRow r in nv.LoadDiaChi().Rows)
            {
                cbbDiaChi.Properties.Items.Add(r[0]);
            }
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.grctrlTT.Enabled = false;

            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;

            this.txtDiaChi.ResetText();
            this.txtHoTen.ResetText();
            this.txtMaKH.ResetText();
            this.cbbPhai.ResetText();
            this.txtSDT.ResetText();

            dtgvTT.DataSource = nv.LayKhachHang();
        }
        private void frmQLKhachHang_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void dtgvTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dtgvTT.CurrentCell.RowIndex;
                txtMaKH.Text = dtgvTT.Rows[r].Cells[0].Value.ToString();
                txtHoTen.Text = dtgvTT.Rows[r].Cells[1].Value.ToString();
                cbbPhai.Text = dtgvTT.Rows[r].Cells[2].Value.ToString();
                txtDiaChi.Text = dtgvTT.Rows[r].Cells[3].Value.ToString();
                txtSDT.Text = dtgvTT.Rows[r].Cells[4].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            this.txtDiaChi.ResetText();
            this.txtHoTen.ResetText();
            this.txtMaKH.ResetText();
            this.cbbPhai.ResetText();
            this.txtSDT.ResetText();

            this.txtMaKH.Enabled = true;

            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.grctrlTT.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            txtMaKH.Text = nv.LayMaKH();
            this.dtgvTT.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBoxYesNo msgyn = new MessageBoxYesNo();
            msgyn.ThongBao = "Bạn Có Muốn Xóa Không?";
            msgyn.ShowDialog();
            msgyn.Hide();
            KT = msgyn.Check;
            if (KT == "Có")
            {
                try
                {
                    nv.XoaKH(txtMaKH.Text);
                    Loaddata();
                    bltb.Show("Đã Xóa Xong");
                }
                catch
                {
                    bltb.Show("Lỗi");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            this.txtDiaChi.ResetText();
            this.txtHoTen.ResetText();
            this.txtMaKH.ResetText();
            this.cbbPhai.ResetText();
            this.txtSDT.ResetText();

            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.grctrlTT.Enabled = true;

            this.txtMaKH.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                try
                {
                    nv.ThemKH(txtMaKH.Text, txtHoTen.Text, cbbPhai.Text, txtDiaChi.Text, txtSDT.Text);
                    Loaddata();
                    bltb.Show("Thêm Xong");
                }
                catch (Exception)
                {
                    bltb.Show("Lỗi");
                }
            }
            else
            {
                try
                {
                    nv.SuaKH(txtMaKH.Text, txtHoTen.Text, cbbPhai.Text, txtDiaChi.Text, txtSDT.Text);
                    Loaddata();
                    bltb.Show("Sửa Xong");
                }
                catch
                {
                    bltb.Show("Lỗi");
                }
            }
            this.dtgvTT.Enabled = true;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Loaddata();
            this.dtgvTT.Enabled = true;
        }

        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtgvTT.DataSource = nv.Loc(cbbDiaChi.Text, cbbGioiTinh.Text, txtTimKiem.Text);
                if (txtTimKiem.Text == "" && cbbDiaChi.Text == "Tất Cả" && cbbGioiTinh.Text == "Tất Cả")
                {
                    Loaddata();
                }
            }
            catch
            {

            }
        }

        private void cbbGioiTinh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtgvTT.DataSource = nv.Loc(cbbDiaChi.Text, cbbGioiTinh.Text, txtTimKiem.Text);
                if (txtTimKiem.Text == "" && cbbDiaChi.Text == "Tất Cả" && cbbGioiTinh.Text == "Tất Cả")
                {
                    Loaddata();
                }
            }
            catch
            {

            }
        }

        private void cbbDiaChi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtgvTT.DataSource = nv.Loc(cbbDiaChi.Text, cbbGioiTinh.Text, txtTimKiem.Text);
                if (txtTimKiem.Text == "" && cbbDiaChi.Text == "Tất Cả" && cbbGioiTinh.Text == "Tất Cả")
                {
                    Loaddata();
                }
            }
            catch
            {

            }
        }
        private void frmQLKhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}