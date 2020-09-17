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
using QuanLyKhachSan.BSlayer;
using DAL;

namespace QuanLyKhachSan
{
    public partial class frmXemThongTinPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmXemThongTinPhong()
        {
            InitializeComponent();
        }
        int temp = 0;
        public string maphong1 { get; set; }
        public string maphieu { get; set; }
        public string manv { get; set; }
        DAL_XemTTPhong p = new DAL_XemTTPhong();
        DAL_DatDichVu ddv = new DAL_DatDichVu();
        public class ban
        {
            public SimpleButton btn;
            public LabelControl lbl;
            public LabelControl lblDT;
            public LabelControl lblDG;
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
            txtDiaChiKH.ResetText();
            txtTenKH.ResetText();
            txtSDT.ResetText();
            dtgvTT.DataSource = null;
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
                              y.TRANGTHAI
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

                    Lban[i].lbl = new LabelControl();
                    Lban[i].lbl.AutoSizeMode = LabelAutoSizeMode.None;
                    Lban[i].lbl.Size = new Size(100, 25);
                    Lban[i].lbl.Text = b.TENPHONG.Trim();
                    Lban[i].lbl.BackColor = Color.WhiteSmoke;
                    Lban[i].lbl.Font = new Font(Lban[i].lbl.Font, FontStyle.Bold);
                    Lban[i].btn.Click += Btn_Click; ; 
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
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            SimpleButton sb = sender as SimpleButton;
            maphong1 = sb.Name;
            DoiMauBan(sb, Lban);
            if (p.LayTThai(maphong1) == "Đã Đặt")
            {
                btnDatDichVu.Enabled = true;
                btnXuatHD.Enabled = true;
                btnDatPhong.Enabled = false;
            }
            else
            {
                btnDatDichVu.Enabled = false;
                btnXuatHD.Enabled = false;
                btnDatPhong.Enabled = true;
            }
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
                    txtDonGiaPhong.Text = Bann[i].lblDG.Text;
                    txtTenKH.Text = p.LayTenKH(Bann[i].btn.Name);
                    txtDiaChiKH.Text = p.LayDCKH(Bann[i].btn.Name);
                    txtSDT.Text = p.LaySDTKH(Bann[i].btn.Name);
                    dtgvTT.DataSource = p.layTTT2(Bann[i].btn.Name);
                    p.LayHinhAnh(Bann[i].btn.Name, pbHA);
                    maphieu = p.LayMaPhieu(Bann[i].btn.Name);
    }
                else
                {
                    Bann[i].lbl.BackColor = Color.WhiteSmoke;
                }
            }
        }
        private void frmXemThongTinPhong_Load(object sender, EventArgs e)
        {
            loadPhong();
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            frmDatPhong d = new frmDatPhong();
            d.maphong = maphong1;
            d.MaNV = manv;
            d.ShowDialog();         
            d.Hide();
            loadPhong();
        }

        private void btnDatDichVu_Click(object sender, EventArgs e)
        {
            frmDatDichVu d = new frmDatDichVu();
            d.maphong = maphong1;
            d.MaNV = manv;
            d.MaP = maphieu;
            d.ShowDialog();
            d.Hide();
            //loadPhong();
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            
            frmXuatHoaDon d = new frmXuatHoaDon();
            if(p.KTTonTaiHoaDon(maphong1)==false)
            {
                string ma = ddv.LayMAHD();
                ddv.ThemPhieu(ma, DateTime.Now.ToString().Substring(0, 10), manv, maphong1);
                d.MaPhieu = ma;
            }
            else
            {
                //MessageBox.Show("có");
                d.MaPhieu = maphieu;
            }
            d.MaPhong = maphong1;
            d.ShowDialog();
            d.Hide();
            loadPhong();
        }
    }
}