﻿
create database QLTC

use QLTC;
go

CREATE TABLE TaiKhoan
(
   TEN_TK char(40) NOT NULL,
   MATKHAU char(30),
   PRIMARY KEY (TEN_TK)
);
insert into TaiKhoan (TEN_TK, MATKHAU) 
values 
('dhthuong','dhthuong123')


CREATE TABLE KhoaHoc
(
   KhoaHoc nvarchar(50),
   PRIMARY KEY (KhoaHoc)
);

insert into KhoaHoc (KhoaHoc) 
values 
('KH001'),
('KH002'),
('KH003'),
('KH004');

select * from KhoaHoc

CREATE TABLE LopHoc
(
   LopHoc nvarchar(50),
   PRIMARY KEY (LopHoc)
);

insert into LopHoc (LopHoc) 
values 
('LH001'),
('LH002'),
('LH003'),
('LH004');

update LopHoc set LopHoc = 'LH002' Where LopHoc = 'KH002'

select * from LopHoc
drop table PHIEU_THU_CHI


CREATE TABLE PHIEU_THU_CHI
(
   MaPhieu INT IDENTITY(1,1) PRIMARY KEY,
   NgayLap date,
   KhoaHoc nvarchar(50),
   LopHoc nvarchar(50),
   Thu int,
   Chi int,
   Nguoi nvarchar(50),
   Cash nvarchar(50),
   Discount nvarchar(50),
   SoHoaDon char(50),
   FOREIGN KEY (KhoaHoc) REFERENCES KhoaHoc(KhoaHoc),
   FOREIGN KEY (LopHoc) REFERENCES LopHoc(LopHoc)
);


select * from PHIEU_THU_CHI
drop TABLE PHIEU_THU_CHI

insert into PHIEU_THU_CHI (NgayLap,KhoaHoc,LopHoc,Thu, Chi, Nguoi, Cash, Discount ,SoHoaDon) 
values 
( '2023-08-11','KH001','LH001',2245000,null,N'DANH',N'Tiền mặt','20','4114478448'),
( '2023-05-07','KH002','LH002',2245000,null,N'MAN',N'Cà thẻ','20','5444365657'),
( '2023-02-07','KH003','LH003',null,2245000,N'LAM',N'Chuyển khoản','20','5565476556'),
( '2023-11-07','KH004','LH004',null,2245000,N'TRACH',N'Tiền mặt','20','56556565556');

