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
    public partial class frmSach : Form
    {
       
        KetNoi k = new KetNoi();
        public frmSach()
        {
            InitializeComponent();
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = k.loadDataTable("select * from Sach");
          


        }
    }
}
