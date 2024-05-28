-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE <Procedure_Name, sysname, ProcedureName> 
	-- Add the parameters for the stored procedure here
	<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>
END
drop proc XemChiTietPhieuMuon
CREATE PROCEDURE XemChiTietPhieuMuon
    @MaPhieuMuon NVARCHAR(10)
AS
BEGIN
    SELECT 
        pm.MaPhieuMuon,
        ctpm.MaCTPM,
        ctpm.MaSach,
        s.TenSach,
        s.NamXB,
        s.MaNhaXuatBan,
        s.SoLuong,
        s.MaTheLoai,
        s.MaTacGia
    FROM ChiTietPhieuMuon ctpm
    INNER JOIN PhieuMuon pm ON ctpm.MaPhieuMuon = pm.MaPhieuMuon
    INNER JOIN Sach s ON ctpm.MaSach = s.MaSach
    WHERE pm.MaPhieuMuon = @MaPhieuMuon;
END;
EXEC XemChiTietPhieuMuon @MaPhieuMuon = 'MPM01';
----drop proc XemChiTietPhieuMuon

---Doc Gia
create proc sp_cobDocGia
as
begin
select MaDocGia from DocGia
end
GO
--cob Ma nhan vien
create proc sp_cobMaNV
as
begin
select MaNV from NhanVien
end 
go
--cob Ma sach
create proc sp_cobMaSach
as
begin
select MaSach from Sach
end 
go
--- LAY DANH SACH THE LOAI
create proc sp_LayDSTheLoai
as
begin
	select * from TheLoai
	end
go


--- LAY DANH SACH NHA XUAT BAN
create proc sp_LayDSNhaXuatBan
as
begin
	select * from NhaXuatBan
	end
go
--- LAY DANH SACH TAC GIA
create proc sp_LayDSTacGia
as
begin
	select * from TacGia
	end
go
create proc sp_ThemTacGia(@matacgia nvarchar(10),@tentacgia nvarchar(10))
as begin 
INsert into TacGia (MaTacGia,TenTacGia)
values(@matacgia,@tentacgia)
select * from TacGia 
end 
go 
create proc		(@matacgia nvarchar(10))
as begin 
 Select *from TacGia where MaTacGia=@matacgia
 end
 go 

 
 create proc sp_GetSoLuongDocGia1
 as 
 begin
     select COUNT (*) SoLuong from DocGia
	 end 
	 go

--- LAY DANH SACH SACH
drop proc sp_LayDSSachTimKiem
create proc sp_LayDSSachTimKiem
as
begin
	 SELECT
        S.MaSach,
        S.TenSach,
        S.MaNhaXuatBan,
        NXB.TenNhaXuatBan,
     
        S.NamXB,
        S.SoLuong,
        S.MaTacGia,
        TG.TenTacGia,
        S.MaTheLoai,
        TL.TenTheLoai
    FROM
        Sach S
    INNER JOIN NhaXuatBan NXB ON S.MaNhaXuatBan = NXB.MaNhaXuatBan
    INNER JOIN TacGia TG ON S.MaTacGia = TG.MaTacGia
    INNER JOIN TheLoai TL ON S.MaTheLoai = TL.MaTheLoai;
	end
go
exec sp_LayDSSachTimKiem

create proc sp_LayDSSach
as begin 
select * from Sach
end 
go 
---lay ma sach theo te n
CREATE PROCEDURE sp_LayMaSachTheoTen
    @tenSach NVARCHAR(50)
AS
BEGIN
    SELECT MaSach
    FROM Sach
    WHERE TenSach = @tenSach;
END
go 
exec sp_LayMaSachTheoTen 'Hóa Lớp 9'

--- LAY DANH SACH PHIEU TRA
create proc sp_LayDSPhieuTra
as
begin
	select * from PhieuTra
	end
go

--- LAY DANH SACH PHIEU PHAT
create proc sp_LayDSPhieuPhat
as
begin
	select * from PhieuPhat
	end
go

--- LAY DANH SACH PHIEU MUON
create proc sp_LayDSPhieuMuon
as
begin
	select * from PhieuMuon
	end
go

--Chi tiet PT
create proc sp_TimKiemCTPTTheoMaPM(@maphieumuon nvarchar(10))
as 
begin
select * from ChiTietPhieuTra where MaPhieuMuon=@maphieumuon
end 
go

create proc sp_TimKiemCTPTTheoMaPT(@maphieutra nvarchar(10))
as
begin
select * from ChiTietPhieuTra where MaPhieuTra=@maphieutra
end
go
drop proc sp_LayBangPhieuTra1DocGia
---Them phieu tra
CREATE PROCEDURE sp_LayBangPhieuTra1DocGia
    @MaPhieuTra nvarchar(10)
