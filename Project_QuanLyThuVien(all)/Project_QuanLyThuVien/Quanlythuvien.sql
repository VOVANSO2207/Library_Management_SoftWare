create database QuanLyThuVien
use QuanLyThuVien

create table Sach
(
	MaSach nvarchar(10)not null primary key,
	TenSach nvarchar(50),
	NamXB int,
	MaNhaXuatBan nvarchar(10),
	SoLuong int ,
	MaTheLoai nvarchar(10)not null,
	MaTacGia nvarchar(10),
);

create table TheLoai
(
	MaTheLoai nvarchar(10)not null primary key,
	TenTheLoai nvarchar(50),
);

create table NhaXuatBan
(
	MaNhaXuatBan nvarchar(10) not null primary key,
	TenNhaXuatBan nvarchar(50),
	DiaChi nvarchar(50),
	Sdt varchar(11),

	
);
create table NhanVien
(
	MaNV nvarchar(10)not null primary key,
	HoTenNV nvarchar(50),
	GioiTinh nvarchar(5),
	SDT varchar(11),
	CaTruc nvarchar(10),
	ChucVu nvarchar(50),
);
create table DocGia 
(		
	MaDocGia nvarchar(10)not null primary key,
	TenDocGia nvarchar(20),
	NgaySinh date,
	GioiTinh nvarchar(5),
	DiaChi nvarchar(50),
	CCCD varchar(15),
	Email nvarchar(20),
	LoaiDocGia nvarchar(10),
	SoSachMuon int,
	
);

create table PhieuMuon
(
	
	MaPhieuMuon nvarchar(10)not null primary key,
	MaSach nvarchar(10),
	NgayMuon date,
	HanTraSach date,
	MaDocGia nvarchar(10),
	SoLuongMuon int,
	MaNV nvarchar(10),
);

create table ChiTietPhieuMuon
(
	MaCTPM nvarchar(10)not null primary key,
	MaPhieuMuon nvarchar(10),
	MaSach nvarchar(10),
	
);
create table ChiTietPhieuTra
(
	MaCTPT nvarchar(10)not null primary key,
	MaPhieuTra nvarchar(10),
	MaPhieuMuon nvarchar(10),
	MaSach nvarchar(10),

);
-- Tim kiem theo MaDocGia,MaPhieuMuon,MaPhieuTra
create table PhieuPhat
(
	MaPhieuPhat nvarchar(10)not null primary key,
	MaDocGia nvarchar(10),
	SoNgayQuaHan int,
	SoTienPhat int,
	MaNV nvarchar(10),
	--MaNVLapPhieuPhat nvarchar(10),
	MaPhieuMuon nvarchar(10),	
	MaSach nvarchar(10),
);
create table PhieuTra
(
	MaPhieuTra nvarchar(10)not null primary key,
	MaDocGia nvarchar(10),
	MaPhieuMuon nvarchar(10),
	NgayTraSach date,
	MaNV nvarchar(10),
	MaSach nvarchar(10),	
	
);
ALTER TABLE PhieuTra
ADD GhiChu nvarchar(20);
-- Nếu Ngày Trả Sách >Hạn Trả Sách Thì Lập Phiếu Phạt
CREATE TABLE TacGia (
	MaTacGia nvarchar(10) not null primary key ,
	TenTacGia nvarchar(10),
	
	
)
ALTER TABLE PhieuMuon DROP CONSTRAINT FK_PhieuMuon_Sach_MaSach;

-- Xóa cột MaSach
ALTER TABLE PhieuMuon DROP COLUMN MaSach;
DELETE FROM ChiTietPhieuMuon;



-----Ràng Buộc điều kiện
ALTER TABLE Sach ADD CONSTRAINT CHK_NamXB CHECK (NamXB > 0);
ALTER TABLE Sach ADD CONSTRAINT CHK_SoLuong CHECK (SoLuong >= 0);


