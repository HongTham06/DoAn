
create database QL_YTE
use QL_YTE

 create tablE BHYte
 (
 SoTheBH char(50),
 TenChuThe nvarchar(50),
 constraint pk_BHYTe primary key(SoTheBH)
 )

 create table Khoa
(
MaKhoa char(10),
TenKhoa nvarchar(50),
constraint pk_khoa primary key(MaKhoa)
)

create table BenhNhan
(
MaBN char(10),
TenBN nvarchar(50),
GioiTinh nvarchar(5),
DiaChi nvarchar(50),
NgaySinh date,
SoTheBH char(50),
constraint pk_BenhNhan primary key(MaBN),
constraint fk_BenhNhan_BHYTe foreign key(SoTheBH) references BHYTe (SoTheBH),
)


create table NhanVien
(
MaNV char(10),
TenNV nvarchar(50),
MaKhoa char(10),
KVCongTac nvarchar(50),
constraint pk_NhanVien primary key(MaNV),
constraint fk_NV_Khoa foreign key(MaKhoa) references Khoa (MaKhoa)
)


create table Thuoc
(
TenThuoc nvarchar(50),
DVT nvarchar(50),
DonGia float,
constraint pk_Thuoc primary key(TenThuoc)
)

create table GiuongBenh
(
MaGB char(10),
SoPB char(10),
MaKhoa char(10),
constraint pk_GiuongBenh primary key(MaGB),
constraint fk_GiuongBenh_Khoa foreign key(MaKhoa) references Khoa(MaKhoa)
)


create table PhieuKham
(
MaPK char(10),
MaBN char (10),
MaNV char(10),
MaKhoa char(10),
SoPB char(10),
NgayKham date,
ChuanDoan nvarchar(100),
KetLuan nvarchar(100),
HuongDieuTri nvarchar(100)
constraint pk_PhieuKham primary key(MaPK),
constraint fk_PhieuKham_BN foreign key(MaBN) references BenhNhan (MaBN),
constraint fk_PhieuKham_Khoa foreign key(MaKhoa) references Khoa(MaKhoa)
)
create table HoaDon 
(
MaHD char(10),
NgayLap date,
MaBN char(10),
MaPK char(10),
constraint pk_HoaDon primary key(MaHD),
constraint fk_hd_PhieuKham foreign key(MaPK) references PhieuKham(MaPK),
constraint fk_HD_BenhNhan foreign key(MaBN) references BenhNhan(MaBN)
)

CREATE TABLE CTHD
(
MaHD char(10),
TenThuoc nvarchar(50),
SL int,
DonGia float,
ThanhTien float,
constraint pk_CTHD primary key(MaHD,TenThuoc),
constraint fk_CTHD_Thuoc foreign key(TenThuoc) references Thuoc(TenThuoc),
constraint fk_CTHD_HD foreign key(MaHD) references HoaDon(MaHD)
)


 insert into BHYTe values('BH01',N'Nguyễn Thanh An');
 insert into BHYTe values('BH02',N'Nguyễn Thanh');
 insert into BHYTe values('BH03',N'Trần Đại Long');
 insert into BHYTe values('BH04',N'Hoàng Thùy Chi');
 insert into BHYTe values('BH05',N'Huỳnh Nhân');
 insert into BHYTe values('BH06',N'Trần Minh Đức');
 insert into BHYTe values('BH07',N'Đinh Linh');
 insert into BHYTe values('BH08',N'Huỳnh Chí Khanh');
  insert into BHYTe values('BH09',N'Huỳnh Chí Khanh');


insert into Khoa values('TK',N'Khoa Thần Kinh');
insert into Khoa values('HS',N'Khoa Hồi Sức');
insert into Khoa values('RHM',N'Khoa Răng Hàm Mặt');
insert into Khoa values('TM',N'Khoa Tim Mạch');
insert into Khoa values('XN',N'Khoa Xét Nghiệm ');
insert into Khoa values('NS',N'Khoa Nội Soi');
insert into Khoa values('HH',N'khoa Hô Hâp');
insert into Khoa values('CTCH',N'Chấn Thương chỉnh hình');
insert into Khoa values('DL',N'Bệnh ngoài da');