AS
BEGIN
    SELECT
        PhieuTra.MaPhieuTra,
        PhieuTra.NgayTraSach,
        Sach.MaSach,
        Sach.TenSach,
		DocGia.MaDocGia,
        DocGia.TenDocGia,
        NhanVien.HoTenNV AS TenNhanVien
    FROM
        PhieuTra
		 INNER JOIN ChiTietPhieuTra ON PhieuTra.MaPhieuTra = ChiTietPhieuTra.MaPhieuTra
		INNER JOIN Sach ON ChiTietPhieuTra.MaSach = Sach.MaSach
    INNER JOIN DocGia ON PhieuTra.MaDocGia = DocGia.MaDocGia
    INNER JOIN NhanVien ON PhieuTra.MaNV = NhanVien.MaNV
    WHERE
        PhieuTra.MaPhieuTra = @MaPhieuTra;
END;
exec sp_LayBangPhieuTra1DocGia 'MPT02'



---drop proc sp_LayDSPhieuMuon
---DROP PROCEDURE sp_LapPhieuMuon
go 
---- Lập Phiếu Mươn j


-- Tạo stored procedure


-- Create a sequence for MaPhieuMuon




	





CREATE PROCEDURE sp_TimKiemPhieuMuon
    @maphieumuon NVARCHAR(10)
AS
BEGIN
    SELECT *
    FROM PhieuMuon
    WHERE MaPhieuMuon = @maphieumuon;
END;
-- Provide the MaPhieuMuon you want to search for


-- Execute stored procedure
EXEC sp_TimKiemPhieuMuon 'MPM01';
drop proc sp_TimKiemPhieuMuonTrung
CREATE PROCEDURE sp_TimKiemPhieuMuonTrung
    @maphieumuon NVARCHAR(10)
AS
BEGIN
    SELECT *
    FROM PhieuMuon
    WHERE MaPhieuMuon = @maphieumuon
       OR MaPhieuMuon IN (
            SELECT MaPhieuMuon
            FROM PhieuMuon
            GROUP BY MaPhieuMuon
            HAVING COUNT(*) > 1
        );
END;


-- Provide the MaPhieuMuon you want to search for


-- Execute stored procedure
EXEC sp_TimKiemPhieuMuonTrung 'MPM02';





---exec sp_LapPhieuMuon




--- LAY DANH SACH NHAN VIEN
create proc sp_LayDSNhanVien
as
begin
	select * from NhanVien
	end
go
--- LAY DANH SACH DOC GIA
create proc sp_LayDSDocGia
as
begin
	select * from DocGia
	end
go
-- Lay Ten Doc Gia theo MaDocGIa
create proc sp_LayTenDGTheoMa(@madocgia nvarchar(10))
as 
begin 
select TenDocGia from DocGia where MaDocGia=@madocgia;
end 
go 
exec sp_LayTenDGTheoMa 'DG02'


----So Sach Muon Nhieu nhat 
drop proc sp_BangSoSachMuonNhieuNhat
CREATE PROCEDURE sp_BangSoSachMuonNhieuNhat
AS
BEGIN
    SELECT
        Sach.MaSach,
        Sach.TenSach,
        TheLoai.TenTheLoai,
        COUNT(ChiTietPhieuMuon.MaSach) AS SoLuotMuon
    FROM
        Sach
    INNER JOIN ChiTietPhieuMuon ON Sach.MaSach = ChiTietPhieuMuon.MaSach
    INNER JOIN TheLoai ON Sach.MaTheLoai = TheLoai.MaTheLoai
    GROUP BY
        Sach.MaSach,
        Sach.TenSach,
        TheLoai.TenTheLoai
    ORDER BY
        SoLuotMuon DESC;
END;
go 
exec sp_BangSoSachMuonNhieuNhat

--Phieu phat


--- LAY DANH SACH CHI TIET PHIEU TRA 
create proc sp_LayDSChiTietPhieuTra
as
begin
	select * from ChiTietPhieuTra
	end
go

--- LAY DANH SACH CHI TIET PHIEU MUON

CREATE PROCEDURE sp_LayDSChiTietPhieuMuon
AS
BEGIN
   select * from ChiTietPhieuMuon
END
GO

EXEC sp_LayDSChiTietPhieuMuon;


---hien thi MaTheLoai lên Combobox 
CREATE PROCEDURE sp_LayDanhSachMaTheLoai
AS
BEGIN
    SELECT MaTheLoai, TenTheLoai
    FROM TheLoai;
