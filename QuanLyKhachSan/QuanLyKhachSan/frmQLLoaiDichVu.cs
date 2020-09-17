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
    public partial class frmQLLoaiDichVu : DevExpress.XtraEditors.XtraForm
    {
        public frmQLLoaiDichVu()
        {
            InitializeComponent();
        }
        DAL_QLLoaiDichVu ncc = new DAL_QLLoaiDichVu();
        BLThongBao bltb = new BLThongBao();
        public string KT { get; set; }
        bool them;
        public void Loaddata()
        {
            dtgvTT.DataSource = ncc.LayLoaiSanPham();
            cbbTenLSP.Properties.DataSource = ncc.loadcbbLSP();
            cbbTenLSP.Properties.DisplayMember = "TENLOAIDV";
            cbbTenLSP.Properties.ValueMember = "MALOAIDV";

            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;

            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;

            this.grctlTT.Enabled = false;

            this.txtMaLoaiMon.ResetText();
            this.txtTenLoaiMon.ResetText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            this.txtMaLoaiMon.ResetText();
            this.txtTenLoaiMon.ResetText();

            this.txtMaLoaiMon.Enabled = true;

            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.grctlTT.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.txtMaLoaiMon.Text = ncc.LayMaLSP();
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
                    ncc.XoaLSP(txtMaLoaiMon.Text);
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
            this.txtMaLoaiMon.ResetText();
            this.txtTenLoaiMon.ResetText();

            this.grctlTT.Enabled = true;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            this.txtMaLoaiMon.Enabled = false;
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
                    ncc.ThemLSP(txtMaLoaiMon.Text, txtTenLoaiMon.Text);
                    Loaddata();
                    bltb.Show("Thêm Xong");
                }
                catch
                {
                    bltb.Show("Lỗi");
                }

            }
            else
            {
                try
                {
                    ncc.SuaLSP(txtMaLoaiMon.Text, txtTenLoaiMon.Text);
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

        private void cbbTenLSP_EditValueChanged(object sender, EventArgs e)
        {
            dtgvTT2.DataSource = ncc.LayLoaiSanPham2(cbbTenLSP.EditValue.ToString());
        }

        private void frmQLLoaiDichVu_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void dtgvTTNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dtgvTT.CurrentCell.RowIndex;
                txtMaLoaiMon.Text = dtgvTT.Rows[r].Cells[0].Value.ToString();
                txtTenLoaiMon.Text = dtgvTT.Rows[r].Cells[1].Value.ToString();
            }
            catch
            {

            }
        }
    }
}