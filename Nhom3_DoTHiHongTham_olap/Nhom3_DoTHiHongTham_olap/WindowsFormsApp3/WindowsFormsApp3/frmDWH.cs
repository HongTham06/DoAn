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
using System.Data.OleDb;
using System.IO;

namespace WindowsFormsApp3
{
    public partial class frmDWH : Form
    {
        public frmDWH()
        {
            InitializeComponent();
        }

        private void tblBenhNhan_Click(object sender, EventArgs e)
        {
            string path = "";
            List<string> listSheet = new List<string>();
            //string namefile;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel Files (.xls*)|*.xls*|All Files (*.*)|*.*";
            dlg.Multiselect = false;

            DialogResult dlgResult = dlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                txtFilePath.Text = dlg.FileName;
                if (txtFilePath.Text.Equals(""))
                {
                    lblMsg.Text = "Please Load File First!!!";
                    return;
                }
                if (!File.Exists(txtFilePath.Text))
                {
                    lblMsg.Text = "Can not Open File!!!";
                    return;
                }
                String filePath = txtFilePath.Text;
                string excelcon;
                if (filePath.Substring(filePath.LastIndexOf('.')).ToLower() == ".xlsx")
                {
                    excelcon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0;HDR=NO;IMEX=1'";
                }
                else
                {
                    excelcon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'";
                }
                OleDbConnection conexcel = new OleDbConnection(excelcon);

                try
                {
                    conexcel.Open();
                    DataTable dtExcel = conexcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetName = dtExcel.Rows[0]["Table_Name"].ToString();
                    OleDbCommand cmdexcel1 = new OleDbCommand();
                    cmdexcel1.Connection = conexcel;
                    cmdexcel1.CommandText = "select * from[" + sheetName + "]";
                    DataTable dt = new DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = cmdexcel1;
                    da.Fill(dt);
                    conexcel.Close();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Rows.RemoveAt(0);
                }
                catch (Exception ex)
                {
                    //conexcel.Close();
                    MessageBox.Show(ex.ToString());
                }
            }
        }


    }
}