set dateformat DMY
insert into BenhNhan values('BN001',N'Huỳnh Nhân',N'Nam',N'Hà Nội','1/1/1995','BH05');
insert into BenhNhan values('BN002',N'Lê Thị Trang',N'Nữ',N'HCM','3/5/1992',null);
insert into BenhNhan values('BN003',N'Nguyễn Thanh An',N'Nam',N'Đà Nẵng','15/7/1983','BH01');
insert into BenhNhan values('BN004',N'trần Minh Phong',N'Nam',N'Hà Nội','19/6/1997',null);
insert into BenhNhan values('BN005',N'Nguyễn Lan',N'Nữ',N'Lạng Sơn','20/5/1991',null);
insert into BenhNhan values('BN006',N'Đỗ Văn Quân',N'Nam',N'Nha Trang','15/9/1998',null);
insert into BenhNhan values('BN007',N'Hoàng Thùy Chi',N'Nam',N'Hà Nội','10/5/1985','BH04');
insert into BenhNhan values('BN008',N'Nguyễn Trí Thắng',N'Nam',N'HCM','28/12/1981',null);
insert into BenhNhan values('BN009',N'Hoàng Lê',N'Nam',N'Cần Thơ','15/10/1997',null);
insert into BenhNhan values('BN010',N'Trần Đại Long',N'Nam',N'Hà Nội','30/5/1998','BH03');
insert into BenhNhan values('BN011',N'Nguyễn Thanh',N'Nam',N'HCM','10/3/1994','BH02');


insert into NhanVien values('NV001',N'Nguyễn Thị Thùy Trang','HS',N'HCM');
insert into NhanVien values('NV002',N'Trần Minh Anh','TK',N'HCM');
insert into NhanVien values('NV003',N'Lê Hoàng An','HH',N'HCM');
insert into NhanVien values('NV004',N'ĐỖ Long','XN',N'Nha Trang');
insert into NhanVien values('NV005',N'Lê Nhi','NS',N'Hà Nội');
insert into NhanVien values('NV006',N'Trần Văn Phong','RHM',N'Bạc Liêu');
insert into NhanVien values('NV007',N'Lê Thị Hồng Gấm','RHM',N'Bạc Liêu');


insert into Thuoc values ('Penicillin',N'Viên',20000);
insert into Thuoc values ('Insulin',N'Viên',20000);
insert into Thuoc values ('Morphin',N'Viên',18000);
insert into Thuoc values ('Aspirin',N'Viên',22000);
insert into Thuoc values ('Chlorpromazin',N'Viên',20000);
insert into Thuoc valueS ('Ether',N'Viên',20000);
insert into Thuoc values (' SUNCURMIN',N'Lọ',22000);
insert into Thuoc values ('Bocalex C 1000',N'Viên',21000);
insert into Thuoc values ('Diamicron MR ',N'Viên',20000);
insert into Thuoc values ('Klenzit MS',N'Tuýp',18000);
insert into Thuoc values ('Timolol Maleate Eye Drops 0,5%',N'Lọ',16000);
insert into Thuoc values ('Augmentin',N'Gói',20000);
insert into Thuoc values ('Fellaini 25mg Medisun',N'Viên',18000);
insert into Thuoc values ('Klenzit – C',N'Tuýp',20000);


insert into GiuongBenh values('P1_01','P1','TK');
insert into GiuongBenh values('P1_02','P1','TK');
insert into GiuongBenh values('P1_03','P1','TK');
insert into GiuongBenh values('P2_01','P2','TK');
insert into GiuongBenh values('P2_02','P2','TK');
insert into GiuongBenh values('P3_01','P3','HH');
insert into GiuongBenh values('P3_02','P3','HH');
insert into GiuongBenh values('P4_01','P4','CTCH');
insert into GiuongBenh values('P4_02','P4','CTCH');
insert into GiuongBenh values('P4_03','P4','CTCH');
select * from GiuongBenh

set dateformat DMY
insert into PhieuKham values ('PK1','BN001','NV001','HH','HH_P1','24/5/2020',N'Dạ Dày',N'Viêm Loét dạ dày',N'Cho thuốc uống 1 tháng sau đó lên tái khám');
insert into PhieuKham values ('PK2','BN007','NV004','TK','TK_P2','23/5/2020',N'Tổn Thương Não',N'Máu bầm tích tụ nhiều trong não','Nằm lại viện');
insert into PhieuKham values ('PK3','BN003','NV007','HH','HH_P2','24/5/2020',N'Phổi',N'Uung Thư Phổi','Nằm lại viện');
insert into PhieuKham values ('PK4','BN010','NV005','HH','HH_P1','24/5/2020',N'Dạ Dày',N'Viêm Loét dạ dày','Cho thuốc uống 1 tháng sau đó lên tái khám');
insert into PhieuKham values ('PK5','BN011','NV003','CTCH','CTCH_P1','24/5/2020',N'Gãy tay',N'Gãy tay','Băng bó, cho thuốc về nhà uống');
insert into PhieuKham values ('PK6','BN006','NV008','HH','P1','24/5/2020',N'Dạ Dày',N'Viêm Loét dạ dày','Cho thuốc uống 1 tháng sau đó lên tái khám');

