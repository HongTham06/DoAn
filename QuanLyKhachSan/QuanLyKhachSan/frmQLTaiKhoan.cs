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
    public partial class frmQLTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public frmQLTaiKhoan()
        {
            InitializeComponent();
        }
        DAL_QLTaiKhoan tk = new DAL_QLTaiKhoan();
        BLThongBao bltb = new BLThongBao();
        public string KT { get; set; }
        bool Them = false;
        public void loaddt()
        {
            grctrlTT.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            Q001.Checked = false;
            Q002.Checked = false;
            Q003.Checked = false;
            this.cbbTrangThai.ResetText();
            this.txtTenDN.ResetText();
            this.cbbTenNV.ResetText();
            this.txtMatKhau.ResetText();
            cbbTenNV.EditValue = null;
            dtgvTT.DataSource = tk.LayThongTin();
        }
        private void frmQLTaiKhoan_Load(object sender, EventArgs e)
        {
            cbbTenNV.Properties.DataSource = tk.LoadDT();
            cbbTenNV.Properties.DisplayMember = "HOTEN";
            cbbTenNV.Properties.ValueMember = "MANV";
            loaddt();
        }

        private void dtgvTT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Q001.Checked = false;
                Q002.Checked = false;
                Q003.Checked = false;
                int r = dtgvTT.CurrentCell.RowIndex;
                cbbTenNV.Text = dtgvTT.Rows[r].Cells[1].Value.ToString();
                txtTenDN.Text = dtgvTT.Rows[r].Cells[2].Value.ToString();
                txtMatKhau.Text = tk.LayMK(txtTenDN.Text);
                cbbTrangThai.Text = dtgvTT.Rows[r].Cells[3].Value.ToString();
                for (int i = 0; i <= tk.LayQ(txtTenDN.Text).Rows.Count - 1; i++)
                {
                    if (tk.LayQ(txtTenDN.Text).Rows[i]["QUYEN"].ToString() == "Q001")
                    {
                        Q001.Checked = true;
                    }
                    if (tk.LayQ(txtTenDN.Text).Rows[i]["QUYEN"].ToString() == "Q002")
                    {
                        Q002.Checked = true;
                    }
                    if (tk.LayQ(txtTenDN.Text).Rows[i]["QUYEN"].ToString() == "Q003")
                    {
                        Q003.Checked = true;
                    }
                }
            }
            catch
            {

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            grctrlTT.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

            this.txtMatKhau.Enabled = true;
            this.txtTenDN.Enabled = true;
            this.cbbTrangThai.Enabled = true;

            this.txtMatKhau.ResetText();
            this.cbbTrangThai.ResetText();
            this.txtTenDN.ResetText();
            cbbTenNV.ResetText();
            Q001.Checked = false;
            Q002.Checked = false;
            Q003.Checked = false;
            this.cbbTenNV.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBoxYesNo msgyn = new MessageBoxYesNo();
            msgyn.ThongBao = "Bạn Có Muốn Thoát Không?";
            msgyn.ShowDialog();
            msgyn.Hide();
            KT = msgyn.Check;
            if (KT == "Có")
            {
                try
                {
                    tk.XoaTK(txtTenDN.Text);
                    loaddt();
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
            Them = false;

            grctrlTT.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            Q001.Checked = false;
            Q002.Checked = false;
            Q003.Checked = false;
            this.txtTenDN.Enabled = false;

            this.txtMatKhau.Enabled = true;
            this.cbbTrangThai.Enabled = true;

            this.txtMatKhau.ResetText();
            this.cbbTrangThai.ResetText();
            this.txtTenDN.ResetText();
            this.cbbTenNV.ResetText();
            cbbTenNV.EditValue = null;
            this.cbbTenNV.Enabled = false;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loaddt();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    tk.ThemTK(cbbTenNV.EditValue.ToString(), txtTenDN.Text, tk.MaHoa(txtMatKhau.Text), cbbTrangThai.Text);
                    if (Q001.Checked)
                    {
                        tk.ThemQTK(txtTenDN.Text, Q001.Name.ToString(), "Không Có");
                    }
                    if (Q002.Checked)
                    {
                        tk.ThemQTK(txtTenDN.Text, Q002.Name.ToString(), "Không Có");
                    }
                    if (Q003.Checked)
                    {
                        tk.ThemQTK(txtTenDN.Text, Q003.Name.ToString(), "Không Có");
                    }
                    loaddt();
                    bltb.Show("Thêm Xong");
                }
                catch
                {
                    bltb.Show("Lỗi");
                }

            }
            else
            {
                if (txtMatKhau.Text == tk.LayMK(txtTenDN.Text))
                {
                    try
                    {
                        string a = tk.LayMK(txtTenDN.Text);
                        tk.XoaTK(txtTenDN.Text);
                        tk.ThemTK(cbbTenNV.EditValue.ToString(), txtTenDN.Text, a, cbbTrangThai.Text);
                        if (Q001.Checked)
                        {
                            tk.ThemQTK(txtTenDN.Text, Q001.Name.ToString(), "Không Có");
                        }
                        if (Q002.Checked)
                        {
                            tk.ThemQTK(txtTenDN.Text, Q002.Name.ToString(), "Không Có");
                        }
                        if (Q003.Checked)
                        {
                            tk.ThemQTK(txtTenDN.Text, Q003.Name.ToString(), "Không Có");
                        }
                        tk.SuaTK2(cbbTenNV.EditValue.ToString(), txtTenDN.Text, cbbTrangThai.Text);
                        loaddt();
                        bltb.Show("Sửa Xong");
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
                        tk.XoaTK(txtTenDN.Text);
                        tk.ThemTK(cbbTenNV.EditValue.ToString(), txtTenDN.Text, tk.MaHoa(txtMatKhau.Text), cbbTrangThai.Text);
                        if (Q001.Checked)
                        {
                            tk.ThemQTK(txtTenDN.Text, Q001.Name.ToString(), "Không Có");
                        }
                        if (Q002.Checked)
                        {
                            tk.ThemQTK(txtTenDN.Text, Q002.Name.ToString(), "Không Có");
                        }
                        if (Q003.Checked)
                        {
                            tk.ThemQTK(txtTenDN.Text, Q003.Name.ToString(), "Không Có");
                        }
                        tk.SuaTK(cbbTenNV.EditValue.ToString(), txtTenDN.Text, tk.MaHoa(txtMatKhau.Text), cbbTrangThai.Text);
                        loaddt();
                        bltb.Show("Sửa Xong");
                    }
                    catch
                    {
                        bltb.Show("Lỗi");
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            loaddt();
        }

        private void txtMatKhau_EditValueChanged(object sender, EventArgs e)
        {
            this.txtMatKhau.Properties.PasswordChar = '•';
        }

        private void cbbTenNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (cbbTenNV.SelectionLength == cbbTenNV.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                cbbTenNV.EditValue = null;
                e.Handled = true;
            }
        }
    }
}