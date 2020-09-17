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
    public partial class frmQLCTHD : Form
    {
        public frmQLCTHD()
        {
            InitializeComponent();
        }
        CTHDBO cthdbo = new CTHDBO();
        private CTHD getDataCTHD()
        {
            CTHD ct = new CTHD();

            return ct;
        }

        private void clearBind()
        {

        }
        private void bindData()
        {
            BindingSource binSourcect = new BindingSource();
            binSourcect.DataSource = cthdbo.getDSCTHD();
            clearBind();

            dgCTHD.DataSource = binSourcect;
        }

        private void frmQLCTHD_Load(object sender, EventArgs e)
        {
            DataTable tablect = new DataTable();
            tablect = cthdbo.getDSCTHD();
            dgCTHD.DataSource = tablect;
        }
    }
}
