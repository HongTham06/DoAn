CREATE DATABASE BS_Fahasa
go
USE BS_Fahasa
go

CREATE TABLE ChuDe
(
	MaCD char(6) NOT NULL,
	TenCD NVARCHAR(30) ,
	Constraint PK_CD primary key(MaCD)	
)
go
CREATE TABLE ChiNhanh
(
	MaCN char(6) NOT NULL,
	TenChiNhanh NVARCHAR(200),
	DiaChi nvarchar(200),
	Constraint PK_CN primary key(MaCN)
	
)
CREATE TABLE NhaXuatBan
(
	MaNXB char(6) NOT NULL,
	TenNXB NVARCHAR(100) ,
	Constraint PK_NXB primary key(MaNXB)
)
GO
CREATE TABLE NhanVien
(
	MaNV char(6) NOT NULL,
	HoTen NVARCHAR(30) ,
	NgaySinh date,
	GioiTinh nvarchar(4),
	DiaChi nvarchar(40),
	MaCN char(6),
	Constraint PK_NV primary key(MaNV),
	Constraint FK_NV_CN foreign key (MaCN) references ChiNhanh(MaCN)
)
GO
CREATE TABLE Sach
(
	MaSach char(6) NOT NULL,
	TenSach NVARCHAR(100) ,
	TenTG NVARCHAR(40) ,
	GiaBan int,
	SoLanBan int,
	NamXB int,
	MaCD char(6),
	MaNXB char(6),
	Constraint PK_Sach primary key(MaSach),
	Constraint FK_S_CD foreign key (MaCD) references CHUDE(MaCD),
	Constraint FK_S_NXB foreign key (MaNXB) references NhaXuatBan(MaNXB)
)

go
CREATE TABLE KhachHang
(
	MaKH char(6) NOT NULL,
	HoTen NVARCHAR(40) ,
	DiaChi NVARCHAR(40) ,
	Constraint PK_KH primary key(MaKH),
)
GO
CREATE TABLE DonHang
(
	MaDH char(6) NOT NULL,
	NgayGiao datetime,
	NgayDH datetime,
	TinhTrangGH nvarchar(30),
	MaKH char(6),
	MaNV char(6),
	ThanhToan int,
	Constraint PK_DH primary key(MaDH),
	Constraint FK_DH_KH foreign key (MAKH) references KhachHang(MaKH),
	Constraint FK_DH_NV foreign key (MANV) references NhanVien(MaNV)
)

GO
CREATE TABLE ChiTietDH
(
	MaDH char(6) NOT NULL,
	MaSach char(6) NOT NULL,
	SoLuong int,
	DonGia int,
	ThanhTien int,
	Constraint PK_CTDH primary key(MaDH,MaSach),
	Constraint FK_CTDH_DH foreign key (MaDH) references DonHang(MaDH),
	Constraint FK_CTDH_S foreign key (MaSach) references Sach(MaSach)
)
go


--trigger cập nhật tổng thành tiền ở DonHang

CREATE TRIGGER TRG_THANHTOAN_DH ON ChiTietDH
AFTER INSERT, UPDATE, DELETE
AS
	/*BEGIN
		UPDATE ChiTietPN
		SET THANHTIEN = INS.SOlUONG* INS.DONGIA
		FROM DonHang CTPN, inserted INS
		WHERE CTPN.MADH = INS.MADH
	END*/
	BEGIN
		UPDATE DonHang
		SET THANHTOAN = (SELECT SUM(ChiTietDH.THANHTIEN) FROM ChiTietDH WHERE DH.MADH = ChiTietDH.MADH GROUP BY ChiTietDH.MADH)
		FROM DonHang DH, ChiTietDH CTDH
		WHERE DH.MaDH= CTDH.MaDH
	END
GO

