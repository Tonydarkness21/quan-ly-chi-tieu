insert into LOAICHI(TENLOAICHI) values(N'Tiền ăn')
insert into LOAICHI(TENLOAICHI) values(N'Điện nước')
insert into LOAICHI(TENLOAICHI) values(N'Quần áo')
insert into LOAICHI(TENLOAICHI) values(N'Giải trí')
insert into LOAICHI(TENLOAICHI) values(N'Làm đẹp')
insert into LOAICHI(TENLOAICHI) values(N'Sức khoẻ')
set dateformat dmy
--Lay tong khoan chi tieu trong ngay
create proc USP_GetTotalSpending
@Ngay smalldatetime ,@TenTK varchar(100)

as
begin
	declare @result int;

	select @result = sum(SOTIEN) from KHOANCHI where TENTK =@TenTK and Ngay = @Ngay;
	if @result is null
		set @result = 0

	select @result;
end

--lay thong tin cac khoan chi tieu trong ngay
create proc USP_GetSpendingTable
@Ngay smalldatetime ,@TenTK varchar(100)
as
begin
	select MaKhoanChi,TenKhoanChi,SoTien,TenLoaiChi,Ngay,TenVi from KHOANCHI
	where TENTK =@TenTK and Ngay = @Ngay
end

--them khoan chi
create proc USP_AddSpending
@TenKhoanChi nvarchar(100), @SoTien int,@TenLoaiChi nvarchar(100),@Ngay smalldatetime,@TenVi nvarchar(100),@TenTK varchar(100)
as
begin 
	insert into KHOANCHI(TenKhoanChi,SoTien,TenLoaiChi,Ngay,TenVi,TenTK) values (@TenKhoanChi,@SoTien,@TenLoaiChi,@Ngay,@TenVi,@TenTK);
end
--update

create proc USP_UpdateSpending
@MaKhoanChi int,@TenKhoanChi nvarchar(100), @SoTien int,@TenLoaiChi nvarchar(100),@Ngay smalldatetime,@TenVi nvarchar(100),@TenTK varchar(100)
as
begin 
	update KHOANCHI
	set TenKhoanChi = @TenKhoanChi ,SoTien =@SoTien,TenLoaiChi=@TenLoaiChi,Ngay = @Ngay,TenVi=@TenVi
	where MaKhoanChi = @MaKhoanChi
end

--delete
create proc USP_DeleteSpending
@MaKhoanChi int
as
begin 
	delete from KhoanChi 
	where MaKhoanChi = @MaKhoanChi
end

--
create trigger vi_insert
on vi
for insert
as
begin

declare @TenTK varchar(100),@SoDu int

select @TenTK = TENTK,@SoDu = SODU
from inserted

update TAIKHOAN
SET SODU += @SoDu
where TENTK = @TenTK
end
--trigger
--insert
create trigger spending_insert
on KhoanChi
for
insert
as
begin
	declare @TenTK varchar(100),@TenVi nvarchar(100),@SoTien int

	Select  @TenTK = TenTK,@TenVi = TenVi ,@SoTien = SoTien
	from inserted

	update Vi
	set SoDu -= @SoTien
		where TenTK = @TenTK and TenVi = @TenVi 
end

--Update
create trigger spending_update
on KhoanChi
for
update
as
begin
	declare @TenTK varchar(100),@TenViCu nvarchar(100),@SoTienCu int
	declare @TenViMoi nvarchar(100),@SoTienMoi int


	Select  @TenTK = TenTK,@TenViCu = TenVi ,@SoTienCu = SoTien
	from deleted

	Select @TenViCu = TenVi ,@SoTienCu = SoTien
	from inserted

	update Vi
	set SoDu += @SoTienCu
		where TenTK = @TenTK and TenVi = @TenViCu
	
	update Vi
	set SoDu -= @SoTienMoi
		where TenTK = @TenTK and TenVi = @TenViMoi
end
--delete 
create trigger spending_delete
on KhoanChi
for
delete
as
begin
	declare @TenTK varchar(100),@TenVi nvarchar(100),@SoTien int

	Select  @TenTK = TenTK,@TenVi = TenVi ,@SoTien = SoTien
	from deleted

	update Vi
	set SoDu += @SoTien
		where TenTK = @TenTK and TenVi = @TenVi 
end
