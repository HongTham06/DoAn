using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using QuanLyKhachSan.BSlayer;
using DAL;

namespace QuanLyKhachSan
{
    public partial class frmQLPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmQLPhong()
        {
            InitializeComponent();
        }
        int temp = 0;
        bool Them = false;
        public string maphong1 { get; set; }
        public string KiemTra { get; set; }
        DAL_QLPhong p = new DAL_QLPhong();
        BLThongBao bltb = new BLThongBao();
        public class ban
        {
            public SimpleButton btn;
            public LabelControl lbl;
            public LabelControl lblDT;
            public LabelControl lblDG;
            public LabelControl lblTrangThai;
            public LabelControl lblLinkHA;
        }

        public class Tang
        {
            public List<ban> Listban;
        }

        public List<ban> Lban = new List<ban>();
        public List<TabPage> Ltabpage = new List<TabPage>();
        public int i = 0;

        public void XoaHet()
        {
            try
            {
                for (int i = p.TimSoTang() - 1; i >= 0; i--)
                    tabcrlPhong.Controls.RemoveAt(i);
            }
            catch
            {

            }
        }
        public void loadPhong()
        {
            XoaHet();
            QLKhachSanEntities cc = new QLKhachSanEntities();
            var kv = from x in cc.TANG select x;
            foreach (var x in kv)
            {
                string mkv = x.MAKV.Trim();
                TabPage tp = new TabPage(mkv);
                Ltabpage.Add(tp);
                tp.Width = this.Width / 2;
                tp.Text = x.TENKV.Trim();
                tp.BackColor = Color.LightSalmon;

                var ban = from y in cc.PHONG
                          join z in cc.TANG
                          on y.MAKV equals z.MAKV
                          where z.TENKV == tp.Text
                          select new
                          {
                              y.MAPHONG,
                              y.TENPHONG,
                              y.DIENTICH,
                              y.DONGIA,
                              z.MAKV,
                              y.TRANGTHAI,
                              y.HINHANH
                          };
                foreach (var b in ban)
                {
                    ban bann = new ban();
                    Lban.Add(bann);
                    Lban[i].btn = new SimpleButton();
                    Lban[i].btn.Size = new Size(100, 100);
                    Lban[i].btn.BackColor = Color.Blue;
                    Lban[i].btn.Name = b.MAPHONG.ToString().Trim();
                    Lban[i].btn.ImageOptions.Location = ImageLocation.MiddleCenter;
                    Lban[i].btn.AppearanceHovered.BackColor = Color.Khaki;
                    Lban[i].btn.AppearancePressed.BackColor = Color.IndianRed;
                    if (b.TRANGTHAI.Trim() == "Trống")
                        this.Lban[i].btn.ImageOptions.Image = global::QuanLyKhachSan.Properties.Resources.Trong;
                    else if (b.TRANGTHAI.Trim() == "Đã Đặt")
                        this.Lban[i].btn.ImageOptions.Image = global::QuanLyKhachSan.Properties.Resources.DaDat;
                    else
                        this.Lban[i].btn.ImageOptions.Image = global::QuanLyKhachSan.Properties.Resources.DaDat;

                    Lban[i].lblDT = new LabelControl();
                    Lban[i].lblDT.Text = b.DIENTICH.ToString().Trim();
                    Lban[i].lblDT.Visible = false;

                    Lban[i].lblDG = new LabelControl();
                    Lban[i].lblDG.Text = b.DONGIA.ToString();
                    Lban[i].lblDG.Visible = false;

                    Lban[i].lblLinkHA = new LabelControl();
                    Lban[i].lblLinkHA.Text = b.HINHANH.ToString();
                    Lban[i].lblLinkHA.Visible = false;

                    Lban[i].lblTrangThai = new LabelControl();
                    Lban[i].lblTrangThai.Text = b.TRANGTHAI.ToString();
                    Lban[i].lblTrangThai.Name = b.MAKV.ToString();
                    Lban[i].lblTrangThai.Visible = false;

                    Lban[i].lbl = new LabelControl();
                    Lban[i].lbl.AutoSizeMode = LabelAutoSizeMode.None;
                    Lban[i].lbl.Size = new Size(100, 25);
                    Lban[i].lbl.Text = b.TENPHONG.Trim();
                    Lban[i].lbl.BackColor = Color.WhiteSmoke;
                    Lban[i].lbl.Font = new Font(Lban[i].lbl.Font, FontStyle.Bold);
                    Lban[i].btn.Click += Btn_Click;
                    tp.Controls.Add(Lban[i].lbl);
                    tp.Controls.Add(Lban[i].btn);

                    if (i == temp)
                    {
                        Lban[i].btn.Location = new Point(30, 5);
                    }
                    else
                    {
                        if (Lban[i - 1].btn.Location.X + 200 > tp.Width)
                        {
                            Lban[i].btn.Location = new Point(30, Lban[i - 1].btn.Location.Y + 150);
                        }
                        else
                        {
                            Lban[i].btn.Location = new Point(Lban[i - 1].btn.Location.X + 150, Lban[i - 1].btn.Location.Y);
                        }
                    }
                    Lban[i].lbl.Location = new Point(Lban[i].btn.Location.X, Lban[i].btn.Location.Y + 100);
                    Lban[i].lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    i++;
                }
                temp += ban.Count();
                tp.Refresh();
                tabcrlPhong.Controls.Add(tp);
            }
            cbbTang.Properties.DataSource = p.loadcbbTang();
            cbbTang.Properties.DisplayMember = "TENKV";
            cbbTang.Properties.ValueMember = "MAKV";
            grcrlTT.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;

            this.txtMaPhong.ResetText();
            this.txtTenPhong.ResetText();
            this.txtDienTich.ResetText();
            this.txtDonGia.ResetText();
            this.cbbTang.ResetText();
            this.cbbTrangThai.ResetText();
            this.txtLinkHA.ResetText();
            txtDonGia.EditValue = null;
            cbbTang.EditValue = null;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            SimpleButton sb = sender as SimpleButton;
            maphong1 = sb.Name;
            DoiMauBan(sb, Lban);
        }

