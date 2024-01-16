insert into LOAITHU(TenLoaiThu) values(N'Tiền lương')
insert into LOAITHU(TenLoaiThu) values(N'Tiền bán hàng')
insert into LOAITHU(TenLoaiThu) values(N'Tiền lãi tiết kiệm')



set dateformat dmy
--Lay tong khoan chi tieu trong ngay
create proc USP_GetTotalIncome
@Ngay smalldatetime ,@TenTK varchar(100)

as
begin
	declare @result int;

	select @result = sum(SOTIEN) from KHOANTHU where TENTK =@TenTK and Ngay = @Ngay;
	if @result is null
		set @result = 0

	select @result;
end

--lay thong tin cac khoan chi tieu trong ngay
create proc USP_GetIncomeTable
@Ngay smalldatetime ,@TenTK varchar(100)
as
begin
	select MaKhoanThu,TenKhoanThu,SoTien,TenLoaiThu,Ngay,TenVi from KHOANTHU
	where TENTK =@TenTK and Ngay = @Ngay
end

--them khoan chi
create proc USP_AddIncome
@TenKhoanThu nvarchar(100), @SoTien int,@TenLoaiThu nvarchar(100),@Ngay smalldatetime,@TenVi nvarchar(100),@TenTK varchar(100)
as
begin 
	insert into KHOANTHU(TenKhoanThu,SoTien,TenLoaiThu,Ngay,TenVi,TenTK) values (@TenKhoanThu,@SoTien,@TenLoaiThu,@Ngay,@TenVi,@TenTK);
end

--update

create proc USP_UpdateIncome
@MaKhoanThu int,@TenKhoanThu nvarchar(100), @SoTien int,@TenLoaiThu nvarchar(100),@Ngay smalldatetime,@TenVi nvarchar(100),@TenTK varchar(100)
as
begin 
	update KHOANTHU
	set TenKhoanThu = @TenKhoanThu ,SoTien =@SoTien,TenLoaiThu=@TenLoaiThu,Ngay = @Ngay,TenVi=@TenVi
	where MaKhoanThu = @MaKhoanThu
end

--delete
create proc USP_DeleteIncome
@MaKhoanThu int
as
begin 
	delete from KhoanThu
	where MaKhoanThu = @MaKhoanThu
end

--trigger
--insert
create trigger income_insert 
on KhoanThu
for
insert
as
begin
	declare @TenTK varchar(100),@TenVi nvarchar(100),@SoTien int

	Select  @TenTK = TenTK,@TenVi = TenVi ,@SoTien = SoTien
	from inserted

	update Vi
	set SoDu += @SoTien
		where TenTK = @TenTK and TenVi = @TenVi 
end

--Update
create trigger income_update
on KhoanThu
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
	set SoDu -= @SoTienCu
		where TenTK = @TenTK and TenVi = @TenViCu
	
	update Vi
	set SoDu += @SoTienMoi
		where TenTK = @TenTK and TenVi = @TenViMoi
end
--delete 
create trigger income_delete
on KhoanThu
for
delete
as
begin
	declare @TenTK varchar(100),@TenVi nvarchar(100),@SoTien int

	Select  @TenTK = TenTK,@TenVi = TenVi ,@SoTien = SoTien
	from deleted

	update Vi
	set SoDu -= @SoTien
		where TenTK = @TenTK and TenVi = @TenVi 
end

