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
    public partial class frmQLThuoc : Form
    {
        public frmQLThuoc()
        {
            InitializeComponent();
        }
        ThuocBO thbo = new ThuocBO();
        private Thuoc getDataThuoc()
        {
            Thuoc th = new Thuoc();
            th.TenThuoc = txtTenThuoc.Text;
            th.DonGia = int.Parse(txtDonGia.Text);
            th.DVT = txtDVT.Text;
            return th;
        }
       
        private void clearBind()
        {
            txtTenThuoc.DataBindings.Clear();
            txtDVT.DataBindings.Clear();
            txtDonGia.DataBindings.Clear();
        }
        //BindingSource binSourceBH = new BindingSource();
        //binSourceBH.DataSource = bhytBO.getDSBHYT();
        //    clearBind();
        //txtSoThe.DataBindings.Add("Text", binSourceBH, "SoTheBH");
        //    txtTenChuThe.DataBindings.Add("Text", binSourceBH, "TenChuThe");
        //    dgBHYT.DataSource = binSourceBH;
        private void bindData()
        {
            BindingSource binSourceth = new BindingSource();
            binSourceth.DataSource = thbo.getDSThuoc();
            clearBind();
            txtTenThuoc.DataBindings.Add("Text",binSourceth,"TenThuoc");
            txtDonGia.DataBindings.Add("Text", binSourceth, "DonGia");
            txtDVT.DataBindings.Add("Text", binSourceth, "DVT");
            dgThuoc.DataSource = binSourceth;
        }

       
        private void frmQLThuoc_Load(object sender, EventArgs e)
        {
            DataTable tableth = new DataTable();
            tableth = thbo.getDSThuoc();
            dgThuoc.DataSource = tableth;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            txtTenThuoc.Text = "";
            txtDVT.Text = "";
            txtDonGia.Text = "";
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtTenThuoc.ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Thuoc th = getDataThuoc();
            if (MessageBox.Show("Bạn có chắc muốn xóa thuốc này?", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (thbo.XoaThuoc(th))
                    MessageBox.Show("Xóa thành công");
                else
                    MessageBox.Show("Không thể xóa");
            }
            bindData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void dgThuoc_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowSelect = e.RowIndex;
            txtTenThuoc.Text = dgThuoc.Rows[rowSelect].Cells[0].Value.ToString();
            txtDVT.Text = dgThuoc.Rows[rowSelect].Cells[1].Value.ToString();
            txtDonGia.Text = dgThuoc.Rows[rowSelect].Cells[2].Value.ToString();
        }
    }
}
