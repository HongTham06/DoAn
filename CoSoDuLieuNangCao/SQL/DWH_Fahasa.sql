CREATE DATABASE DWH_Fahasa2
go
USE DWH_Fahasa2
go
CREATE TABLE  Dim_ChuDe
(
	MaCD char(6) not null,
	TenCD nvarchar(40),
	constraint pk_CD primary key (MaCD),
)
go
CREATE TABLE  Dim_NhaXuatBan
(
	MaNXB char(6) not null,
	TenNXB nvarchar(40),
	constraint PK_NXB primary key (MaNXB)
)
go
CREATE TABLE  Dim_Sach
(
	MaSach char(6) not null,
	TenSach nvarchar(100),
	TenTG nvarchar(40),
	SoLanBan int,
	GiaBan int,
	NamXB int,
	MaNXB char(6),
	MaCD char(6),
	constraint FK_sach primary key (MaSach),
	Constraint FK_S_CD foreign key (MaCD) references Dim_ChuDe(MaCD),
	Constraint FK_S_NXB foreign key (MaNXB) references Dim_NhaXuatBan(MaNXB)
)
go
CREATE TABLE  Dim_KhachHang
(
	MaKH char(6) not null,
	HoTen nvarchar(40),
	DiaChi nvarchar(40),
	constraint PK_KH primary key (MaKH),
	
)
go
CREATE TABLE  Dim_ChiNhanh
(
	MaCN char(6) not null,
	TenChiNhanh nvarchar(200),
	DiaChi nvarchar(200),
	constraint PK_CN primary key (MaCN),
)
go
CREATE TABLE  Dim_NhanVien
(
	MaNV char(6) not null,
	HoTen nvarchar(30),
	MaCN char(6),
	constraint PK_NV primary key (MaNV),
	Constraint FK_NV_CN foreign key (MaCN) references Dim_ChiNhanh(MaCN)
)
go
CREATE TABLE  Dim_Time
(
	NgayBan datetime not null primary key,
	ThangBan int,
	NamBan int,
	QuyBan int,
)
go
CREATE TABLE FACT
(
	MaSach char(6) not null,
	MaKH char(6) not null,
	MaNV char(6) not null,
	NgayBan datetime,
	SoLuong int,
	DonGia int,
	ThanhTien int,
	constraint FK_fact primary key (MaSach,MaKH,MaNV,NgayBan),
	Constraint FK_S_fact foreign key (MaSach) references Dim_Sach(MaSach),
	Constraint FK_F_S foreign key (MaKH) references Dim_KhachHang(MaKH),
	Constraint FK_F_NV foreign key (MaNV) references Dim_NhanVien(MaNV),
	--Constraint FK_F_T foreign key (NgayBan) references Dim_Time(NgayBan) nối khóa ngoại bằng công cụ
)

GO

/*create proc load_KH
as
begin
	insert into Dim_KhachHang
	select * from NhaSachFahasha_TacNghiep.dbo.D_KHACHHANG
end
go
*/

create proc load_CD
as
begin
	
	insert into Dim_ChuDe
	select * from BS_Fahasa.dbo.D_CHUDE
end
go
exec load_CD
GO

create proc load_NXB
as
begin

	insert into Dim_NhaXuatBan
	select * from BS_Fahasa.dbo.D_NHAXUATBAN
end
go
exec load_NXB
GO

create proc load_S
as
begin
	
	insert into Dim_Sach
	select * from BS_Fahasa.dbo.D_SACH
end
go
exec load_S
GO

create proc load_CN
as
begin

	insert into Dim_ChiNhanh
	select * from BS_Fahasa.dbo.D_CHINHANH
end
go
exec load_CN
GO

create proc load_NV
as
begin

	insert into Dim_NhanVien
	select * from BS_Fahasa.dbo.D_NHANVIEN
end
go
exec load_NV
GO

create proc load_KH
as
begin

	insert into Dim_KhachHang
	select * from BS_Fahasa.dbo.D_KHACHHANG
end
go
exec load_KH
GO

create proc load_FACT
as
begin
	
	insert into FACT
	select * from BS_Fahasa.dbo.V_FACT
end
go
exec load_FACT
GO


/*create proc load_Time
as
begin
	insert into Dim_Time
	select * from BS_Fahasa.dbo.D_Time
end
go
exec load_Time
GO*/



--Tự tạo thời gian chạy từ ngày bán nhỏ nhất tới ngày bán lớn nhất trong bảng FACT
CREATE PROC autoTime
AS
	BEGIN
	delete from Dim_Time
		Declare @SmallDate datetime
		Declare @MaxDate datetime
			Select @Smalldate = min(NgayBan) from FACT
			Select @MaxDate = max(NgayBan) from FACT
			While (@SmallDate <= @MaxDate )
		BEGIN
			Insert into Dim_Time values (@SmallDate, MONTH(@SmallDate), YEAR(@SmallDate), DATEPART(QUARTER, @SmallDate))
			Set @SmallDate = @SmallDate +1
		END
	END
go
Exec autoTime
go

select * from FACT
select * from Dim_Time
select * from Dim_ChiNhanh
select * from Dim_KhachHang
select * from Dim_NhanVien
select * from Dim_Sach
select * from Dim_ChuDe
select * from Dim_NhaXuatBan

go
create proc delete_All
as
begin
	delete from fact
	delete from Dim_KhachHang
	delete from Dim_Sach
	delete from Dim_Time
	delete from Dim_ChuDe
	delete from Dim_NhaXuatBan
	delete from Dim_NhanVien
	delete from Dim_ChiNhanh
end
go
create proc themCD
(
	@MaCD char(6),
	@TenCD nvarchar(100)
)
as
begin
		insert into ChuDe()
		values(@MaCD, @TenCD)
end

--Phân quyền và nhóm quyền truy cập
Create Role CongTy --Quyền quản lý
--
Go
--
create login QuanLy01 with password='123'
create user QuanLy01 for login QuanLy01 
execute sp_addrolemember 'CongTy','QuanLy01'
exec sp_addsrvrolemember 'QuanLy01', 'sysadmin'

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