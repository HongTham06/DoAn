namespace WindowsFormsApp3
{
    partial class frmQLPhieuKham
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
            this.dgPhieuKham = new System.Windows.Forms.DataGridView();
            this.MaPK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayKham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChuanDoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KetLuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HuongDieuTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgPhieuKham)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPhieuKham
            // 
            this.dgPhieuKham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPhieuKham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPK,
            this.MaBN,
            this.MaNV,
            this.MaKhoa,
            this.SoPB,
            this.NgayKham,
            this.ChuanDoan,
            this.KetLuan,
            this.HuongDieuTri});
            this.dgPhieuKham.Location = new System.Drawing.Point(12, 35);
            this.dgPhieuKham.Name = "dgPhieuKham";
            this.dgPhieuKham.RowTemplate.Height = 28;
            this.dgPhieuKham.Size = new System.Drawing.Size(944, 625);
            this.dgPhieuKham.TabIndex = 1;
            // 
            // MaPK
            // 
            this.MaPK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaPK.DataPropertyName = "MaPK";
            this.MaPK.HeaderText = "Mã Phiếu Khám";
            this.MaPK.Name = "MaPK";
            // 
            // MaBN
            // 
            this.MaBN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaBN.DataPropertyName = "MaBN";
            this.MaBN.HeaderText = "Mã Bệnh Nhân";
            this.MaBN.Name = "MaBN";
            // 
            // MaNV
            // 
            this.MaNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã NV";
            this.MaNV.Name = "MaNV";
            // 
            // MaKhoa
            // 
            this.MaKhoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaKhoa.DataPropertyName = "MaKhoa";
            this.MaKhoa.HeaderText = "Mã Khoa";
            this.MaKhoa.Name = "MaKhoa";
            // 
            // SoPB
            // 
            this.SoPB.DataPropertyName = "SoPB";
            this.SoPB.HeaderText = "Số Phòng";
            this.SoPB.Name = "SoPB";
            // 
            // NgayKham
            // 
            this.NgayKham.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NgayKham.DataPropertyName = "NgayKham";
            this.NgayKham.HeaderText = "Ngày Khám";
            this.NgayKham.Name = "NgayKham";
            // 
            // ChuanDoan
            // 
            this.ChuanDoan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChuanDoan.DataPropertyName = "ChuanDoan";
            this.ChuanDoan.HeaderText = "Chuẩn Đoán";
            this.ChuanDoan.Name = "ChuanDoan";
            // 
            // KetLuan
            // 
            this.KetLuan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.KetLuan.DataPropertyName = "KetLuan";
            this.KetLuan.HeaderText = "Kết Luận";
            this.KetLuan.Name = "KetLuan";
            // 
            // HuongDieuTri
            // 
            this.HuongDieuTri.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HuongDieuTri.DataPropertyName = "HuongDieuTri";
            this.HuongDieuTri.HeaderText = "Hướng Điều Trị";
            this.HuongDieuTri.Name = "HuongDieuTri";
            // 
            // frmQLPhieuKham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 734);
            this.Controls.Add(this.dgPhieuKham);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQLPhieuKham";
            this.Text = "frmQLPhieuKham";
            this.Load += new System.EventHandler(this.frmQLPhieuKham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPhieuKham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPhieuKham;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPK;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPB;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayKham;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChuanDoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn KetLuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn HuongDieuTri;
    }
}