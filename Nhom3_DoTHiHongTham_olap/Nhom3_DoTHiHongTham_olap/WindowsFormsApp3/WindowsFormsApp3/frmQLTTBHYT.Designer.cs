namespace WindowsFormsApp3
{
    partial class frmQLTTBHYT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLTTBHYT));
            this.lblTenChuThe = new System.Windows.Forms.Label();
            this.txtTenChuThe = new System.Windows.Forms.TextBox();
            this.txtSoThe = new System.Windows.Forms.TextBox();
            this.lblSoThe = new System.Windows.Forms.Label();
            this.btnBangLuong = new System.Windows.Forms.Button();
            this.dgBHYT = new System.Windows.Forms.DataGridView();
            this.SoTheBH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenChuThe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.dgBHYT)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTenChuThe
            // 
            this.lblTenChuThe.AutoSize = true;
            this.lblTenChuThe.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenChuThe.Location = new System.Drawing.Point(28, 58);
            this.lblTenChuThe.Name = "lblTenChuThe";
            this.lblTenChuThe.Size = new System.Drawing.Size(107, 19);
            this.lblTenChuThe.TabIndex = 13;
            this.lblTenChuThe.Text = "Tên Chủ Thẻ";
            // 
            // txtTenChuThe
            // 
            this.txtTenChuThe.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenChuThe.Location = new System.Drawing.Point(200, 58);
            this.txtTenChuThe.Name = "txtTenChuThe";
            this.txtTenChuThe.Size = new System.Drawing.Size(208, 26);
            this.txtTenChuThe.TabIndex = 12;
            // 
            // txtSoThe
            // 
            this.txtSoThe.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoThe.Location = new System.Drawing.Point(200, 12);
            this.txtSoThe.Name = "txtSoThe";
            this.txtSoThe.Size = new System.Drawing.Size(208, 26);
            this.txtSoThe.TabIndex = 6;
            // 
            // lblSoThe
            // 
            this.lblSoThe.AutoSize = true;
            this.lblSoThe.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoThe.Location = new System.Drawing.Point(28, 16);
            this.lblSoThe.Name = "lblSoThe";
            this.lblSoThe.Size = new System.Drawing.Size(111, 19);
            this.lblSoThe.TabIndex = 0;
            this.lblSoThe.Text = "Số Thẻ BHYT";
            // 
            // btnBangLuong
            // 
            this.btnBangLuong.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBangLuong.Image = ((System.Drawing.Image)(resources.GetObject("btnBangLuong.Image")));
            this.btnBangLuong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBangLuong.Location = new System.Drawing.Point(575, 471);
            this.btnBangLuong.Name = "btnBangLuong";
            this.btnBangLuong.Size = new System.Drawing.Size(207, 40);
            this.btnBangLuong.TabIndex = 20;
            this.btnBangLuong.Text = "XEM BẢNG LƯƠNG";
            this.btnBangLuong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBangLuong.UseVisualStyleBackColor = true;
            // 
            // dgBHYT
            // 
            this.dgBHYT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBHYT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoTheBH,
            this.TenChuThe});
            this.dgBHYT.Location = new System.Drawing.Point(9, 153);
            this.dgBHYT.Name = "dgBHYT";
            this.dgBHYT.Size = new System.Drawing.Size(628, 192);
            this.dgBHYT.TabIndex = 19;
            this.dgBHYT.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBHYT_RowEnter);
            // 
            // SoTheBH
            // 
            this.SoTheBH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoTheBH.DataPropertyName = "SoTheBH";
            this.SoTheBH.HeaderText = "Số Thẻ BHYT";
            this.SoTheBH.Name = "SoTheBH";
            // 
            // TenChuThe
            // 
            this.TenChuThe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenChuThe.DataPropertyName = "TenChuThe";
            this.TenChuThe.HeaderText = "Tên Chủ Thẻ";
            this.TenChuThe.Name = "TenChuThe";
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(0, 471);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(192, 40);
            this.btnHuy.TabIndex = 18;
            this.btnHuy.Text = "THOÁT";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(529, 96);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(96, 34);
            this.btnLuu.TabIndex = 17;
            this.btnLuu.Text = "LƯU";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(312, 100);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(96, 34);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "XÓA";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(25, 96);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(96, 34);
            this.btnThem.TabIndex = 14;
            this.btnThem.Text = "THÊM";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTenChuThe);
            this.groupBox1.Controls.Add(this.txtTenChuThe);
            this.groupBox1.Controls.Add(this.txtSoThe);
            this.groupBox1.Controls.Add(this.lblSoThe);
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Location = new System.Drawing.Point(0, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 140);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 477);
            this.splitter1.TabIndex = 21;
            this.splitter1.TabStop = false;
            // 
            // frmQLTTBHYT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 477);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btnBangLuong);
            this.Controls.Add(this.dgBHYT);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmQLTTBHYT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmQLTTBHYT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBHYT)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTenChuThe;
        private System.Windows.Forms.TextBox txtTenChuThe;
        private System.Windows.Forms.TextBox txtSoThe;
        private System.Windows.Forms.Label lblSoThe;
        private System.Windows.Forms.Button btnBangLuong;
        private System.Windows.Forms.DataGridView dgBHYT;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTheBH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenChuThe;
    }
}