END;
exec sp_LayDanhSachMaTheLoai
---BANG THE LOAI
create proc sp_ThemTheLoai(@matheloai nvarchar(10),@tentheloai nvarchar(50))
as 
	begin
	---THEM
	insert into TheLoai(MaTheLoai,TenTheLoai)
	values (@matheloai,@tentheloai)

	--exec sp_ThemTheLoai 'TL05',N'Sinh hoc'
	select * from TheLoai 
	end
	
	go
	execute sp_ThemTheLoai @matheloai='TL012',@tentheloai=N'Hóa Học 12'
create proc sp_CapNhatTheLoai(@matheloai nvarchar(10),@tentheloai nvarchar(50))
as
	begin
	Update TheLoai
	Set TenTheLoai=@tentheloai
	Where MaTheLoai=@matheloai

	--exec sp_CapNhatTheLoai 'TL05',N'Vat ly'
	select * from TheLoai

	end
	go
create proc sp_XoaTheLoai(@matheloai nvarchar(10))
as 
	begin
	---XOA
	Delete TheLoai
	Where MaTheLoai=@matheloai

		exec sp_XoaTheLoai 'TL06'
	select * from TheLoai
	
	end
	go
	--- lay danh sach manhaxuatban 
	create proc sp_LayDsMaNhaXuatBan
	as begin 
	select MaNhaXuatBan,TenNhaXuatBan from NhaXuatBan
	end 
	go 
--- BANG NHA XUAT BAN
create proc sp_ThemNhaXuatBan(@manhaxuatban nvarchar(10),@tennhaxuatban nvarchar(50),@diachi nvarchar(50),@sdt varchar(11))
as 
begin 
	--THEM
	insert into NhaXuatBan(MaNhaXuatBan,TenNhaXuatBan,DiaChi,Sdt)
	values (@manhaxuatban,@tennhaxuatban,@diachi,@sdt)

	--exec sp_ThemNhaXuatBan 'NXB04',N'Hoa Binh',N'Ha Noi',6542156
	select * from NhaXuatBan
	
	end
	go
create proc sp_CapNhatNhaXuatBan(@manhaxuatban nvarchar(10),@tennhaxuatban nvarchar(50),@diachi nvarchar(50),@sdt varchar(11))
as 
begin
	---CAP NHAT
	Update NhaXuatBan
	Set TenNhaXuatBan=@tennhaxuatban,DiaChi=@diachi,Sdt=@sdt
	Where MaNhaXuatBan=@manhaxuatban

	--exec sp_CapNhatNhaXuatBan 'NXB04',N'Hoa Binh',N'Cao Lanh',6542156
	select * from NhaXuatBan
	
	end
	go
create proc sp_XoaNhaXuatBan(@manhaxuatban nvarchar(10))
as 
	begin
	--XOA
	Delete NhaXuatBan
	Where MaNhaXuatBan=@manhaxuatban
	
	select * from NhaXuatBan
	
	end
	go
	---exec sp_XoaNhaXuatBan 'NXB04'
	create proc sp_TimKiemMaNXB (@manhaxuatban nvarchar(10))
	as 
	begin 
	SELECT *FROM NhaXuatBan where MaNhaXuatBan=@manhaxuatban
	end 
	go 
	----exec sp_TimKiemMaNXB 'NXB01'

---BANG NHAN VIEN
create proc sp_ThemNhanVien(@manv nvarchar(10),@hotennv nvarchar(50),@gioitinh nvarchar(5),@sdt varchar(11), @catruc nvarchar(10),@chucvu nvarchar(50))
as	
	begin
	---THEM
	insert into NhanVien(MaNV,HoTenNV,GioiTinh,Sdt,CaTruc,ChucVu)
	values (@manv,@hotennv,@gioitinh,@sdt,@catruc,@chucvu)

	--exec sp_ThemNhanVien 'NV05',N'Nguyen Van A','Nam',1234564,N'Sang',N'Nhan Vien'
	select * from NhanVien
	
	end
	go

create proc sp_CapNhatNhanVien(@manv nvarchar(10),@hotennv nvarchar(50),@gioitinh nvarchar(5),@sdt varchar(11), @catruc nvarchar(10),@chucvu nvarchar(50))
as 
	begin 
	---CAP NHAT
	Update NhanVien
	Set HoTenNV=@hotennv,GioiTinh=@gioitinh,Sdt=@sdt,CaTruc=@catruc,ChucVu=@chucvu
	Where MaNV=@manv

	--exec sp_CapNhatNhanVien 'NV05',N'Nguyen Van A','Nam',1234564,N'Sang',N'Quan ly'
	select * from NhanVien
	 
	end 
	go

