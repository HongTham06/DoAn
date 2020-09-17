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
    public partial class frmCTDH : Form
    {
        KetNoi k = new KetNoi();
        public frmCTDH()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCTDH_Load(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = k.loadDataTable("select * from ChiTietDH");
        }
    }
}
