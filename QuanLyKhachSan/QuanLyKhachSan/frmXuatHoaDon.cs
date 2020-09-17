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
using System.Globalization;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using DAL;

namespace QuanLyKhachSan
{
    public partial class frmXuatHoaDon : DevExpress.XtraEditors.XtraForm
    {
        public frmXuatHoaDon()
        {
            InitializeComponent();
        }
        public string MaPhieu { get; set; }
        public string MaPhong { get; set; }
        DAL_XuatHD hd = new DAL_XuatHD();
        private void frmXuatHoaDon_Load(object sender, EventArgs e)
        {
            lblTenKH.Text = "Tên KH: " + hd.LayTenKH(MaPhong);
            lblTenPhong.Text = "Tên Phòng: " + hd.LayTenPhong(MaPhong) + " " + hd.LayTenTang(MaPhong);
            lblTongTien.Text = "Tổng Tiền: " + string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", hd.TongTienDV(MaPhieu) + hd.TongTienPhong(MaPhong));
        }
        public double TienThoi()
        {
            try
            {
                double t = int.Parse(txtTienKhachGui.EditValue.ToString()) - (hd.TongTienDV(MaPhieu) + hd.TongTienPhong(MaPhong));
                return t;
            }
            catch
            {

            }
            return 0;
        }

        private void txtTienKhachGui_EditValueChanged(object sender, EventArgs e)
        {
            if (TienThoi() < 0)
                btnXuat.Enabled = false;
            else
                btnXuat.Enabled = true;
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            string st = "Data Source=DESKTOP-9SFBHE9; Initial Catalog=QLKhachSan; Integrated Security=True";
            SqlConnection sql = new SqlConnection(st);
            sql.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM RPHoaDon WHERE MAHD = '"+MaPhieu+"'", sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sql.Close();
            RPHoaDon rp = new RPHoaDon();
            rp.DataSource = dt;
            rp.DataMember = "RPHoaDon";
            rp.MaHD = MaPhieu;
            rp.TenNV = hd.LayTenNV(MaPhieu);
            rp.TienPhong = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", hd.TongTienPhong(MaPhong));
            rp.SoNgay = hd.LayNgay(MaPhong)+ " Ngày";
            rp.GiaPhong = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", int.Parse(hd.LayGiaPhong(MaPhong))) +"/Ngày";
            rp.TenKhachHang = hd.LayTenKH(MaPhong);
            rp.TongTienDV = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", hd.TongTienDV(MaPhieu));
            rp.TienNhan = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", int.Parse(txtTienKhachGui.EditValue.ToString()));
            rp.TienThua = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", TienThoi());
            rp.TongTien = string.Format(new CultureInfo("vi-VN"), "{0:#,##0} VNĐ", hd.TongTienDV(MaPhieu) + hd.TongTienPhong(MaPhong));
            rp.TienBangChu = hd.So_chu(hd.TongTienDV(MaPhieu) + hd.TongTienPhong(MaPhong));
            hd.SuaTTHoaDon(MaPhieu, hd.TongTienDV(MaPhieu) + hd.TongTienPhong(MaPhong));
            hd.SuaNgayKetThuc(hd.LayMaPhieuDat(MaPhong), DateTime.Now.ToString().Substring(0, 10));// cap nhat tong tien cho hoa don.
            hd.SuaTrangThaiPhong(MaPhong);
            rp.ShowPreview();            
            this.Hide();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }    
}