-- Create Procedure sp_chitietcc_select_one.sql
-- chitietcc select one
-- Author:		Sok Kim Thanh
-- Create date: <14/12/2023>
go
drop procedure if exists sp_chitietcc_select_one
go
CREATE PROCEDURE sp_chitietcc_select_one	
	@MANCC CHAR(11),
	@MASP CHAR(11)
AS
BEGIN
	SELECT * from chitietcc  --  ch�nh x�c m� 100%
END
GO
execute sp_chitietcc_select_one  'ncc01' , 'sp01'