---------------------------Liên kết khóa ngoại 
ALTER TABLE PhieuPhat ADD CONSTRAINT FK_PhieuPhat_DocGia_MaDocGia FOREIGN KEY (MaDocGia) REFERENCES DocGia(MaDocGia);
ALTER TABLE PhieuMuon ADD CONSTRAINT FK_PhieuMuon_DocGia_MaDocGia FOREIGN KEY (MaDocGia) REFERENCES DocGia(MaDocGia);
ALTER TABLE PhieuTra ADD CONSTRAINT FK_PhieuTra_DocGia_MaDocGia FOREIGN KEY (MaDocGia) REFERENCES DocGia(MaDocGia);
ALTER TABLE PhieuPhat ADD CONSTRAINT FK_PhieuPhat_NhanVien_MaNV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV);
ALTER TABLE PhieuMuon ADD CONSTRAINT FK_PhieuMuon_NhanVien_MaNV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV);
ALTER TABLE PhieuTra ADD CONSTRAINT FK_PhieuTra_NhanVien_MaNV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV);

ALTER TABLE PhieuTra ADD CONSTRAINT FK_PhieuTra_PhieuMuon_MaPhieuMuon FOREIGN KEY (MaPhieuMuon) REFERENCES PhieuMuon(MaPhieuMuon);
ALTER TABLE PhieuPhat ADD CONSTRAINT FK_PhieuPhat_PhieuMuon_MaPhieuMuon FOREIGN KEY (MaPhieuMuon) REFERENCES PhieuMuon(MaPhieuMuon);

ALTER TABLE Sach ADD CONSTRAINT FK_Sach_LoaiSach_MaTheLoai FOREIGN KEY (MaTheLoai) REFERENCES TheLoai(MaTheLoai);
ALTER TABLE PhieuTra ADD CONSTRAINT FK_Sach_PhieuTra_MaPhieuMuon FOREIGN KEY (MaSach) REFERENCES Sach(MaSach);
ALTER TABLE PhieuPhat ADD CONSTRAINT FK_Sach_PhieuPhat_MaSach FOREIGN KEY (MaSach) REFERENCES Sach(MaSach);
ALTER TABLE PhieuMuon ADD CONSTRAINT FK_Sach_PhieuMuon_MaSach FOREIGN KEY (MaSach) REFERENCES Sach(MaSach);

ALTER TABLE Sach ADD CONSTRAINT FK_NhaXuatBan_Sach_MaNhaXuatBan FOREIGN KEY (MaNhaXuatBan) REFERENCES NhaXuatBan(MaNhaXuatBan);



ALTER TABLE Sach ADD CONSTRAINT FK_TacGia_Sach_MaTacGia FOREIGN KEY(MaTacGia) REFERENCES TacGia(MaTacGia);

ALTER TABLE ChiTietPhieuMuon
ADD CONSTRAINT FK_ChiTietPhieuMuon_PhieuMuon FOREIGN KEY(MaPhieuMuon) REFERENCES PhieuMuon(MaPhieuMuon);
ALTER TABLE ChiTietPhieuMuon
ADD CONSTRAINT FK_ChiTietPhieuMuon_Sach FOREIGN KEY(MaSach) REFERENCES Sach(MaSach);


ALTER TABLE ChiTietPhieuTra
ADD CONSTRAINT FK_ChiTietPhieuTra_PhieuTra FOREIGN KEY(MaPhieuTra) REFERENCES PhieuTra(MaPhieuTra);

ALTER TABLE ChiTietPhieuTra
ADD CONSTRAINT FK_ChiTietPhieuTra_Sach FOREIGN KEY(MaSach) REFERENCES Sach(MaSach);

set dateformat dmy
--Chèn dữ liệu cho bảng Thể loại
GO
insert into TheLoai(MaTheLoai,TenTheLoai)
values('TL01',N'Ngoại ngữ')
GO
insert into TheLoai(MaTheLoai,TenTheLoai)
values('TL02',N'Toán')
GO
insert into TheLoai(MaTheLoai,TenTheLoai)
values('TL03',N'Hóa Học')
GO
insert into TheLoai(MaTheLoai,TenTheLoai)
values('TL04',N'Ngữ Văn')
insert into TheLoai(MaTheLoai,TenTheLoai)
values('TL05',N'Lịch Sử')
insert into TheLoai(MaTheLoai,TenTheLoai)
values('TL06',N'Địa lý')
--Chèn dữ liệu bảng Nhà Xuất Bản
GO
insert into NhaXuatBan(MaNhaXuatBan,TenNhaXuatBan,DiaChi,Sdt)
values('NXB01',N'Kim Đồng',N'TP.Hồ Chí Minh','098254136')
GO
insert into NhaXuatBan(MaNhaXuatBan,TenNhaXuatBan,DiaChi,Sdt)
values('NXB02',N'Tiền Phong',N'Đà Nẵng','087542143')
GO
insert into NhaXuatBan(MaNhaXuatBan,TenNhaXuatBan,DiaChi,Sdt)
values('NXB03',N'Quân Đội',N'TP.Hồ Chí Minh','0572514235')

