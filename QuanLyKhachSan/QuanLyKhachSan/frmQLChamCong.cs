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
    public partial class frmQLChamCong : DevExpress.XtraEditors.XtraForm
    {
        public frmQLChamCong()
        {
            InitializeComponent();
        }
        DAL_QLChamCong cc = new DAL_QLChamCong();
        BLThongBao bltb = new BLThongBao();
        public string KT { get; set; }
        string a = DateTime.Now.ToString().Substring(0, 10);
        public void loaddata()
        {
            if (txtMaNV.Text == "")
                btnThem.Enabled = false;
            else
                btnThem.Enabled = true;
        }
        private void frmQLChamCong_Load(object sender, EventArgs e)
        {
            for (int i = 2017; i <= 2030; i++)
            {
                cbbNam.Properties.Items.Add(i);
            }
            for (int i = 1; i <= 12; i++)
            {
                cbbThang.Properties.Items.Add(i);
            }
            dtgvTTNV.DataSource = cc.LayNhanVien();
            dtgvTTCC.DataSource = cc.LayThongTinNgayLam();
            if (cbbCa.Text == "Tất Cả")
            {
                btnThem.Enabled = false;
            }
            btnXoa.Enabled = false;
        }

        private void cbbThang_TextChanged(object sender, EventArgs e)
        {
            try
            {

                dtgvTTCC.DataSource = cc.TimKiemCC(cbbThang.Text, cbbNam.Text, cbbCa.Text);
                if (cbbCa.Text == "Tất Cả" && cbbThang.Text == "Tất Cả" && cbbNam.Text == "Tất Cả")
                {
                    dtgvTTCC.DataSource = cc.LayThongTinNgayLam();
                }
            }
            catch
            {

            }
        }

        private void cbbNam_TextChanged(object sender, EventArgs e)
        {
            try
            {

                dtgvTTCC.DataSource = cc.TimKiemCC(cbbThang.Text, cbbNam.Text, cbbCa.Text);
                if (cbbCa.Text == "Tất Cả" && cbbThang.Text == "Tất Cả" && cbbNam.Text == "Tất Cả")
                {
                    dtgvTTCC.DataSource = cc.LayThongTinNgayLam();
                }
            }
            catch
            {

            }
        }

        private void cbbCa_TextChanged(object sender, EventArgs e)
        {
            try
            {

                dtgvTTCC.DataSource = cc.TimKiemCC(cbbThang.Text, cbbNam.Text, cbbCa.Text);
                if (cbbCa.Text == "Tất Cả" && cbbThang.Text == "Tất Cả" && cbbNam.Text == "Tất Cả")
                {
                    dtgvTTCC.DataSource = cc.LayThongTinNgayLam();
                }
            }
            catch
            {

            }
        }

        private void dtgvTTNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dtgvTTNV.CurrentCell.RowIndex;
                txtMaNV.Text = dtgvTTNV.Rows[r].Cells[0].Value.ToString();
                txtTenNV.Text = dtgvTTNV.Rows[r].Cells[1].Value.ToString();
                btnXoa.Enabled = false;
                cbbCaTCC.Enabled = true;
            }
            catch
            {

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                cc.ThemChamCong(txtMaNV.Text, a, cbbCaTCC.Text);
                bltb.Show("Đã thêm thành công " + txtTenNV.Text + ".Vào ngày " + a + " Ca " + cbbCaTCC.Text);
                dtgvTTCC.DataSource = cc.LayThongTinNgayLam();
                dtgvTTCC.DataSource = cc.TimKiemCC(cbbThang.Text, cbbNam.Text, cbbCa.Text);
                if (cbbCa.Text == "Tất Cả" && cbbThang.Text == "Tất Cả" && cbbNam.Text == "Tất Cả")
                {
                    dtgvTTCC.DataSource = cc.LayThongTinNgayLam();
                }
                btnThem.Enabled = false;
                cbbCaTCC.Enabled = false;
            }
            catch
            {
                bltb.Show("Không Thể Thêm Trùng");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int r = dtgvTTCC.CurrentCell.RowIndex;
            string manv = dtgvTTCC.Rows[r].Cells[0].Value.ToString();
            string Ngaylam = dtgvTTCC.Rows[r].Cells[2].Value.ToString();
            string ca = dtgvTTCC.Rows[r].Cells[3].Value.ToString();
            MessageBoxYesNo msgyn = new MessageBoxYesNo();
            msgyn.ThongBao = "Bạn Có Muốn Xóa Không?";
            msgyn.ShowDialog();
            msgyn.Hide();
            KT = msgyn.Check;
            if (KT == "Có")
            {
                try
                {
                    cc.XoaChamCong(manv, Ngaylam, ca);
                    dtgvTTCC.DataSource = cc.LayThongTinNgayLam();
                    bltb.Show("Xóa Thành Công");
                    dtgvTTCC.DataSource = cc.TimKiemCC(cbbThang.Text, cbbNam.Text, cbbCa.Text);
                    if (cbbCa.Text == "Tất Cả" && cbbThang.Text == "Tất Cả" && cbbNam.Text == "Tất Cả")
                    {
                        dtgvTTCC.DataSource = cc.LayThongTinNgayLam();
                    }
                    btnXoa.Enabled = false;
                }
                catch
                {
                    bltb.Show("Xóa Thất Bại");
                }
            }
        }

        private void txtMaNV_EditValueChanged(object sender, EventArgs e)
        {
            loaddata();
        }

        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtgvTTNV.DataSource = cc.TimKiemNV(txtTimKiem.Text);
            }
            catch
            {

            }
        }

        private void dtgvTTCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            cbbCaTCC.Enabled = false;
        }

        private void cbbCaTCC_TextChanged(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
        }
    }
}