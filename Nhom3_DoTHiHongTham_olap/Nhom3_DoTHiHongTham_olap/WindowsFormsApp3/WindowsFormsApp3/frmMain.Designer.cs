namespace WindowsFormsApp3
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSDBH = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDSKhoa = new System.Windows.Forms.Button();
            this.btnThuoc = new System.Windows.Forms.Button();
            this.btnBenhNhan = new System.Windows.Forms.Button();
            this.btnDSNV = new System.Windows.Forms.Button();
            this.btnDSHD = new System.Windows.Forms.Button();
            this.btnDSGiuong = new System.Windows.Forms.Button();
            this.btnDSPhieuKham = new System.Windows.Forms.Button();
            this.btnCTHD = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTK = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ExcelBN = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSDBH
            // 
            this.btnSDBH.Location = new System.Drawing.Point(3, 55);
            this.btnSDBH.Name = "btnSDBH";
            this.btnSDBH.Size = new System.Drawing.Size(165, 46);
            this.btnSDBH.TabIndex = 0;
            this.btnSDBH.Text = "DS BHYT";
            this.btnSDBH.UseVisualStyleBackColor = true;
            this.btnSDBH.Click += new System.EventHandler(this.btnSDBH_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnDSKhoa);
            this.flowLayoutPanel1.Controls.Add(this.btnSDBH);
            this.flowLayoutPanel1.Controls.Add(this.btnThuoc);
            this.flowLayoutPanel1.Controls.Add(this.btnBenhNhan);
            this.flowLayoutPanel1.Controls.Add(this.btnDSNV);
            this.flowLayoutPanel1.Controls.Add(this.btnDSHD);
            this.flowLayoutPanel1.Controls.Add(this.btnDSGiuong);
            this.flowLayoutPanel1.Controls.Add(this.btnDSPhieuKham);
            this.flowLayoutPanel1.Controls.Add(this.btnCTHD);
            this.flowLayoutPanel1.Controls.Add(this.btnTK);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 85);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(168, 735);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // btnDSKhoa
            // 
            this.btnDSKhoa.Location = new System.Drawing.Point(3, 3);
            this.btnDSKhoa.Name = "btnDSKhoa";
            this.btnDSKhoa.Size = new System.Drawing.Size(165, 46);
            this.btnDSKhoa.TabIndex = 1;
            this.btnDSKhoa.Text = "DS Khoa";
            this.btnDSKhoa.UseVisualStyleBackColor = true;
            this.btnDSKhoa.Click += new System.EventHandler(this.btnDSKhoa_Click);
            // 
            // btnThuoc
            // 
            this.btnThuoc.Location = new System.Drawing.Point(3, 107);
            this.btnThuoc.Name = "btnThuoc";
            this.btnThuoc.Size = new System.Drawing.Size(165, 46);
            this.btnThuoc.TabIndex = 2;
            this.btnThuoc.Text = "DS Thuốc";
            this.btnThuoc.UseVisualStyleBackColor = true;
            this.btnThuoc.Click += new System.EventHandler(this.btnThuoc_Click);
            // 
            // btnBenhNhan
            // 
            this.btnBenhNhan.Location = new System.Drawing.Point(3, 159);
            this.btnBenhNhan.Name = "btnBenhNhan";
            this.btnBenhNhan.Size = new System.Drawing.Size(165, 46);
            this.btnBenhNhan.TabIndex = 3;
            this.btnBenhNhan.Text = "DS Bệnh nhân";
            this.btnBenhNhan.UseVisualStyleBackColor = true;
            this.btnBenhNhan.Click += new System.EventHandler(this.btnBenhNhan_Click);
            // 
            // btnDSNV
            // 
            this.btnDSNV.Location = new System.Drawing.Point(3, 211);
            this.btnDSNV.Name = "btnDSNV";
            this.btnDSNV.Size = new System.Drawing.Size(165, 50);
            this.btnDSNV.TabIndex = 4;
            this.btnDSNV.Text = "DS Nhân Viên";
            this.btnDSNV.UseVisualStyleBackColor = true;
            this.btnDSNV.Click += new System.EventHandler(this.btnDSNV_Click);
            // 
            // btnDSHD
            // 
            this.btnDSHD.Location = new System.Drawing.Point(3, 267);
            this.btnDSHD.Name = "btnDSHD";
            this.btnDSHD.Size = new System.Drawing.Size(165, 50);
            this.btnDSHD.TabIndex = 6;
            this.btnDSHD.Text = "DS Hóa Đơn";
            this.btnDSHD.UseVisualStyleBackColor = true;
            this.btnDSHD.Click += new System.EventHandler(this.btnDSHD_Click);
            // 
            // btnDSGiuong
            // 
            this.btnDSGiuong.Location = new System.Drawing.Point(3, 323);
            this.btnDSGiuong.Name = "btnDSGiuong";
            this.btnDSGiuong.Size = new System.Drawing.Size(165, 50);
            this.btnDSGiuong.TabIndex = 8;
            this.btnDSGiuong.Text = "DS Giường Bệnh";
            this.btnDSGiuong.UseVisualStyleBackColor = true;
            this.btnDSGiuong.Click += new System.EventHandler(this.btnDSGiuong_Click);
            // 
            // btnDSPhieuKham
            // 
            this.btnDSPhieuKham.Location = new System.Drawing.Point(3, 379);
            this.btnDSPhieuKham.Name = "btnDSPhieuKham";
            this.btnDSPhieuKham.Size = new System.Drawing.Size(165, 50);
            this.btnDSPhieuKham.TabIndex = 10;
            this.btnDSPhieuKham.Text = "DS Phiếu Khám";
            this.btnDSPhieuKham.UseVisualStyleBackColor = true;
            this.btnDSPhieuKham.Click += new System.EventHandler(this.btnDSPhieuKham_Click);
            // 
            // btnCTHD
            // 
            this.btnCTHD.Location = new System.Drawing.Point(3, 435);
            this.btnCTHD.Name = "btnCTHD";
            this.btnCTHD.Size = new System.Drawing.Size(165, 50);
            this.btnCTHD.TabIndex = 11;
            this.btnCTHD.Text = "Chi Tiết Hóa Đơn";
            this.btnCTHD.UseVisualStyleBackColor = true;
            this.btnCTHD.Click += new System.EventHandler(this.btnCTHD_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(200, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 735);
            this.panel1.TabIndex = 4;
            // 
            // btnTK
            // 
            this.btnTK.Location = new System.Drawing.Point(3, 491);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(165, 50);
            this.btnTK.TabIndex = 12;
            this.btnTK.Text = "Thống Kê";
            this.btnTK.UseVisualStyleBackColor = true;
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1208, 70);
            this.panel2.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExcelBN});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1208, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ExcelBN
            // 
            this.ExcelBN.Name = "ExcelBN";
            this.ExcelBN.Size = new System.Drawing.Size(94, 29);
            this.ExcelBN.Text = "Mở Excel";
            this.ExcelBN.Click += new System.EventHandler(this.ExcelBN_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 849);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSDBH;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDSKhoa;
        private System.Windows.Forms.Button btnThuoc;
        private System.Windows.Forms.Button btnBenhNhan;
        private System.Windows.Forms.Button btnDSNV;
        private System.Windows.Forms.Button btnDSHD;
        private System.Windows.Forms.Button btnDSGiuong;
        private System.Windows.Forms.Button btnDSPhieuKham;
        private System.Windows.Forms.Button btnCTHD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ExcelBN;
    }
}