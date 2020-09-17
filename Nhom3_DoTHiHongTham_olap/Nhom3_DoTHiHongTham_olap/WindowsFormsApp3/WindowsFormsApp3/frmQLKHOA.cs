using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.GetData;
using WindowsFormsApp3.Class;

namespace WindowsFormsApp3
{
    public partial class frmQLKHOA : Form
    {
        public frmQLKHOA()
        {
            InitializeComponent();
        }
        KhoaBO khbo = new KhoaBO();

        private void dgKhoa_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowSelect = e.RowIndex;
            txtMaKhoa.Text = dgKhoa.Rows[rowSelect].Cells[0].Value.ToString();
            txtTenKhoa.Text = dgKhoa.Rows[rowSelect].Cells[1].Value.ToString();
        }
        private Khoa getDataKhoa()
        {
            Khoa kh = new Khoa();
            kh.MaKhoa = txtMaKhoa.Text;
            kh.TenKhoa = txtTenKhoa.Text;
            return kh;
        }

        private void clearBind()
        {
            txtMaKhoa.DataBindings.Clear();
            txtTenKhoa.DataBindings.Clear();
        }
        private void bindData()
        {
            BindingSource binSourcekh = new BindingSource();
            binSourcekh.DataSource = khbo.getDSKhoa();
            clearBind();
            txtMaKhoa.DataBindings.Add("Text", binSourcekh, "MaKhoa");
            txtTenKhoa.DataBindings.Add("Text", binSourcekh, "TenKhoa");
            dgKhoa.DataSource = binSourcekh;
        }

        private void frmQLKHOA_Load(object sender, EventArgs e)
        {
            DataTable tableKh = new DataTable();
            tableKh = khbo.getDSKhoa();
            dgKhoa.DataSource = tableKh;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaKhoa.ReadOnly == true)
                txtTenKhoa.ReadOnly = false;
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaKhoa.ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Khoa kh = getDataKhoa();
            if (MessageBox.Show("Bạn có chắc muốn xóa khoa này?", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (khbo.XoaKhoa(kh))
                    MessageBox.Show("Xóa thành công");
                else
                    MessageBox.Show("Không thể xóa");
            }
            bindData();
           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Khoa kh = getDataKhoa();
           
            if (txtMaKhoa.Text == "" || txtTenKhoa.Text == "")
                MessageBox.Show("Bạn cần nhập đủ thông tin");
            else
            {
                if (btnSua.Enabled == false)
                {
                    //if (khbo.kiemTraKhoa(txtMaKhoa.Text) == false)
                    //{
                    //    if (khbo.ThemKhoa(kh))
                    //        MessageBox.Show("Thêm thành công");
                    //    else
                    //        MessageBox.Show("Lỗi nhập dữ liệu");
                    //}
                    //else
                        MessageBox.Show("Đã có khoa " + txtTenKhoa.Text + " trong hệ thống");
                }
                else
                {
                    if (khbo.SuaKhoa(kh))
                        MessageBox.Show("Sửa thành công");
                    else
                        MessageBox.Show("Không thể sửa thông tin");
                }
            }
            bindData();
            btnSua.Enabled = true;
        }
    }
}
