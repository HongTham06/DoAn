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
    public partial class frmQLPhieuKham : Form
    {
        public frmQLPhieuKham()
        {
            InitializeComponent();
        }
        PhieuKhamBO pkbo = new PhieuKhamBO();
        private PhieuKham getDataPhieuKham()
        {
            PhieuKham pk = new PhieuKham();

            return pk;
        }

        private void clearBind()
        {

        }
        private void bindData()
        {
            BindingSource binSourcepk = new BindingSource();
            binSourcepk.DataSource = pkbo.getDSPhieuKham();
            clearBind();

            dgPhieuKham.DataSource = binSourcepk;
        }
        private void frmQLPhieuKham_Load(object sender, EventArgs e)
        {
            DataTable tablepk = new DataTable();
            tablepk = pkbo.getDSPhieuKham();
            dgPhieuKham.DataSource = tablepk;
        }
    }
}
