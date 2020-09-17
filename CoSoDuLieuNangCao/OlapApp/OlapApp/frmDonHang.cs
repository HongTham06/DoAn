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
    public partial class frmDonHang : Form
    {
        KetNoi k = new KetNoi();
        public frmDonHang()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDonHang_Load(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = k.loadDataTable("select * from DonHang");

        }
    }
}