--Chèn dữ liệu bảng Nhân Viên
GO
insert into NhanVien(MaNV,HoTenNV,GioiTinh,Sdt,CaTruc,ChucVu)
values('NV01',N'Võ Văn Sô','Nam','015234561',N'Sáng',N'Nhân viên')
GO
insert into NhanVien(MaNV,HoTenNV,GioiTinh,Sdt,CaTruc,ChucVu)
values('NV02',N'Trần Võ Quang Tín','Nam','012234562',N'Chiều',N'Nhân viên')
GO
insert into NhanVien(MaNV,HoTenNV,GioiTinh,Sdt,CaTruc,ChucVu)
values('NV03',N'Cao Nguyễn Thiên Bảo','Nam','012234563',N'Tối',N'Nhân viên')

--Chèn dữ liệu bảng Độc giả
GO
insert into DocGia(MaDocGia,TenDocGia,NgaySinh,GioiTinh,DiaChi,CCCD,Email,LoaiDocGia,SoSachMuon)
values('DG01',N'Trần Văn A','03/01/2000',N'Nam',N'Hà Nội','12345677','tranvana@gmail.com',N'Cán Bộ',4)
GO
insert into DocGia(MaDocGia,TenDocGia,NgaySinh,GioiTinh,DiaChi,CCCD,Email,LoaiDocGia,SoSachMuon)
values('DG02',N'Nguyễn Văn B' ,'02/02/2000',N'Nam',N'Đà Nẵng','12345678','nguyenvanb@gmail.com',N'Sinh Viên',5)
GO
insert into DocGia(MaDocGia,TenDocGia,NgaySinh,GioiTinh,DiaChi,CCCD,Email,LoaiDocGia,SoSachMuon)
values('DG03',N'Trần Thị C','03/06/2000',N'Nữ',N'TP.HCM','12345679','tranthic@gmail.com',N'Khác',4)
GO
insert into DocGia(MaDocGia,TenDocGia,NgaySinh,GioiTinh,DiaChi,CCCD,Email,LoaiDocGia,SoSachMuon)
values('DG04',N'Lê Hữu Khang ','03/01/2000',N'Nam',N'Hà Nội','12345677','levand@gmail.com',N'Khác',3)
insert into DocGia(MaDocGia,TenDocGia,NgaySinh,GioiTinh,DiaChi,CCCD,Email,LoaiDocGia,SoSachMuon)
values('DG011',N'Lê na','03/01/2000',N'Nam',N'Hà Nội','12345677','levand@gmail.com',N'Khác',3)
insert into DocGia(MaDocGia,TenDocGia,NgaySinh,GioiTinh,DiaChi,CCCD,Email,LoaiDocGia,SoSachMuon)
values('DG12',N'Trần Bình ','03/01/2000',N'Nam',N'Hà Nội','12345677','levand@gmail.com',N'Khác',3)
insert into DocGia(MaDocGia,TenDocGia,NgaySinh,GioiTinh,DiaChi,CCCD,Email,LoaiDocGia,SoSachMuon)
values('DG13',N'Võ Sơn','03/01/2000',N'Nam',N'Hà Nội','12345677','levand@gmail.com',N'Khác',3)
insert into DocGia(MaDocGia,TenDocGia,NgaySinh,GioiTinh,DiaChi,CCCD,Email,LoaiDocGia,SoSachMuon)
values('DG014',N'Bích Thái','03/01/2000',N'Nam',N'Hà Nội','12345677','levand@gmail.com',N'Khác',3)
select * from DocGia 
--Chèn dữ liệu bảng Tác Giả
GO 
insert into TacGia(MaTacGia,TenTacGia)
values('TG01',N'Tô Hoài')
GO 
insert into TacGia(MaTacGia,TenTacGia)
values('TG02',N'Nam Cao')
GO 
insert into TacGia(MaTacGia,TenTacGia)
values('TG03',N'Văn Lâm')
--Chèn dữ liệu bảng Sách
GO
insert into Sach(MaSach, TenSach, NamXB, MaNhaXuatBan, SoLuong, MaTheLoai, MaTacGia)
values('S01', N'Toán Lớp 1', 2000, 'NXB01', 5, 'TL02', 'TG01');
GO
insert into Sach(MaSach,TenSach,NamXB,MaNhaXuatBan,SoLuong,MaTheLoai,MaTacGia)
values('S02',N'Ngữ văn Lớp 6',2000,'NXB02',35,'TL04','TG03')
GO
insert into Sach(MaSach,TenSach,NamXB,MaNhaXuatBan,SoLuong,MaTheLoai,MaTacGia)
values('S03',N'Hóa Lớp 9',2001,'NXB03',5,'TL03','TG01')
GO
insert into Sach(MaSach,TenSach,NamXB,MaNhaXuatBan,SoLuong,MaTheLoai,MaTacGia)
values('S04',N'Ngoại ngữ Lớp 9',2004,'NXB03',15,'TL01','TG02')
GO
insert into Sach(MaSach,TenSach,NamXB,MaNhaXuatBan,SoLuong,MaTheLoai,MaTacGia)
values('S05',N'Toán Lớp 3',2004,'NXB01',15,'TL02','TG01')
GO
insert into Sach(MaSach,TenSach,NamXB,MaNhaXuatBan,SoLuong,MaTheLoai,MaTacGia)
values('S06',N'Hóa Lớp 8','2002','NXB03',20,'TL03','TG03')
GO
insert into Sach(MaSach,TenSach,NamXB,MaNhaXuatBan,SoLuong,MaTheLoai,MaTacGia)
values('S09',N'Hóa Lớp 12','2002','NXB03',50,'TL03','TG03')