INSERT INTO ChuDe
VALUES ('AN',N'Âm nhạc'),
		('CT',N'Chính trị'),
		('KHKT',N'Khoa học kỹ thuật'),
		('KT',N'Kinh tế'),
		('NDC',N'Nuôi dạy con'),
		('NN', N'Ngoại ngữ'),
		('TL-KNS',N'Tâm lý - kĩ năng sống'),
		('VHTN',N'Văn học trong nước'),
		('VHNN',N'Văn học nước ngoài'),
		('LD',N'Làm Đẹp'),
		('KHXH',N'Khoa học xã hội'),
		('TCGD',N'Tình cảm gia đình'),
		('NA',N'Nấu ăn'),
		('VH',N'Văn hóa'),
		('DN',N'Doanh nhân')
GO

INSERT INTO CHINHANH
VALUES ('CN001',N'Fahasa Bình Tân',N'Siêu thị Co.op Mart Bình Tân (Lầu 2) - Số 158 đường 19, Q. Bình Tân, TP.HCM'),
		('CN002',N'Fahasa Tân Phú',N'Trung tâm Thương Mại Aeon - Tân Phú Celadon (Lầu 1), 30 Bờ Bao Tân Thắng, P.Sơn Kỳ, Q.Tân Phú, TP.HCM'),
		('CN003',N'Fahasa Phạm Văn Đồng',N'TTTM Sense City Phạm Văn Đồng, Số 240, 242 Kha Vạn Cân, Phường Hiệp Bình Chánh, Quận Thủ Đức, TP.HCM'),
		('CN008',N'Fahasa An Giang',N'Số 12 Nguyễn Huệ (Tầng 3 Siêu thị Co.op Mart), P Mỹ Long, Thành phố Long Xuyên, Tỉnh An Giang'),
		('CN004',N'Fahasa Vũng Tàu',N'Số 36 Nguyễn Thái Học (tầng 1, Sthị Co.op Mart VTàu), P7, Thành Phố Vũng Tàu, Tỉnh Bà Rịa - Vũng Tàu'),
		('CN005',N'Fahasa Vĩnh Long',N'Tầng 1, Siêu thị Coop Mart Số 26 đường 3/2 phường 1, Thành phố Vĩnh Long, Tỉnh Vĩnh Long'),
		('CN006',N'Fahasa Đà Nẵng',N'300, 302 Lê Duẩn, Phường Tân Chính, Quận Thanh Khê, TP.Đà Nẵng'),
		('CN007',N'Fahasa Quang Trung',N'TTTM Vincom Quang Trung (Lầu 1) - Số 190 Quang Trung, Phường 10, Quận Gò Vấp, TP.HCM'),
		('CN009',N'Fahasa Tân Định',N'387-389 Hai Bà Trưng, Q.3, TP.HCM'),
		('CN010',N'Fahasa Hà Nội',N'338 Phố Xã Đàn, P. Phương Liên, Q. Đống Đa, TP.Hà Nội'),
		('CN011',N'Fahasa Huế',N'Siêu thị Co.op Mart Huế (Tầng 2) - 06 Trần Hưng Đạo, TP.Huế'),
		('CN012',N'Fahasa Nha Trang',N'11 Lý Thánh Tôn, Vạn Thạnh, Thành phố Nha Trang, Tỉnh Khánh Hòa'),
		('CN013',N'Fahasa Cà Mau',N'03 Lưu Tấn Tài, P. 5, TP. Cà Mau, Tỉnh Cà Mau'),
		('CN014',N'Fahasa Bình Dương',N'Siêu Thị Co.op Mart Bình Dương (Lầu 1), đường 30/4, TP. Thủ Dầu Một, Tỉnh Bình Dương')	
GO

INSERT INTO NHANVIEN
VALUES ('NV001',N'Nguyễn Văn Khải','12-05-1998',N'Nam',N'HCM','CN001'),
		('NV002',N'Nguyễn Văn Thái','12-05-1998',N'Nam',N'HCM','CN001'),
		('NV003',N'Nguyễn Văn Tùng','12-06-1998',N'Nam',N'HCM','CN002'),
		('NV004',N'Nguyễn Thị Thu','12-05-1998',N'Nữ',N'Tây Ninh','CN001'),
		('NV005',N'Nguyễn Thị Anh Thư','12-05-1998',N'Nữ',N'Tây Ninh','CN002')
