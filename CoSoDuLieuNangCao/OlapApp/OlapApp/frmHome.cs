using Dashboard_OlapDataProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OlapApp
{
    public partial class frmHome : Form
    {

        public frmHome()
        {
            InitializeComponent();
            hideSubMenu();

        }
        private void hideSubMenu()
        {
            panQuanLy.Visible = false;

            panThongKe.Visible = false;

        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private Form activeForm = null;
        void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildform.Controls.Add(childForm);
            panelChildform.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TrungGiang m = new TrungGiang();
            TaiKhoan.Text = m.layTen();
            Nhom.Text = m.layTen2();

        }
        private void btnQuanLyDM_Click(object sender, EventArgs e)
        {
            if (KetNoi.mGroup == "CongTy")
            {
                MessageBox.Show("Chỉ nhân viên được thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                showSubMenu(panQuanLy);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {

            if (KetNoi.mGroup == "CongTy")
            {
                MessageBox.Show("Chỉ Quản lý được thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                showSubMenu(panThongKe);
            }

        }

        private void btnCD_Click(object sender, EventArgs e)
        {

            if (KetNoi.mGroup == "CongTy")
            {
                MessageBox.Show("Chỉ nhân viên được thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                openChildForm(new frmChuDe());
            }
        }

        private void btnNXBan_Click(object sender, EventArgs e)
        {

            if (KetNoi.mGroup == "CongTy")
            {
                MessageBox.Show("Chỉ nhân viên được thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                openChildForm(new frmNXB());
            }
        }

        private void btnSach_Click(object sender, EventArgs e)
        {

            if (KetNoi.mGroup == "CongTy")
            {
                MessageBox.Show("Chỉ nhân viên được thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                openChildForm(new frmSach());
            }
        }

        private void btnTK1_Click(object sender, EventArgs e)
        {
            openChildForm(new frmDonHang());

        }

        private void btnTK2_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCTDH());

        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {

            if (KetNoi.mGroup == "NhanVien")
            {
                MessageBox.Show("Chỉ Quản lý được thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                openChildForm(new frmWareHouse());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhanVien());

        }

        private void btnChiNhanh_Click(object sender, EventArgs e)
        {
            openChildForm(new frmChiNhanh());
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            openChildForm(new frmKH());
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (KetNoi.mGroup == "NhanVien")
            {
                MessageBox.Show("Chỉ Quản lý được thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                openChildForm(new Form1());

            }

        }
    }
}
