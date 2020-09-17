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
    public partial class frmQLTTBHYT : Form
    {
        public frmQLTTBHYT()
        {
            InitializeComponent();
        }
        BHYTBO bhytBO = new BHYTBO();
       

        

        private void dgBHYT_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowSelect = e.RowIndex;
            txtSoThe.Text = dgBHYT.Rows[rowSelect].Cells[0].Value.ToString();
            txtTenChuThe.Text = dgBHYT.Rows[rowSelect].Cells[1].Value.ToString();
        }
        private BHYT getDataBHYT()
        {
            BHYT bh = new BHYT();
            bh.SoTheBH = txtSoThe.Text;
            bh.TenChuThe = txtTenChuThe.Text;
            return bh;
        }

        private void clearBind()
        {
            txtSoThe.DataBindings.Clear();
            txtTenChuThe.DataBindings.Clear();
        }
        private void bindData()
        {
            BindingSource binSourceBH = new BindingSource();
            binSourceBH.DataSource = bhytBO.getDSBHYT();
            clearBind();
            txtSoThe.DataBindings.Add("Text", binSourceBH, "SoTheBH");
            txtTenChuThe.DataBindings.Add("Text", binSourceBH, "TenChuThe");
            dgBHYT.DataSource = binSourceBH;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoThe.ReadOnly == true)
                txtTenChuThe.ReadOnly = false;
            txtSoThe.Text = "";
            txtTenChuThe.Text = "";
            btnSua.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           txtSoThe.ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            BHYT bh = getDataBHYT();
            if (MessageBox.Show("Bạn có chắc muốn xóa thẻ bảo hiểm này?", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (bhytBO.XoaBHYT(bh))
                    MessageBox.Show("Xóa thành công");
                else
                    MessageBox.Show("Không thể xóa");
            }
            bindData();
        }
        
        private void frmQLTTBHYT_Load(object sender, EventArgs e)
        {

            DataTable tablebhyt = new DataTable();
            tablebhyt = bhytBO.getDSBHYT();
            dgBHYT.DataSource = tablebhyt;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            BHYT bh = getDataBHYT();
            if (txtSoThe.Text == "" || txtTenChuThe.Text == "")
                MessageBox.Show("Bạn cần nhập đủ thông tin");
            else
            {
                if (btnSua.Enabled == false)
                {
                    if (bhytBO.kiemTraBHYT(txtSoThe.Text) == false)
                    {
                        if (bhytBO.ThemBHYT(bh))
                            MessageBox.Show("Thêm thành công");
                        else
                            MessageBox.Show("Lỗi nhập dữ liệu");
                    }
                    else
                        MessageBox.Show("Đã có bảo hiểm " + txtSoThe.Text + " trong hệ thống");
                }
                else
                {
                    if (bhytBO.SuaBHYT(bh))
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