GO

INSERT INTO KhachHang
VALUES 
('KH001 ', N'Võ Hoàng Thuận', N'TP.HCM'),
('KH002 ', N'Trần Thị Thanh Vân', N'An Giang'),
('KH003 ', N'Nguyễn Phi Nhung', N'Tây Ninh'),
('KH004 ', N'Đỗ Thị Hồng Thắm', N'Phú Yên'),
('KH005 ', N'Trần Nguyễn Trọng Tuyển', N'Bến Tre'),
('KH006 ', N'Phạm Quốc Nhiên', N'Bến Tre'),
('KH007 ', N'Nguyễn Hoài Sang', N'TP.HCM'),
('KH008 ', N'Nguyễn Hoài Lâm', N'TP.HCM'),
('KH009 ', N'Nguyễn Văn Vũ', N'TP.HCM'),
('KH010 ', N'Nguyễn Thanh Đông', N'TP.HCM'),
('KH011 ', N'Nguyễn Hoài Lâm', N'TP.HCM'),
('KH012 ', N'Nguyễn Văn Vũ', N'TP.HCM'),
('KH013 ', N'Nguyễn Thanh Đông', N'TP.HCM'),
('KH014 ', N'Nguyễn Thanh Khánh', N'TP.HCM'),
('KH015 ', N'Nguyễn Khải Siêu', N'TP.HCM'),
('KH016 ', N'Nguyễn Thị Quỳnh Như', N'TP.HCM'),
('KH026', N'Trần Thị Tuyết Anh', N'TP.HCM'),
('KH017', N'Nguyễn Đức Phúc', N'TP.HCM'),
('KH018', N'Trần Thị Thu Phương', N'TP.HCM'),
('KH019', N'Nguyễn Hữu Thiện', N'TP.HCM'),
('KH020', N'Thị Hoài Thương', N'TP.HCM'),
('KH021', N'Trần Đức Tài', N'TP.HCM'),
('KH022', N'Phạm Anh Tuấn', N'TP.HCM'),
('KH023', N'Ngô Bảo Vân', N'TP.HCM'),
('KH024', N'Trần Trí Việt', N'TP.HCM'),
('KH025', N'Ngô Bảo Lâm Phong', N'TP.HCM')	
GO

--dữ liệu test thêm
--INSERT [dbo].[NhaXuatBan]  VALUES (N'NXB001', N'NXB Văn hóa Văn nghệ')

INSERT INTO NhaXuatBan
VALUES ('NXB001', N'NXB Văn hóa Văn nghệ'),
('NXB002', N'Bách Việt'),
('NXB003', N'NXB Trẻ'),
('NXB004', N'NXB Tổng Hợp TPHCM'),
('NXB005', N'NXB Văn hóa Văn nghệ'),
('NXB006', N'NXB Phụ Nữ Phái Đẹp'),
('NXB007', N'NXB Khoa Học Kỹ Thuật'),
('NXB008', N'NXB Kim Đồng'),
('NXB009', N'NXB Lao Động'),
('NXB010', N'NXB Xây Dựng'),
('NXB011', N'NXB Quân Đội Nhân Dân'),
('NXB012', N'NXB Thông Tấn'),
('NXB013', N'NXB Thể Dục Thể Thao'),
('NXB014', N'NXB Phương Đông'),
('NXB015', N'NXB Tri Thức'),
('NXB016', N'NXB Thanh Niên'),
('NXB017', N'NXB Mỹ Thuật')
GO

--dữ liệu test thêm
--INSERT [dbo].[Sach]  VALUES ('SH021', N'NXB Văn hóa Văn nghệ',N'Tố Hữu',68000,2,2013,'VH','NXB001')

