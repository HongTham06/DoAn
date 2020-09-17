﻿CREATE DATABASE QL_CAPHE
USE QL_CAPHE
CREATE TABLE NGUYENLIEU
(
	MANL NCHAR(5) PRIMARY KEY,
	TENNL NVARCHAR(20),
	DVT NVARCHAR(10),
	SOLUONGNHAP FLOAT DEFAULT 0,
	SOLUONGCU FLOAT DEFAULT 0,
	SOLUONG FLOAT,
	GIANGUYENLIEU FLOAT, -- /DVT VD:gianguyenlieu cà phê 46k/1kg
	CONSTRAINT CHK_DVT_NL CHECK (DVT='g' OR DVT ='ml' or DVT = 'kg' OR DVT='l')
)
select * from HOADON

CREATE TABLE TAIKHOANNV
(
	MATK NCHAR(20) PRIMARY KEY,
	MATKHAU NCHAR(20),
	TENTK NVARCHAR(30)
)
ALTER TABLE TAIKHOANNV
ADD CHUCVU NVARCHAR(20);

ALTER TABLE TAIKHOANNV
ADD CONSTRAINT chk_chucvu CHECK (CHUCVU = N'quản lý' or CHUCVU=N'quản lý kho' or CHUCVU=N'thu ngân') 

CREATE TABLE NUOCGIAIKHAT
(
	MANGK NCHAR(5) PRIMARY KEY,
	TENNGK NVARCHAR(20),
	DVT NVARCHAR(15),
	SLTRUOCNHAP INT DEFAULT 0,
	SLNHAPTHEM INT default 0,
	SLHIENTAI INT,
	DONGIA MONEY,  --giá nhập sỉ
	GIABAN MONEY, --GIÁ BÁN TRONG QUÁN
	CONSTRAINT CHK_DVT_NGK CHECK (DVT='chai' OR DVT ='lon')
)


CREATE TABLE LOAI
(
	MALOAI NCHAR(5) PRIMARY KEY,
	TENLOAI NVARCHAR(20)
)
use QL_CAPHE
CREATE TABLE NUOCPHACHE
(
	MANPC NCHAR(5) PRIMARY KEY,
	TENNPC NVARCHAR(30),
	DONGIA MONEY,
	MALOAI NCHAR(5),
	CONSTRAINT FK_LOAI_PC FOREIGN KEY (MALOAI) REFERENCES LOAI(MALOAI)
)
CREATE TABLE CONGTHUC
(
	MANPC NCHAR(5),
	MANL NCHAR(5),
	DVT NVARCHAR(10),
	SOLUONG FLOAT,
	CONSTRAINT PK_CONGTHUC PRIMARY KEY (MANPC, MANL),
	CONSTRAINT FK_CT_NPC FOREIGN KEY (MANPC) REFERENCES NUOCPHACHE(MANPC),
	CONSTRAINT CHK_DVT_CT CHECK (DVT='kg' or DVT='l')
)
ALTER TABLE CONGTHUC
ADD CONSTRAINT FK_NL_CONGTHUC FOREIGN KEY (MANL) REFERENCES NGUYENLIEU(MANL)


SELECT * FROM CONGTHUC
CREATE TABLE BAN
(
	MABAN INT IDENTITY(1,1) PRIMARY KEY,
	TINHTRANG NVARCHAR(20) DEFAULT N'TRỐNG'
)

CREATE TABLE HOADON
(
	MAHD INT IDENTITY(1,1) PRIMARY KEY,
	MABAN INT NOT NULL,
	NGAYLAP DATE,
	THANHTIEN MONEY DEFAULT 0,
	MATK NCHAR(20),
	CONSTRAINT FK_MANV_HOADON FOREIGN KEY (MATK) REFERENCES TAIKHOANNV(MATK),
	CONSTRAINT FK_HD_BAN FOREIGN KEY (MABAN) REFERENCES BAN(MABAN)
)

