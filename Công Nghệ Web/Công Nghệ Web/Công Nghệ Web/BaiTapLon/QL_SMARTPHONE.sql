CREATE DATABASE QL_SMARTPHONE
GO
CREATE TABLE SANPHAM
(
	MASANPHAM CHAR(10) NOT NULL,
	TENSANPHAM NVARCHAR(50),
	NHASX NVARCHAR(20),
	CAUHINH NVARCHAR(200),
	TINHNANGNOIBAT NVARCHAR(100),
	PHANKHUC NVARCHAR (30),
	GIABAN FLOAT,
	HINHANH NVARCHAR(MAX) NULL,
	MANSX CHAR(10),
	CONSTRAINT PK_MASANPHAM PRIMARY KEY(MASANPHAM),
	CONSTRAINT FK_SANPHAM_NHASANXUAT FOREIGN KEY(MANSX) REFERENCES NHASANXUAT(MANSX)
)
CREATE TABLE NHASANXUAT
(
	MANSX CHAR(10) NOT NULL,
	TENNSX NVARCHAR(20),
	CONSTRAINT PK_MANSX PRIMARY KEY(MANSX),
)
CREATE TABLE KHACHHANG
(
	MAKH char(5) not null,
	TENKH nvarchar(50),
	NGAYSINH DATETIME,
	GIOITINH nvarchar(5),
	DIACHI nvarchar(50),
	SDT char(10),
	TAIKHOAN CHAR(30),
	MATKHAU VARCHAR(30),
	constraint pk_KhachHang primary key(MAKH)
)
CREATE TABLE HOADON
(
	MAHOADON CHAR(10) NOT NULL,
	TENKHACHHANG NvarChar(50),
	TENSP NVARCHAR(50),
	NGAYNHAPHD DATETIME,
	MASANPHAM CHAR(10),
	CONSTRAINT PK_MAHD PRIMARY KEY(MAHOADON),
	CONSTRAINT FK_MASANPHAM1 FOREIGN KEY(MASANPHAM) REFERENCES SANPHAM(MASANPHAM)
)
CREATE TABLE CHITIETHOADON
(
	MAHOADON CHAR(10) NOT NULL,
	MASANPHAM CHAR(10),
	SOLUONG INT,
	DONGIA FLOAT,
	GIAMGIA FLOAT,
	THANHTIEN FLOAT,
	CONSTRAINT PK_MAHOADON PRIMARY KEY(MAHOADON, MASANPHAM),
	CONSTRAINT FK_MAHOADON FOREIGN KEY(MAHOADON) REFERENCES HOADON(MAHOADON),
	CONSTRAINT FK_MASANPHAM2 FOREIGN KEY(MASANPHAM) REFERENCES SANPHAM(MASANPHAM)
)

