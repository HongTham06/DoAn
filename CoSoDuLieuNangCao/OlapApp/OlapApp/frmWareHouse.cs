using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace OlapApp
{
    public partial class frmWareHouse : Form
    {
        LoadDL db = new LoadDL();
        KetNoi k = new KetNoi();
        public frmWareHouse()
        {
            InitializeComponent();


        }
        
        private void btnCD_Click(object sender, EventArgs e)
        {
            try
            {
                var cmd = new SqlCommand("load_CD", KetNoi.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var dap = new SqlDataAdapter(cmd);
                var tb = new DataTable();
                dap.Fill(tb);
                dgvWH.DataSource = tb;
                dgvWH.DataSource = db.Load_CD();
                frmWareHouse_Load(sender, e);
                MessageBox.Show("Nạp dữ liệu thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //btnCD.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }



        private void frmWareHouse_Load(object sender, EventArgs e)
        {

        }

        private void btnNXB_Click(object sender, EventArgs e)
        {
            try
            {
                var cmd = new SqlCommand("load_NXB", KetNoi.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var dap = new SqlDataAdapter(cmd);
                var tb = new DataTable();
                dap.Fill(tb);
                dgvWH.DataSource = tb;
                dgvWH.DataSource = db.Load_NXB();
                frmWareHouse_Load(sender, e);

                MessageBox.Show("Nạp dữ liệu thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //btnNXB.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            try
            {
                var cmd = new SqlCommand("load_S", KetNoi.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var dap = new SqlDataAdapter(cmd);
                var tb = new DataTable();
                dap.Fill(tb);
                dgvWH.DataSource = tb;
                dgvWH.DataSource = db.Load_S();
                frmWareHouse_Load(sender, e);

                MessageBox.Show("Nạp dữ liệu thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSach.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnChiNhanh_Click(object sender, EventArgs e)
        {
            try
            {
                var cmd = new SqlCommand("load_CN", KetNoi.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var dap = new SqlDataAdapter(cmd);
                var tb = new DataTable();
                dap.Fill(tb);
                dgvWH.DataSource = tb;
                dgvWH.DataSource = db.Load_CN();
                frmWareHouse_Load(sender, e);

                MessageBox.Show("Nạp dữ liệu thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnChiNhanh.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                var cmd = new SqlCommand("load_NV", KetNoi.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var dap = new SqlDataAdapter(cmd);
                var tb = new DataTable();
                dap.Fill(tb);
                dgvWH.DataSource = tb;
                dgvWH.DataSource = db.Load_NV();
                frmWareHouse_Load(sender, e);

                MessageBox.Show("Nạp dữ liệu thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNhanVien.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

       
        private void btnKH_Click(object sender, EventArgs e)
        {
            try
            {
                var cmd = new SqlCommand("load_KH", KetNoi.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var dap = new SqlDataAdapter(cmd);
                var tb = new DataTable();
                dap.Fill(tb);
                dgvWH.DataSource = tb;
                dgvWH.DataSource = db.Load_KH();
                frmWareHouse_Load(sender, e);

                MessageBox.Show("Nạp dữ liệu thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnKH.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void btnFact_Click(object sender, EventArgs e)
        {
            try
            {
                var cmd = new SqlCommand("load_FACT", KetNoi.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var dap = new SqlDataAdapter(cmd);
                var tb = new DataTable();
                dap.Fill(tb);
                dgvWH.DataSource = tb;
                dgvWH.DataSource = db.Load_F();
                frmWareHouse_Load(sender, e);

                MessageBox.Show("Nạp dữ liệu thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnFact.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnTime_Click(object sender, EventArgs e)
        {
            try
            {
                var cmd = new SqlCommand("autoTime", KetNoi.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var dap = new SqlDataAdapter(cmd);
                var tb = new DataTable();
                dap.Fill(tb);
                dgvWH.DataSource = tb;
                dgvWH.DataSource = db.Load_Time();
                frmWareHouse_Load(sender, e);

                MessageBox.Show("Nạp dữ liệu thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnTime.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnNap_Click(object sender, EventArgs e)
        {
            try
            {
                btnTime.Enabled = true;
                btnSach.Enabled = true;
                btnCD.Enabled = true;
                btnNXB.Enabled = true;
                btnNhanVien.Enabled = true;
                btnChiNhanh.Enabled = true;
                btnFact.Enabled = true;
                btnKH.Enabled = true;
                var cmd = new SqlCommand("delete_All", KetNoi.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var dap = new SqlDataAdapter(cmd);
                var tb = new DataTable();
                dap.Fill(tb);
                //frmWareHouse_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
          
    }
}
