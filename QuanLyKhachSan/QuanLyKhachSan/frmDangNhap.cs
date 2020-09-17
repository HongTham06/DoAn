using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachSan.BSlayer;
using DAL;
namespace QuanLyKhachSan
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
            this.AcceptButton = btnDangNhap;
        }
        public string MaNVDangChon { get; set; }
        public string TenNVDangChon { get; set; }
        public string QuyenNVDangChon { get; set; }
        public string TenTK { get; set; }
        public string KT { get; set; }
        BLThongBao bltb = new BLThongBao();
        DAL_DangNhap dn = new DAL_DangNhap();

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (dn.LayTaiKhoan(txtTenDN.TextName, txtMatKhau.TextName) == 1 && dn.LayTrangThai(txtTenDN.TextName, txtMatKhau.TextName) == "Hoạt Động")
                {
                    TenNVDangChon = dn.LayTenNV(txtTenDN.TextName, txtMatKhau.TextName);
                    MaNVDangChon = dn.LayMaNV(txtTenDN.TextName, txtMatKhau.TextName);
                    TenTK = txtTenDN.TextName;
                    bltb.Show("Thành Công!");
                    frmTrangChu h = new frmTrangChu();
                    h.MaNVDangChon = MaNVDangChon;
                    h.TenNV = TenNVDangChon;
                    h.TenDN = TenTK;
                    h.ShowDialog();
                    this.Hide();
                }
                else if (dn.LayTaiKhoan(txtTenDN.TextName, txtMatKhau.TextName) == 1 && dn.LayTrangThai(txtTenDN.TextName, txtMatKhau.TextName) == "Khóa")
                {
                    bltb.Show("Tài Khoản Đã Bị Khóa!");
                }
                else
                    bltb.Show("Sai Tên Đăng Nhập Hoặc Mật Khẩu!");
            }
            catch
            {

            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            MessageBoxYesNo msgyn = new MessageBoxYesNo();
            msgyn.ThongBao = "Bạn Có Muốn Thoát Không?";
            msgyn.ShowDialog();
            msgyn.Hide();
            KT = msgyn.Check;
            if (KT == "Có")
            {
                this.Close();
                Application.Exit();
            }
        }
    }
}