CREATE TABLE CHITIETHOADON
(
	MAHD INT,
	MANUOC NCHAR(5),
	SOLUONG INT,
	DONGIA MONEY,
	CONSTRAINT PK_CT PRIMARY KEY (MAHD,MANUOC),
	CONSTRAINT FK_HD_CTHD FOREIGN KEY (MAHD) REFERENCES HOADON(MAHD)
)
alter table CHITIETHOADON
ADD 
CONSTRAINT FK_MANGK_CT FOREIGN KEY (MANUOC) REFERENCES NUOCGIAIKHAT(MANGK)


SELECT * FROM CONGTHUC

CREATE TRIGGER TR_CT_THEMSUA ON CHITIETHOADON
FOR INSERT, UPDATE AS
BEGIN
	UPDATE HOADON
	SET THANHTIEN = (SELECT SUM(CHITIETHOADON.SOLUONG * CHITIETHOADON.DONGIA) FROM CHITIETHOADON, inserted WHERE CHITIETHOADON.MAHD = INSERTED.MAHD)
	FROM HOADON, inserted
	WHERE HOADON.MAHD = INSERTED.MAHD
END

CREATE TRIGGER TR_CT_XOA ON CHITIETHOADON
FOR DELETE AS
BEGIN
	UPDATE HOADON
	SET THANHTIEN = THANHTIEN - (SELECT SUM(SOLUONG * DONGIA) FROM DELETED, HOADON WHERE DELETED.MAHD = HOADON.MAHD)
	FROM HOADON, DELETED
	WHERE HOADON.MAHD = DELETED.MAHD
END

CREATE TRIGGER TR_CT_DONGIA ON CHITIETHOADON
FOR INSERT, UPDATE 
AS
	DECLARE @NGK INT = (SELECT NUOCGIAIKHAT.GIABAN from NUOCGIAIKHAT, inserted WHERE MANGK = INSERTED.MANUOC)
	DECLARE @NPC INT = (SELECT NUOCPHACHE.DONGIA FROM NUOCPHACHE, inserted WHERE MANPC = INSERTED.MANUOC)
	IF ((SELECT count(*) FROM NUOCGIAIKHAT, inserted WHERE MANGK = INSERTED.MANUOC) > 0)
		BEGIN
			UPDATE CHITIETHOADON
			SET DONGIA = @NGK
			FROM CHITIETHOADON, INSERTED
		WHERE CHITIETHOADON.MAHD = INSERTED.MAHD AND CHITIETHOADON.MANUOC = inserted.MANUOC
		END
	ELSE
		BEGIN
			UPDATE CHITIETHOADON
			SET DONGIA = @NPC
			FROM CHITIETHOADON, INSERTED
			WHERE CHITIETHOADON.MAHD = INSERTED.MAHD AND CHITIETHOADON.MANUOC = inserted.MANUOC
		END
GO



CREATE TRIGGER TR_CT_THEMSOLUONGTON ON CHITIETHOADON --da sua lai phan set
FOR INSERT
AS
	DECLARE @THEM INT = (SELECT SOLUONG FROM INSERTED)
	BEGIN
		UPDATE NUOCGIAIKHAT
		SET SLHIENTAI = (SELECT NUOCGIAIKHAT.SLHIENTAI FROM NUOCGIAIKHAT, inserted WHERE MANGK = INSERTED.MANUOC) - @THEM
		FROM NUOCGIAIKHAT, INSERTED
		WHERE NUOCGIAIKHAT.MANGK = INSERTED.MANUOC
	END
GO

CREATE TRIGGER TR_CT_XOASOLUONGTON ON CHITIETHOADON --da sua lai phan set
FOR DELETE
AS
	DECLARE @HUY INT = (SELECT SOLUONG FROM DELETED)
	BEGIN
		UPDATE NUOCGIAIKHAT
		SET SLHIENTAI = (SELECT NUOCGIAIKHAT.SLHIENTAI FROM NUOCGIAIKHAT, DELETED WHERE MANGK = DELETED.MANUOC) + @HUY
		FROM NUOCGIAIKHAT, DELETED
		WHERE NUOCGIAIKHAT.MANGK = DELETED.MANUOC
	END