create table DONDATHANG
(
MADH CHAR(10) ,
MAKH CHAR(5),
NGAYDAT DATE,
NGAYGIAO DATE,
TINHTRANGGIAOHANG bit,
DATHANHTOAN bit,
Constraint pk_dhd primary key(MADH),
constraint fk_dhd_kh foreign key(MAKH) references KHACHHANG(MAKH)
)
create  table CTDATHANG
(
MADH CHAR(10) not null,
MASANPHAM CHAR(10),
SOLUONG INT,
DONGIA FLOAT,
constraint pk_CTDATHANG primary key(MADH)
)
ALTER TABLE CTDATHANG
ADD constraint fk_CTDH_DDH foreign key(MADH) references DONDATHANG(MADH)
ALTER TABLE CTDATHANG
ADD constraint fk_CTDH_SANPHAM foreign key(MASANPHAM) references SANPHAM (MASANPHAM)
GO
USE QL_SMARTPHONE
SET DATEFORMAT DMY
INSERT INTO SANPHAM
VALUES
('IPXR','iPhone XR','Apple', N'Độ phân giải	HD, Hệ điều hành: iOS 12, CPU: Apple A12', N'Face ID', N'Cao cấp',17990000,'ip1.PNG','APPLE'),
('IP11PMAX','iPhone 11 Pro Max','Apple', N'Độ phân giải	2K, Hệ điều hành: iOS 13, CPU: Apple A13', N'Face ID', N'Cao cấp',33990000,'ip2.PNG','APPLE'),
('IPX','iPhone X','Apple', N'Độ phân giải Full HD, Hệ điều hành: iOS 12, CPU: Apple A12', N'Face ID', N'Cao cấp',21990000,'ip3.PNG','APPLE'),
('IP8PL','iPhone 8 Plus','Apple', N'Độ phân giải Full HD, Hệ điều hành: iOS 12, CPU: Apple A11', N'3D Touch', N'Cao cấp',18000000,'ip5.PNG','APPLE'),	
('IP7PL','iPhone 7 Plus', 'Apple',N'Độ phân giải Ful HD, Hệ điều hành: iOS 12, CPU: Apple A10 Fusion', N'3D Touch', N'Cận cao cấp',12990000,'ip4.PNG','APPLE'),
('SSA30S','Samsung Galaxy A30S', 'Sangsung',N'Độ phân giải HD, Hệ điều hành: Android 9.0, CPU: Exynos 9620', N'Mở khóa khuôn mặt', N'Cao cấp',5490000,'ss2.PNG','SAMSUNG'),
('SSM20','Samsung Galaxy M20', 'Sangsung',N'Độ phân giải Full HD, Hệ điều hành: Android 9.0, CPU: Exynos 9620', N'Mở khóa khuôn mặt', N'Giá rẻ',4490000,'h1.PNG','SAMSUNG'),
('SSA7','Samsung Galaxy A7', 'Sangsung',N'Độ phân giải Full HD, Hệ điều hành: Android 9.0, CPU: Exynos 9710', N'Mở khóa khuôn mặt', N'Tầm trung',6900000,'ss3.PNG','SAMSUNG'),
('SSA9','Samsung Galaxy A9','Sangsung', N'Độ phân giải Full HD, Hệ điều hành: Android 9.0, CPU: Exynos 9760', N'Mở khóa khuôn mặt', N'Cận cao cấp',9900000,'ss4.PNG','SAMSUNG'),
('SSN10PL','Samsung Galaxy Note 10 Plus', 'Sangsung',N'Độ phân giải 2K, Hệ điều hành: Android 10, CPU: Exynos 9820', N'Vân tay siêu âm', N'Cao cấp',26900000,'ss5.PNG','SAMSUNG'),
('OPF9','Oppo F9', 'OPPO',N'Độ phân giải Full HD, Hệ điều hành: Android 9.0, CPU: Snapdragon 660', N'Mở khóa khuôn mặt', N'Tầm trung',4900000,'op1.PNG','OPPO'),
('OPA7','Oppo A7','OPPO', N'Độ phân giải HD, Hệ điều hành: Android 9.0, CPU: Snapdragon 445', N'Mở khóa khuôn mặt', N'Giá rẻ',4900000,'op3.PNG','OPPO'),
('OPA3S','Oppo A3S','OPPO', N'Độ phân giải Full HD, Hệ điều hành: Android 9.0, CPU: Snapdragon 435', N'Mở khóa khuôn mặt', N'Giá rẻ',3490000,'op4.PNG','OPPO'),
('OPA5S','Oppo A5S','OPPO', N'Độ phân giải Full HD, Hệ điều hành: Android 9.0, CPU: Snapdragon 460', N'Mở khóa khuôn mặt', N'Giá rẻ',3690000,'op5.PNG','OPPO'),
('XM9Se','Xiaomi Mi 9 SE','XIAOMI', N'Độ phân giải: 20PM, Hệ điều hành: Android 9.0 (Pie), CPU: Snapdragon 712 8 nhân 64-bit', N'Mở Khóa Khuôn Mặt', N'Cao cấp',7525000,'xm1.PNG','XIAOMI'),
('XM9T','Xiaomi Mi 9T', 'XIAOMI',N'Độ phân giải: Full HD+ (1080 x 2340 Pixels), Hệ điều hành: Android 9.0 (Pie), CPU: Snapdragon 730 8 nhân 64-bit', N'Màn hình luôn hiển thị AOD', N'Cao cấp',7990000,'xm2.PNG','XIAOMI'),
('XMN8P','Xiaomi Redmi Note 8 Pro', 'XIAOMI',N'Độ phân giải: Full HD, Hệ điều hành: Android 9.0 (Pie), CPU: Mediatek', N'Mở Khóa Vân Tay', N'Cao cấp',5990000,'xm3.PNG','XIAOMI'),
('XMA5','Xiaomi Mi A5','XIAOMI', N'Độ phân giải: HD, Hệ điều hành: Android 8.0 (Pie), CPU: Mediatek', N'Mở Khóa Vân Tay', N'Tầm Trung',5990000,'xm4.PNG','XIAOMI'),
('XMA3','Xiaomi Mi A3', 'XIAOMI',N'Độ phân giải: HD, Hệ điều hành: Android 7.0 (Pie), CPU: Qualcomm ', N' ', N'Tầm Trung',499000,'xm5.PNG','XIAOMI'),
('Vv17',' Vivo V17 Pro', 'VIVO',N'Độ phân giải 2K, Hệ điều hành: Android 10, CPU: Exynos 9820', N'Mở khóa bằng vân tay, độ phân giải cao', N'Cao cấp',9900000,'vv4.PNG','VIVO'),
('Vv15',' Vivo V15 Pro','VIVO', N'Android 9.0 (Pie), CPU: MediaTek Helio P70 8 nhân', N'Mở khóa bằng vân tay, độ phân giải cao', N'Tầm trung',5500000,'vv3.PNG','VIVO'),
('VvY11',' Vivo Y11C', 'VIVO',N'Độ phân giải 2K, Hệ điều hành: Android 10, CPU: Exynos 9820', N'Mở khóa bằng vân tay, độ phân giải cao', N'Tầm trung',9900000,'vv1.PNG','VIVO'),
('VvY91',' Vivo Y91C', 'VIVO',N'Độ phân giải 2K, Hệ điều hành: Android 9.0 (Oreo), CPU:Qualcomm Snapdragon 439 8 nhân 64-bit', N'Sạc pin nhanh', N'Tầm ',5900000,'vv2.PNG','VIVO'),
('Vv11',' Vivo V11 Pro', 'VIVO',N'Độ phân giải 2K, Hệ điều hành: Android 9.0 (Pie), CPU: MediaTek Helio P35 8 nhân 64-bit', N'Mở khóa bằng vân tay,nhận diện khuôn mặt', N'Cao cấp',4690000,'vv5.PNG','VIVO'),
('HWNV3I','HUAWEI Nova 3i','HUAWEI', N'Độ phân giải: Full HD, Hệ điều hành: Android 8.1 (Pie), CPU: Qualcomm ', N' ', N'Tầm Trung',4990000,'hw2.PNG','HUAWEI'),
('HWY9','HUAWEI Y9', 'HUAWEI',N'Độ phân giải: HD, Hệ điều hành: Android 9.0 (Pie), CPU: Qualcomm ', N'Mở khóa vân tay', N'Giá rẻ',4990000,'hw1.PNG','HUAWEI'),
('HWP30PR','Huawei P30 Pro','HUAWEI', N'Độ phân giải: HD+, Hệ điều hành: Android 8.0 (Pie), CPU: Qualcomm ', N'Mở Khóa Vân Tay', N'Cao Cấp',8990000,'hw3.PNG','HUAWEI'),
('HWP30LT','Huawei P30 Lite','HUAWEI', N'Độ phân giải: FullHD+, Hệ điều hành: Android 9.0 (Pie), CPU:Snapdragon 730 8 nhân 64-bit', N'Mở Khóa Khuôn Mặt', N'Cao Cấp',9990000,'hw5.PNG','HUAWEI'),
('RM5PR','REALME 5Pro','REALME', N'Độ phân giải	HD+, Hệ điều hành: Android 9.0, CPU: MediaTek', N'Mở Khóa Khuôn Mặt', N'Cao cấp',15000000,'rm3.PNG','REALME'),
('RM3PR','REALME 3Pro','REALME', N'Độ phân giải	HD+, Hệ điều hành: Android 7.0(pie), CPU: MediaTek', N'Đa Cửa Sổ', N'Cao cấp',13000000,'rm2.PNG','REALME'),
('RM4PR','REALME 4Pro', 'REALME',N'Độ phân giải	HD+, Hệ điều hành: Android 8.0.1, CPU: MediaTek', N'Trợ lý ảo Google Assistant', N'Tầm Trung',10000000,'rm1.PNG','REALME'),
('RMC3','REALME C3', 'REALME',N'Độ phân giải HD, Hệ điều hành: Android 6.0.1, CPU: MediaTek', N'Tiết Kiệm Pin', N'Tầm Trung',900000,'rm4.PNG','REALME'),
('RMC2','REALME C2','REALME', N'Độ phân giải HD, Hệ điều hành: Android 6.0, CPU: MediaTek', N' ', N'Giá Rẻ',500000,'rm5.PNG','REALME'),
('NK81','NOKIA 8.1','NOKIA', N'Độ phân giải Full HD, Hệ điều hành: Android 10, CPU: Snapdragon 710', N' ', N'Tầm trung',6590000,'nk81.PNG','NOKIA'),
('NK72','NOKIA 7.2','NOKIA', N'Độ phân giải Full HD, Hệ điều hành: Android 9, CPU: Snapdragon 660', N' ', N'Tầm trung',5990000,'nk72.PNG','NOKIA'),
('NK110','NOKIA 110','NOKIA', N'Độ phân giải TFT, Hệ điều hành: Android, CPU: Snapdragon 435', N' ', N'Giá rẻ',470000,'nk110.PNG','NOKIA')

