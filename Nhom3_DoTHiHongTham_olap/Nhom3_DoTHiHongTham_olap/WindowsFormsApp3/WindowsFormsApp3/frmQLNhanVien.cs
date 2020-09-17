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
    public partial class frmQLNhanVien : Form
    {
        public frmQLNhanVien()
        {
            InitializeComponent();
        }
        NhanVienBO nvbo = new NhanVienBO();
        private NhanVien getDataNhanVien()
        {
            NhanVien nv = new NhanVien();

            return nv;
        }

        private void clearBind()
        {

        }
        private void bindData()
        {
            BindingSource binSourcenv = new BindingSource();
            binSourcenv.DataSource = nvbo.getDSNhanVien();
            clearBind();

            dgNV.DataSource = binSourcenv;
        }
        
        private void frmQLNhanVien_Load(object sender, EventArgs e)
        {
            DataTable tablenv= new DataTable();
            tablenv = nvbo.getDSNhanVien();
            dgNV.DataSource = tablenv;
        }
    }
}
