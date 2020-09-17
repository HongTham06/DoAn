using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.Skins;
using DevExpress.UserSkins;
using QuanLyKhachSan.BSlayer;
using DAL;

namespace QuanLyKhachSan
{
    public partial class frmTrangChu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmTrangChu()
        {
            InitializeComponent();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(skinRibbonGalleryBarItem2, true, true);
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Summer 2008");
        }
        DAL_QLTaiKhoan q = new DAL_QLTaiKhoan();
        BLThongBao bltb = new BLThongBao();
        public string TenDN { get; set; }
        public string MaNVDangChon { get; set; }
        public string KT { get; set; }
        public string TenNV { get; set; }

        public string mp { get; set; }
        public void DongTatCaCacTab()
        {
            dockChucNang.Close();
            for (int i = xtraTabbedMdiManager1.Pages.Count - 1; i >= 0; i--)
            {
                xtraTabbedMdiManager1.Pages[i].MdiChild.Close();
            }
        }
        public void loaddata()
        {
            DongTatCaCacTab();
            frmXemThongTinPhong qlnv = new frmXemThongTinPhong();
            qlnv.manv = MaNVDangChon;
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            lblTenNV.Caption = TenNV;

            for (int i = 0; i <= q.LayQ(TenDN).Rows.Count - 1; i++)
            {
                if (q.LayQ(TenDN).Rows[i]["QUYEN"].ToString() == "Q001")
                {
                    btnQ2.Visible = true;                    
                }
                if (q.LayQ(TenDN).Rows[i]["QUYEN"].ToString() == "Q002")
                {
                    btnQ1.Visible = true;
                    loaddata();
                }
                if (q.LayQ(TenDN).Rows[i]["QUYEN"].ToString() == "Q003")
                {
                    btnQ3.Visible = true;                        
                }
            }
        }

        private void frmTrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmDangNhap dn = new frmDangNhap();
            dn.Show();
        }

        private void btnTrangChu_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            frmXemThongTinPhong qlnv = new frmXemThongTinPhong();
            qlnv.manv = MaNVDangChon;
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void btnQLKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            frmQLKhachHang qlnv = new frmQLKhachHang();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void btnQLNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            frmQLNhanVien qlnv = new frmQLNhanVien();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void btnQLTaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            frmQLTaiKhoan qlnv = new frmQLTaiKhoan();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void btnQLChamCong_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            frmQLChamCong qlnv = new frmQLChamCong();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void btnQLDichVu_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            frmQLDichVu qlnv = new frmQLDichVu();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void btnQLLoaiDV_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            frmQLLoaiDichVu qlnv = new frmQLLoaiDichVu();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void btnQLPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            DongTatCaCacTab();
            frmQLPhong qlnv = new frmQLPhong();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void btnTinhLuong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTinhLuong qlnv = new frmTinhLuong();
            qlnv.ShowDialog();
        }

        private void btnThongKe_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDoanhThu qlnv = new frmDoanhThu();
            qlnv.ShowDialog();
        }

        private void btnMoCN_ItemClick(object sender, ItemClickEventArgs e)
        {
            dockChucNang.Show();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau qlnv = new frmDoiMatKhau();
            qlnv.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            MessageBoxYesNo msgyn = new MessageBoxYesNo();
            msgyn.ThongBao = "Bạn Có Muốn Đăng Xuất Không?";
            msgyn.ShowDialog();
            msgyn.Hide();
            KT = msgyn.Check;
            if (KT == "Có")
            {
                this.Close();
            }
        }
    }
}