go
create database PhongKham
go
use PhongKham
go
create table BacSi(
MaBS char(5) not null primary key,
TenBS nvarchar(30) not null,
DiaChi nvarchar(30) not null,
SDT int,
ChuyenMon nvarchar(30) not null)
go
create table BenhNhan(
MaBN char(5) not null primary key,
TenBN nvarchar(30) not null,
DiaChi nvarchar(30) not null,
SDT int,
NgaySinh date)
go
create table HoSoBenhAn(
MaHS char(5) not null,
MaBN char(5) not null foreign key(MaBN) references BenhNhan(MaBN),
TenBN nvarchar(30) not null,
TenBS nvarchar(30) not null,
TinhTrang nvarchar(30) not null,
LichKham nvarchar(30) not null,
ThuocDangDung nvarchar(30) not null
primary key (MaHS,MaBN))
go
create table DuocPham(
MaDP char(5) not null primary key,
TenDP nvarchar(30) not null,
SoLuong int,
DonGia int,
NgayNhap datetime)
go
create table NhanVien(
MaNV char(5) not null primary key,
TenNV nvarchar(30) not null,
DiaChi nvarchar(30) not null,
SDT int,
CongViec nvarchar(30) not null)
go
create table DonThuoc(
MaDT char(5) not null primary key,
MaDP char(5) not null foreign key(MaDP) references DuocPham(MaDP),
MaBS char(5) not null foreign key(MaBS) references BacSi(MaBS),
MaBN char(5) not null foreign key (MaBN) references BenhNhan(MaBN),
SoLuong int,
CachDung nvarchar(30) not null,
NgayKeDon datetime)
go
create table Phong(
MaPK char(5) not null primary key,
TenPK nvarchar(30) not null,
MaNV char(5) not null foreign key(MaNV) references NhanVien(MaNV),
MaBS char(5) not null foreign key(MaBS) references BacSi(MaBS))
go
create table NguoiDung(
TenDN nvarchar(20) not null primary key,
MatKhau nvarchar(20) not null,
Quyen int )
go
insert into BacSi values ('BS001',N'Le Van Tung','Ha Noi',0999999999,N'Khoa noi')
insert into BacSi values ('BS002',N'Le Van Trung','Ha Nam',099999998,N'Khoa noi')
insert into BacSi values ('BS003',N'Pham Van Hung','Ha Noi',0999999997,N'Khoa noi')
insert into BacSi values ('BS004',N'Le Van Khoa','Thai Binh',0999999996,N'Khoa ngoai')
insert into BacSi values ('BS005',N'Tran Van Hai','Ha Noi',0999999995,N'Khoa ngoai')
insert into BacSi values ('BS006',N'Le Thu Huong','Thai Binh',0999999994,N'Khoa ngoai')
insert into BacSi values ('BS007',N'Mac Hong Ha','Ha Noi',0999999993,N'Khoa noi')
insert into BacSi values ('BS008',N'Vu Thi Lan','Ha Noi',0999999992,N'Khoa noi')
insert into BacSi values ('BS009',N'Bui Thu Linh','Ha Nam',0999999991,N'Khoa ngoai')
insert into BacSi values ('BS010',N'Le Van Long','Hai Phong',0999999990,N'Khoa ngoai')
insert into BacSi values ('BS011',N'Tran Thi Quynh','Hai Phong',0999999900,N'Khoa ngoai')
go
insert into BenhNhan values ('BN001','Tran Van Hung','Ha Nam',0898999999,'2017-11-30')
insert into BenhNhan values ('BN002','Tran Van Nam','Ha Noi',0898999998,'2018-01-12')
insert into BenhNhan values ('BN003','Tran Hai Ha','Ha Nam',0898999997,'2018-02-13')
insert into BenhNhan values ('BN004','Nguyen Cong Van','Hung Yen',0898999996,'2018-01-28')
insert into BenhNhan values ('BN005','Nguyen Xuan Thai','Thai Binh',0898999995,'2019-02-17')
insert into BenhNhan values ('BN006','Nguyen Thi Lan','Thai Binh',0898999994,'2019-02-15')
insert into BenhNhan values ('BN007','Le Hong Nhung','Thai Binh',0898999993,'2019-01-31')
insert into BenhNhan values ('BN008','Vu Van Ve','Thai Binh',0898999992,'2019-11-30')
insert into BenhNhan values ('BN009','Vu Thu Huong','Ha Noi',0898999991,'2019-09-01')
insert into BenhNhan values ('BN010','Tran Van Thang','Ha Nam',0898999990,'2019-08-02')
go
insert into HoSoBenhAn values ('HS001','BN001','Tran Van Hung','Le Van Tung','Nhe','Thu 2','Panadol')
insert into HoSoBenhAn values ('HS002','BN002','Tran Van Nam','Le Van Trung','Nhe','Thu 3','Panadol')
insert into HoSoBenhAn values ('HS003','BN003','Tran Hai Ha','Pham Van Hung','Nhe','Thu 6','Panadol')
insert into HoSoBenhAn values ('HS004','BN004','Nguyen Cong Van','Le Van Khoa','Nang','Thu 4','Barbiturate')
insert into HoSoBenhAn values ('HS005','BN005','Nguyen Xuan Thai','Tran Van Hai','Nang','Thu 2','Barbiturate')
insert into HoSoBenhAn values ('HS006','BN006','Nguyen Thi Lan','Le Thu Huong','Nang','Thu 5','Barbiturate')
insert into HoSoBenhAn values ('HS007','BN007','Le Hong Nhung','Vu Thi Lan','Nhe','Thu 6','Panadol')
insert into HoSoBenhAn values ('HS008','BN008','Vu Van Ve','Bui Thu Linh','Nghiem trong','Thu 4','Benzodiazepines')
insert into HoSoBenhAn values ('HS009','BN009','Vu Thu Huong','Le Van Long','Nghiem trong','Thu 3','Benzodiazepines')
insert into HoSoBenhAn values ('HS010','BN010','Tran Van Thang','Tran Thi Quynh','Nghiem trong','Thu 5','Benzodiazepines')
go
insert into DuocPham values ('DP001','Panadol',3500,5000,'2022-03-11')
insert into DuocPham values ('DP002','PanadolExtra',3000,7000,'2022-03-12')
insert into DuocPham values ('DP008','Benzodiazepines',50000,10000,'2022-03-15')
insert into DuocPham values ('DP009','Tiffy',50000,10000,'2022-03-15')
insert into DuocPham values ('DP010','AlphaChoay',11000,5000,'2022-03-19')
insert into DuocPham values ('DP003','Lactacid',3000,5000,'2022-03-21')
insert into DuocPham values ('DP004','Barbiturate',4000,7000,'2022-03-22')
insert into DuocPham values ('DP005','EyeMiru',11000,7000,'2022-04-12')
insert into DuocPham values ('DP006','Yumangel',11000,7000,'2022-04-12')
insert into DuocPham values ('DP007','Verocell',10000,10000,'2022-03-15')
go
insert into NhanVien values ('NV001','Tran Thi Phuong','Thai Binh',0969111222,'Y ta Truong')
insert into NhanVien values ('NV002','Le Thu Ha','Nam Dinh',0969111222,'Y ta')
insert into NhanVien values ('NV003','Nguyen Van Quan','Thai Binh',0969111222,'Y ta')
insert into NhanVien values ('NV004','Nguyen Xuan Truong','Thai Binh',0969111222,'Bac si truong khoa Noi')
insert into NhanVien values ('NV005','Nguyen Thi Bich','Hung Yen',0969111222,'Bac si khoa noi')
insert into NhanVien values ('NV006','Tran Xuan Hung','Hung Yen',0969111222,'Bac si khoa noi')
insert into NhanVien values ('NV007','Ha Cong Hai','Ha Nam',0969111222,'Bac si khoa noi')
insert into NhanVien values ('NV008','Vu Thi Diem','Nam Dinh',0969111222,'Bac si truong khoa Ngoai')
insert into NhanVien values ('NV009','Nguyen Xuan Tu','Ha Noi',0969111222,'Bac si khoa Ngoai')
insert into NhanVien values ('NV010','Tran Thi Anh','Ha Noi',0969111222,'Bac si khoa Ngoai')
go
insert into DonThuoc values ('DT001','DP001','BS001','BN001',100,'Ngay 2 lan','2022-03-01')
insert into DonThuoc values ('DT002','DP002','BS002','BN002',100,'Ngay 2 lan','2022-03-01')
insert into DonThuoc values ('DT003','DP003','BS003','BN003',100,'Ngay 2 lan','2022-03-01')
insert into DonThuoc values ('DT004','DP004','BS004','BN004',800,'Ngay 2 lan','2022-03-02')
insert into DonThuoc values ('DT005','DP005','BS005','BN005',800,'Ngay 2 lan','2022-03-02')
insert into DonThuoc values ('DT006','DP006','BS006','BN006',80,'Ngay 2 lan','2022-03-03')
insert into DonThuoc values ('DT007','DP007','BS007','BN007',100,'Ngay 2 lan','2022-03-05')
insert into DonThuoc values ('DT008','DP008','BS008','BN008',600,'Ngay 2 lan','2022-03-06')
insert into DonThuoc values ('DT009','DP009','BS009','BN009',600,'Ngay 2 lan','2022-03-07')
insert into DonThuoc values ('DT010','DP009','BS010','BN010',600,'Ngay 2 lan','2022-03-12')
insert into DonThuoc values ('DT011','DP005','BS010','BN010',800,'Ngay 2 lan','2022-03-14')
insert into DonThuoc values ('DT012','DP004','BS009','BN001',700,'Ngay 2 lan','2022-03-17')
insert into DonThuoc values ('DT013','DP004','BS008','BN002',800,'Ngay 2 lan','2022-03-17')
insert into DonThuoc values ('DT014','DP006','BS007','BN003',700,'Ngay 2 lan','2022-03-19')
insert into DonThuoc values ('DT015','DP008','BS006','BN004',800,'Ngay 2 lan','2022-03-19')
insert into DonThuoc values ('DT016','DP009','BS005','BN005',700,'Ngay 2 lan','2022-03-20')
insert into DonThuoc values ('DT017','DP001','BS006','BN009',800,'Ngay 2 lan','2022-03-21')
insert into DonThuoc values ('DT018','DP003','BS003','BN007',700,'Ngay 2 lan','2022-03-21')
insert into DonThuoc values ('DT019','DP003','BS004','BN010',800,'Ngay 2 lan','2022-03-22')
insert into DonThuoc values ('DT020','DP007','BS006','BN008',700,'Ngay 2 lan','2022-03-23')
insert into DonThuoc values ('DT021','DP003','BS010','BN010',700,'Ngay 2 lan','2022-03-24')
insert into DonThuoc values ('DT022','DP004','BS009','BN009',1000,'Ngay 2 lan','2022-03-26')
insert into DonThuoc values ('DT023','DP006','BS010','BN010',200,'Ngay 2 lan','2022-03-26')
insert into DonThuoc values ('DT024','DP010','BS010','BN002',300,'Ngay 2 lan','2022-03-30')
insert into DonThuoc values ('DT025','DP010','BS009','BN001',400,'Ngay 2 lan','2022-04-01')
insert into DonThuoc values ('DT026','DP008','BS010','BN001',500,'Ngay 2 lan','2022-04-01')
insert into DonThuoc values ('DT027','DP009','BS010','BN001',200,'Ngay 2 lan','2022-04-02')
insert into DonThuoc values ('DT028','DP005','BS001','BN002',300,'Ngay 2 lan','2022-04-02')
insert into DonThuoc values ('DT029','DP006','BS003','BN003',500,'Ngay 2 lan','2022-04-03')
insert into DonThuoc values ('DT030','DP001','BS010','BN004',600,'Ngay 2 lan','2022-04-03')
insert into DonThuoc values ('DT031','DP001','BS010','BN005',700,'Ngay 2 lan','2022-04-03')
insert into DonThuoc values ('DT032','DP002','BS002','BN006',800,'Ngay 2 lan','2022-04-04')
insert into DonThuoc values ('DT033','DP002','BS010','BN007',900,'Ngay 2 lan','2022-04-05')
insert into DonThuoc values ('DT034','DP002','BS004','BN008',200,'Ngay 2 lan','2022-04-06')
insert into DonThuoc values ('DT035','DP007','BS010','BN001',100,'Ngay 2 lan','2022-04-07')
insert into DonThuoc values ('DT036','DP007','BS006','BN002',100,'Ngay 2 lan','2022-04-08')
insert into DonThuoc values ('DT037','DP010','BS006','BN006',100,'Ngay 2 lan','2022-04-08')
insert into DonThuoc values ('DT038','DP010','BS006','BN006',200,'Ngay 2 lan','2022-04-09')
insert into DonThuoc values ('DT039','DP009','BS009','BN007',200,'Ngay 2 lan','2022-04-10')
insert into DonThuoc values ('DT040','DP008','BS003','BN007',300,'Ngay 2 lan','2022-04-11')
insert into DonThuoc values ('DT041','DP007','BS010','BN009',900,'Ngay 2 lan','2022-04-12')
insert into DonThuoc values ('DT042','DP010','BS010','BN001',600,'Ngay 2 lan','2022-04-12')
insert into DonThuoc values ('DT043','DP003','BS010','BN010',300,'Ngay 2 lan','2022-04-13')
insert into DonThuoc values ('DT044','DP002','BS010','BN010',100,'Ngay 2 lan','2022-04-14')
insert into DonThuoc values ('DT045','DP001','BS009','BN006',400,'Ngay 2 lan','2022-04-15')
insert into DonThuoc values ('DT046','DP008','BS010','BN005',400,'Ngay 2 lan','2022-04-15')
insert into DonThuoc values ('DT047','DP009','BS001','BN004',600,'Ngay 2 lan','2022-04-15')
insert into DonThuoc values ('DT048','DP002','BS010','BN008',700,'Ngay 2 lan','2022-04-16')
insert into DonThuoc values ('DT049','DP003','BS002','BN008',200,'Ngay 2 lan','2022-04-17 12:00:00.000')
insert into DonThuoc values ('DT050','DP005','BS003','BN006',100,'Ngay 2 lan','2022-04-17 06:00:00.000')

go
insert into Phong values ('P001','Phong kham tai','NV001','BS001')
insert into Phong values ('P002','Phong kham mui','NV002','BS002')
insert into Phong values ('P003','Phong kham hong','NV003','BS003')
insert into Phong values ('P004','Phong kham mat','NV004','BS004')
insert into Phong values ('P005','Phong noi soi','NV005','BS005')
insert into Phong values ('P006','Phong xet nghiem','NV006','BS006')
insert into Phong values ('P007','Phong kham than kinh','NV007','BS007')
insert into Phong values ('P008','Phong sieu am','NV008','BS008')
insert into Phong values ('P009','Phong kham xuong','NV009','BS009')
insert into Phong values ('P010','Phong kham dau','NV010','BS010')
go
insert into NguoiDung values('lcentury','12345',1)
insert into NguoiDung values('kingofwar','12345',1)
insert into NguoiDung values('someone','12345',2)

--lấy ra số dược phẩm tồn kho
go
update DuocPham 
set  DuocPham.SoLuong = DuocPham.SoLuong - dt.Quantity
from DuocPham 
inner join (select MaDP, SUM(SoLuong) AS Quantity
			from DonThuoc
			group by MaDP) dt on DuocPham.MaDP = dt.MaDP