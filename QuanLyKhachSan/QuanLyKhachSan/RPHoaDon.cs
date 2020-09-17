using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QuanLyKhachSan
{
    public partial class RPHoaDon : DevExpress.XtraReports.UI.XtraReport
    {
        public RPHoaDon()
        {
            InitializeComponent();
        }
        public string TenKhachHang { get; set; }
        public string TongTienDV { get; set; }
        public string MaHD { get; set; }
        public string TenNV { get; set; }
        public string GiaPhong { get; set; }
        public string SoNgay { get; set; }
        public string TienPhong { get; set; }
        public string TienNhan { get; set; }
        public string TienThua { get; set; }
        public string TongTien { get; set; }
        public string TienBangChu { get; set; }
        private void RPHoaDon_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblMaHD.Text = MaHD;
            lblTongTienDV.Text = TongTienDV;
            lblTenNV.Text = TenNV;
            lblTenKH.Text = TenKhachHang;
            lblGiaPhong.Text = GiaPhong;
            lblSoNgayO.Text = SoNgay;
            lblTienThuePhong.Text = TienPhong;
            lblTienNhan.Text = TienNhan;
            lblTienTraLai.Text = TienThua;
            lblTongTienHD.Text = TongTien;
            lblBangChu.Text = TienBangChu;
        }
    }
}
