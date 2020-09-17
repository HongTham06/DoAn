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
using System.IO;
namespace QuanLyKhachSan
{
    public partial class frmQLDichVu : DevExpress.XtraEditors.XtraForm
    {
        public frmQLDichVu()
        {
            InitializeComponent();
        }
        bool Them = false;
        BLThongBao bltb = new BLThongBao();
        DAL_QLDichVu vd = new DAL_QLDichVu();
        public string MaMonDangChon { get; set; }
        public string KiemTra { get; set; }
        public void loaddata()
        {
            
            cbbLoaiSP.Properties.DataSource = vd.loadcbbLSP();
            cbbLoaiSP.Properties.DisplayMember = "TENLOAIDV";
            cbbLoaiSP.Properties.ValueMember = "MALOAIDV";
            grctrlTTThucDon.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

            this.txtMaSP.ResetText();
            this.txtTenSP.ResetText();
            this.txtDVT.ResetText();
            this.txtDonGiaNhap.ResetText();
            this.cbbLoaiSP.ResetText();
            this.txtLinkHA.ResetText();
            txtDonGiaNhap.EditValue = null;
            cbbLoaiSP.EditValue = null;
            dtgvTT.DataSource = vd.LayDICHVU();
        }

        private void frmQLDichVu_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            this.txtMaSP.ResetText();
            this.txtTenSP.ResetText();
            this.txtDVT.ResetText();
            this.txtDonGiaNhap.ResetText();
            this.cbbLoaiSP.ResetText();
            this.txtLinkHA.ResetText();
            txtDonGiaNhap.EditValue = null;
            cbbLoaiSP.EditValue = null;
            this.txtMaSP.Focus();

            this.grctrlTTThucDon.Enabled = true;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.txtMaSP.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;
            txtMaSP.Text = vd.LayMaSP();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxYesNo msgyn = new MessageBoxYesNo();
                msgyn.ThongBao = "Bạn Có Muốn Xóa " + txtTenSP.Text + " Không?";
                msgyn.ShowDialog();
                msgyn.Hide();
                KiemTra = msgyn.Check;
                if (KiemTra == "Có")
                {
                    vd.XoaSP(txtMaSP.Text);
                    loaddata();
                    bltb.Show("Đã Xóa Xong");
                }
                else
                {
                    bltb.Show("Không Xóa Được");
                }
            }
            catch
            {
                bltb.Show("Lỗi");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            this.txtMaSP.ResetText();
            this.txtTenSP.ResetText();
            this.txtDVT.ResetText();
            this.txtDonGiaNhap.ResetText();
            this.cbbLoaiSP.ResetText();
            this.txtLinkHA.ResetText();
            txtDonGiaNhap.EditValue = null;
            cbbLoaiSP.EditValue = null;
            this.txtTenSP.Focus();
            this.txtMaSP.Enabled = false;

            this.grctrlTTThucDon.Enabled = true;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string link = "HinhAnh\\" + Path.GetFileName(txtLinkHA.Text);
            if (Them)
            {
                try
                {
                    vd.ThemSP(txtMaSP.Text, txtTenSP.Text, txtDVT.Text, txtDonGiaNhap.EditValue.ToString(), cbbLoaiSP.EditValue.ToString(), link);
                    if (txtLinkHA.Text != "")
                    {
                        if (File.Exists(Environment.CurrentDirectory + "\\" + link) == false)
                        {
                            File.Copy(txtLinkHA.Text, Environment.CurrentDirectory + "\\" + link);
                        }
                    }
                    loaddata();
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
                    vd.SuaSP(txtMaSP.Text, txtTenSP.Text, txtDVT.Text, txtDonGiaNhap.EditValue.ToString(), cbbLoaiSP.EditValue.ToString(), link);
                    if (txtLinkHA.Text != "")
                    {
                        if (File.Exists(Environment.CurrentDirectory + "\\" + link) == false)
                        {
                            File.Copy(txtLinkHA.Text, Environment.CurrentDirectory + "\\" + link);
                        }
                    }
                    loaddata();
                    bltb.Show("Sửa Xong");
                }
                catch
                {
                    vd.SuaSP(txtMaSP.Text, txtTenSP.Text, txtDVT.Text, txtDonGiaNhap.EditValue.ToString(), cbbLoaiSP.EditValue.ToString(), @"HinhAnh\NhaTrangLuxury.png");
                    loaddata();
                    bltb.Show("Sửa Xong");
                }
            }
            this.dtgvTT.Enabled = true;
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btnDuyetHA_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtLinkHA.Text = openFileDialog1.FileName;
                pbHA.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            txtLinkHA.Text = "No Image";
            pbHA.Image = Image.FromFile("NhaTrangLuxury.png");
        }

        private void dtgvTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtDonGiaNhap.EditValue = "";
                int r = dtgvTT.CurrentCell.RowIndex;
                txtMaSP.Text = dtgvTT.Rows[r].Cells[0].Value.ToString();
                txtTenSP.Text = dtgvTT.Rows[r].Cells[1].Value.ToString();
                txtDVT.Text = dtgvTT.Rows[r].Cells[2].Value.ToString();
                txtDonGiaNhap.Text = dtgvTT.Rows[r].Cells[3].Value.ToString();
                cbbLoaiSP.Text = dtgvTT.Rows[r].Cells[4].Value.ToString();
                txtLinkHA.Text = vd.LayLinkHA(txtMaSP.Text);
                vd.LayHinhAnh(MaMonDangChon, pbHA);
            }
            catch
            {

            }
        }

        private void txtLinkHA_EditValueChanged(object sender, EventArgs e)
        {
            vd.LayHinhAnh3(txtLinkHA.Text, pbHA);         
        }
    }
}