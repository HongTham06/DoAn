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
    public partial class frmFact : Form
    {
        public frmFact()
        {
            InitializeComponent();
        }
        GiuongBenhBO gbbo =new GiuongBenhBO();

        private GiuongBenh getDataGiuongBenh()
        {
            GiuongBenh gb = new GiuongBenh();

            return gb;
        }

        private void clearBind()
        {

        }
        private void bindData()
        {
            BindingSource binSourcegb = new BindingSource();
            binSourcegb.DataSource = gbbo.getDSGiuongBenh();
            clearBind();

            dgGiuongBenh.DataSource = binSourcegb;
        }



        private void frmQLGiuongBenh_Load(object sender, EventArgs e)
        {
            DataTable tablegb = new DataTable();
            tablegb = gbbo.getDSGiuongBenh();
            dgGiuongBenh.DataSource = tablegb;
        }
    }
}
