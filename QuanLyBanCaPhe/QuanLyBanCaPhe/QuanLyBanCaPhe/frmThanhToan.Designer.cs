namespace QuanLyBanCaPhe
{
    partial class frmThanhToan
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
            this.components = new System.ComponentModel.Container();
            this.lstViewChiTietHD = new System.Windows.Forms.ListView();
            this.clmTenNuoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSoLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDonGia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTongTien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtMaBan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTongThanhTien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTienNhan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtKhuyetMai = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstViewChiTietHD
            // 
            this.lstViewChiTietHD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmTenNuoc,
            this.clmSoLuong,
            this.clmDonGia,
            this.clmTongTien});
            this.lstViewChiTietHD.FullRowSelect = true;
            this.lstViewChiTietHD.Location = new System.Drawing.Point(25, 12);
            this.lstViewChiTietHD.Name = "lstViewChiTietHD";
            this.lstViewChiTietHD.Size = new System.Drawing.Size(449, 246);
            this.lstViewChiTietHD.TabIndex = 15;
            this.lstViewChiTietHD.UseCompatibleStateImageBehavior = false;
            this.lstViewChiTietHD.View = System.Windows.Forms.View.Details;
            this.lstViewChiTietHD.SelectedIndexChanged += new System.EventHandler(this.lstViewChiTietHD_SelectedIndexChanged);
            // 
            // clmTenNuoc
            // 
            this.clmTenNuoc.Text = "Tên nước";
            this.clmTenNuoc.Width = 132;
            // 
            // clmSoLuong
            // 
            this.clmSoLuong.Text = "Số lượng";
            // 
            // clmDonGia
            // 
            this.clmDonGia.Text = "Đơn giá";
            this.clmDonGia.Width = 135;
            // 
            // clmTongTien
            // 
            this.clmTongTien.Text = "Tổng tiền";
            this.clmTongTien.Width = 118;
            // 
            // txtMaBan
            // 
            this.txtMaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaBan.Location = new System.Drawing.Point(160, 279);
            this.txtMaBan.Name = "txtMaBan";
            this.txtMaBan.Size = new System.Drawing.Size(59, 26);
            this.txtMaBan.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Bàn:";
            // 
            // txtTongThanhTien
            // 
            this.txtTongThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongThanhTien.Location = new System.Drawing.Point(160, 311);
            this.txtTongThanhTien.Name = "txtTongThanhTien";
            this.txtTongThanhTien.Size = new System.Drawing.Size(156, 26);
            this.txtTongThanhTien.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Tổng thanh toán:";
            // 
            // txtTienNhan
            // 
            this.txtTienNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienNhan.Location = new System.Drawing.Point(160, 343);
            this.txtTienNhan.Name = "txtTienNhan";
            this.txtTienNhan.Size = new System.Drawing.Size(156, 26);
            this.txtTienNhan.TabIndex = 23;
            this.txtTienNhan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTienNhan_KeyPress);
            this.txtTienNhan.Leave += new System.EventHandler(this.txtTienNhan_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Tiền nhận:";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(131, 385);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(88, 31);
            this.btnXacNhan.TabIndex = 26;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(261, 385);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(88, 31);
            this.btnHuy.TabIndex = 27;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtKhuyetMai
            // 
            this.txtKhuyetMai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhuyetMai.Location = new System.Drawing.Point(390, 279);
            this.txtKhuyetMai.Name = "txtKhuyetMai";
            this.txtKhuyetMai.Size = new System.Drawing.Size(84, 26);
            this.txtKhuyetMai.TabIndex = 29;
            this.txtKhuyetMai.Leave += new System.EventHandler(this.txtKhuyetMai_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(251, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "Khuyến mãi giảm:";
            // 
            // frmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 420);
            this.Controls.Add(this.txtKhuyetMai);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtTienNhan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTongThanhTien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaBan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstViewChiTietHD);
            this.Name = "frmThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmThanhToan_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstViewChiTietHD;
        private System.Windows.Forms.ColumnHeader clmTenNuoc;
        private System.Windows.Forms.ColumnHeader clmSoLuong;
        private System.Windows.Forms.ColumnHeader clmDonGia;
        private System.Windows.Forms.ColumnHeader clmTongTien;
        private System.Windows.Forms.TextBox txtMaBan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTongThanhTien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTienNhan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtKhuyetMai;
        private System.Windows.Forms.Label label4;

    }
}