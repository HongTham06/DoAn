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
    public partial class frmDatDichVu : DevExpress.XtraEditors.XtraForm
    {
        public frmDatDichVu()
        {
            InitializeComponent();
        }
        DAL_DatDichVu dvd = new DAL_DatDichVu();
        BLThongBao bltb = new BLThongBao();
        public string MaNV { get; set; }
        public string maphong { get; set; }
        public string MaP { get; set; }
        public string KT { get; set; }
        public void loaddt()
        {
            xtraTabDS.Enabled = false;
            btnXoaPhieu.Enabled = false;
            txtNgayTao.Enabled = true;
            txtHD.Enabled = true;
            txtSDT.ResetText();
            txtPhong.ResetText();
            txtHD.Text = dvd.LayMAHD();
            txtTenKH.ResetText();
            nmrSL.Value = 1;
            
            txtNgayTao.Text = DateTime.Now.ToString().Substring(0, 10);
            dtgvTTDat.DataSource = dvd.ThongTinBan(txtHD.Text);
        }

        private void frmDatDichVu_Load(object sender, EventArgs e)
        {
            nmrSL.Value = 1;
            if (MaP == "")
                txtHD.Text = dvd.LayMAHD();
            else
            {
                txtHD.Text = MaP;
                btnTaoPhieu.Enabled = false;
                xtraTabDS.Enabled = true;
                btnXuatHD.Enabled = true;
            }
            txtTenKH.Text = dvd.LayTenKH(maphong);
            txtSDT.Text = dvd.LaySDTKH(maphong);
            txtPhong.Text = dvd.LayTenPhong(maphong) + " " + dvd.LayTenTang(maphong);
            txtNgayTao.Text = DateTime.Now.ToString().Substring(0, 10);
            Image img = null;
            foreach (DataRow r in dvd.LayDICHVU().Rows)
            {
                if (r["HINHANH"].ToString() == @"HinhAnh\No Image" || r["HINHANH"] == DBNull.Value)
                {
                    img = Image.FromFile("Concung.png");
                }
                else
                {
                    img = Image.FromFile(r["HINHANH"].ToString());
                }
                dtgvTT.Rows.Add(r["MADV"].ToString(), r["TENDV"].ToString(), r["DONGIA"].ToString(), img);
            }
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            dvd.ThemPhieu(txtHD.Text, txtNgayTao.Text, MaNV, maphong);
            bltb.Show("Thêm Phiếu Thành Công");
            xtraTabDS.Enabled = true;
            btnXoaPhieu.Enabled = true;
            txtNgayTao.Enabled = false;
            txtHD.Enabled = false;
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            MessageBoxYesNo msgyn = new MessageBoxYesNo();
            msgyn.ThongBao = "Bạn Có Muốn Hủy Không?";
            msgyn.ShowDialog();
            msgyn.Hide();
            KT = msgyn.Check;
            if (KT == "Có")
            {
                try
                {
                    dvd.XoaPhieu(txtHD.Text);                   
                    bltb.Show("Hủy Thành Công");
                    this.Hide();
                }
                catch
                {
                    bltb.Show("Lỗi");
                }
            }
        }

        private void txtTimKiem_EditValueChanged(object sender, EventArgs e)
        {
            dtgvTT.Rows.Clear();
            Image img = null;
            foreach (DataRow r in dvd.TimKiemMenu(txtTimKiem.Text).Rows)
            {
                if (r["HINHANH"].ToString() == @"HinhAnh\No Image" || r["HINHANH"] == DBNull.Value)
                {
                    img = Image.FromFile("Concung.png");
                }
                else
                {
                    img = Image.FromFile(r["HINHANH"].ToString());
                }
                dtgvTT.Rows.Add(r["MADV"].ToString(), r["TENDV"].ToString(), r["DONGIA"].ToString(), img);
            }
        }

        private void dtgvTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lblTenMon.Text != "" || lblTenMon.Text != "Tên Dịch Vụ")
            {
                btnThemSanPham.Enabled = true;
                nmrSL.Enabled = true;
            }
            else
            {
                btnThemSanPham.Enabled = false;
                nmrSL.Enabled = false;
            }
            int r = dtgvTT.CurrentCell.RowIndex;
            lblTenMon.Text = dtgvTT.Rows[r].Cells[1].Value.ToString().Trim();
            if (dvd.LayHA(dtgvTT.Rows[r].Cells[0].Value.ToString()) == "No Image" || dvd.LayHA(dtgvTT.Rows[r].Cells[0].Value.ToString()) == null)
                pbHA.Image = Image.FromFile("Concung.png");
            else
                pbHA.Image = Image.FromFile(dvd.LayHA(dtgvTT.Rows[r].Cells[0].Value.ToString()));
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dtgvTT.CurrentCell.RowIndex;
                dvd.ThemCTPhieu(txtHD.Text, dtgvTT.Rows[r].Cells[0].Value.ToString(), int.Parse(nmrSL.Value.ToString()));
                dtgvTTDat.DataSource = dvd.ThongTinBan(txtHD.Text);
                btnXuatHD.Enabled = true;
                nmrSL.Value = 1;
            }
            catch
            {
                bltb.Show("Không Thể Thêm Trùng Sản Phẩm!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int r = dtgvTTDat.CurrentCell.RowIndex;
            dvd.XoaCTPhieu(txtHD.Text, dtgvTTDat.Rows[r].Cells[0].Value.ToString());
            dtgvTTDat.DataSource = dvd.ThongTinBan(txtHD.Text);
        }

        private void dtgvTTDat_Click(object sender, EventArgs e)
        {
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = true;
            int r = dtgvTTDat.CurrentCell.RowIndex;
            lblTenMonCN.Text = dtgvTTDat.Rows[r].Cells[1].Value.ToString();
            nmrSLCN.Value = int.Parse(dtgvTTDat.Rows[r].Cells[3].Value.ToString());
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int r = dtgvTTDat.CurrentCell.RowIndex;
            dvd.SuaCTPhieu(txtHD.Text, dtgvTTDat.Rows[r].Cells[0].Value.ToString(), int.Parse(nmrSLCN.Value.ToString()));
            dtgvTTDat.DataSource = dvd.ThongTinBan(txtHD.Text);
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            bltb.Show("Đặt Dịch Vụ Thành Công");
            this.Hide();
        }

        private void txtHD_EditValueChanged(object sender, EventArgs e)
        {
            dtgvTTDat.DataSource = dvd.ThongTinBan(txtHD.Text);
        }
    }
}