GO

CREATE TRIGGER TR_CT_SUASOLUONGTON ON CHITIETHOADON --da sua lai phan set
AFTER UPDATE
AS
	DECLARE @THEM INT = (SELECT SOLUONG FROM INSERTED)
	DECLARE @HUY INT = (SELECT SOLUONG FROM DELETED)
	BEGIN
		UPDATE NUOCGIAIKHAT
		SET SLHIENTAI = NUOCGIAIKHAT.SLHIENTAI - @THEM + @HUY
		FROM NUOCGIAIKHAT, DELETED
		WHERE NUOCGIAIKHAT.MANGK = DELETED.MANUOC
	END
GO


CREATE TRIGGER TR_THEMCTHD_NL ON CHITIETHOADON
FOR INSERT
AS
	DECLARE @THEM INT = (SELECT SOLUONG FROM INSERTED)
	DECLARE @MA Nchar(5)
	DECLARE @UDNL CURSOR
	DECLARE @SL FLOAT
	DECLARE @i int = 0
	SET @UDNL = CURSOR FAST_FORWARD
	FOR
	SELECT MANL, CONGTHUC.SOLUONG FROM CONGTHUC,INSERTED WHERE INSERTED.MANUOC = CONGTHUC.MANPC
	OPEN @UDNL
	FETCH NEXT FROM @UDNL
	INTO @MA, @SL
	WHILE @@FETCH_STATUS = 0
	BEGIN
		UPDATE NGUYENLIEU
		SET SOLUONG = SOLUONG - (@THEM * @SL)
		FROM NGUYENLIEU
		WHERE MANL = @MA
	FETCH NEXT FROM @UDNL
	INTO @MA, @SL
	END
	CLOSE @UDNL
	DEALLOCATE @UDNL
GO

CREATE TRIGGER TR_XOACTHD_NL ON CHITIETHOADON
FOR DELETE
AS
	DECLARE @XOA INT = (SELECT SOLUONG FROM DELETED)
	DECLARE @MA Nchar(5)
	DECLARE @UDNL CURSOR
	DECLARE @SL FLOAT
	DECLARE @i int = 0
	SET @UDNL = CURSOR FAST_FORWARD
	FOR
	SELECT MANL, CONGTHUC.SOLUONG FROM CONGTHUC, DELETED WHERE DELETED.MANUOC = CONGTHUC.MANPC
	OPEN @UDNL
	FETCH NEXT FROM @UDNL
	INTO @MA, @SL
	WHILE @@FETCH_STATUS = 0
	BEGIN
		UPDATE NGUYENLIEU
		SET SOLUONG = SOLUONG + (@XOA * @SL)
		FROM NGUYENLIEU
		WHERE MANL = @MA
	FETCH NEXT FROM @UDNL
	INTO @MA, @SL
	END
	CLOSE @UDNL
	DEALLOCATE @UDNL
GO

CREATE TRIGGER TR_SUACTHD_NL ON CHITIETHOADON
FOR UPDATE
AS
	DECLARE @THEM INT = (SELECT SOLUONG FROM INSERTED)
	DECLARE @XOA INT = (SELECT SOLUONG FROM DELETED)
	DECLARE @MA Nchar(5)
	DECLARE @UDNL CURSOR
	DECLARE @SL FLOAT
	DECLARE @i int = 0
	SET @UDNL = CURSOR FAST_FORWARD
	FOR
	SELECT MANL, CONGTHUC.SOLUONG FROM CONGTHUC, INSERTED WHERE INSERTED.MANUOC = CONGTHUC.MANPC
	OPEN @UDNL
	FETCH NEXT FROM @UDNL
	INTO @MA, @SL
	WHILE @@FETCH_STATUS = 0
	BEGIN
		UPDATE NGUYENLIEU
		SET SOLUONG = SOLUONG - (@THEM * @SL) + (@XOA * @SL)
		FROM NGUYENLIEU
		WHERE MANL = @MA
	FETCH NEXT FROM @UDNL
	INTO @MA, @SL
	END
	CLOSE @UDNL
	DEALLOCATE @UDNL
