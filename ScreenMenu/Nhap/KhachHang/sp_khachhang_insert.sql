-- Author:		Vo Tu
-- Create date: <13/11/2023>
-- Create Procedure sp_khachhang_insert.sql
-- nhacungcap insert
drop procedure if exists sp_khachhang_insert
go
CREATE PROCEDURE sp_khachhang_insert
	@maKH char(11),
	@tenKH NVARCHAR(255),
	@sdtKH int = 0,
	@diemTL int = 0
AS
BEGIN
	INSERT INTO KHACHHANG VALUES (@maKH, @tenKH, @sdtKH,@diemTL)
END
GO