insert into Sach(MaSach,TenSach,NamXB,MaNhaXuatBan,SoLuong,MaTheLoai,MaTacGia)
values('S014',N'Lịch Sử 12','1999','NXB03',20,'TL05','TG02')
go 
insert into Sach(MaSach,TenSach,NamXB,MaNhaXuatBan,SoLuong,MaTheLoai,MaTacGia)
values('S010',N'Hóa Lớp 12','2022','NXB02',40,'TL03','TG02')
insert into Sach(MaSach,TenSach,NamXB,MaNhaXuatBan,SoLuong,MaTheLoai,MaTacGia)
values('S011',N'Văn Hóa Địa Lý','2004','NXB03',60,'TL06','TG02')
insert into Sach(MaSach,TenSach,NamXB,MaNhaXuatBan,SoLuong,MaTheLoai,MaTacGia)
values('S012',N'Đia Lý Thế Giới','1980','NXB01',30,'TL06','TG01')
insert into Sach(MaSach,TenSach,NamXB,MaNhaXuatBan,SoLuong,MaTheLoai,MaTacGia)
values('S013',N'Hóa Lớp 8','2002','NXB01',30,'TL03','TG03')
insert into Sach(MaSach,TenSach,NamXB,MaNhaXuatBan,SoLuong,MaTheLoai,MaTacGia)
values('S015',N'Vật Lý 11','2000','NXB01',30,'TL02','TG03')

insert into Sach(MaSach,TenSach,NamXB,MaNhaXuatBan,SoLuong,MaTheLoai,MaTacGia)
values('S016',N'Toán 10','2004','NXB02',50,'TL02','TG02')
insert into Sach(MaSach,TenSach,NamXB,MaNhaXuatBan,SoLuong,MaTheLoai,MaTacGia)
values('S017',N'Anh Văn 8','2003','NXB02',30,'TL01','TG03')

insert into Sach(MaSach,TenSach,NamXB,MaNhaXuatBan,SoLuong,MaTheLoai,MaTacGia)
values('S018',N'Anh Văn 9','2003','NXB02',60,'TL01','TG03')
SELECT * from Sach 
--Chèn dữ liệu cho bảng Phiếu Mượn