INSERT INTO Sach
VALUES('SH001', N'Con nhà nghèo', N'Hồ Biểu Chánh', 79000, 2, 2020, 'VH', 'NXB001'),
('SH002', N'Con nhà giàu', N'Hồ Biểu Chánh', 78000, 1, 2020, 'VH', 'NXB001'),
('SH003', N'Dòng sông cuộn chảy', N'Trần Thế Tuyển', 64000, 10, 2020, N'VH', 'NXB004'),
('SH004', N'Tuổi 40 yêu dấu', N'Ann Lee', 80000, 100, 2020, 'VH', 'NXB003'),
('SH005', N'Từ Tốt Đến Vĩ Đại ', N'Jim Collins', 94000, 50, 2019, 'KT', 'NXB003'),
('SH006', N'Nếu Tôi Biết Được Khi Còn 20', N'Tina Seelig', 52000, 15, 2019, 'KT', N'NXB003'),
('SH007', N'Vũ Điệu Của Làn Da', N'Okyanmama', 40000, 26, 2020, 'LD', N'NXB001'),
('SH008', N'Hỏi Đáp Về Mọi Chuyện - Chủ Đề Khoa Học Xã Hội', N'Nguyễn Lân Dũng', 60000, 20, 1997, 'KHXH', 'NXB001'),
('SH009', N'Những Nhà Khám Phá', N'Daniel J. Boorstin', 167000, 27, 2020, 'VHNN', 'NXB002'),
('SH010', N'Bí Mật Của Nước', N'Masaru Emoto', 107000, 29, 2012, 'VHNN', 'NXB002'),
('SH011', N'Ngẫu Hứng Vào Bếp', N'Phan Thắng Thái Hòa', 104000, 2, 2016, 'LD', 'NXB002'),
('SH012', N'Phụ Nữ Là Phải Đẹp', N'Okyanmama', 39000, 29, 2019, 'LD', 'NXB005'),
('SH013', N'Xã Hội Việt Nam', N'Lương Đức Hiệp', 39000, 25, 2017, 'VHTN', 'NXB007'),
('SH014', N'Ẩm Thực-Con Dao Hai Lưỡi', N'Yun WuXin', 250000, 20, 2017, 'NA', 'NXB006'),
('SH015', N'Cha và Con', N'Tony Parsons', 65000,40, 2020, 'VHNN', 'NXB006'),
('SH016', N'Hãy Chăm Sóc Mẹ', N'Shin Kyung-sook', 39000, 21, 2020, 'VHNN', 'NXB007'),
('SH017', N'Con Trở Thành Siêu Đầu Bếp', N'Nguyễn Mạnh Cường', 40000, 38, 2020, 'NA', 'NXB008'),
('SH018', N'Việt Nam Phong Tục', N'Phan Kế Bình', 39000, 21, 2020, 'VHTN', 'NXB001'),
('SH019', N'Đẹp Lên Cái Đã Rồi Đời Sẽ Vui', N'Giovanna Battaglia', 39000, 35, 2020, 'LD', 'NXB009'),
('SH020', N'Việt Nam Văn Hóa Sử Cương', N'Đào Duy Anh', 39000, 40, 2020, 'VHTN', 'NXB006')
GO

-- dữ liệu test thêm
--INSERT [dbo].DonHang values ('DH021','06-04-2020','01-02-2020',N'Chưa giao', N'KH009','NV002', 0)
--INSERT [dbo].DonHang values ('DH022','06-04-2020','01-02-2020',N'Chưa giao', N'KH002','NV002', 0)

