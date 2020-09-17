namespace QuanLyKhachSan
{
    partial class frmDatPhong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatPhong));
            this.grc = new DevExpress.XtraEditors.GroupControl();
            this.dtNgayBD = new DevExpress.XtraEditors.DateEdit();
            this.dtNgayTao = new DevExpress.XtraEditors.DateEdit();
            this.txtMaPD = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.btnXacNhanDK = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtDonGiaPhong = new ThietKeConTrol.TextEditNhapSo();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtTang = new DevExpress.XtraEditors.TextEdit();
            this.txtDienTich = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenPhong = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cbbKhachHang = new DevExpress.XtraEditors.LookUpEdit();
            this.btnThemKH = new DevExpress.XtraEditors.SimpleButton();
            this.txtSDT = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtDiaChiKH = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.rdobtnNu = new System.Windows.Forms.RadioButton();
            this.rdobtnNam = new System.Windows.Forms.RadioButton();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grc)).BeginInit();
            this.grc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayBD.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayBD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayTao.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayTao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGiaPhong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienTich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenPhong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbKhachHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChiKH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grc
            // 
            this.grc.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grc.AppearanceCaption.Options.UseFont = true;
            this.grc.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("grc.CaptionImageOptions.Image")));
            this.grc.Controls.Add(this.dtNgayBD);
            this.grc.Controls.Add(this.dtNgayTao);
            this.grc.Controls.Add(this.txtMaPD);
            this.grc.Controls.Add(this.labelControl13);
            this.grc.Controls.Add(this.labelControl14);
            this.grc.Controls.Add(this.labelControl15);
            this.grc.Location = new System.Drawing.Point(435, 144);
            this.grc.Name = "grc";
            this.grc.Size = new System.Drawing.Size(409, 226);
            this.grc.TabIndex = 35;
            this.grc.Text = "Thông Tin Phiếu Đặt";
            // 
            // dtNgayBD
            // 
            this.dtNgayBD.EditValue = null;
            this.dtNgayBD.Location = new System.Drawing.Point(143, 186);
            this.dtNgayBD.Name = "dtNgayBD";
            this.dtNgayBD.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayBD.Properties.Appearance.Options.UseFont = true;
            this.dtNgayBD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayBD.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayBD.Size = new System.Drawing.Size(229, 26);
            this.dtNgayBD.TabIndex = 42;
            // 
            // dtNgayTao
            // 
            this.dtNgayTao.EditValue = null;
            this.dtNgayTao.Location = new System.Drawing.Point(143, 117);
            this.dtNgayTao.Name = "dtNgayTao";
            this.dtNgayTao.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayTao.Properties.Appearance.Options.UseFont = true;
            this.dtNgayTao.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayTao.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayTao.Size = new System.Drawing.Size(229, 26);
            this.dtNgayTao.TabIndex = 42;
            // 
            // txtMaPD
            // 
            this.txtMaPD.Location = new System.Drawing.Point(143, 55);
            this.txtMaPD.Name = "txtMaPD";
            this.txtMaPD.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPD.Properties.Appearance.Options.UseFont = true;
            this.txtMaPD.Size = new System.Drawing.Size(229, 26);
            this.txtMaPD.TabIndex = 41;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(31, 124);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(66, 19);
            this.labelControl13.TabIndex = 27;
            this.labelControl13.Text = "Ngày Tạo";
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Location = new System.Drawing.Point(31, 58);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(90, 19);
            this.labelControl14.TabIndex = 25;
            this.labelControl14.Text = "Số Hợp Đồng";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Location = new System.Drawing.Point(31, 189);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(96, 19);
            this.labelControl15.TabIndex = 23;
            this.labelControl15.Text = "Ngày Bắt Đầu";
            // 
            // btnXacNhanDK
            // 
            this.btnXacNhanDK.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhanDK.Appearance.Options.UseFont = true;
            this.btnXacNhanDK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXacNhanDK.ImageOptions.Image")));
            this.btnXacNhanDK.Location = new System.Drawing.Point(153, 51);
            this.btnXacNhanDK.Name = "btnXacNhanDK";
            this.btnXacNhanDK.Size = new System.Drawing.Size(140, 52);
            this.btnXacNhanDK.TabIndex = 34;
            this.btnXacNhanDK.Text = "Xác Nhận ĐK";
            this.btnXacNhanDK.Click += new System.EventHandler(this.btnXacNhanDK_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.ImageOptions.Image")));
            this.btnHuy.Location = new System.Drawing.Point(567, 51);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(140, 52);
            this.btnHuy.TabIndex = 33;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl2.CaptionImageOptions.Image")));
            this.groupControl2.Controls.Add(this.txtDonGiaPhong);
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Controls.Add(this.txtTang);
            this.groupControl2.Controls.Add(this.txtDienTich);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.txtTenPhong);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.labelControl9);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Location = new System.Drawing.Point(12, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(832, 126);
            this.groupControl2.TabIndex = 33;
            this.groupControl2.Text = "Thông Tin Căn Hộ";
            // 
            // txtDonGiaPhong
            // 
            this.txtDonGiaPhong.Location = new System.Drawing.Point(566, 47);
            this.txtDonGiaPhong.Name = "txtDonGiaPhong";
            this.txtDonGiaPhong.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonGiaPhong.Properties.Appearance.Options.UseFont = true;
            this.txtDonGiaPhong.Properties.Mask.EditMask = "c0";
            this.txtDonGiaPhong.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDonGiaPhong.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDonGiaPhong.Size = new System.Drawing.Size(229, 26);
            this.txtDonGiaPhong.TabIndex = 43;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(454, 50);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(79, 19);
            this.labelControl7.TabIndex = 42;
            this.labelControl7.Text = "Giá Căn Hộ";
            // 
            // txtTang
            // 
            this.txtTang.Location = new System.Drawing.Point(566, 89);
            this.txtTang.Name = "txtTang";
            this.txtTang.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTang.Properties.Appearance.Options.UseFont = true;
            this.txtTang.Size = new System.Drawing.Size(229, 26);
            this.txtTang.TabIndex = 41;
            // 
            // txtDienTich
            // 
            this.txtDienTich.Location = new System.Drawing.Point(150, 89);
            this.txtDienTich.Name = "txtDienTich";
            this.txtDienTich.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDienTich.Properties.Appearance.Options.UseFont = true;
            this.txtDienTich.Size = new System.Drawing.Size(229, 26);
            this.txtDienTich.TabIndex = 41;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(19, 96);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(65, 19);
            this.labelControl5.TabIndex = 40;
            this.labelControl5.Text = "Diện Tích";
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.Location = new System.Drawing.Point(150, 51);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenPhong.Properties.Appearance.Options.UseFont = true;
            this.txtTenPhong.Size = new System.Drawing.Size(229, 26);
            this.txtTenPhong.TabIndex = 39;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(19, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(81, 19);
            this.labelControl2.TabIndex = 38;
            this.labelControl2.Text = "Tên Căn Hộ";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(39, 126);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(65, 19);
            this.labelControl9.TabIndex = 27;
            this.labelControl9.Text = "Diện Tích";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(454, 92);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 19);
            this.labelControl3.TabIndex = 23;
            this.labelControl3.Text = "Khu Vực";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImageOptions.Image")));
            this.groupControl1.Controls.Add(this.cbbKhachHang);
            this.groupControl1.Controls.Add(this.btnThemKH);
            this.groupControl1.Controls.Add(this.txtSDT);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.txtDiaChiKH);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.rdobtnNu);
            this.groupControl1.Controls.Add(this.rdobtnNam);
            this.groupControl1.Controls.Add(this.labelControl18);
            this.groupControl1.Location = new System.Drawing.Point(12, 144);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(417, 226);
            this.groupControl1.TabIndex = 34;
            this.groupControl1.Text = "Thông Tin Khách Hàng";
            // 
            // cbbKhachHang
            // 
            this.cbbKhachHang.Location = new System.Drawing.Point(152, 53);
            this.cbbKhachHang.Name = "cbbKhachHang";
            this.cbbKhachHang.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbKhachHang.Properties.Appearance.Options.UseFont = true;
            this.cbbKhachHang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbKhachHang.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TENKH", "Tên Khách Hàng")});
            this.cbbKhachHang.Properties.NullText = "";
            this.cbbKhachHang.Properties.PopupSizeable = false;
            this.cbbKhachHang.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbbKhachHang.Size = new System.Drawing.Size(227, 26);
            this.cbbKhachHang.TabIndex = 45;
            this.cbbKhachHang.EditValueChanged += new System.EventHandler(this.cbbKhachHang_EditValueChanged);
            // 
            // btnThemKH
            // 
            this.btnThemKH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThemKH.ImageOptions.Image")));
            this.btnThemKH.Location = new System.Drawing.Point(385, 56);
            this.btnThemKH.Name = "btnThemKH";
            this.btnThemKH.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnThemKH.Size = new System.Drawing.Size(25, 26);
            this.btnThemKH.TabIndex = 44;
            this.btnThemKH.Click += new System.EventHandler(this.btnThemKH_Click);
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(152, 188);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Properties.Appearance.Options.UseFont = true;
            this.txtSDT.Properties.Mask.EditMask = "(\\d?\\d?\\d?) \\d\\d\\d-\\d\\d\\d\\d";
            this.txtSDT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.txtSDT.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtSDT.Size = new System.Drawing.Size(229, 26);
            this.txtSDT.TabIndex = 43;
            this.txtSDT.EditValueChanged += new System.EventHandler(this.txtSDT_EditValueChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(12, 189);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(95, 19);
            this.labelControl6.TabIndex = 42;
            this.labelControl6.Text = "Số Điện Thoại";
            // 
            // txtDiaChiKH
            // 
            this.txtDiaChiKH.Location = new System.Drawing.Point(152, 143);
            this.txtDiaChiKH.Name = "txtDiaChiKH";
            this.txtDiaChiKH.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChiKH.Properties.Appearance.Options.UseFont = true;
            this.txtDiaChiKH.Size = new System.Drawing.Size(229, 26);
            this.txtDiaChiKH.TabIndex = 40;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 146);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(107, 19);
            this.labelControl1.TabIndex = 38;
            this.labelControl1.Text = "Địa Chỉ K.Hàng";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(12, 58);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(113, 19);
            this.labelControl4.TabIndex = 39;
            this.labelControl4.Text = "Tên Khách Hàng";
            // 
            // rdobtnNu
            // 
            this.rdobtnNu.AutoSize = true;
            this.rdobtnNu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdobtnNu.Location = new System.Drawing.Point(326, 97);
            this.rdobtnNu.Name = "rdobtnNu";
            this.rdobtnNu.Size = new System.Drawing.Size(53, 26);
            this.rdobtnNu.TabIndex = 32;
            this.rdobtnNu.TabStop = true;
            this.rdobtnNu.Text = "Nữ";
            this.rdobtnNu.UseVisualStyleBackColor = true;
            // 
            // rdobtnNam
            // 
            this.rdobtnNam.AutoSize = true;
            this.rdobtnNam.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdobtnNam.Location = new System.Drawing.Point(152, 97);
            this.rdobtnNam.Name = "rdobtnNam";
            this.rdobtnNam.Size = new System.Drawing.Size(67, 26);
            this.rdobtnNam.TabIndex = 31;
            this.rdobtnNam.TabStop = true;
            this.rdobtnNam.Text = "Nam";
            this.rdobtnNam.UseVisualStyleBackColor = true;
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl18.Appearance.Options.UseFont = true;
            this.labelControl18.Location = new System.Drawing.Point(12, 99);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(63, 19);
            this.labelControl18.TabIndex = 25;
            this.labelControl18.Text = "Giới Tính";
            // 
            // groupControl4
            // 
            this.groupControl4.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl4.AppearanceCaption.Options.UseFont = true;
            this.groupControl4.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl4.CaptionImageOptions.Image")));
            this.groupControl4.Controls.Add(this.labelControl12);
            this.groupControl4.Controls.Add(this.btnHuy);
            this.groupControl4.Controls.Add(this.btnXacNhanDK);
            this.groupControl4.Location = new System.Drawing.Point(11, 376);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(832, 118);
            this.groupControl4.TabIndex = 36;
            this.groupControl4.Text = "Thông Tin Căn Hộ";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(39, 126);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(65, 19);
            this.labelControl12.TabIndex = 27;
            this.labelControl12.Text = "Diện Tích";
            // 
            // frmDatPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 503);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.grc);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmDatPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đặt Phòng";
            this.Load += new System.EventHandler(this.frmDatPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grc)).EndInit();
            this.grc.ResumeLayout(false);
            this.grc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayBD.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayBD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayTao.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayTao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGiaPhong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienTich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenPhong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbKhachHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChiKH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grc;
        private DevExpress.XtraEditors.SimpleButton btnXacNhanDK;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private System.Windows.Forms.RadioButton rdobtnNu;
        private System.Windows.Forms.RadioButton rdobtnNam;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtDiaChiKH;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtSDT;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtTenPhong;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDienTich;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtMaPD;
        private ThietKeConTrol.TextEditNhapSo txtDonGiaPhong;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtTang;
        private DevExpress.XtraEditors.DateEdit dtNgayBD;
        private DevExpress.XtraEditors.DateEdit dtNgayTao;
        private DevExpress.XtraEditors.SimpleButton btnThemKH;
        private DevExpress.XtraEditors.LookUpEdit cbbKhachHang;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.LabelControl labelControl12;
    }
}