INSERT INTO NHASANXUAT
VALUES
('NOKIA','Nokia'),
('APPLE', 'Apple'),
('SAMSUNG', 'Samsung'),
('OPPO', 'Oppo'),
('XIAOMI', 'Xiaomi'),
('VIVO', 'Vivo'),
('HUAWEI', 'Huawei'),
('REALME', 'Realme')


insert into KhachHang values('KH01',N'Nguyễn Thị Hoa','12/04/1994',N'Nữ',N'Hà Nội',0923579173,'quang123','123456');
insert into KhachHang values('KH02',N'Trần Tuấn Kiệt','05/10/1997',N'Nam',N'HCM',0923579119,'tham123','123456');
insert into KhachHang values('KH03',N'Lê Văn Nam','20/02/1989',N'Nam',N'Đà Nẵng',0973572857,'tuan123','123456');
insert into KhachHang values('KH04',N'Nguyễn Hoài Linh','25/12/1997',N'Nữ',N'HCM',0971250712,null,null);
insert into KhachHang values('KH05',N'Nguyễn Tiến Bảo','04/08/1995',N'Nam',N'Hà Nội',0982489274,null,null);
insert into KhachHang values('KH06',N'Nguyễn Trí Nhân','09/10/1995',N'Nam',N'Long An',0982489190,null,null);
insert into KhachHang values('KH07',N'Trần Anh Hào','15/01/1993',N'Nam',N'Hà Nội',0982481264,null,null);

