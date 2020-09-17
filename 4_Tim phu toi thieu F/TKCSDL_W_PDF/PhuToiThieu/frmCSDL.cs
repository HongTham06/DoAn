using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using iTextSharp;
using iTextSharp.text.pdf.parser;
using System.IO;

namespace PhuToiThieu
{
    public partial class frmCSDL : Form
    {
        ThuatToan tt;
        List<string> listTrai;
        List<string> listPhai;

        public frmCSDL()
        {
            InitializeComponent();
            tt = new ThuatToan();
            listTrai = new List<string>();
            listPhai = new List<string>();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTrai.Text != "" && txtPhai.Text != "")
            {
                listTrai.Add(txtTrai.Text);
                listPhai.Add(txtPhai.Text);
                listBox1.Items.Add(txtTrai.Text.ToUpper() + " -> " + txtPhai.Text.ToUpper());

                txtTrai.Clear();
                txtPhai.Clear();

                txtTrai.Focus();
            }
            else
                MessageBox.Show("Hãy nhập phụ thuộc hàm vào!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            listTrai = new List<string>();
            listPhai = new List<string>();

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            txtBaoDong.Clear();
            txtTrai.Clear();
            txtPhai.Clear();
            txtTapThuocTinh.Clear();

            txtTrai.Focus();
        }

        private void btnXoaHet_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listTrai = new List<string>();
            listPhai = new List<string>();
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                //Đưa vào luồng
                StreamReader sr = new StreamReader(o.FileName);
                //duyệt dong tương ứng với PTH vế trái , dong1 tương ứng PTH vế phải
                string dong = "";
                string dong1 = "";
                while (dong != null && dong1 != null)
                {
                    dong = sr.ReadLine();

                    dong1 = sr.ReadLine();
                    if (dong != null && dong1 != null)
                    {
                        listTrai.Add(dong);
                        listPhai.Add(dong1);
                        listBox1.Items.Add(dong.ToUpper() + " -> " + dong1.ToUpper());
                    }

                }
                sr.Close();
            }
        }


        private void btnTimBaoDong_Click(object sender, EventArgs e)
        {
            if (txtBaoDong.Text != "" && listBox1.Items.Count > 0)
                MessageBox.Show("Bao đóng là: " + tt.timBaoDong(txtBaoDong.Text, listTrai, listPhai).ToUpper());
            else
                MessageBox.Show("Hãy nhập bao đóng cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnPhuToiThieu_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox2.Items.Clear();

                S_PhuToiThieu ptt = new S_PhuToiThieu();

                ptt = tt.timPhuToiThieu(listTrai, listPhai);

                for (int i = 0; i < ptt.VP.Count; i++)
                    listBox2.Items.Add(ptt.VT[i].ToUpper() + " -> " + ptt.VP[i].ToUpper());
            }
            else
                MessageBox.Show("Hãy nhập phụ thuộc hàm vào!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private void btnWord_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                ValidateNames = true,
                Multiselect = false,
                Filter = "Word 97-2003|*.doc|Word Document|*.docx"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    object readOnly = false;
                    object visible = true;
                    object save = false;
                    object fileName = ofd.FileName;
                    object newTemplate = false;
                    object docType = 0;
                    object missing = Type.Missing;
                    Microsoft.Office.Interop.Word._Document doc;
                    Microsoft.Office.Interop.Word._Application app = new Microsoft.Office.Interop.Word.Application() { Visible = false };
                    doc = app.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref visible,
                        ref missing, ref missing, ref missing, ref missing);
                    doc.ActiveWindow.Selection.WholeStory();
                    doc.ActiveWindow.Selection.Copy();
                    IDataObject data = Clipboard.GetDataObject();
                    rtxtWord.Rtf = data.GetData(DataFormats.Rtf).ToString();
                    app.Quit(ref missing, ref missing, ref missing);
                }
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "PDF files|*.pdf", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(ofd.FileName);
                        StringBuilder sb = new StringBuilder();
                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            sb.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                        }
                        rtxtWord.Text = sb.ToString();
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
    }

}
