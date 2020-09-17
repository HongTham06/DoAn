namespace QuanLyKhachSan
{
    partial class frmTrangChu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrangChu));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.lblTenNV = new DevExpress.XtraBars.BarStaticItem();
            this.btnTrangChu = new DevExpress.XtraBars.BarButtonItem();
            this.btnQLKhachHang = new DevExpress.XtraBars.BarButtonItem();
            this.btnTinhLuong = new DevExpress.XtraBars.BarButtonItem();
            this.btnQLNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnQLTaiKhoan = new DevExpress.XtraBars.BarButtonItem();
            this.btnQLChamCong = new DevExpress.XtraBars.BarButtonItem();
            this.btnQLDichVu = new DevExpress.XtraBars.BarButtonItem();
            this.btnQLLoaiDV = new DevExpress.XtraBars.BarButtonItem();
            this.btnQLPhong = new DevExpress.XtraBars.BarButtonItem();
            this.btnThongKe = new DevExpress.XtraBars.BarButtonItem();
            this.btnMoCN = new DevExpress.XtraBars.BarStaticItem();
            this.skinRibbonGalleryBarItem2 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.btnQ1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnQ2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnQ3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockChucNang = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnDoiMK = new DevExpress.XtraEditors.SimpleButton();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockChucNang.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.lblTenNV,
            this.btnTrangChu,
            this.btnQLKhachHang,
            this.btnTinhLuong,
            this.btnQLNhanVien,
            this.btnQLTaiKhoan,
            this.btnQLChamCong,
            this.btnQLDichVu,
            this.btnQLLoaiDV,
            this.btnQLPhong,
            this.btnThongKe,
            this.btnMoCN,
            this.skinRibbonGalleryBarItem2});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 17;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.btnQ1,
            this.btnQ2,
            this.btnQ3});
            this.ribbon.QuickToolbarItemLinks.Add(this.lblTenNV);
            this.ribbon.QuickToolbarItemLinks.Add(this.btnMoCN);
            this.ribbon.QuickToolbarItemLinks.Add(this.skinRibbonGalleryBarItem2);
            this.ribbon.Size = new System.Drawing.Size(1590, 162);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // lblTenNV
            // 
            this.lblTenNV.Caption = "Tên Nhân Viên";
            this.lblTenNV.Id = 2;
            this.lblTenNV.Name = "lblTenNV";
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.Caption = "Trang Chủ";
            this.btnTrangChu.Id = 3;
            this.btnTrangChu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTrangChu.ImageOptions.Image")));
            this.btnTrangChu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTrangChu.ImageOptions.LargeImage")));
            this.btnTrangChu.LargeWidth = 80;
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTrangChu_ItemClick);
            // 
            // btnQLKhachHang
            // 
            this.btnQLKhachHang.Caption = "Quản Lý Khách Hàng";
            this.btnQLKhachHang.Id = 4;
            this.btnQLKhachHang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQLKhachHang.ImageOptions.Image")));
            this.btnQLKhachHang.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnQLKhachHang.ImageOptions.LargeImage")));
            this.btnQLKhachHang.LargeWidth = 80;
            this.btnQLKhachHang.Name = "btnQLKhachHang";
            this.btnQLKhachHang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQLKhachHang_ItemClick);
            // 
            // btnTinhLuong
            // 
            this.btnTinhLuong.Caption = "Tính Lương";
            this.btnTinhLuong.Id = 5;
            this.btnTinhLuong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTinhLuong.ImageOptions.Image")));
            this.btnTinhLuong.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTinhLuong.ImageOptions.LargeImage")));
            this.btnTinhLuong.LargeWidth = 80;
            this.btnTinhLuong.Name = "btnTinhLuong";
            this.btnTinhLuong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTinhLuong_ItemClick);
            // 
            // btnQLNhanVien
            // 
            this.btnQLNhanVien.Caption = "Quản Lý Nhân Viên";
            this.btnQLNhanVien.Id = 6;
            this.btnQLNhanVien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQLNhanVien.ImageOptions.Image")));
            this.btnQLNhanVien.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnQLNhanVien.ImageOptions.LargeImage")));
            this.btnQLNhanVien.LargeWidth = 80;
            this.btnQLNhanVien.Name = "btnQLNhanVien";
            this.btnQLNhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQLNhanVien_ItemClick);
            // 
            // btnQLTaiKhoan
            // 
            this.btnQLTaiKhoan.Caption = "Tài Khoản - Cấp Quyền";
            this.btnQLTaiKhoan.Id = 7;
            this.btnQLTaiKhoan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQLTaiKhoan.ImageOptions.Image")));
            this.btnQLTaiKhoan.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnQLTaiKhoan.ImageOptions.LargeImage")));
            this.btnQLTaiKhoan.LargeWidth = 80;
            this.btnQLTaiKhoan.Name = "btnQLTaiKhoan";
            this.btnQLTaiKhoan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQLTaiKhoan_ItemClick);
            // 
            // btnQLChamCong
            // 
            this.btnQLChamCong.Caption = "Quản Lý Chấm Công";
            this.btnQLChamCong.Id = 8;
            this.btnQLChamCong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQLChamCong.ImageOptions.Image")));
            this.btnQLChamCong.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnQLChamCong.ImageOptions.LargeImage")));
            this.btnQLChamCong.LargeWidth = 80;
            this.btnQLChamCong.Name = "btnQLChamCong";
            this.btnQLChamCong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQLChamCong_ItemClick);
            // 
            // btnQLDichVu
            // 
            this.btnQLDichVu.Caption = "Quản Lý Dịch Vụ";
            this.btnQLDichVu.Id = 9;
            this.btnQLDichVu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQLDichVu.ImageOptions.Image")));
            this.btnQLDichVu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnQLDichVu.ImageOptions.LargeImage")));
            this.btnQLDichVu.LargeWidth = 80;
            this.btnQLDichVu.Name = "btnQLDichVu";
            this.btnQLDichVu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQLDichVu_ItemClick);
            // 
            // btnQLLoaiDV
            // 
            this.btnQLLoaiDV.Caption = "Quản Lý Loại Dịch Vụ";
            this.btnQLLoaiDV.Id = 10;
            this.btnQLLoaiDV.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQLLoaiDV.ImageOptions.Image")));
            this.btnQLLoaiDV.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnQLLoaiDV.ImageOptions.LargeImage")));
            this.btnQLLoaiDV.LargeWidth = 80;
            this.btnQLLoaiDV.Name = "btnQLLoaiDV";
            this.btnQLLoaiDV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQLLoaiDV_ItemClick);
            // 
            // btnQLPhong
            // 
            this.btnQLPhong.Caption = "Quản Lý Phòng";
            this.btnQLPhong.Id = 11;
            this.btnQLPhong.ImageOptions.Image = global::QuanLyKhachSan.Properties.Resources.Phong;
            this.btnQLPhong.ImageOptions.LargeImage = global::QuanLyKhachSan.Properties.Resources.Phong;
            this.btnQLPhong.LargeWidth = 80;
            this.btnQLPhong.Name = "btnQLPhong";
            this.btnQLPhong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQLPhong_ItemClick);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Caption = "Thống Kê";
            this.btnThongKe.Id = 12;
            this.btnThongKe.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKe.ImageOptions.Image")));
            this.btnThongKe.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThongKe.ImageOptions.LargeImage")));
            this.btnThongKe.LargeWidth = 80;
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThongKe_ItemClick);
            // 
            // btnMoCN
            // 
            this.btnMoCN.Caption = "Mở Chức Năng";
            this.btnMoCN.Id = 14;
            this.btnMoCN.Name = "btnMoCN";
            this.btnMoCN.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMoCN_ItemClick);
            // 
            // skinRibbonGalleryBarItem2
            // 
            this.skinRibbonGalleryBarItem2.Caption = "skinRibbonGalleryBarItem2";
            // 
            // 
            // 
            this.skinRibbonGalleryBarItem2.Gallery.ImageSize = new System.Drawing.Size(50, 50);
            this.skinRibbonGalleryBarItem2.Gallery.ShowItemText = true;
            this.skinRibbonGalleryBarItem2.Id = 16;
            this.skinRibbonGalleryBarItem2.Name = "skinRibbonGalleryBarItem2";
            // 
            // btnQ1
            // 
            this.btnQ1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.btnQ1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQ1.ImageOptions.Image")));
            this.btnQ1.Name = "btnQ1";
            this.btnQ1.Text = "Chức Năng";
            this.btnQ1.Visible = false;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnTrangChu);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Chức Năng";
            // 
            // btnQ2
            // 
            this.btnQ2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.btnQ2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQ2.ImageOptions.Image")));
            this.btnQ2.Name = "btnQ2";
            this.btnQ2.Text = "Quản Lý";
            this.btnQ2.Visible = false;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnQLKhachHang);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnQLNhanVien);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnQLTaiKhoan);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnQLChamCong);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnQLDichVu);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnQLLoaiDV);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnQLPhong);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Quản Lý";
            // 
            // btnQ3
            // 
            this.btnQ3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.btnQ3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQ3.ImageOptions.Image")));
            this.btnQ3.Name = "btnQ3";
            this.btnQ3.Text = "Hệ Thống";
            this.btnQ3.Visible = false;
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnTinhLuong);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnThongKe);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Thống Kê";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 868);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1590, 31);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockChucNang});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockChucNang
            // 
            this.dockChucNang.Controls.Add(this.dockPanel1_Container);
            this.dockChucNang.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockChucNang.ID = new System.Guid("cb6a59a4-d079-4884-b916-2076459d8978");
            this.dockChucNang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("dockChucNang.ImageOptions.Image")));
            this.dockChucNang.Location = new System.Drawing.Point(0, 162);
            this.dockChucNang.Name = "dockChucNang";
            this.dockChucNang.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockChucNang.Size = new System.Drawing.Size(200, 706);
            this.dockChucNang.Text = "Chức Năng";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.btnThoat);
            this.dockPanel1_Container.Controls.Add(this.btnDoiMK);
            this.dockPanel1_Container.Controls.Add(this.navBarControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(191, 679);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.Location = new System.Drawing.Point(8, 69);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(180, 46);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDoiMK
            // 
            this.btnDoiMK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDoiMK.ImageOptions.Image")));
            this.btnDoiMK.Location = new System.Drawing.Point(8, 12);
            this.btnDoiMK.Name = "btnDoiMK";
            this.btnDoiMK.Size = new System.Drawing.Size(180, 48);
            this.btnDoiMK.TabIndex = 1;
            this.btnDoiMK.Text = "Đổi Mật Khẩu";
            this.btnDoiMK.Click += new System.EventHandler(this.btnDoiMK_Click);
            // 
            // navBarControl1
            // 
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 191;
            this.navBarControl1.Size = new System.Drawing.Size(191, 679);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // frmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1590, 899);
            this.Controls.Add(this.dockChucNang);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "frmTrangChu";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Trang Chủ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTrangChu_FormClosing);
            this.Load += new System.EventHandler(this.frmTrangChu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockChucNang.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage btnQ1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockChucNang;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarStaticItem lblTenNV;
        private DevExpress.XtraBars.Ribbon.RibbonPage btnQ2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage btnQ3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnTrangChu;
        private DevExpress.XtraBars.BarButtonItem btnQLKhachHang;
        private DevExpress.XtraBars.BarButtonItem btnTinhLuong;
        private DevExpress.XtraBars.BarButtonItem btnQLNhanVien;
        private DevExpress.XtraBars.BarButtonItem btnQLTaiKhoan;
        private DevExpress.XtraBars.BarButtonItem btnQLChamCong;
        private DevExpress.XtraBars.BarButtonItem btnQLDichVu;
        private DevExpress.XtraBars.BarButtonItem btnQLLoaiDV;
        private DevExpress.XtraBars.BarButtonItem btnQLPhong;
        private DevExpress.XtraBars.BarButtonItem btnThongKe;
        private DevExpress.XtraBars.BarStaticItem btnMoCN;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem2;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnDoiMK;
    }
}