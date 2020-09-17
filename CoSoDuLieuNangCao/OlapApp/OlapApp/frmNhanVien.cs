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
    public partial class frmNhanVien : Form
    {

        KetNoi k = new KetNoi();
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
           
            dgvNV.DataSource = k.loadDataTable("select * from nhanvien");


        }
    }
}