GO

create trigger TG_Nhap_slton on NUOCGIAIKHAT --trigger khi nhập thêm hàng ngk thì cộng dồn vào sl tồn cũ thành sl hiện tại
after update
as
begin
	declare @them int =(select SLNHAPTHEM from inserted)
	update NUOCGIAIKHAT
	set SLTRUOCNHAP = NUOCGIAIKHAT.SLHIENTAI from NUOCGIAIKHAT,inserted where NUOCGIAIKHAT.MANGK = inserted.MANGK
	update NUOCGIAIKHAT 
	set SLHIENTAI = (select NUOCGIAIKHAT.SLTRUOCNHAP from NUOCGIAIKHAT,inserted where NUOCGIAIKHAT.MANGK = inserted.MANGK)+@them
	from NUOCGIAIKHAT,inserted
	where NUOCGIAIKHAT.MANGK=inserted.MANGK
end


create trigger TG_Nhap_sltonNL on NGUYENLIEU --trigger khi nhập thêm hàng ngk thì cộng dồn vào sl tồn cũ thành sl hiện tại
after update
as
begin
	declare @them int =(select SOLUONGNHAP from inserted)
	update NGUYENLIEU
	set SOLUONGCU = NGUYENLIEU.SOLUONG from NGUYENLIEU,inserted where NGUYENLIEU.MANL = inserted.MANL
	update NGUYENLIEU 
	set SOLUONG = (select NGUYENLIEU.SOLUONGCU from NGUYENLIEU,inserted where NGUYENLIEU.MANL = inserted.MANL)+@them
	from NGUYENLIEU,inserted
	where NGUYENLIEU.MANL=inserted.MANL
end

use QL_CAPHE

select * from TAIKHOANNV
INSERT INTO TAIKHOANNV
VALUES ('nv001','123456',N'Nguyễn Văn Toàn',N'quản lý kho'),
('nv002','123456',N'admin',N'quản lý'),
('nv003','123456',N'Nông Ngọc Hoàng',N'thu ngân')
select * from TAIKHOANNV

INSERT INTO NGUYENLIEU(MANL,TENNL,DVT,SOLUONG, GIANGUYENLIEU)
VALUES ('NL001',N'CÀ PHÊ','kg',5,46000),('NL002',N'sữa','l',7,15000),('NL003',N'ĐƯỜNG','kg',6,5000),('NL004',N'SIRUP VẢI','l',5,10000),
('NL005',N'SIRUP ĐÀO','l',5,12000),('NL006',N'CHANH','kg',5,7000),('NL007',N'BƠ','kg',5,25000),('NL008',N'MÃNG CẦU','kg',5,20000)

INSERT INTO LOAI
VALUES ('L0001',N'CÀ PHÊ'),('L0002',N'SODA'),('L0003',N'SINH TỐ')

INSERT INTO NUOCGIAIKHAT(MANGK, TENNGK, DVT, SLNHAPTHEM, SLHIENTAI, DONGIA, GIABAN)
VALUES ('NGK01',N'STING','chai',null,null,40, 4000,16000),('NGK02',N'Ô LONG','chai',null,null,45,6000,12000),('NGK03','7UP','lon',null,null,40,6000,15000)

INSERT INTO NUOCPHACHE
VALUES ('NPC01',N'CÀ PHÊ ĐÁ', 12000,'L0001'),('NPC02',N'CÀ PHÊ SỮA',15000,'L0001'),('NPC03',N'BẠC XỈU', 17000,'L0001'),
('NPC04',N'SODA CHANH', 18000,'L0002'),('NPC05',N'SODA VẢI',20000,'L0002'),('NPC06',N'SODA ĐÀO', 20000,'L0002'),
('NPC07',N'SINH TỐ BƠ', 22000,'L0003'),('NPC08',N'SINH TỐ MÃNG CẦU',21000,'L0003'),('NPC09',N'SINH TỐ LÚA MẠCH', 21000,'L0003')

	use QL_CAPHE
