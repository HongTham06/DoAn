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
    public partial class frmQLHoaDon : Form
    {
        public frmQLHoaDon()
        {
            InitializeComponent();
        }
        HoaDonBO hdbo = new HoaDonBO();
        private HoaDon getDataHoaDon()
        {
            HoaDon hd = new HoaDon();

            return hd;
        }

        private void clearBind()
        {

        }
        private void bindData()
        {
            BindingSource binSourcehd = new BindingSource();
            binSourcehd.DataSource = hdbo.getDSHoaDon();
            clearBind();

            dgHoaDon.DataSource = binSourcehd;
        }



       
        private void frmQLHoaDon_Load(object sender, EventArgs e)
        {
             DataTable tablehd = new DataTable();
            tablehd = hdbo.getDSHoaDon();
            dgHoaDon.DataSource = tablehd;
        }
    }
}