create proc sp_XoaNhanVien(@manv nvarchar(10))
as 
	begin
	---XOA
	Delete NhanVien
	Where MaNV=@manv

	--exec sp_XoaNhanVien 'NV05'
	select * from NhanVien
	
	end
	go



---BANG DOC GIA
create proc sp_ThemDocGia(@madocgia nvarchar(10),@tendocgia nvarchar(20),@ngaysinh date,@gioitinh nvarchar(5),@diachi nvarchar(50),@cccd int,@email nvarchar(20),@loaidocgia nvarchar(10),@sosachmuon int)
as
	begin 
	--THEM
	insert into DocGia(MaDocGia,TenDocGia,NgaySinh,GioiTinh,DiaChi,CCCD,Email,LoaiDocGia,SoSachMuon)
	values (@madocgia,@tendocgia,@ngaysinh,@gioitinh,@diachi,@cccd,@email,@loaidocgia,@sosachmuon)

	--exec sp_ThemDocGia 'DG05',N'Nguyen Huy Hoang','01/01/1998',N'Nam',N'Da Nang',12345675,'nguyenhuyhoang@mail.com',N'Sinh Vien',6
	select * from DocGia
	 
	end 
	go

create proc sp_CapNhatDocGia(@madocgia nvarchar(10),@tendocgia nvarchar(20),@ngaysinh date,@gioitinh nvarchar(5),@diachi nvarchar(50),@cccd varchar(15),@email nvarchar(20),@loaidocgia nvarchar(10),@sosachmuon int)
as
	begin 
	--CAP NHAT
	Update DocGia
	Set TenDocGia=@tendocgia,NgaySinh=@ngaysinh,GioiTinh=@gioitinh,DiaChi=@diachi,CCCD=@cccd,Email=@email,LoaiDocGia=@loaidocgia,SoSachMuon=@sosachmuon
	Where MaDocGia=@madocgia

	--exec sp_CapNhatDocGia 'DG05',N'Nguyen Huy Hoang','01/01/1998',N'Nam',N'Da Nang',12345675,'nguyenhuyhoang@mail.com',N'Khac',6
	select * from DocGia
	
	end
	go

create proc sp_XoaDocGia(@madocgia nvarchar(10))
as
	begin 
	--XOA
	Delete DocGia
	Where MaDocGia=@madocgia

	--exec sp_XoaDocGia 'DG05'
	select * from DocGia
	 
	end
	go

	----hien thi ma =tac gia len cob
	drop proc LayDsMaTacGia
	create proc sp_LayDsMaTacGia 
	as 
	begin 
	select MaTacGia,TenTacGia from TacGia
	end 
	go 
---BANG TAC GIA
create proc sp_ThemTacGia(@matacgia nvarchar(10),@tentacgia nvarchar(10))
as 
	begin 
	--THEM
	insert into TacGia(MaTacGia,TenTacGia)
	values (@matacgia,@tentacgia)

	
	select * from TacGia 
	end 
	go
	execute sp_ThemTacGia 'TG04',N'Nguyen Du'


create proc sp_CapNhatTacGia(@matacgia nvarchar(10),@tentacgia nvarchar(10))
as 
	begin
	--CAP NHAT
	Update TacGia
	Set TenTacGia=@tentacgia
	Where MaTacGia=@matacgia
	select * from TacGia 
	end 
	go
	----exec sp_CapNhatTacGia 'TG04',N'Huy Can'


create proc sp_XoaTacGia(@matacgia nvarchar(10))
as 
	begin 
	--XOA
	Delete TacGia
	Where MaTacGia=@matacgia

	select * from TacGia 
	end 
	go
	----exec sp_XoaTacGia 'TG04'
	---- tìm kiếm sách 
	CREATE PROCEDURE sp_TimKiemThongTinSach
    @maSach nvarchar(10)
AS
BEGIN
    -- Tìm kiếm thông tin sách theo mã sách
    SELECT  TenSach, NamXB, MaNhaXuatBan, SoLuong, MaTheLoai, MaTacGia
    FROM Sach
    WHERE MaSach = @maSach;
END;
-- Thực hiện stored procedure
EXEC sp_TimKiemThongTinSach @maSach = 'S01';


