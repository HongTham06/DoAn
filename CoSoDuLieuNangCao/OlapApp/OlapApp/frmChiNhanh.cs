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
    public partial class frmChiNhanh : Form
    {

        KetNoi k = new KetNoi();
        public frmChiNhanh()
        {
            InitializeComponent();
        }

        private void frmChiNhanh_Load(object sender, EventArgs e)
        {
            
            dgvCN.DataSource = k.loadDataTable("select * from chinhanh");
           

        }
    }
}