GO
insert into PhieuMuon(MaPhieuMuon,NgayMuon,HanTraSach,MaDocGia,SoLuongMuon,MaNV)
values('MPM01','4/2/2023','10/2/2023','DG01',4,'NV01')
GO
insert into PhieuMuon(MaPhieuMuon,NgayMuon,HanTraSach,MaDocGia,SoLuongMuon,MaNV)
values('MPM02','4/3/2023','7/3/2023','DG02',2,'NV02')
GO
insert into PhieuMuon(MaPhieuMuon,NgayMuon,HanTraSach,MaDocGia,SoLuongMuon,MaNV)
values('MPM03','4/7/2023','7/7/2023','DG03',4,'NV03')
GO
insert into PhieuMuon(MaPhieuMuon,NgayMuon,HanTraSach,MaDocGia,SoLuongMuon,MaNV)
values('MPM04','2/4/2023','7/4/2023','DG04',3,'NV01')
insert into PhieuMuon(MaPhieuMuon,NgayMuon,HanTraSach,MaDocGia,SoLuongMuon,MaNV)
values('MPM05','12/4/2023','7/4/2023','DG03',3,'NV02')
insert into PhieuMuon(MaPhieuMuon,NgayMuon,HanTraSach,MaDocGia,SoLuongMuon,MaNV)
values('MPM06','2/4/2023','7/4/2023','DG04',3,'NV01')
insert into PhieuMuon(MaPhieuMuon,NgayMuon,HanTraSach,MaDocGia,SoLuongMuon,MaNV)
values('MPM07','2/4/2023','7/4/2023','DG04',3,'NV01')
insert into PhieuMuon(MaPhieuMuon,NgayMuon,HanTraSach,MaDocGia,SoLuongMuon,MaNV)
values('MPM08','2/4/2023','7/4/2023','DG04',3,'NV01')

insert into PhieuMuon(MaPhieuMuon,NgayMuon,HanTraSach,MaDocGia,SoLuongMuon,MaNV)
values('MPM09','2/2/2023','7/4/2023','DG01',3,'NV02')
insert into PhieuMuon(MaPhieuMuon,NgayMuon,HanTraSach,MaDocGia,SoLuongMuon,MaNV)
values('MPM010','2/2/2023','7/4/2023','DG01',3,'NV02')

select * from PhieuMuon
SELECT * from ChiTietPhieuMuon 
select * from PhieuMuon where MaPhieuMuon ='MPM01'
--Chèn dữ liệu cho bảng Chi tiết phiếu mượn
GO

Insert into ChiTietPhieuMuon(MaCTPM,MaPhieuMuon,MaSach)
values('CTPM01','MPM01','S02')
GO
Insert into ChiTietPhieuMuon(MaCTPM,MaPhieuMuon,MaSach)
values('CTPM02','MPM02','S04')
GO
Insert into ChiTietPhieuMuon(MaCTPM,MaPhieuMuon,MaSach)
values('CTPM03','MPM02','S06')
GO
Insert into ChiTietPhieuMuon(MaCTPM,MaPhieuMuon,MaSach)
values('CTPM04','MPM04','S03')

Insert into ChiTietPhieuMuon(MaCTPM,MaPhieuMuon,MaSach)
values('CTPM05','MPM04','S03')
Insert into ChiTietPhieuMuon(MaCTPM,MaPhieuMuon,MaSach)
values('CTPM06','MPM04','S04')
Insert into ChiTietPhieuMuon(MaCTPM,MaPhieuMuon,MaSach)
values('CTPM07','MPM04','S02')

Insert into ChiTietPhieuMuon(MaCTPM,MaPhieuMuon,MaSach)
values('CTPM08','MPM05','S05')
Insert into ChiTietPhieuMuon(MaCTPM,MaPhieuMuon,MaSach)
values('CTPM09','MPM06','S03')
Insert into ChiTietPhieuMuon(MaCTPM,MaPhieuMuon,MaSach)
values('CTPM10','MPM06','S04')
Insert into ChiTietPhieuMuon(MaCTPM,MaPhieuMuon,MaSach)
values('CTPM010','MPM06','S06')

--Chèn dữ liệu bảng Phiếu Trả
--Xóa trước khi thêm Ghi chú
DELETE FROM PhieuTra
WHERE MaPhieuTra = 'MPT02';

GO
insert into PhieuTra(MaPhieuTra, MaDocGia, MaPhieuMuon, NgayTraSach, MaNV,MaSach,GhiChu)
values('MPT01', 'DG01', 'MPM01', '7/3/2023', 'NV01','S01','Tốt');
GO
insert into PhieuTra(MaPhieuTra,MaDocGia,MaPhieuMuon,NgayTraSach,MaNV,MaSach,GhiChu)
values('MPT02','DG02','MPM02','7/7/2023','NV02','S02','Sách bị rách')
GO
insert into PhieuTra(MaPhieuTra,MaDocGia,MaPhieuMuon,NgayTraSach,MaNV,MaSach,GhiChu)
values('MPT03','DG03','MPM03','7/4/2023','NV03','S03','Sách bị rách bìa')
GO
insert into PhieuTra(MaPhieuTra,MaDocGia,MaPhieuMuon,NgayTraSach,MaNV,MaSach,GhiChu)
values('MPT04','DG04','MPM04','7/4/2023','NV01','S04','Tốt')