----BANG SACH
create proc sp_ThemSach(@masach nvarchar(10),@tensach nvarchar(50), @namxb int,@manhaxuatban nvarchar(10),@soluong int,@matheloai nvarchar(10),@matacgia nvarchar(10))
as 
	begin 
	---THEM
	insert into Sach(MaSach,TenSach,NamXB,MaNhaXuatBan,SoLuong,MaTheLoai,MaTacGia)
	values (@masach,@tensach,@namxb,@manhaxuatban,@soluong,@matheloai,@matacgia)

	--exec sp_ThemSach 'S07',N'Toan lop 2',2000,'NXB01',5,'TL02','TL01'
	select * from Sach
	end 
	go 

create proc sp_CapNhatSach(@masach nvarchar(10),@tensach nvarchar(50), @namxb int,@manhaxuatban nvarchar(10),@soluong int,@matheloai nvarchar(10),@matacgia nvarchar(10))
as 
	begin
	---CAP NHAT
	Update Sach
	Set TenSach=@tensach,NamXB=@namxb,MaNhaXuatBan=@manhaxuatban,SoLuong=@soluong,MaTheLoai=@matheloai,MaTacGia=@matacgia
	Where MaSach=@masach

	--exec sp_CapNhatSach 'S07',N'Toan lop 5',2000,'NXB01',5,'TL02','TL01'
	select * from Sach
	end 
	go
	drop proc LayPhieuMuon1DocGia
	create proc LayPhieuMuon1DocGia(@maphieumuon nvarchar(10))
	as 
	   SELECT
            PM.*,
            DG.TenDocGia,
            CT.MaSach
        FROM
            PhieuMuon PM
            INNER JOIN ChiTietPhieuMuon CT ON PM.MaPhieuMuon = CT.MaPhieuMuon
            INNER JOIN DocGia DG ON PM.MaDocGia = DG.MaDocGia
        WHERE
            PM.MaPhieuMuon = @maphieumuon OR DG.MaDocGia = @maphieumuon;

    
----	exec LayPhieuMuon1DocGia 'DG02'
---drop proc  sp_GetSoLuongDocGia1
create proc sp_GetSoLuongDocGia1
 as 
 begin
     select COUNT (*) SoLuong from DocGia
	 end 
	 go


create proc sp_XoaSach(@masach nvarchar(10))
as 
	begin 
	---THEM
	Delete Sach
	Where MaSach=@masach

	--exec sp_XoaSach 'S07'
	select * from Sach
	end 
	go
	 ----cobobox Tên Sách 
	 create proc sp_cobTenSach 
	 as begin 
	 Select TenSach from SACH
	 end 
	 go 
	 --cobbox MaPhieuMuon trong PhieuTra]
	 create proc sp_cobMaPhieuMuon
	 as 
	 begin 
	 select MaPhieuMuon from PhieuMuon
	 end 
	 go 
	---- exec sp_cobTenSach
	drop proc sp_ThemPhieuMuon
---BANG PHIEU MUON
create proc sp_ThemPhieuMuon(@maphieumuon nvarchar(10),@ngaymuon date,@hantrasach date,@madocgia nvarchar(10),@soluongmuon int, @manv nvarchar(10))
as 
	begin 
	--THEM
	insert into PhieuMuon(MaPhieuMuon,NgayMuon,HanTraSach,MaDocGia,SoLuongMuon,MaNV)
	values (@maphieumuon,@ngaymuon,@hantrasach,@madocgia,@soluongmuon,@manv)

	--exec sp_ThemPhieuMuon 'MPM05','S05','05/03/2023','10/03/2023','DG05',5,'NV04'
	select * from PhieuMuon
	end 
	go 


	
create proc sp_CapNhatPhieuMuon(@maphieumuon nvarchar(10),@ngaymuon date,@hantrasach date,@madocgia nvarchar(10),@soluongmuon int, @manv nvarchar(10))
as 
	begin 
	--CAP NHAT
	Update PhieuMuon
	Set NgayMuon=@ngaymuon,HanTraSach=@hantrasach,MaDocGia=@madocgia,SoLuongMuon=@soluongmuon,MaNV=@manv
	Where MaPhieuMuon=@maphieumuon

	--exec sp_CapNhatPhieuMuon 'MPM05','S05','05/03/2023','11/03/2023','DG05',5,'NV04'
	select * from PhieuMuon
	end 
	go 

create proc sp_XoaPhieuMuon(@maphieumuon nvarchar(10))
as
	begin 
	--XOA
	Delete PhieuMuon
	Where MaPhieuMuon=@maphieumuon

	--exec sp_XoaPhieuMuon 'MPM05'
	select * from PhieuMuon
	end 
	go 
---BANG Chi tiet phieu muon
----drop proc sp_ThemChiTietPhieuMuon

