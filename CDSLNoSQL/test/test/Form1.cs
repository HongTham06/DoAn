using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace test
{
    public partial class Form1 : Form
    {
        static MongoClient client = new MongoClient();
        /*static IMongoDatabase db = client.GetDatabase("studentDB");
        static IMongoCollection<student> col = db.GetCollection<student>("students");
        static IMongoDatabase db1 = client.GetDatabase("QLThuVien");
        static IMongoCollection<DocGia> col1 = db1.GetCollection<DocGia>("DocGia");*/

        static IMongoDatabase nv = client.GetDatabase("QL_NHANVIEN");
        static IMongoCollection<NhanVien> colnv = nv.GetCollection<NhanVien>("NHANVIEN");
        static IMongoCollection<PhongBan> colpb = nv.GetCollection<PhongBan>("PHONGBAN");

        static IMongoDatabase sv = client.GetDatabase("QL_SINHVIEN");
        static IMongoCollection<SinhVien> colsv = sv.GetCollection<SinhVien>("SINHVIEN");
        static IMongoCollection<Lop> colLop = sv.GetCollection<Lop>("LOP");
        static IMongoCollection<MonHoc> colmh = sv.GetCollection<MonHoc>("MONHOC");
        static IMongoCollection<Khoa> colkh = sv.GetCollection<Khoa>("KHOA");


        public Form1()
        {
            InitializeComponent();
            loadNV();
            loadSV();
            cboCollection.Enabled = false;
            cboSV.Enabled = false;
            
        }
        public void loadNV()
        {
            if (cboCollection.SelectedIndex == 0)
            {
                /*List<student> list = col.AsQueryable().ToList<student>();
                dataGridView1.DataSource = list;
                textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                textBox4.Clear();*/
                List<NhanVien> list = colnv.AsQueryable().ToList<NhanVien>();
                dataGridView1.DataSource = list;
                textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();

            }
            if (cboCollection.SelectedIndex == 1)
            {
                /*List<DocGia> list = col1.AsQueryable().ToList<DocGia>();
                dataGridView1.DataSource = list;
                textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();*/
                List<PhongBan> list = colpb.AsQueryable().ToList<PhongBan>();
                dataGridView1.DataSource = list;
                textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                textBox3.Clear();
                textBox4.Clear();
                //textBox3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                //textBox4.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            }

        }
        public void loadSV()
        {
            if (cboSV.SelectedIndex == 0)
            {
                /*List<student> list = col.AsQueryable().ToList<student>();
                dataGridView1.DataSource = list;
                textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                textBox4.Clear();*/
                List<SinhVien> list = colsv.AsQueryable().ToList<SinhVien>();
                dataGridView1.DataSource = list;
                textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();

            }
            if (cboSV.SelectedIndex == 1)
            {
              
                List<Khoa> list = colkh.AsQueryable().ToList<Khoa>();
                dataGridView1.DataSource = list;
                textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                textBox3.Clear();
                textBox4.Clear();
                //textBox3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                //textBox4.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            }
            if (cboSV.SelectedIndex == 2)
            {

                List<Lop> list = colLop.AsQueryable().ToList<Lop>();
                dataGridView1.DataSource = list;
                textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                textBox4.Clear();
                //textBox3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                //textBox4.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            }
            if (cboSV.SelectedIndex == 3)
            {

                List<MonHoc> list = colmh.AsQueryable().ToList<MonHoc>();
                dataGridView1.DataSource = list;
                textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
                //textBox3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                //textBox4.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (cboCollection.SelectedIndex == 0)
            {
                textBox1.DataBindings.Clear();
                textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "Id");
                textBox2.DataBindings.Clear();
                textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "Ho");
                textBox3.DataBindings.Clear();
                textBox3.DataBindings.Add("Text", dataGridView1.DataSource, "Ten");
            }
            if (cboCollection.SelectedIndex == 1)
            {
                textBox1.DataBindings.Clear();
                textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "Id");
                textBox2.DataBindings.Clear();
                textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "Id_DG");
                textBox3.DataBindings.Clear();
                textBox3.DataBindings.Add("Text", dataGridView1.DataSource, "Id_TheTV");
                textBox4.DataBindings.Clear();
                textBox4.DataBindings.Add("Text", dataGridView1.DataSource, "SDTDG");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cboCollection.SelectedIndex == 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            }
            if (cboCollection.SelectedIndex == 1)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                //textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            if (cboSV.SelectedIndex == 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            }
            if (cboSV.SelectedIndex == 1)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            }
            if (cboSV.SelectedIndex == 2)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            if (cboSV.SelectedIndex == 3)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }
        
        

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboCollection.SelectedIndex==0)
            {
                NhanVien nv = new NhanVien(textBox2.Text, textBox3.Text,double.Parse(textBox4.Text));
                colnv.InsertOne(nv);
                loadNV();
            }
            if (cboCollection.SelectedIndex == 1)
            {
                PhongBan pb = new PhongBan(textBox2.Text, textBox3.Text);
                colpb.InsertOne(pb);
                loadNV();
            }
            if (cboSV.SelectedIndex == 0)
            {
                SinhVien sv = new SinhVien(textBox2.Text, textBox3.Text, textBox4.Text);
                colsv.InsertOne(sv);
                loadSV();
            }
            if (cboSV.SelectedIndex == 1)
            {
                Khoa k = new Khoa(textBox2.Text, textBox3.Text);
                colkh.InsertOne(k);
                loadSV();
            }
            if (cboSV.SelectedIndex == 2)
            {
                Lop l = new Lop(textBox2.Text, textBox3.Text,textBox4.Text);
                colLop.InsertOne(l);
                loadSV();
            }
            if (cboSV.SelectedIndex == 3)
            {
                MonHoc mh = new MonHoc(textBox2.Text, textBox3.Text, double.Parse(textBox4.Text));
                colmh.InsertOne(mh);
                loadSV();
            }


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cboCollection.SelectedIndex == 0)
            {
                var update = Builders<NhanVien>.Update.Set("MaNV", textBox2.Text).Set("HoTen", textBox3.Text).Set("Luong", textBox4.Text);
                colnv.UpdateOne(nv => nv.Id == ObjectId.Parse(textBox1.Text), update);
                loadNV();
            }
            if (cboCollection.SelectedIndex == 1)
            {
                var update1 = Builders<PhongBan>.Update.Set("MaPH", textBox2.Text).Set("TenPH", textBox3.Text); 

                colpb.UpdateOne(pb => pb.Id == ObjectId.Parse(textBox1.Text), update1);
                loadNV();
            }
            if (cboSV.SelectedIndex == 0)
            {
                var update2 = Builders<SinhVien>.Update.Set("MaSV", textBox2.Text).Set("HoTen", textBox3.Text).Set("MaLop", textBox4.Text);

                colsv.UpdateOne(sv => sv.Id == ObjectId.Parse(textBox1.Text), update2);
                loadSV();
            }
            if (cboSV.SelectedIndex == 1)
            {
                var update3 = Builders<Khoa>.Update.Set("MaKhoa", textBox2.Text).Set("TenKhoa", textBox3.Text);

                colkh.UpdateOne(k => k.Id == ObjectId.Parse(textBox1.Text), update3);
                loadSV();
            }
            if (cboSV.SelectedIndex == 2)
            {
                var update4 = Builders<Lop>.Update.Set("MaLop", textBox2.Text).Set("TenLop", textBox3.Text).Set("MaKhoa", textBox4.Text);

                colLop.UpdateOne(l=> l.Id == ObjectId.Parse(textBox1.Text), update4);
                loadSV();
            }
            if (cboSV.SelectedIndex == 3)
            {
                var update5 = Builders<MonHoc>.Update.Set("MaMH", textBox2.Text).Set("TenMH", textBox3.Text).Set("SoTC", textBox4.Text);

                colmh.UpdateOne(mh => mh.Id == ObjectId.Parse(textBox1.Text), update5);
                loadSV();
            }


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //nhanvien
            if (cboCollection.SelectedIndex == 0)
            {
                colnv.DeleteOne(nv => nv.Id == ObjectId.Parse(textBox1.Text));
                loadNV();
            }
            //phongban
            if (cboCollection.SelectedIndex == 1)
            {
                colpb.DeleteOne(pb => pb.Id == ObjectId.Parse(textBox1.Text));
                loadNV();
            }
            //sinhvien
            if (cboSV.SelectedIndex == 0)
            {
                colsv.DeleteOne(sv => sv.Id == ObjectId.Parse(textBox1.Text));
                loadSV();
            }
            //khoa
            if (cboSV.SelectedIndex == 1)
            {
                colkh.DeleteOne(k => k.Id == ObjectId.Parse(textBox1.Text));
                loadSV();
            }
            //lop
            if (cboSV.SelectedIndex == 2)
            {
                colLop.DeleteOne(l => l.Id == ObjectId.Parse(textBox1.Text));
                loadSV();
            }
            //monhoc
            if (cboSV.SelectedIndex == 3)
            {
                colmh.DeleteOne(mh => mh.Id == ObjectId.Parse(textBox1.Text));
                loadSV();
            }
            /*if (cboCollection.SelectedIndex == 0)
            {
                col.DeleteOne(st => st.Id == ObjectId.Parse(textBox1.Text));
                load();
            }
            if (cboCollection.SelectedIndex == 1)
            {
                col1.DeleteOne(dg => dg.Id == ObjectId.Parse(textBox1.Text));
                load();
            }*/
           
        }

        private void cboDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDatabase.SelectedIndex == 0)
            {
                cboSV.Enabled = false;
                cboCollection.Enabled = true;
               
            }
            if(cboDatabase.SelectedIndex == 1)
            {
                cboCollection.Enabled =false;
                cboSV.Enabled = true;
            }
        }

        private void cboCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            loadNV();
            cboSV.SelectedIndex = -1;

        }

        private void cboSV_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            loadSV();
            cboCollection.SelectedIndex = -1;

        }
    }
}
