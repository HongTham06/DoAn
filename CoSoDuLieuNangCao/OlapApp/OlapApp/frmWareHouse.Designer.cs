namespace OlapApp
{
    partial class frmWareHouse
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
            this.dgvWH = new System.Windows.Forms.DataGridView();
            this.btnCD = new System.Windows.Forms.Button();
            this.btnNXB = new System.Windows.Forms.Button();
            this.btnSach = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.loadKho = new OlapApp.LoadKho();
            this.dimChuDeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dim_ChuDeTableAdapter = new OlapApp.LoadKhoTableAdapters.Dim_ChuDeTableAdapter();
            this.btnChiNhanh = new System.Windows.Forms.Button();
            this.btnKH = new System.Windows.Forms.Button();
            this.btnTime = new System.Windows.Forms.Button();
            this.btnFact = new System.Windows.Forms.Button();
            this.btnNap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimChuDeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWH
            // 
            this.dgvWH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWH.Location = new System.Drawing.Point(31, 208);
            this.dgvWH.Name = "dgvWH";
            this.dgvWH.Size = new System.Drawing.Size(703, 229);
            this.dgvWH.TabIndex = 0;
            // 
            // btnCD
            // 
            this.btnCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCD.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCD.Location = new System.Drawing.Point(12, 12);
            this.btnCD.Name = "btnCD";
            this.btnCD.Size = new System.Drawing.Size(117, 41);
            this.btnCD.TabIndex = 1;
            this.btnCD.Text = "Chiều Chủ đề";
            this.btnCD.UseVisualStyleBackColor = true;
            this.btnCD.Click += new System.EventHandler(this.btnCD_Click);
            // 
            // btnNXB
            // 
            this.btnNXB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNXB.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNXB.Location = new System.Drawing.Point(146, 12);
            this.btnNXB.Name = "btnNXB";
            this.btnNXB.Size = new System.Drawing.Size(117, 41);
            this.btnNXB.TabIndex = 2;
            this.btnNXB.Text = "Chiều NXB";
            this.btnNXB.UseVisualStyleBackColor = true;
            this.btnNXB.Click += new System.EventHandler(this.btnNXB_Click);
            // 
            // btnSach
            // 
            this.btnSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSach.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSach.Location = new System.Drawing.Point(67, 72);
            this.btnSach.Name = "btnSach";
            this.btnSach.Size = new System.Drawing.Size(117, 41);
            this.btnSach.TabIndex = 3;
            this.btnSach.Text = "Chiều Sách";
            this.btnSach.UseVisualStyleBackColor = true;
            this.btnSach.Click += new System.EventHandler(this.btnSach_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanVien.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.Location = new System.Drawing.Point(293, 81);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(117, 41);
            this.btnNhanVien.TabIndex = 5;
            this.btnNhanVien.Text = "Chiều NhanVien";
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // loadKho
            // 
            this.loadKho.DataSetName = "LoadKho";
            this.loadKho.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dimChuDeBindingSource
            // 
            this.dimChuDeBindingSource.DataMember = "Dim_ChuDe";
            this.dimChuDeBindingSource.DataSource = this.loadKho;
            // 
            // dim_ChuDeTableAdapter
            // 
            this.dim_ChuDeTableAdapter.ClearBeforeFill = true;
            // 
            // btnChiNhanh
            // 
            this.btnChiNhanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiNhanh.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiNhanh.Location = new System.Drawing.Point(293, 12);
            this.btnChiNhanh.Name = "btnChiNhanh";
            this.btnChiNhanh.Size = new System.Drawing.Size(117, 41);
            this.btnChiNhanh.TabIndex = 4;
            this.btnChiNhanh.Text = "Chiều chi nhánh";
            this.btnChiNhanh.UseVisualStyleBackColor = true;
            this.btnChiNhanh.Click += new System.EventHandler(this.btnChiNhanh_Click);
            // 
            // btnKH
            // 
            this.btnKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKH.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKH.Location = new System.Drawing.Point(450, 12);
            this.btnKH.Name = "btnKH";
            this.btnKH.Size = new System.Drawing.Size(117, 41);
            this.btnKH.TabIndex = 6;
            this.btnKH.Text = "Chiều khách hàng";
            this.btnKH.UseVisualStyleBackColor = true;
            this.btnKH.Click += new System.EventHandler(this.btnKH_Click);
            // 
            // btnTime
            // 
            this.btnTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTime.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTime.Location = new System.Drawing.Point(600, 12);
            this.btnTime.Name = "btnTime";
            this.btnTime.Size = new System.Drawing.Size(117, 41);
            this.btnTime.TabIndex = 8;
            this.btnTime.Text = "Chiều thời gian";
            this.btnTime.UseVisualStyleBackColor = true;
            this.btnTime.Click += new System.EventHandler(this.btnTime_Click);
            // 
            // btnFact
            // 
            this.btnFact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFact.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFact.Location = new System.Drawing.Point(527, 81);
            this.btnFact.Name = "btnFact";
            this.btnFact.Size = new System.Drawing.Size(117, 41);
            this.btnFact.TabIndex = 7;
            this.btnFact.Text = "FACT";
            this.btnFact.UseVisualStyleBackColor = true;
            this.btnFact.Click += new System.EventHandler(this.btnFact_Click);
            // 
            // btnNap
            // 
            this.btnNap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNap.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNap.Location = new System.Drawing.Point(312, 145);
            this.btnNap.Name = "btnNap";
            this.btnNap.Size = new System.Drawing.Size(177, 41);
            this.btnNap.TabIndex = 9;
            this.btnNap.Text = "Nạp lại dữ liệu";
            this.btnNap.UseVisualStyleBackColor = true;
            this.btnNap.Click += new System.EventHandler(this.btnNap_Click);
            // 
            // frmWareHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 460);
            this.Controls.Add(this.btnNap);
            this.Controls.Add(this.btnFact);
            this.Controls.Add(this.btnTime);
            this.Controls.Add(this.btnKH);
            this.Controls.Add(this.btnChiNhanh);
            this.Controls.Add(this.btnNhanVien);
            this.Controls.Add(this.btnSach);
            this.Controls.Add(this.btnNXB);
            this.Controls.Add(this.btnCD);
            this.Controls.Add(this.dgvWH);
            this.Name = "frmWareHouse";
            this.Text = "frmWareHouse";
            this.Load += new System.EventHandler(this.frmWareHouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimChuDeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWH;
        private System.Windows.Forms.Button btnCD;
        private System.Windows.Forms.Button btnNXB;
        private System.Windows.Forms.Button btnSach;
        private System.Windows.Forms.Button btnNhanVien;
        private LoadKho loadKho;
        private System.Windows.Forms.BindingSource dimChuDeBindingSource;
        private LoadKhoTableAdapters.Dim_ChuDeTableAdapter dim_ChuDeTableAdapter;
        private System.Windows.Forms.Button btnChiNhanh;
        private System.Windows.Forms.Button btnKH;
        private System.Windows.Forms.Button btnTime;
        private System.Windows.Forms.Button btnFact;
        private System.Windows.Forms.Button btnNap;
    }
}