set dateformat dmy
INSERT INTO DonHang
VALUES ('DH014','02-02-2020','01-01-2020', N'Đã giao', N'KH001','NV001', 0),
('DH001','02-02-2020','01-01-2020', N'Đã giao', N'KH001','NV001', 0),
('DH002','03-02-2020','02-01-2020', N'Đã giao', N'KH002','NV001', 0),
('DH003','04-02-2020','03-01-2020', N'Đã giao', N'KH003','NV001', 0),
('DH004','05-02-2020','04-01-2020', N'Đã giao', N'KH001','NV001', 0),
('DH005','06-02-2020','04-01-2020', N'Đã giao', N'KH002','NV001', 0),
('DH006','07-02-2020','04-01-2020', N'Đã giao', N'KH003','NV001', 0),
('DH007','08-02-2020','04-01-2020', N'Đã giao', N'KH001','NV001', 0),
('DH008','09-02-2020','05-01-2020', N'Đã giao', N'KH002','NV001', 0),
('DH009','03-02-2020','06-01-2020', N'Đã giao', N'KH002','NV001', 0),
('DH010','03-02-2020','01-02-2020', N'Đã giao', N'KH004','NV001', 0),
('DH011','04-02-2020','01-02-2020', N'Đã giao', N'KH004','NV001', 0),
('DH012','05-02-2020','01-02-2020', N'Đã giao', N'KH005','NV001', 0),
('DH013','06-02-2020','01-02-2020', N'Đã giao', N'KH005','NV001', 0),
('DH015','06-02-2020','01-02-2020', N'Đã giao', N'KH005','NV002', 0),
('DH016','06-02-2020','01-02-2020', N'Đã giao', N'KH005','NV002', 0),
('DH017','06-02-2020','01-02-2020', N'Đã giao', N'KH005','NV002', 0),
('DH018','06-02-2020','01-02-2020', N'Đã giao', N'KH005','NV002', 0),
('DH019','06-02-2020','01-02-2020', N'Đã giao', N'KH005','NV002', 0),
('DH020','06-02-2020','01-02-2020', N'Đã giao', N'KH005','NV002', 0)
GO

-- dữ liệu test thêm

--INSERT [dbo].ChiTietDH values ('DH015','SH003 ', 1, 85000,0)
--INSERT [dbo].ChiTietDH values ('DH022','SH009', 1, 85000,0)

INSERT INTO ChiTietDH
VALUES ('DH001','SH007', 2, 85000,0),
('DH001','SH001 ', 1, 15000,0),
('DH001','SH002 ', 1, 15000,0),
('DH001','SH003 ', 1, 15000,0),
('DH002','SH001 ', 2, 15000,0),
('DH002','SH007 ', 1, 15000,0),
('DH003','SH001 ', 1, 45000,0),
('DH003','SH002 ', 1, 45000,0),
('DH003','SH003 ', 1, 55000,0),
('DH004','SH006 ', 1, 15000,0),
('DH004','SH005 ', 1, 15000,0),
('DH005','SH002 ', 1, 85000,0),
('DH005','SH003 ', 1, 85000,0),
('DH005','SH004 ', 1, 85000,0),
('DH006','SH007 ', 1, 85000,0),
('DH006','SH008 ', 1, 85000,0),
('DH007','SH001 ', 1, 85000,0),
('DH007','SH002 ', 1, 85000,0),
('DH007','SH003 ', 1, 85000,0),
('DH015','SH003 ', 1, 85000,0),
('DH016','SH003 ', 1, 85000,0),
('DH021','SH003 ', 1, 85000,0)
GO


--Thủ tục cập nhật giá sách cho bảng chitietDH
CREATE PROC UPDATE_GIASACH
AS
BEGIN
	UPDATE ChiTietDH
	SET DONGIA = (SELECT GIABAN FROM SACH WHERE SACH.MaSach = ChiTietDH.MaSach)
END
go
EXEC  UPDATE_GIASACH
go

--Thủ tục cập nhật thành tiền của đơn hàng (SoLuong * DonGia)
CREATE PROC UPDATE_THANHTIEN_DH
AS
BEGIN
	update ChiTietDH
	set ThanhTien =SoLuong* DonGia
END
GO
EXEC UPDATE_THANHTIEN_DH
go

--View danh sách chủ đề theo mã sách
CREATE VIEW D_CHUDE
AS
SELECT DISTINCT(CD.MACD), CD.TENCD
FROM CHUDE CD JOIN Sach S ON CD.MACD = S.MACD
go
select * from D_CHUDE
GO

