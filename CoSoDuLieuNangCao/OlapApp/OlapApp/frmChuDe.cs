using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OlapApp
{
    public partial class frmChuDe : Form
    {
        
        KetNoi k = new KetNoi();
        LoadDBBS bs = new LoadDBBS();
        bool Them;
        public frmChuDe()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void loaddata()
        {
            dataGridView1.DataSource = k.loadDataTable("select * from ChuDe");
        }
        private void frmChuDe_Load(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = k.loadDataTable("select * from ChuDe");
            HienThiButton(false);

        }
        void HienThiButton(bool e)
        {
            txtMaCD.Enabled = e;
            txtTenCD.Enabled = e;
            btnLuu.Enabled = e;
         
        }
        void HienThiButtonLucSua(bool e)
        {
            txtMaCD.Enabled = !e;
            txtTenCD.Enabled = e;
            btnLuu.Enabled = e;
           

        }
        void XoaDuLieuTrenTextBox()
        {
            txtMaCD.Text = "";
            txtTenCD.Text = "";
            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            XoaDuLieuTrenTextBox();
            HienThiButton(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành 
                int r = dataGridView1.CurrentCell.RowIndex;
                // Lấy MaSP của record hiện hành 
                string MaNV = dataGridView1.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL 
                // Hiện thông báo xác nhận việc xóa mẫu tin 
                // Khai báo biến traloi 
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Bạn chắc chắn xóa CD này ?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                string err = "";
                if (traloi == DialogResult.Yes)
                {

                    // Thực hiện câu lệnh SQL 
                    bool f = bs.XoaCD(ref err, this.txtMaCD.Text);
                    if (f)
                    {
                        // Cập nhật lại DataGridView 

                        loaddata();
                        // Thông báo 
                        MessageBox.Show("Đã xóa xong!");
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!\n\r" + "Lỗi:" + err);
                    }
                }
                else
                {
                    // Thông báo 
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!!!");
            }
            //Đóng kết nối
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            HienThiButtonLucSua(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                bool f = false;
                string _maCD = "";
                try
                {
                    _maCD = txtMaCD.Text;
                }
                catch { }

                string _tenCD = "";
                try
                {
                    _tenCD = txtTenCD.Text;
                }
                catch { }
   
                if (Them)
                {
                    if (_maCD == "" || _tenCD == "")
                    {
                        MessageBox.Show("Hãy nhập đầy đủ thông tin");
                        HienThiButton(true);
                    }
                    else
                    {
                        string err = "";
                        f = bs.ThemCD(ref err, this.txtMaCD.Text, this.txtTenCD.Text);
                        if (f)
                        {
                            //KetNoi.conn.ConnectionString = KetNoi.connstr;
                            
 
                            loaddata();
                            HienThiButton(false);
                            // Thông báo 
                            MessageBox.Show("Thêm CD thành công !");
                        }
                        else
                        {
                            MessageBox.Show("Thêm CD bị lỗi !\n\r" + "Lỗi:" + err);
                            HienThiButton(false);
                        }
                    }
                }
                else
                {
                    string err = "";
                    try
                    {
                        f = bs.SuaCD(ref err, this.txtMaCD.Text, this.txtTenCD.Text);
                        if (f)
                        {
                            // Load lại dữ liệu trên DataGridView 
                            
                            loaddata();
                            HienThiButton(false);
                            // Thông báo 
                            MessageBox.Show("Đã cập nhật thành công !");
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật không thành công !\n\r" + "Lỗi:" + err);
                            HienThiButton(false);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không cập nhật được. Lỗi rồi!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không lấy được cơ sở dữ liệu trong bảng CD!",
                    "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaCD.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
            this.txtTenCD.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
        }
    }
}
