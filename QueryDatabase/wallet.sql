--TRIGGER
--wallet insert
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

--wallet delete
create trigger vi_delete
on vi
for delete
as
begin

declare @TenTK varchar(100),@SoDu int

select @TenTK = TENTK,@SoDu = SODU
from deleted

update TAIKHOAN
SET SODU -= @SoDu
where TENTK = @TenTK
end
--walet update
create trigger vi_UPDATE
on vi
for update
as
begin

declare @TenTK varchar(100),@SoDuMoi int,@SoDuCu int

select @TenTK = TENTK,@SoDuMoi = SODU
from inserted
select @SoDuCu = SODU
from deleted

update TAIKHOAN
SET SODU += (@SoDuMoi - @SoDuCu)
where TENTK = @TenTK
end

--PROCEDURE
-- Thêm mới ví
CREATE PROC USP_AddWallet
@TENVI NVARCHAR(100), @TENTK VARCHAR(100), @SODU int
AS
BEGIN
	INSERT INTO VI VALUES (@TENVI, @TENTK, @SODU)
END
go

--lay ds cac vi cua mot tai khoan
CREATE PROC USP_GetWallet
@TENTK VARCHAR(100)
AS
BEGIN
	select TenVi from vi where TENTK = @TENTK
END
go
--lay thong tin cau cac vi
CREATE PROC USP_GetWalletInfo
@TENTK VARCHAR(100)
AS
BEGIN
	select TenVi,SoDu from vi where TENTK = @TENTK
END
go
-- Cập nhật ví
CREATE PROC USP_UpdateWallet
 @TENVI NVARCHAR(100), @SODU MONEY, @TENTK VARCHAR(100)
AS
BEGIN
	UPDATE VI
	SET  SODU = @SODU
	WHERE TenVi = @TENVI and TenTk = @TenTK
END

-- Xóa ví
CREATE PROC USP_DeleteWallet
@TenVi nVARCHAR(100), @TenTK varchar(100)
AS
BEGIN
	DELETE FROM VI
	WHERE TenVi = @TenVi
END





select * from Vi
select * from TAIKHOAN