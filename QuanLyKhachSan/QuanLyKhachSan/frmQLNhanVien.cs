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
    public partial class frmQLNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmQLNhanVien()
        {
            InitializeComponent();
        }
        DAL_QLNhanVien nv = new DAL_QLNhanVien();
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
            this.txtLuongCB.ResetText();
            this.txtMaNV.ResetText();
            this.dtNgaySinh.ResetText();
            this.cbbPhai.ResetText();
            this.txtSDT.ResetText();
            txtLuongCB.EditValue = null;

            dtgvTT.DataSource = nv.LayNhanVien();

        }
        private void frmQLNhanVien_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void dtgvTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dtgvTT.CurrentCell.RowIndex;
                txtMaNV.Text = dtgvTT.Rows[r].Cells[0].Value.ToString();
                txtHoTen.Text = dtgvTT.Rows[r].Cells[1].Value.ToString();
                cbbPhai.Text = dtgvTT.Rows[r].Cells[2].Value.ToString();
                dtNgaySinh.Text = dtgvTT.Rows[r].Cells[3].Value.ToString();
                txtDiaChi.Text = dtgvTT.Rows[r].Cells[4].Value.ToString();
                txtSDT.Text = dtgvTT.Rows[r].Cells[5].Value.ToString();
                txtLuongCB.Text = dtgvTT.Rows[r].Cells[6].Value.ToString();
                lblTongCa.Text = nv.LayCaLam(txtMaNV.Text);
                lblTongTien.Text = nv.LayLuong(txtMaNV.Text, int.Parse(txtLuongCB.EditValue.ToString()));
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
            this.txtLuongCB.ResetText();
            this.txtMaNV.ResetText();
            this.dtNgaySinh.ResetText();
            this.cbbPhai.ResetText();
            this.txtSDT.ResetText();
            txtLuongCB.EditValue = null;
            this.txtMaNV.Enabled = true;

            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.grctrlTT.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            txtMaNV.Text = nv.LayMaNV();
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
                    nv.XoaNV(txtMaNV.Text);
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
            this.txtLuongCB.ResetText();
            this.txtMaNV.ResetText();
            this.dtNgaySinh.ResetText();
            this.cbbPhai.ResetText();
            this.txtSDT.ResetText();
            txtLuongCB.EditValue = null;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.grctrlTT.Enabled = true;

            this.txtMaNV.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.dtgvTT.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                try
                {
                    if (nv.KTTuoi(DateTime.Parse(dtNgaySinh.EditValue.ToString())) == 0)
                    {
                        bltb.Show("Nhân Viên Chưa Đủ 18 Tuổi");
                        this.dtNgaySinh.ResetText();
                    }
                    else
                    {
                        nv.ThemNV(txtMaNV.Text, txtHoTen.Text, cbbPhai.Text, dtNgaySinh.Text, txtDiaChi.Text, txtSDT.Text, txtLuongCB.EditValue.ToString());
                        Loaddata();
                        bltb.Show("Thêm Xong");
                    }
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
                    if (nv.KTTuoi(DateTime.Parse(dtNgaySinh.EditValue.ToString())) == 0)
                    {
                        bltb.Show("Nhân Viên Chưa Đủ 18 Tuổi");
                        this.dtNgaySinh.ResetText();
                    }
                    else
                    {
                        nv.SuaNV(txtMaNV.Text, txtHoTen.Text, cbbPhai.Text, dtNgaySinh.Text, txtDiaChi.Text, txtSDT.Text, txtLuongCB.EditValue.ToString());
                        Loaddata();
                        bltb.Show("Sửa Xong");
                    }
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
    }
}