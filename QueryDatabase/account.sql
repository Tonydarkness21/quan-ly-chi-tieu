-- Lấy dữ liệu các tài khoản
CREATE PROC USP_LoadAccount
AS
begin
SELECT * FROM TAIKHOAN
end
go

-- Thêm mới tài khoản
CREATE PROC USP_AddAccount
@TENTK VARCHAR (100), @MATKHAU VARCHAR(100)
AS
BEGIN
	INSERT INTO TAIKHOAN(TENTK,MATKHAU) VALUES (@TENTK, @MATKHAU)
END
go

--lay tong so du tai khoan
CREATE PROC USP_GetAccountMoney
@TENTK VARCHAR (100)
AS
BEGIN
	select SODU from TaiKhoan where TenTK = @TENTK
END

--thong tin so du
create proc USP_GetBalance
@Ngay smalldatetime ,@TenTK varchar(100)

as
begin
	declare @result int;

	select @result = SoDu from BIENDONGSODU where TENTK =@TenTK and Ngay = @Ngay;
	if @result is null
		set @result = 0

	select @result;
end