-- sp_ThemChiTietPhieuMuon
CREATE PROCEDURE sp_ThemChiTietPhieuMuon
    @MaCTPM NVARCHAR(10),
    @MaPhieuMuon NVARCHAR(10),
    @MaSach NVARCHAR(10)
AS
BEGIN
    INSERT INTO ChiTietPhieuMuon (MaCTPM, MaPhieuMuon, MaSach)
    VALUES (@MaCTPM, @MaPhieuMuon, @MaSach)
END
go 

-----Cap nhat CHi Tiet Phieu Muon 
CREATE PROCEDURE sp_SuaChiTietPhieuMuon
    @MaCTPM NVARCHAR(10),
    @MaPhieuMuon NVARCHAR(10),
    @MaSach NVARCHAR(10)
AS
BEGIN
    UPDATE ChiTietPhieuMuon
    SET MaPhieuMuon = @MaPhieuMuon,
        MaSach = @MaSach
    WHERE MaCTPM = @MaCTPM;
END
create proc sp_TimKiemDocGiaTheoMaDG(@madocgia nvarchar(10))
as
     begin
	  Select *from DocGia where MaDocGia=@madocgia
 end
 go 

 create proc sp_TimKiemDocGiaTheoTen(@tendocgia nvarchar(10))
as
     begin
	  Select *from DocGia where TenDocGia=@tendocgia
 end
 go 
 create proc sp_TimTheLoai(@matheloai nvarchar(10))
as
     begin
	  Select *from TheLoai where MaTheLoai=@matheloai
 end




----Tìm Kiếm phiếu mượn theo MaPhieuMuon 
CREATE PROCEDURE sp_TimKiemChiTietPhieuMuon
    @MaPhieuMuon NVARCHAR(10)
AS
BEGIN
    SELECT *
    FROM ChiTietPhieuMuon
    WHERE MaPhieuMuon = @MaPhieuMuon;
END;
exec sp_TimKiemChiTietPhieuMuon 'MPM01'
---Tìm kiếm phiếu mượn theo mã sách 
drop proc sp_TimKiemChiTietPhieuMuonTheoMaSach
CREATE PROCEDURE sp_TimKiemChiTietPhieuMuonTheoMaSach
    @masach NVARCHAR(10)
AS
BEGIN
    SELECT *
    FROM ChiTietPhieuMuon
    WHERE MaSach = @masach;
	
END;
exec sp_TimKiemChiTietPhieuMuonTheoMaSach @masach='SO4';
select * from ChiTietPhieuMuon where MaSach ='S04';




-- Thêm dòng dữ liệu thứ nhất
EXEC sp_ThemChiTietPhieuMuon 'CTPM08', 'MPM01', 'S04';

-- Thêm dòng dữ liệu thứ hai
EXEC sp_ThemChiTietPhieuMuon 'CTPM09', 'MPM01', 'S05';
SELECT * FROM ChiTietPhieuMuon;
select * from PhieuMuon
CREATE PROCEDURE sp_LayDsChiTietPhieuMuonTheoMaPM
    @mapm NVARCHAR(10)
AS
BEGIN
    SELECT
        ctpm.MaCTPM,
        ctpm.MaPhieuMuon,
        ctpm.MaSach
       
    FROM
        ChiTietPhieuMuon ctpm
    JOIN
        Sach s ON ctpm.MaSach = s.MaSach
    WHERE
        ctpm.MaPhieuMuon = @MaPM;
END
GO
exec sp_LayDsChiTietPhieuMuonTheoMaPM'MPM02'

CREATE PROCEDURE sp_ThemPhieuMuon
    @MaPhieuMuon nvarchar(10),
    @NgayMuon date,
    @HanTraSach date,
    @MaDocGia nvarchar(10),
    @SoLuongMuon int,
    @MaNV nvarchar(10)
AS
BEGIN
    
    INSERT INTO PhieuMuon (MaPhieuMuon, NgayMuon, HanTraSach, MaDocGia, SoLuongMuon, MaNV)
    VALUES (@MaPhieuMuon, @NgayMuon, @HanTraSach, @MaDocGia, @SoLuongMuon, @MaNV);
END;

CREATE PROCEDURE sp_XoaPhieuMuon
    @MaPhieuMuon nvarchar(10)
AS
BEGIN
   
    DELETE FROM PhieuMuon
    WHERE MaPhieuMuon = @MaPhieuMuon;
END;
go 
CREATE PROCEDURE CapNhatPhieuMuon
    @MaPhieuMuon nvarchar(10),
    @NgayMuon date,
    @HanTraSach date,
    @MaDocGia nvarchar(10),
    @SoLuongMuon int,
    @MaNV nvarchar(10)
