using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OlapApp
{
    public partial class frmKH : Form
    {
        KetNoi k = new KetNoi();
        public frmKH()
        {
            InitializeComponent();
        }

        private void frmKH_Load(object sender, EventArgs e)
        {
           
            dgvKH.DataSource = k.loadDataTable("select * from KhachHang");


        }
    }
}