insert into HOADON values('HD01',N'Nguyên Tiến Bảo',N'iPhone XR','25/05/2019','IPXR');
insert into HOADON values('HD02',N'Nguyễn Thị Hoa',N'iPhone 11 Pro Max','26/05/2019','IP11PMAX');
insert into HOADON values('HD03',N'Trần Tuấn Kiệt',N'iPhone X','12/07/2019','IPX');
insert into HOADON values('HD04',N'Nguyễn Hoài Linh',N'iPhone 8 Plus','22/07/2019','IP8PL');
insert into HOADON values('HD05',N'Nguyễn Trí Nhân',N'iPhone 7 Plus','23/07/2019','IP7PL');
insert into HOADON values('HD06',N'Vũ Đức Kiên',N'Vivo V15 Pro','23/07/2019','Vv15');
insert into HOADON values('HD07',N'Trần Anh Hào',N'Samsung Galaxy M20','24/08/2019','SSM20');
insert into HOADON values('HD08',N'Trần Vũ Minh',N'Samsung Galaxy A7','21/09/2019','SSA7');
insert into HOADON values('HD09',N'Đỗ Minh Phong',N'Samsung Galaxy Note 10 Plus','22/09/2019','SSN10PL');
insert into HOADON values('HD10',N'Lê Văn Nam',N'Vivo V17 Pro','30/09/2019','Vv17');

insert into CHITIETHOADON values('HD01','IPXR',1,17990000,0,17990000);
insert into CHITIETHOADON values('HD02','IP11PMAX',1,33990000,990000,33000000);
insert into CHITIETHOADON values('HD03','IPX',2,21990000,0,43980000);
insert into CHITIETHOADON values('HD04','IP8PL',1,18000000,1000000,17000000);
insert into CHITIETHOADON values('HD05','IP7PL',1,12990000,0,12990000);
INSERT INTO CHITIETHOADON 
VALUES
('HD06','Vv15',1,5500000,0,5500000),
('HD07','SSM20',1,4490000,490000,4000000),
('HD08','SSA7',1,6900000,0,6900000),
('HD09','SSN10PL',1,26900000,900000,26000000),
('HD10','Vv17',1,9900000,0,9900000)