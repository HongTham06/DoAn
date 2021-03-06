USE [master]
GO
/****** Object:  Database [QLKhachSan]    Script Date: 16/07/2020 04:23:49 CH ******/
CREATE DATABASE [QLKhachSan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLKhachSan', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QLKhachSan.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLKhachSan_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QLKhachSan_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QLKhachSan] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLKhachSan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLKhachSan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLKhachSan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLKhachSan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLKhachSan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLKhachSan] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLKhachSan] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLKhachSan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLKhachSan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLKhachSan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLKhachSan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLKhachSan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLKhachSan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLKhachSan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLKhachSan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLKhachSan] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLKhachSan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLKhachSan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLKhachSan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLKhachSan] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [QLKhachSan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLKhachSan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLKhachSan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLKhachSan] SET RECOVERY FULL 
GO
ALTER DATABASE [QLKhachSan] SET  MULTI_USER 
GO
ALTER DATABASE [QLKhachSan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLKhachSan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLKhachSan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLKhachSan] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLKhachSan] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLKhachSan', N'ON'
GO
ALTER DATABASE [QLKhachSan] SET QUERY_STORE = OFF
GO
USE [QLKhachSan]
GO
/****** Object:  Table [dbo].[CHITIETHOADON]    Script Date: 16/07/2020 04:23:49 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETHOADON](
	[MAHD] [varchar](10) NOT NULL,
	[MADV] [varchar](10) NOT NULL,
	[SOLUONG] [int] NULL,
 CONSTRAINT [PK_CHITIETHOADON] PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC,
	[MADV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DICHVU]    Script Date: 16/07/2020 04:23:49 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DICHVU](
	[MADV] [varchar](10) NOT NULL,
	[TENDV] [nvarchar](50) NULL,
	[DVT] [nvarchar](20) NULL,
	[DONGIA] [int] NULL,
	[HINHANH] [nvarchar](100) NULL,
	[MALOAIDV] [varchar](10) NULL,
 CONSTRAINT [PK_DICHVU] PRIMARY KEY CLUSTERED 
(
	[MADV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 16/07/2020 04:23:49 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[MAHD] [varchar](10) NOT NULL,
	[NGAYTAO] [date] NULL,
	[MANV] [varchar](10) NULL,
	[MAPHONG] [varchar](10) NULL,
	[THANHTIEN] [int] NULL,
 CONSTRAINT [PK_HOADON] PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 16/07/2020 04:23:49 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MANV] [varchar](10) NOT NULL,
	[HOTEN] [nvarchar](50) NULL,
	[GIOITINH] [nvarchar](4) NULL,
	[NGAYSINH] [date] NULL,
	[DIACHI] [nvarchar](50) NULL,
	[SDT] [varchar](15) NULL,
	[LUONGCB] [int] NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[RPHoaDon]    Script Date: 16/07/2020 04:23:49 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RPHoaDon]
AS
SELECT        dbo.NHANVIEN.HOTEN, dbo.DICHVU.TENDV, dbo.HOADON.MAHD, dbo.CHITIETHOADON.SOLUONG, dbo.DICHVU.DONGIA, dbo.CHITIETHOADON.SOLUONG * dbo.DICHVU.DONGIA AS TONGTIEN
FROM            dbo.CHITIETHOADON INNER JOIN
                         dbo.DICHVU ON dbo.CHITIETHOADON.MADV = dbo.DICHVU.MADV INNER JOIN
                         dbo.HOADON ON dbo.CHITIETHOADON.MAHD = dbo.HOADON.MAHD INNER JOIN
                         dbo.NHANVIEN ON dbo.HOADON.MANV = dbo.NHANVIEN.MANV
GO
/****** Object:  Table [dbo].[CHAMCONG]    Script Date: 16/07/2020 04:23:49 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHAMCONG](
	[MANV] [varchar](10) NOT NULL,
	[NGAYLAM] [date] NOT NULL,
	[CA] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_CHAMCONG] PRIMARY KEY CLUSTERED 
(
	[MANV] ASC,
	[NGAYLAM] ASC,
	[CA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[RPChamCong]    Script Date: 16/07/2020 04:23:49 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RPChamCong]
AS
SELECT        dbo.NHANVIEN.HOTEN, dbo.NHANVIEN.SDT, dbo.NHANVIEN.LUONGCB, COUNT(dbo.CHAMCONG.MANV) AS SOCA, COUNT(dbo.CHAMCONG.MANV) * dbo.NHANVIEN.LUONGCB AS THANHTIEN, MONTH(dbo.CHAMCONG.NGAYLAM) 
                         AS THANG, YEAR(dbo.CHAMCONG.NGAYLAM) AS NAM
FROM            dbo.CHAMCONG INNER JOIN
                         dbo.NHANVIEN ON dbo.CHAMCONG.MANV = dbo.NHANVIEN.MANV
GROUP BY dbo.NHANVIEN.HOTEN, dbo.NHANVIEN.SDT, dbo.NHANVIEN.LUONGCB, MONTH(dbo.CHAMCONG.NGAYLAM), YEAR(dbo.CHAMCONG.NGAYLAM)
GO
/****** Object:  Table [dbo].[PHONG]    Script Date: 16/07/2020 04:23:49 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONG](
	[MAPHONG] [varchar](10) NOT NULL,
	[TENPHONG] [nvarchar](50) NULL,
	[DIENTICH] [varchar](10) NULL,
	[DONGIA] [int] NULL,
	[MAKV] [varchar](10) NULL,
	[TRANGTHAI] [nvarchar](20) NULL,
	[HINHANH] [nvarchar](100) NULL,
 CONSTRAINT [PK_PHONG] PRIMARY KEY CLUSTERED 
(
	[MAPHONG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[RPDoanhThu]    Script Date: 16/07/2020 04:23:49 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RPDoanhThu]
AS
SELECT        dbo.HOADON.MAHD, dbo.HOADON.NGAYTAO, dbo.HOADON.THANHTIEN, dbo.NHANVIEN.HOTEN, dbo.PHONG.TENPHONG, MONTH(dbo.HOADON.NGAYTAO) AS THANG, YEAR(dbo.HOADON.NGAYTAO) AS NAM
FROM            dbo.HOADON INNER JOIN
                         dbo.NHANVIEN ON dbo.HOADON.MANV = dbo.NHANVIEN.MANV INNER JOIN
                         dbo.PHONG ON dbo.HOADON.MAPHONG = dbo.PHONG.MAPHONG
GROUP BY dbo.HOADON.MAHD, dbo.HOADON.NGAYTAO, dbo.HOADON.THANHTIEN, dbo.NHANVIEN.HOTEN, dbo.PHONG.TENPHONG, MONTH(dbo.HOADON.NGAYTAO), YEAR(dbo.HOADON.NGAYTAO)
GO
/****** Object:  Table [dbo].[CTQUYEN]    Script Date: 16/07/2020 04:23:49 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTQUYEN](
	[TENDN] [varchar](30) NOT NULL,
	[MAQUYEN] [varchar](10) NOT NULL,
	[CHUTHICH] [nvarchar](30) NULL,
 CONSTRAINT [PK_CTQUYEN] PRIMARY KEY CLUSTERED 
(
	[TENDN] ASC,
	[MAQUYEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 16/07/2020 04:23:49 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MAKH] [varchar](10) NOT NULL,
	[TENKH] [nvarchar](50) NULL,
	[GIOITINH] [nvarchar](4) NULL,
	[DIACHI] [nvarchar](50) NULL,
	[SDT] [varchar](14) NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MAKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIDICHVU]    Script Date: 16/07/2020 04:23:49 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIDICHVU](
	[MALOAIDV] [varchar](10) NOT NULL,
	[TENLOAIDV] [nvarchar](50) NULL,
 CONSTRAINT [PK_LOAIDICHVU] PRIMARY KEY CLUSTERED 
(
	[MALOAIDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUDATPHONG]    Script Date: 16/07/2020 04:23:49 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUDATPHONG](
	[MAPHIEUDAT] [varchar](10) NOT NULL,
	[MAKH] [varchar](10) NULL,
	[MANV] [varchar](10) NULL,
	[MAPHONG] [varchar](10) NULL,
	[NGAYLAP] [date] NULL,
	[NGAYBD] [date] NULL,
	[NGAYKT] [date] NULL,
 CONSTRAINT [PK_PHIEUDATPHONG] PRIMARY KEY CLUSTERED 
(
	[MAPHIEUDAT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUYEN]    Script Date: 16/07/2020 04:23:49 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUYEN](
	[MAQUYEN] [varchar](10) NOT NULL,
	[TENQUYEN] [nvarchar](30) NULL,
 CONSTRAINT [PK_QUYEN] PRIMARY KEY CLUSTERED 
(
	[MAQUYEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 16/07/2020 04:23:49 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[MANV] [varchar](10) NULL,
	[TENDN] [varchar](30) NOT NULL,
	[MATKHAU] [varchar](30) NULL,
	[TRANGTHAI] [nvarchar](20) NULL,
 CONSTRAINT [PK_TAIKHOAN] PRIMARY KEY CLUSTERED 
(
	[TENDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TANG]    Script Date: 16/07/2020 04:23:49 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TANG](
	[MAKV] [varchar](10) NOT NULL,
	[TENKV] [nvarchar](30) NULL,
 CONSTRAINT [PK_KHUVUC] PRIMARY KEY CLUSTERED 
(
	[MAKV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MADV], [SOLUONG]) VALUES (N'HD001', N'DV001', 10)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MADV], [SOLUONG]) VALUES (N'HD001', N'DV003', 4)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MADV], [SOLUONG]) VALUES (N'HD002', N'DV003', 4)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MADV], [SOLUONG]) VALUES (N'HD002', N'DV004', 6)
INSERT [dbo].[CTQUYEN] ([TENDN], [MAQUYEN], [CHUTHICH]) VALUES (N'ADMIN', N'Q001', N'Không Có')
INSERT [dbo].[CTQUYEN] ([TENDN], [MAQUYEN], [CHUTHICH]) VALUES (N'ADMIN', N'Q002', N'Không Có')
INSERT [dbo].[CTQUYEN] ([TENDN], [MAQUYEN], [CHUTHICH]) VALUES (N'ADMIN', N'Q003', N'Không Có')
INSERT [dbo].[CTQUYEN] ([TENDN], [MAQUYEN], [CHUTHICH]) VALUES (N'bang', N'Q002', N'Không Có')
INSERT [dbo].[CTQUYEN] ([TENDN], [MAQUYEN], [CHUTHICH]) VALUES (N'bang', N'Q003', N'Không Có')
INSERT [dbo].[DICHVU] ([MADV], [TENDV], [DVT], [DONGIA], [HINHANH], [MALOAIDV]) VALUES (N'DV001', N'Bia Tiger', N'Lon', 20000, N'HinhAnh\BiaTiger.jpg', N'LDV003')
INSERT [dbo].[DICHVU] ([MADV], [TENDV], [DVT], [DONGIA], [HINHANH], [MALOAIDV]) VALUES (N'DV002', N'Bia Heineken', N'Lon', 25000, N'HinhAnh\BiaHeniken.jpg', N'LDV003')
INSERT [dbo].[DICHVU] ([MADV], [TENDV], [DVT], [DONGIA], [HINHANH], [MALOAIDV]) VALUES (N'DV003', N'Trái Cây Tô', N'Tô', 100000, N'HinhAnh\TraiCayTo.jpg', N'LDV002')
INSERT [dbo].[DICHVU] ([MADV], [TENDV], [DVT], [DONGIA], [HINHANH], [MALOAIDV]) VALUES (N'DV004', N'Sting', N'Lon', 15000, N'HinhAnh\Sting.jfif', N'LDV001')
INSERT [dbo].[DICHVU] ([MADV], [TENDV], [DVT], [DONGIA], [HINHANH], [MALOAIDV]) VALUES (N'DV005', N'Nước Cam Twister', N'Chai', 22000, N'HinhAnh\NuocCamTwister.jpeg', N'LDV001')
INSERT [dbo].[HOADON] ([MAHD], [NGAYTAO], [MANV], [MAPHONG], [THANHTIEN]) VALUES (N'HD001', CAST(N'2020-07-15' AS Date), N'NV001', N'P001', 4200000)
INSERT [dbo].[HOADON] ([MAHD], [NGAYTAO], [MANV], [MAPHONG], [THANHTIEN]) VALUES (N'HD002', CAST(N'2020-07-15' AS Date), N'NV001', N'P002', 0)
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [GIOITINH], [DIACHI], [SDT]) VALUES (N'KH001', N'Nguyễn Khánh Nam', N'Nam', N'Bình Định', N'(032) 668-5588')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [GIOITINH], [DIACHI], [SDT]) VALUES (N'KH002', N'Nguyễn Ngọc Thảo Nhi', N'Nữ', N'Lâm Đồng', N'(034) 649-5146')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [GIOITINH], [DIACHI], [SDT]) VALUES (N'KH003', N'Trần Ngọc Khánh Chi', N'Nữ', N'Bình Dương', N'(036) 564-5231')
INSERT [dbo].[LOAIDICHVU] ([MALOAIDV], [TENLOAIDV]) VALUES (N'LDV001', N'Nước Giải Khác')
INSERT [dbo].[LOAIDICHVU] ([MALOAIDV], [TENLOAIDV]) VALUES (N'LDV002', N'Hoa Quả')
INSERT [dbo].[LOAIDICHVU] ([MALOAIDV], [TENLOAIDV]) VALUES (N'LDV003', N'Bia')
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [GIOITINH], [NGAYSINH], [DIACHI], [SDT], [LUONGCB]) VALUES (N'NV001', N'Trần Thị Thanh Vân', N'Nữ', CAST(N'1999-07-27' AS Date), N'An Giang', N'(032) 694-5295', 100000)
INSERT [dbo].[NHANVIEN] ([MANV], [HOTEN], [GIOITINH], [NGAYSINH], [DIACHI], [SDT], [LUONGCB]) VALUES (N'NV002', N'Đào Nguyễn Huy Bằng', N'Nam', CAST(N'1998-02-25' AS Date), N'Bình Định', N'(032) 668-5588', 90000)
INSERT [dbo].[PHIEUDATPHONG] ([MAPHIEUDAT], [MAKH], [MANV], [MAPHONG], [NGAYLAP], [NGAYBD], [NGAYKT]) VALUES (N'PD001', N'KH001', N'NV001', N'P001', CAST(N'2020-07-12' AS Date), CAST(N'2020-07-12' AS Date), CAST(N'2020-07-15' AS Date))
INSERT [dbo].[PHIEUDATPHONG] ([MAPHIEUDAT], [MAKH], [MANV], [MAPHONG], [NGAYLAP], [NGAYBD], [NGAYKT]) VALUES (N'PD002', N'KH003', N'NV001', N'P002', CAST(N'2020-07-15' AS Date), CAST(N'2020-07-15' AS Date), NULL)
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P001', N'Phòng 101', N'45m2', 1200000, N'T001', N'Trống', N'HinhAnh\Phong1.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P002', N'Phòng 102', N'46m2', 1250000, N'T001', N'Đã Đặt', N'HinhAnh\phong2.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P003', N'Phòng 103', N'44m2', 1050000, N'T001', N'Trống', N'HinhAnh\phong3.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P004', N'Phòng 104', N'44m2', 1200000, N'T001', N'Trống', N'HinhAnh\phong4.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P005', N'Phòng 105', N'47m2', 1400000, N'T001', N'Trống', N'HinhAnh\phong5.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P006', N'Phòng 201', N'47m2', 1450000, N'T002', N'Trống', N'HinhAnh\phong6.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P007', N'Phòng 202', N'44m2', 1350000, N'T002', N'Trống', N'HinhAnh\phong7.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P008', N'Phòng 203', N'48m2', 1500000, N'T002', N'Trống', N'HinhAnh\phong8.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P009', N'Phòng 204', N'42m2', 1250000, N'T002', N'Trống', N'HinhAnh\phong9.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P010', N'Phòng 205', N'46m2', 1450000, N'T002', N'Trống', N'HinhAnh\phong10.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P011', N'Phòng 301', N'46m2', 1400000, N'T003', N'Trống', N'HinhAnh\phong11.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P012', N'Phòng 302', N'44m2', 1350000, N'T003', N'Trống', N'HinhAnh\phong12.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P013', N'Phòng 303', N'42m2', 1300000, N'T003', N'Trống', N'HinhAnh\phong13.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P014', N'Phòng 304', N'44m2', 1400000, N'T003', N'Trống', N'HinhAnh\phong14.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P015', N'Phòng 305', N'42m2', 1300000, N'T003', N'Trống', N'HinhAnh\phong15.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P016', N'Phòng 401', N'44m2', 1400000, N'T004', N'Trống', N'HinhAnh\phong16.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P017', N'Phòng 402', N'45m2', 1500000, N'T004', N'Trống', N'HinhAnh\phong17.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P018', N'Phòng 403', N'45m2', 1550000, N'T004', N'Trống', N'HinhAnh\phong18.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P019', N'Phòng 404', N'43m2', 1400000, N'T004', N'Trống', N'HinhAnh\phong19.jpg')
INSERT [dbo].[PHONG] ([MAPHONG], [TENPHONG], [DIENTICH], [DONGIA], [MAKV], [TRANGTHAI], [HINHANH]) VALUES (N'P020', N'Phòng 405', N'45m2', 1550000, N'T004', N'Trống', N'HinhAnh\phong20.jpg')
INSERT [dbo].[QUYEN] ([MAQUYEN], [TENQUYEN]) VALUES (N'Q001', N'Quản Lý')
INSERT [dbo].[QUYEN] ([MAQUYEN], [TENQUYEN]) VALUES (N'Q002', N'Đặt Phòng')
INSERT [dbo].[QUYEN] ([MAQUYEN], [TENQUYEN]) VALUES (N'Q003', N'Thống Kê')
INSERT [dbo].[TAIKHOAN] ([MANV], [TENDN], [MATKHAU], [TRANGTHAI]) VALUES (N'NV001', N'ADMIN', N'225102205773186', N'Hoạt Động')
INSERT [dbo].[TAIKHOAN] ([MANV], [TENDN], [MATKHAU], [TRANGTHAI]) VALUES (N'NV002', N'bang', N'225102205773186', N'Hoạt Động')
INSERT [dbo].[TANG] ([MAKV], [TENKV]) VALUES (N'T001', N'Tầng 1')
INSERT [dbo].[TANG] ([MAKV], [TENKV]) VALUES (N'T002', N'Tầng 2')
INSERT [dbo].[TANG] ([MAKV], [TENKV]) VALUES (N'T003', N'Tâng 3')
INSERT [dbo].[TANG] ([MAKV], [TENKV]) VALUES (N'T004', N'Tầng 4')
ALTER TABLE [dbo].[CHAMCONG]  WITH CHECK ADD  CONSTRAINT [FK_CHAMCONG_NHANVIEN] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CHAMCONG] CHECK CONSTRAINT [FK_CHAMCONG_NHANVIEN]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETHOADON_DICHVU] FOREIGN KEY([MADV])
REFERENCES [dbo].[DICHVU] ([MADV])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CHITIETHOADON_DICHVU]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETHOADON_HOADON] FOREIGN KEY([MAHD])
REFERENCES [dbo].[HOADON] ([MAHD])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CHITIETHOADON_HOADON]
GO
ALTER TABLE [dbo].[CTQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_CTQUYEN_QUYEN] FOREIGN KEY([MAQUYEN])
REFERENCES [dbo].[QUYEN] ([MAQUYEN])
GO
ALTER TABLE [dbo].[CTQUYEN] CHECK CONSTRAINT [FK_CTQUYEN_QUYEN]
GO
ALTER TABLE [dbo].[CTQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_CTQUYEN_TAIKHOAN] FOREIGN KEY([TENDN])
REFERENCES [dbo].[TAIKHOAN] ([TENDN])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CTQUYEN] CHECK CONSTRAINT [FK_CTQUYEN_TAIKHOAN]
GO
ALTER TABLE [dbo].[DICHVU]  WITH CHECK ADD  CONSTRAINT [FK_DICHVU_LOAIDICHVU] FOREIGN KEY([MALOAIDV])
REFERENCES [dbo].[LOAIDICHVU] ([MALOAIDV])
GO
ALTER TABLE [dbo].[DICHVU] CHECK CONSTRAINT [FK_DICHVU_LOAIDICHVU]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_NHANVIEN] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_NHANVIEN]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_PHONG] FOREIGN KEY([MAPHONG])
REFERENCES [dbo].[PHONG] ([MAPHONG])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_PHONG]
GO
ALTER TABLE [dbo].[PHIEUDATPHONG]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUDATPHONG_KHACHHANG] FOREIGN KEY([MAKH])
REFERENCES [dbo].[KHACHHANG] ([MAKH])
GO
ALTER TABLE [dbo].[PHIEUDATPHONG] CHECK CONSTRAINT [FK_PHIEUDATPHONG_KHACHHANG]
GO
ALTER TABLE [dbo].[PHIEUDATPHONG]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUDATPHONG_NHANVIEN] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[PHIEUDATPHONG] CHECK CONSTRAINT [FK_PHIEUDATPHONG_NHANVIEN]
GO
ALTER TABLE [dbo].[PHIEUDATPHONG]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUDATPHONG_PHONG] FOREIGN KEY([MAPHONG])
REFERENCES [dbo].[PHONG] ([MAPHONG])
GO
ALTER TABLE [dbo].[PHIEUDATPHONG] CHECK CONSTRAINT [FK_PHIEUDATPHONG_PHONG]
GO
ALTER TABLE [dbo].[PHONG]  WITH CHECK ADD  CONSTRAINT [FK_PHONG_TANG] FOREIGN KEY([MAKV])
REFERENCES [dbo].[TANG] ([MAKV])
GO
ALTER TABLE [dbo].[PHONG] CHECK CONSTRAINT [FK_PHONG_TANG]
GO
ALTER TABLE [dbo].[TAIKHOAN]  WITH CHECK ADD  CONSTRAINT [FK_TAIKHOAN_NHANVIEN] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TAIKHOAN] CHECK CONSTRAINT [FK_TAIKHOAN_NHANVIEN]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CHAMCONG"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 224
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "NHANVIEN"
            Begin Extent = 
               Top = 6
               Left = 262
               Bottom = 136
               Right = 448
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RPChamCong'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RPChamCong'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "HOADON"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "NHANVIEN"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PHONG"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 136
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RPDoanhThu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RPDoanhThu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CHITIETHOADON"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DICHVU"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "HOADON"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 136
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "NHANVIEN"
            Begin Extent = 
               Top = 6
               Left = 662
               Bottom = 136
               Right = 832
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RPHoaDon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RPHoaDon'
GO
USE [master]
GO
ALTER DATABASE [QLKhachSan] SET  READ_WRITE 
GO