SET DATEFORMAT DMY;
insert into HoaDon values('HD001','20/5/2019','BN001','PK1');
insert into HoaDon values('HD002','25/5/2020','BN003','PK3');
insert into HoaDon values('HD003','26/5/2020','BN004','PK2');
insert into HoaDon values('HD004','26/5/2020','BN006','PK4');
insert into HoaDon values('HD005','27/5/2020','BN002','PK5');
insert into HoaDon values('HD006','27/5/2020','BN010','PK6');


insert into CTHD values ('HD001','Morphin',15,22000,null);
insert into CTHD values ('HD002','Diamicron MR',30,350000,null);
insert into CTHD values ('HD003','Bocalex C 1000',10,200000,null);
insert into CTHD values ('HD004','Penicillin',10,200000,null);
insert into CTHD values ('HD005','Timolol Maleate Eye Drops 0,5%',10,200000,null);
insert into CTHD values ('HD006','Penicillin',11,210000,null);
go


CREATE PROC UPDATE_GIA
AS
BEGIN
	UPDATE CTHD
	SET DonGia = (SELECT DonGia FROM Thuoc t WHERE t.TenThuoc=CTHD.TenThuoc)
END
go
EXEC  UPDATE_GIA
go

CREATE PROC UPDATE_THANHTIEN
AS
BEGIN
	update CTHD
	set ThanhTien =SL* DonGia
END
GO
EXEC UPDATE_THANHTIEN
go

CREATE VIEW D_BHYTE
AS
SELECT DISTINCT bh.SoTheBH,bh.TenChuThe
FROM BenhNhan n JOIN BHYte bh ON n.SoTheBH=bh.SoTheBH
go
select * from D_BHYTE
GO

CREATE VIEW D_PhieuKham
AS
SELECT DISTINCT p.MaPK,b.MaBN,p.NgayKham,p.ChuanDoan,p.KetLuan,p.HuongDieuTri
FROM PhieuKham p JOIN BenhNhan b ON p.MaBN=b.MaBN
go
select * from D_PhieuKham
GO

CREATE VIEW  D_NhanVien
AS
SELECT DISTINCT (n.MaNV),(n.TenNV),k.MaKhoa
FROM NhanVien n JOIN Khoa k ON k.MaKhoa=n.MaKhoa
go
select * from D_NhanVien
GO

CREATE VIEW  D_Khoa
AS
SELECT DISTINCT k.MaKhoa,k.TenKhoa
FROM Khoa k JOIN NhanVien n ON k.MaKhoa=n.MaKhoa
go
select * from D_Khoa
GO

CREATE VIEW  D_BenhNhan
AS
SELECT DISTINCT (b.MaBN),b.SoTheBH,(b.TenBN),b.NgaySinh,b.GioiTinh,b.DiaChi
FROM	BenhNhan b JOIN PhieuKham p ON p.MaBN=b.MaBN
go
select * from D_BenhNhan
GO




CREATE VIEW  D_Thuoc
AS
SELECT DISTINCT t.TenThuoc,t.DVT,t.DonGia
FROM Thuoc t JOIN CTHD c ON t.TenThuoc=c.TenThuoc
go
select * from D_Thuoc
GO

CREATE VIEW V_FACT
AS
SELECT  Distinct (h.MaBN),(c.TenThuoc),(p.MaNV),(p.MaPK),(h.NgayLap),c.SL,c.DonGia,c.ThanhTien
FROM Thuoc t JOIN CTHD c ON c.TenThuoc = t.TenThuoc
	JOIN HoaDon h ON h.MaHD = c.MAHD
	JOIN  PhieuKham p ON p.MaPK=h.MaPK
	JOIN NhanVien n ON p.MaNV=n.MaNV
	Join BenhNhan b ON p.MaBN=h.MaBN

go
select * from V_FACT
go


select * from PhieuKham
select * from BenhNhan
select * from Khoa
select * from GiuongBenh
select * from HoaDon
select * from CTHD
select * from BHYte
select * from NhanVien
select * from Thuoc