AS
BEGIN
 
    UPDATE PhieuMuon
    SET NgayMuon = @NgayMuon,
        HanTraSach = @HanTraSach,
        MaDocGia = @MaDocGia,
        SoLuongMuon = @SoLuongMuon,
        MaNV = @MaNV
    WHERE MaPhieuMuon = @MaPhieuMuon;
END;








create proc sp_CapNhatChiTietPhieuMuon(@mactpm nvarchar(10),@maphieumuon nvarchar(10),@masach nvarchar(10))
as 
begin 
	---CAP NHAT
	Update ChiTietPhieuMuon
	Set MaPhieuMuon=@maphieumuon,MaSach=@masach
	Where MaCTPM=@mactpm


	--exec sp_CapNhatChiTietPhieuMuon 'CTPM05','MPM05','S01','Vat ly lop 10'
	select * from ChiTietPhieuMuon
	end 
	go 
create proc sp_XoaChiTietPhieuMuon(@mactpm nvarchar(10))
as 
	begin 
	---XOA
	Delete ChiTietPhieuMuon
	Where MaCTPM=@mactpm
	--exec sp_XoaChiTietPhieuMuon 'CTPM05','MPM05','S01','Vat ly lop 7'
	select * from ChiTietPhieuMuon
	end 
	go 

---BANG PHIEU TRA 
--vvs
create proc sp_ThemPhieuPhat(@maphieuphat nvarchar(10),@madocgia nvarchar(10),@songayquahan int,@sotienphat int,@manv nvarchar(10),@maphieumuon nvarchar(10))
as
	begin 
	--THEM
	insert into PhieuPhat(MaPhieuPhat,MaDocGia,SoNgayQuaHan,SoTienPhat,MaNV,MaPhieuMuon)
	values (@maphieuphat,@madocgia,@songayquahan,@sotienphat,@manv,@maphieumuon)


	--exec sp_ThemPhieuPhat 'MPP05','DG05',3,6000,'NV04','MPM05','S05'
	select * from PhieuPhat
	end 
	go 
	---Phieu Phat 
create proc sp_TimKiemPP(@maphieuphat nvarchar(10))
as
begin
select * from PhieuPhat where MaPhieuPhat=@maphieuphat
end
go
------SACH --------
create proc sp_TimSachTheoMa(@masach nvarchar(10))
as 
begin
 Select *from Sach where MaSach=@masach
 end
 go 
 create proc sp_TimSachTheoTen(@tensach nvarchar(50))
as 
begin
 Select *from Sach where TenSach=@tensach
 end
 go 

 create proc sp_TimSachTheoTheLoai(@tentheloai nvarchar(10))
as 
begin
 Select Sach.MaSach, Sach.TenSach,Sach.NamXB,Sach.MaNhaXuatBan,Sach.MaTheLoai,Sach.SoLuong,Sach.MaTacGia from Sach INNER JOIN TheLoai ON Sach.MaTheLoai = TheLoai.MaTheLoai where TheLoai.TenTheLoai=@tentheloai
 end
 go 

 create proc sp_TimSachTheoTacGia(@tentacgia nvarchar(10))
as 
begin
Select Sach.MaSach, Sach.TenSach,Sach.NamXB,Sach.MaNhaXuatBan,Sach.MaTheLoai,Sach.SoLuong,Sach.MaTacGia from Sach INNER JOIN TacGia ON Sach.MaTacGia = TacGia.MaTacGia where TacGia.TenTacGia=@tentacgia
 end
 go 

---Them phieu tra
create proc sp_ThemPhieuTra(@maphieutra nvarchar(10),@madocgia nvarchar(10),@maphieumuon nvarchar(10),@ngaytrasach date,@manv nvarchar(10),@ghichu nvarchar(20))
as 
	begin 
	---THEM
	insert into PhieuTra(MaPhieuTra,MaDocGia,MaPhieuMuon,NgayTraSach,MaNV,GhiChu)
	values (@maphieutra,@madocgia,@maphieumuon,@ngaytrasach,@manv,@ghichu)

	--exec sp_ThemPhieuTra 'MPT05','DG05','Lam Dinh Khoa','MPM05' ,'02/05/2023','NV01','S05'
	select * from PhieuTra
	end 
	go



