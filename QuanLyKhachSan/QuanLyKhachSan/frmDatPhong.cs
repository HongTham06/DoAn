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
using DAL;
using QuanLyKhachSan.BSlayer;

namespace QuanLyKhachSan
{
    public partial class frmDatPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmDatPhong()
        {
            InitializeComponent();
        }
        DAL_PhieuDatPhong d = new DAL_PhieuDatPhong();
        public string maphong { get; set; }
        public string MaNV { get; set; }
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frmQLKhachHang qlncc = new frmQLKhachHang();
            qlncc.ShowDialog();
            qlncc.Hide();
            cbbKhachHang.Properties.DataSource = d.loadcbbKH();

            txtDiaChiKH.ResetText();
            txtSDT.ResetText();
            rdobtnNam.Checked = false;
            rdobtnNu.Checked = false;
        }

        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            txtTenPhong.Text = d.LayTenPhong(maphong);
            txtDienTich.Text = d.LayDienTich(maphong);
            txtDonGiaPhong.Text = d.LayGiaPhong(maphong);
            txtTang.Text = d.LayTang(maphong);

            cbbKhachHang.Properties.DataSource = d.loadcbbKH();
            cbbKhachHang.Properties.DisplayMember = "TENKH";
            cbbKhachHang.Properties.ValueMember = "MAKH";

            dtNgayTao.EditValue = DateTime.Now;
            dtNgayBD.EditValue = DateTime.Now;
            txtMaPD.Text = d.LayMaPD();
        }

        private void cbbKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            txtSDT.Text = d.LaySDTKH(cbbKhachHang.EditValue.ToString());
            txtDiaChiKH.Text = d.LayDCKH(cbbKhachHang.EditValue.ToString());
            if (d.LayGTKH(cbbKhachHang.EditValue.ToString()) == "Nam")
                rdobtnNam.Checked = true;
            else
                rdobtnNu.Checked = true;
        }

        private void txtSDT_EditValueChanged(object sender, EventArgs e)
        {
            cbbKhachHang.EditValue = d.LayMaKH(txtSDT.Text);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhanDK_Click(object sender, EventArgs e)
        {
            this.Hide();
            d.ThemPD(txtMaPD.Text, cbbKhachHang.EditValue.ToString(), MaNV, maphong, dtNgayTao.Text, dtNgayBD.Text);
            d.SuaTrangThaiP(maphong);
        }
    }
}