INSERT INTO CONGTHUC
VALUES ('NPC01', 'NL001','kg', 0.05),('NPC01', 'NL003','l', 0.01),
('NPC02', 'NL001','kg', 0.04),('NPC02', 'NL002','l', 0.05),('NPC02', 'NL003','kg', 0.02),
('NPC03', 'NL001','kg', 0.02),('NPC03', 'NL002','l', 0.06),('NPC03', 'NL003','kg', 0.02),
('NPC04', 'NL006','kg', 0.5),('NPC04', 'NL003','kg', 0.02),('NPC05', 'NL004','l', 0.5),
('NPC06', 'NL005','l', 0.02),('NPC07', 'NL007','kg', 0.5),('NPC07', 'NL002','l', 0.4),('NPC07', 'NL003','kg', 0.02),
('NPC08', 'NL008','kg', 0.5),('NPC08', 'NL002','kg', 0.4),('NPC08', 'NL003','kg', 0.02)


INSERT INTO BAN(TINHTRANG)
VALUES (N'TRỐNG'),(N'TRỐNG'),(N'TRỐNG'),(N'TRỐNG'),(N'TRỐNG'),
(N'TRỐNG'),(N'TRỐNG'),(N'TRỐNG'),(N'TRỐNG'),(N'TRỐNG'),
(N'TRỐNG'),(N'TRỐNG'),(N'TRỐNG'),(N'TRỐNG'),(N'TRỐNG'),
(N'TRỐNG'),(N'TRỐNG'),(N'TRỐNG')
SET DATEFORMAT DMY

INSERT INTO HOADON(MABAN, NGAYLAP,MATK)
VALUES (1, GETDATE(),'nv003'),(3, GETDATE(),'nv003')

INSERT INTO CHITIETHOADON(MAHD, MANUOC, SOLUONG)
VALUES (5,'NPC01', 2), (1,'NGK02', 2), ('1','NPC01', 2)

INSERT INTO CHITIETHOADON(MAHD, MANUOC, SOLUONG) VALUES (1,'" + Manuoc + "', " + sl + ")
UPDATE BAN
SET TINHTRANG = N'TRỐNG'
WHERE MABAN = 2

UPDATE NUOCGIAIKHAT SET TENNGK = N'STING', DVT = N'chai' AND SLNHAPTHEM = 2 AND SLHIENTAI = 40 AND  DONGIA = 4000.0000 AND GIABAN = 16000.0000 WHERE MANGK = 'NGK01'


SELECT * FROM NUOCGIAIKHAT
SELECT * FROM NUOCPHACHE
SELECT * FROM HOADON
SELECT * FROM loai
SELECT * FROM CHITIETHOADON
SELECT * FROM NGUYENLIEU
SELECT * FROM TAIKHOAN WHERE MATK = 'admin' and matkhau = '123456'
SELECT MANL FROM CONGTHUC WHERE MANPC = 'NPC01' 

SELECT MANL, CONGTHUC.SOLUONG FROM CONGTHUC, CHITIETHOADON WHERE CHITIETHOADON.MANUOC = CONGTHUC.MANPC AND CHITIETHOADON.MANUOC = 'NPC01'

SELECT TINHTRANG FROM BAN WHERE MABAN = '1' 
SELECT HOADON.MAHD, MABAN, MANUOC, SOLUONG, DONGIA, THANHTIEN FROM HOADON, CHITIETHOADON WHERE HOADON.MAHD = CHITIETHOADON.MAHD AND MABAN = '1' ORDER BY MAHD DESC

DELETE CHITIETHOADON
WHERE MAHD = 5
DELETE HOADON

SELECT TOP(1) MAHD FROM HOADON ORDER BY MAHD DESC