--View danh sách NXB theo mã sách
CREATE VIEW D_NHAXUATBAN
AS
SELECT DISTINCT(NXB.MANXB), NXB.TENNXB
FROM NhaXuatBan NXB JOIN Sach S ON NXB.MaNXB = S.MaNXB
GO
select * from D_NHAXUATBAN
GO

--View danh sách SACH được bán
CREATE VIEW D_SACH
AS
SELECT DISTINCT(S.MaSach), S.TenSach,S.TenTG, S.SoLanBan,S.GiaBan, S.NamXB,S.MaNXB, S.MaCD
FROM Sach S JOIN ChiTietDH CTDH ON CTDH.MaSach = S.MaSach
GO
select * from D_SACH
GO

--View danh sách CHINHANH theo nhân viên
CREATE VIEW D_CHINHANH
AS
SELECT DISTINCT(CN.MACN), CN.TenChiNhanh, CN.DIACHI
FROM ChiNhanh CN JOIN NhanVien NV ON CN.MaCN = NV.MaCN
go
select * from D_CHINHANH
go

--View danh sách NHANVIEN bán hàng

CREATE VIEW D_NHANVIEN
AS
SELECT DISTINCT(NV.MaNV), NV.HoTen, NV.MaCN
FROM NhanVien NV JOIN DonHang DH ON NV.MaNV = DH.MaNV
JOIN ChiTietDH CTDH ON CTDH.MaDH = DH.MaDH
go
select * from D_NhanVien
GO

--View danh sách KHACHHANG mua hàng
CREATE VIEW D_KHACHHANG
AS
SELECT DISTINCT(KH.MAKH), KH.HoTen, KH.DiaChi
FROM KhachHang KH JOIN DonHang DH ON DH.MaKH = KH.MaKH
JOIN ChiTietDH CTDH ON CTDH.MaDH = DH.MaDH
go
select * from D_KHACHHANG
GO

--View FACT phân tích
CREATE VIEW V_FACT
AS
SELECT  Distinct(S.MaSach),(KH.MAKH),(NV.MANV),(DH.NgayDH),CTDH.SoLuong,CTDH.DonGia,CTDH.ThanhTien
FROM Sach S JOIN ChiTietDH CTDH ON CTDH.MaSach = S.MaSach
	JOIN DonHang DH ON DH.MaDH = CTDH.MADH
	JOIN KhachHang KH ON KH.MAKH = DH.MaKH
	JOIN NhanVien NV ON NV.MANV = DH.MaNV
go

select * from V_FACT
go
--DROP VIEW V_FACT

go
	select * from ChiNhanh
	select * from ChuDe
	select * from NhaXuatBan
	select * from NhanVien
	select * from Sach
	select * from DonHang
	select * from ChiTietDH
	select * from KhachHang
go
/*	ALTER PROC UPDATE_THANHTIEN
AS
BEGIN
	UPDATE ChiTietPN
	SET THANHTIEN = (SELECT DGNhap * SLNhap from ChiTietPN CTPN)
END
GO
EXEC UPDATE_THANHTIEN
*/

GO
--Phân quyền và nhóm quyền truy cập
Create Role NhanVien --Quyền nhân viên
--
Go
--
create login NV001 with password='123'
create user NV001 for login NV001 
execute sp_addrolemember 'NhanVien','NV001'
exec sp_addsrvrolemember 'NV001', 'sysadmin'

create view DanhSachDB
as
 select name from sys.databases
go

create proc KiemTraDangNhap
@tenlogin nvarchar(50)
as
declare @tenuser nvarchar(50)
select @tenuser= NAME  from sys.sysusers where  sid  = SUSER_SID(@tenlogin)
select  username =  @tenuser,
 TENNHOM=NAME 
 from sys.sysusers
 WHERE UID = (select GROUPUID 
			from sys.SYSMEMBERS
			where MEMBERUID = (select  UID from sys.sysusers
								where NAME =@tenuser))




	