        public void DoiMauBan(SimpleButton btnBan, List<ban> Bann)
        {
            for (int i = 0; i <= Bann.Count - 1; i++)
            {
                if (btnBan.Name == Bann[i].btn.Name)
                {
                    Bann[i].lbl.BackColor = Color.Yellow;
                    txtTenPhong.Text = Bann[i].lbl.Text;
                    txtDienTich.Text = Bann[i].lblDT.Text;
                    txtDonGia.Text = Bann[i].lblDG.Text;
                    txtMaPhong.Text = Bann[i].btn.Name;
                    cbbTrangThai.Text = Bann[i].lblTrangThai.Text;
                    cbbTang.EditValue = Bann[i].lblTrangThai.Name;
                    txtLinkHA.Text = Bann[i].lblLinkHA.Text;
                    p.LayHinhAnh(Bann[i].btn.Name, pbHA);
                }
                else
                {
                    Bann[i].lbl.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void frmQLPhong_Load(object sender, EventArgs e)
        {

            loadPhong();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            this.txtMaPhong.ResetText();
            this.txtTenPhong.ResetText();
            this.txtDienTich.ResetText();
            this.txtDonGia.ResetText();
            this.cbbTang.ResetText();
            this.cbbTrangThai.ResetText();
            this.txtLinkHA.ResetText();
            txtDonGia.EditValue = null;
            cbbTang.EditValue = null;
            this.txtMaPhong.Focus();

            this.grcrlTT.Enabled = true;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.txtMaPhong.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;
            txtMaPhong.Text = p.LayMaP();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxYesNo msgyn = new MessageBoxYesNo();
                msgyn.ThongBao = "Bạn Có Muốn Xóa " + txtTenPhong.Text + " Không?";
                msgyn.ShowDialog();
                msgyn.Hide();
                KiemTra = msgyn.Check;
                if (KiemTra == "Có")
                {
                    p.XoaP(txtMaPhong.Text);
                    loadPhong();
                    bltb.Show("Đã Xóa Xong");
                }
                else
                {
                    bltb.Show("Không Xóa Được");
                }
            }
            catch
            {
                bltb.Show("Lỗi");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            this.txtMaPhong.ResetText();
            this.txtTenPhong.ResetText();
            this.txtDienTich.ResetText();
            this.txtDonGia.ResetText();
            this.cbbTang.ResetText();
            this.cbbTrangThai.ResetText();
            this.txtLinkHA.ResetText();
            txtDonGia.EditValue = null;
            cbbTang.EditValue = null;
            this.txtTenPhong.Focus();
            this.txtMaPhong.Enabled = false;

            this.grcrlTT.Enabled = true;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string link = "HinhAnh\\" + Path.GetFileName(txtLinkHA.Text);
            if (Them)
            {
                try
                {
                    p.ThemP(txtMaPhong.Text, txtTenPhong.Text, txtDienTich.Text, txtDonGia.EditValue.ToString(), cbbTang.EditValue.ToString(),cbbTrangThai.Text, link);
                    if (txtLinkHA.Text != "")
                    {
                        if (File.Exists(Environment.CurrentDirectory + "\\" + link) == false)
                        {
                            File.Copy(txtLinkHA.Text, Environment.CurrentDirectory + "\\" + link);
                        }
                    }
                    loadPhong();
                    bltb.Show("Thêm Xong");
                }
                catch
                {
                    bltb.Show("Lỗi");
                }
            }
            else
            {
                try
                {
                    p.SuaP(txtMaPhong.Text, txtTenPhong.Text, txtDienTich.Text, txtDonGia.EditValue.ToString(), cbbTang.EditValue.ToString(), cbbTrangThai.Text, link);
                    if (txtLinkHA.Text != "")
                    {
                        if (File.Exists(Environment.CurrentDirectory + "\\" + link) == false)
                        {
                            File.Copy(txtLinkHA.Text, Environment.CurrentDirectory + "\\" + link);
                        }
                    }
                    loadPhong();
                    bltb.Show("Sửa Xong");
                }
                catch
                {
                    p.SuaP(txtMaPhong.Text, txtTenPhong.Text, txtDienTich.Text, txtDonGia.EditValue.ToString(), cbbTang.EditValue.ToString(), cbbTrangThai.Text, @"HinhAnh\NhaTrangLuxury.png");                   
                    loadPhong();
                    bltb.Show("Sửa Xong");
                }
            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            loadPhong();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            loadPhong();
        }

        private void btnDuyetHA_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtLinkHA.Text = openFileDialog1.FileName;
                pbHA.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void txtLinkHA_EditValueChanged(object sender, EventArgs e)
        {
            p.LayHinhAnh3(txtLinkHA.Text, pbHA);
        }
    }
}