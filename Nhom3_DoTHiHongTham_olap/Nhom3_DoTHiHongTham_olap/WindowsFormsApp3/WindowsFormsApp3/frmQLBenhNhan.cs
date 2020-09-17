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
    public partial class frmQLBenhNhan : Form
    {
        public frmQLBenhNhan()
        {
            InitializeComponent();
        }
        BenhNhanBo bnbo = new BenhNhanBo();
        private BenhNhan getDataBenhNhan()
        {
            BenhNhan bn = new BenhNhan();
            
            return bn;
        }

        private void clearBind()
        {
           
        }
        private void bindData()
        {
            BindingSource binSourceBN = new BindingSource();
            binSourceBN.DataSource = bnbo.getDSBenhNhan();
            clearBind();
           
            dgBenhNhan.DataSource = binSourceBN;
        }

        private void frmQLBenhNhan_Load(object sender, EventArgs e)
        {
            DataTable tablebn = new DataTable();
            tablebn = bnbo.getDSBenhNhan();
            dgBenhNhan.DataSource = tablebn;
        }
    }
}
