using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp3
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
       

        private void btnSDBH_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            frmQLTTBHYT f = new frmQLTTBHYT()
            { Width = 1000, Height = 750 };
           
            f.TopLevel = false;
            this.panel1.Controls.Add(f);
          
            f.Show();
        }

        private void btnDSKhoa_Click(object sender, EventArgs e)
        {
            
            frmQLKHOA f = new frmQLKHOA()
            { Width = 1000, Height = 750 };
            this.panel1.Controls.Clear();
            f.TopLevel = false;
            this.panel1.Controls.Add(f);

            f.Show();
        }
        private void btnBenhNhan_Click(object sender, EventArgs e)
         {
             frmQLBenhNhan f = new frmQLBenhNhan() { Width = 1000, Height = 750 };
            this.panel1.Controls.Clear();
            f.TopLevel = false;
            this.panel1.Controls.Add(f);

            f.Show();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void btnThuoc_Click(object sender, EventArgs e)
        {
            frmQLThuoc f = new frmQLThuoc() { Width = 1000, Height = 750 };
            this.panel1.Controls.Clear();
            f.TopLevel = false;
            this.panel1.Controls.Add(f);

            f.Show();
        }

        private void btnDSNV_Click(object sender, EventArgs e)
        {
            frmQLNhanVien f = new frmQLNhanVien() { Width = 1000, Height = 750 };
            this.panel1.Controls.Clear();
            f.TopLevel = false;
            this.panel1.Controls.Add(f);

            f.Show();
        }

       

        private void btnDSHD_Click(object sender, EventArgs e)
        {
            frmQLHoaDon f = new frmQLHoaDon() { Width = 1000, Height = 750 };
            this.panel1.Controls.Clear();
            f.TopLevel = false;
            this.panel1.Controls.Add(f);

            f.Show();
        }

       

        private void btnDSGiuong_Click(object sender, EventArgs e)
        {
            frmFact f = new frmFact() { Width = 1000, Height = 750 };
            this.panel1.Controls.Clear();
            f.TopLevel = false;
            this.panel1.Controls.Add(f);

            f.Show();
        }

      
        private void btnCTHD_Click(object sender, EventArgs e)
        {
            frmQLCTHD f = new frmQLCTHD() { Width = 1000, Height = 750 };
            this.panel1.Controls.Clear();
            f.TopLevel = false;
            this.panel1.Controls.Add(f);

            f.Show();
        }

        private void btnDSPhieuKham_Click(object sender, EventArgs e)
        {
            frmQLPhieuKham f = new frmQLPhieuKham() { Width = 1000, Height = 750 };
            this.panel1.Controls.Clear();
            f.TopLevel = false;
            this.panel1.Controls.Add(f);

            f.Show();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            frmChart f = new frmChart ()
            { Width = 1000, Height = 750 };
            this.panel1.Controls.Clear();
            f.TopLevel = false;
            this.panel1.Controls.Add(f);

            f.Show();
        }

        private void loadExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Excel.Application xlApp;
            //Excel.Workbook xlWorkBook;
            //Excel.Worksheet xlWorkSheet;
            //Excel.Range range;

            //string str;
            //int rCnt;
            //int cCnt;
            //int rw = 0;
            //int cl = 0;

            //xlApp = new Excel.Application();
            //xlWorkBook = xlApp.Workbooks.Open(@"D:\New folder\Nhom3_DoTHiHongTham_olap\Nhom3_DoThiHongTham_Tuan9\LoadExcel1.xls", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //range = xlWorkSheet.UsedRange;
            //rw = range.Rows.Count;
            //cl = range.Columns.Count;


            //for (rCnt = 1; rCnt <= rw; rCnt++)
            //{
            //    for (cCnt = 1; cCnt <= cl; cCnt++)
            //    {
            //        str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
            //        MessageBox.Show(str);
            //    }
            //}

            //xlWorkBook.Close(true, null, null);
            //xlApp.Quit();

            //Marshal.ReleaseComObject(xlWorkSheet);
            //Marshal.ReleaseComObject(xlWorkBook);
            //Marshal.ReleaseComObject(xlApp);

        }

        private void ExcelBN_Click(object sender, EventArgs e)
        {
            frmDWH f = new frmDWH()
            { Width = 1000, Height = 750 };
            this.panel1.Controls.Clear();
            f.TopLevel = false;
            this.panel1.Controls.Add(f);

            f.Show();
        }
    }
    }