create proc sp_CapNhatPhieuTra(@maphieutra nvarchar(10),@madocgia nvarchar(10),@maphieumuon nvarchar(10),@ngaytrasach date,@manv nvarchar(10),@masach nvarchar(10),@ghichu nvarchar(20))
as 
	begin 
	---CAP NHAT
	Update PhieuTra 
	Set MaDocGia=@madocgia,MaPhieuMuon=@maphieumuon,NgayTraSach=@ngaytrasach,MaNV=@manv,MaSach=@masach,GhiChu=@ghichu
	Where MaPhieuTra=@maphieutra

	--exec sp_CapNhatPhieuTra 'MPT05','DG05','Nguyen Quang Van','MPM05' ,'02/05/2023','NV01','S05'
	select * from PhieuTra
	end 
	go 


create proc sp_XoaPhieuTra(@maphieutra nvarchar(10))
as 
	begin 
	---XOA
	Delete PhieuTra
	Where MaPhieuTra=@maphieutra

	--exec sp_XoaPhieuTra 'MPT05'
	select * from PhieuTra
	end 
	go 

---BANG Chi tiet phieu tra
drop proc sp_ThemChiTietPhieuTra
create proc sp_ThemChiTietPhieuTra(@mactpt nvarchar(10),@maphieutra nvarchar(10),@maphieumuon nvarchar(10),@masach nvarchar(10))
as
	begin 
	--THEM
	insert into ChiTietPhieuTra(MaCTPT,MaPhieuTra,MaPhieuMuon,MaSach)
	values (@mactpt,@maphieutra,@maphieumuon,@masach)
	exec sp_ThemChiTietPhieuTra 'CTPT060','MPT05','MPM05','S01'
	select * from ChiTietPhieuTra
	end 
	go



create proc sp_CapNhatChiTietPhieuTra(@mactpt nvarchar(10),@maphieutra nvarchar(10),@maphieumuon nvarchar(10),@masach nvarchar(10))
as
	begin 
	--CAP NHAT
	Update ChiTietPhieuTra
	Set MaPhieuTra=@maphieutra,MaPhieuMuon=@maphieumuon,MaSach=@masach
	Where MaCTPT=@mactpt
	exec sp_CapNhatChiTietPhieuTra 'CTPT05','MPT05','MPM05','S01'
	select * from ChiTietPhieuTra
	end 
	go



create proc sp_XoaChiTietPhieuTra(@mactpt nvarchar(10))
as
	begin 
	--XOA
	Delete ChiTietPhieuTra
	Where MaCTPT=@mactpt


	--exec sp_XoaChiTietPhieuTra 'CTPT05'
	select * from ChiTietPhieuTra
	end 
	go

---BANG PHIEU PHAT



create proc sp_CapNhatPhieuPhat(@maphieuphat nvarchar(10),@madocgia nvarchar(10),@songayquahan int,@sotienphat int,@manv nvarchar(10),@maphieumuon nvarchar(10),@masach nvarchar(10))
as
	begin 
	--CAP NHAT
	Update PhieuPhat
	Set MaDocGia=@madocgia,SoNgayQuaHan=@songayquahan,SoTienPhat=@sotienphat,MaNV=@manv,MaPhieuMuon=@maphieumuon,MaSach=@masach
	Where MaPhieuPhat=@maphieuphat


	--exec sp_CapNhatPhieuPhat 'MPP05','DG05',5,6000,'NV04','MPM05','S05'
	select * from PhieuPhat
	end 
	go 


create proc sp_XoaPhieuPhat(@maphieuphat nvarchar(10))
as
	begin 
	--Xoa
	Delete PhieuPhat
	Where MaPhieuPhat=@maphieuphat
	--exec sp_XoaPhieuPhat 'MPP05'
	select * from PhieuPhat
	end 
	go 
	drop proc sp_LayDanhSachSach
	--- Lay DAnh sach sasch 
	create proc sp_LayDanhSachSach 
	as 
	select * from Sach s,NhaXuatBan nxb,TheLoai tl
	where s.MaNhaXuatBan=nxb.MaNhaXuatBan and tl.MaTheLoai=s.MaTheLoai

	exec sp_LayDanhSachSach
	-- Tạo stored procedure trong SQL Server
	drop proc LaySoLuongChiTietPhieuMuon
CREATE PROCEDURE LaySoLuongChiTietPhieuMuon
    @MaPhieuMuon NVARCHAR(50)
AS
BEGIN
    SELECT COUNT(*) AS SoLuong
    FROM ChiTietPhieuMuon -- Thay thế 'TenBangChiTietPhieuMuon' bằng tên thực tế của bảng chi tiết phiếu mượn
    WHERE MaPhieuMuon = @MaPhieuMuon;
END
exec LaySoLuongChiTietPhieuMuon 'MPM02'







	create proc sp_SoLuongPhieuMuon
	as begin 
	SELECT COUNT(*) FROM PhieuMuon
	end 
	go 