insert into PhieuTra(MaPhieuTra,MaDocGia,MaPhieuMuon,NgayTraSach,MaNV,MaSach,GhiChu)
values('MPT08','DG04','MPM04','7/4/2023','NV01','S05','Tốt')
insert into PhieuTra(MaPhieuTra,MaDocGia,MaPhieuMuon,NgayTraSach,MaNV,MaSach,GhiChu)
values('MPT06','DG02','MPM05','6/3/2023','NV01','S06','Sách bị dính màu')
insert into PhieuTra(MaPhieuTra,MaDocGia,MaPhieuMuon,NgayTraSach,MaNV,MaSach,GhiChu)
values('MPT07','DG03','MPM06','2/4/2023','NV02','S07','Tốt')

--Chèn dữ liệu cho bảng Chi tiết phiếu trả
GO
Insert into ChiTietPhieuTra(MaCTPT,MaPhieuTra,MaPhieuMuon,MaSach)
values('CTPT01','MPT01','MPM01','S02')
GO
Insert into ChiTietPhieuTra(MaCTPT,MaPhieuTra,MaPhieuMuon,MaSach)
values('CTPT02','MPT02','MPM02','S04')
GO
Insert into ChiTietPhieuTra(MaCTPT,MaPhieuTra,MaPhieuMuon,MaSach)
values('CTPT03','MPT03','MPM03','S06')
GO
Insert into ChiTietPhieuTra(MaCTPT,MaPhieuTra,MaPhieuMuon,MaSach)
values('CTPT04','MPT04','MPM04','S03')
Insert into ChiTietPhieuTra(MaCTPT,MaPhieuTra,MaPhieuMuon,MaSach)
values('CTPT05','MPT05','MPM05','S02')
Insert into ChiTietPhieuTra(MaCTPT,MaPhieuTra,MaPhieuMuon,MaSach)
values('CTPT06','MPT05','MPM05','S06')
Insert into ChiTietPhieuTra(MaCTPT,MaPhieuTra,MaPhieuMuon,MaSach)
values('CTPT07','MPT06','MPM06','S04')

--Chèn dữ liệu bảng Phiếu phạt
GO
Insert into PhieuPhat(MaPhieuPhat,MaDocGia,SoNgayQuaHan,SoTienPhat,MaNV,MaPhieuMuon)
values('MPP01','DG01',3,6000,'NV01','MPM01')
GO
Insert into PhieuPhat(MaPhieuPhat,MaDocGia,SoNgayQuaHan,SoTienPhat,MaNV,MaPhieuMuon)
values('MPP02','DG02',4,8000,'NV02','MPM02')
GO
Insert into PhieuPhat(MaPhieuPhat,MaDocGia,SoNgayQuaHan,SoTienPhat,MaNV,MaPhieuMuon)
values('MPP03','DG03',5,10000,'NV03','MPM03')
GO
Insert into PhieuPhat(MaPhieuPhat,MaDocGia,SoNgayQuaHan,SoTienPhat,MaNV,MaPhieuMuon)
values('MPP04','DG04',7,14000,'NV01','MPM04')
Insert into PhieuPhat(MaPhieuPhat,MaDocGia,SoNgayQuaHan,SoTienPhat,MaNV,MaPhieuMuon)
values('MPP08','DG05',2,33333,'NV02','MPM05')
Insert into PhieuPhat(MaPhieuPhat,MaDocGia,SoNgayQuaHan,SoTienPhat,MaNV,MaPhieuMuon)
values('MPP06','DG02',3,32000,'NV01','MPM05')
Insert into PhieuPhat(MaPhieuPhat,MaDocGia,SoNgayQuaHan,SoTienPhat,MaNV,MaPhieuMuon)
values('MPP07','DG01',5,11000,'NV01','MPM06')


SELECT
    S.MaSach,
    S.TenSach,
    S.MaNhaXuatBan,
    NXB.TenNhaXuatBan,
    NXB.DiaChi,
	NXB.SDT
FROM Sach S
INNER JOIN NhaXuatBan NXB ON S.MaNhaXuatBan = NXB.MaNhaXuatBan;

select * From PhieuTra 






