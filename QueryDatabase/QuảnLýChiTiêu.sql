
CREATE DATABASE QuanLyChiTieu
go

USE QuanLyChiTieu
go

Set dateformat dmy

go

--cac bang ve so du
CREATE TABLE BIENDONGSODU
(
	TenTK VARCHAR(100),
	SoDu int,
	Ngay smalldatetime
)
go

CREATE TABLE TAIKHOAN
(
	TenTK VARCHAR(100) NOT NULL constraint PK_TAIKHOAN primary key,
	MatKhau VARCHAR(100),
	SoDu int default 0
)
go

--
create proc USP_UpdateBalance
@TenTK varchar(100)
as
begin
	DECLARE @Yesterday date;
	SET @Yesterday = DATEADD(DAY, -1, GETDATE());

	declare @RecentDay date;
	select @RecentDay = max(Ngay) 
	from BIENDONGSODU
	where TenTK = @TenTK

	if(@RecentDay is null or @Yesterday > @RecentDay)
	begin
		declare @SoDu int;
		select @SoDu = Sodu
		from TaiKhoan
		where TenTK = @TenTK

		insert into BIENDONGSODU(TenTK,SoDu,Ngay) values (@TenTK,@SoDu,@Yesterday);
	end
end

--
CREATE TABLE VI
(
	TenVi NVARCHAR(100),
	TenTK VARCHAR(100),
	SoDu int,
)

--cac ban ve chi tieu
CREATE TABLE LOAICHI
(
	TenLoaiChi NVARCHAR(100)
)
go

CREATE TABLE KHOANCHI
(
	MaKhoanChi int  identity(1,1) primary key,
	TenKhoanChi NVARCHAR (100),
	SoTien int,
	TenLoaiChi NVARCHAR(100),
	Ngay SMALLDATETIME,
	TenTK varchar(100),
	TenVi nvarchar(100),
)
go
--bang ve thu nhap
CREATE TABLE LOAITHU
(
	TenLoaiThu NVARCHAR(100)
)
go

CREATE TABLE KHOANTHU
(
	MaKhoanThu int identity(1,1) primary key,
	TenKhoanThu NVARCHAR(100),
	SoTien int,
	TenLoaiThu NVARCHAR(100),
	Ngay SMALLDATETIME,
	TenTK varchar(100),
	TenVi nvarchar(100) ,
)
go

