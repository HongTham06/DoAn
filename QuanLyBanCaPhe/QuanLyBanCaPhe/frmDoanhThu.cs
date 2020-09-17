using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanCaPhe
{
    public partial class frmDoanhThu : Form
    {
        frmTrangChinh main;
        public frmDoanhThu(frmTrangChinh main)
        {
            this.main = main;
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            CrystalReportDoanhThu rpt = new CrystalReportDoanhThu();
            crystalReportViewer1.ReportSource = rpt;
            rpt.SetDatabaseLogon("sa", "sa2012", @"WIN8_1", "QL_CAPHE");
            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.Refresh();

        }

        private void frmDoanhThu_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Enabled = true;
            this.Hide();
        }
    }
}
