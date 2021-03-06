
create database QL_YTE_Dim
use QL_YTE_Dim

 create tablE Dim_BHYte
 (
 SoTheBH char(50),
 TenChuThe nvarchar(50),
 constraint pk_Dim_BHYTe primary key(SoTheBH)
 )

 
 create table Dim_Khoa
(
MaKhoa char(10),
TenKhoa nvarchar(50),
constraint pk_Dim_khoa primary key(MaKhoa)
)

create table Dim_BenhNhan
(
MaBN char(10),
SoTheBH char(50),
TenBN nvarchar(50),
NgaySinh date,
GioiTinh nvarchar(5),
DiaChi nvarchar(50),
constraint pk_Dim_BenhNhan primary key(MaBN),
CONSTRAINT  fk_BenhNhan_BHYte foreign key(SoTheBH) references Dim_BHYte(SoTheBH)

)
create table Dim_Time
(
	NgayBan datetime not null primary key,
	ThangBan int,
	NamBan int,
	QuyBan int
)


create table Dim_NhanVien
(
MaNV char(10),
TenNV nvarchar(50),
MaKhoa char(10),
constraint pk_Dim_NhanVien primary key(MaNV),
constraint  fk_NhanVien_Khoa foreign key(MaKhoa) references Dim_Khoa(MaKhoa)

)

create table Dim_Thuoc
(
TenThuoc nvarchar(50),
DVT nvarchar(50),
DonGia float,
constraint pk_Dim_Thuoc primary key(TenThuoc)
)


create table Dim_PhieuKham
(
MaPK char(10),
MaBN char (10),
NgayKham date,
ChuanDoan nvarchar(100),
KetLuan nvarchar(100),
HuongDieuTri nvarchar(100),
constraint pk_PhieuKham primary key(MaPK),
constraint  fk_PhieuKham_BN foreign key(MaBN) references Dim_BenhNhan(MaBN)

)

create table Fact
( 
MaBN char(10),
TenThuoc nvarchar(50),
MaNV char(10),
MaPK char(10),
NgayBan datetime,
SL int,
DonGia float,
ThanhTien float,
constraint pk_Fact primary key(MaBN,TenThuoc,MaNV,MaPK,NgayBan),
constraint fk_Fact_BN foreign key(MaBN) references Dim_BenhNhan (MaBN),
constraint fk_Fact_Thuoc foreign key(TenThuoc) references Dim_Thuoc (TenThuoc),
constraint fk_Fact_NV foreign key(MaNV) references Dim_NhanVien (MaNV),
constraint fk_Fact_PK foreign key(MaPK) references Dim_PhieuKham (MaPK)


)
go


create proc load_BHYT
as
begin
	
	insert into Dim_BHYte
	select * from QL_YTE.dbo.D_BHYte
end
go
exec load_BHYT
GO

create proc load_Khoa
as
begin
	
	insert into Dim_Khoa
	select * from [QL_YTE].dbo.D_Khoa
end
go
exec load_Khoa
GO

create proc load_BenhNhan
as
begin
	
	insert into Dim_BenhNhan
	select * from QL_YTE.dbo.D_BenhNhan
end
go
exec load_BenhNhan
GO


create proc load_NhanVien
as
begin
	
	insert into Dim_NhanVien
	select * from QL_YTE.dbo.D_NhanVien
end
go
exec load_NhanVien


create proc load_PhieuKham
as
begin
	
	insert into Dim_PhieuKham
	select * from QL_YTE.dbo.D_PhieuKham
end
go
exec load_PhieuKham
GO




create proc load_Thuoc
as
begin
	
	insert into Dim_Thuoc
	select * from QL_YTE.dbo.Thuoc
end
go
exec load_Thuoc
GO

create proc load_Fact
as
begin
	
	insert into Fact
	select * from QL_YTE.dbo.V_FACT
end
go
exec load_Fact
GO

select * from Fact
go

CREATE PROC autoTime
AS
	BEGIN
	delete from Dim_Time
		Declare @SmallDate datetime
		Declare @MaxDate datetime
			Select @Smalldate = min(NgayBan) from Fact
			Select @MaxDate = max(NgayBan) from Fact
			While (@SmallDate <= @MaxDate )
		BEGIN
			Insert into Dim_Time values (@SmallDate, MONTH(@SmallDate), YEAR(@SmallDate), DATEPART(QUARTER, @SmallDate))
			Set @SmallDate = @SmallDate +1
		END
	END
go
Exec autoTime
go


Select * from Fact
Select * from [dbo].[Dim_BenhNhan]
Select * from [dbo].[Dim_BHYte]
Select * from [dbo].[Dim_Khoa]
Select * from [dbo].[Dim_NhanVien]
Select * from [dbo].[Dim_PhieuKham]
Select * from [dbo].[Dim_Thuoc]
Select * from [dbo].[Dim_Time]


create proc delete_All
as
begin
	delete from [dbo].[Dim_NhanVien]
	delete from [dbo].[Dim_Khoa]
	delete from [dbo].[Dim_PhieuKham]
	delete from [dbo].[Fact]
	delete from [dbo].[Dim_Time]
	delete from [dbo].[Dim_Thuoc]
	delete from [dbo].[Dim_BenhNhan]
	delete from [dbo].[Dim_BHYte]
end
go


select * from Fact
