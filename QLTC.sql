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

CREATE TABLE KhoaHoc
(
   KhoaHoc nvarchar(50),
   ChiTiet nvarchar(500),
   PRIMARY KEY (KhoaHoc)
);


CREATE TABLE LopHoc
(
   LopHoc nvarchar(50),
   ChiTiet nvarchar(500),
   PRIMARY KEY (LopHoc)
);



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




insert into TaiKhoan (TEN_TK, MATKHAU) 
values 
('dhthuong','dhthuong123')

insert into KhoaHoc (KhoaHoc, ChiTiet) 
values 
('KH001', N'Khóa 12'),
('KH002', N'Khóa 11'),
('KH003', N'Khóa 11'),
('KH004', N'Khóa 11');

select * from KhoaHoc

insert into LopHoc (LopHoc, ChiTiet) 
values 
('LH001', N'Khóa 12'),
('LH002', N'Khóa 11'),
('LH003', N'Khóa 11'),
('LH004', N'Khóa 11');


insert into PHIEU_THU_CHI (NgayLap,KhoaHoc,LopHoc,Thu, Chi, Nguoi, Cash, Discount ,SoHoaDon) 
values 
( '2023-08-11','KH001','LH001',2245000,null,N'DANH',N'Tiền mặt','20','4114478448'),
( '2023-05-07','KH002','LH002',2245000,null,N'MAN',N'Cà thẻ','20','5444365657'),
( '2023-02-07','KH003','LH003',null,2245000,N'LAM',N'Chuyển khoản','20','5565476556'),
( '2023-11-07','KH004','LH004',null,2245000,N'TRACH',N'Tiền mặt','20','56556565556');

select NgayLap AS Ngày_lập,KhoaHoc AS Khóa_học ,
LopHoc AS Lớp_học ,FORMAT(thu, '#,##0') AS Thu,FORMAT(chi, '#,##0') AS Chi,
Nguoi AS Khách_hàng, Cash AS Thanh_toán,Discount as Giảm_giá, SoHoaDon AS Số_hóa_đơn 
from PHIEU_THU_CHI 
WHERE Nguoi LIKE 'Man' OR KhoaHoc LIKE 'KH001' 

select NgayLap AS Ngày_lập,KhoaHoc AS Khóa_học ,LopHoc AS Lớp_học ,FORMAT(thu, '#,##0') AS Thu,Nguoi AS Khách_hàng, Cash AS Thanh_toán,Discount as Giảm_giá, SoHoaDon AS Số_hóa_đơn 
from PHIEU_THU_CHI WHERE thu is not null and Nguoi LIKE 'ma%' or thu is not null and KhoaHoc LIKE 'ma%' or thu is not null and lophoc LIKE 'ma%'  

Update KHOAHOC set khoahoc = N'KH001' and ChiTiet =  N'Khóa 1' where khoahoc = N'KH001'

UPDATE KHOAHOC
SET khoahoc = N'KH001', ChiTiet = N'Khóa 1' 
WHERE khoahoc = N'KH001';

select FORMAT(NgayLap, '#,##0') AS Ngày_lập,KhoaHoc AS Khóa_học ,LopHoc AS Lớp_học ,FORMAT(thu, '#,##0') AS Thu,
FORMAT(chi, '#,##0') AS Chi,Nguoi AS Khách_hàng, Cash AS Thanh_toán,Discount as Giảm_giá,SoHoaDon AS Số_hóa_đơn from PHIEU_THU_CHI
            