-- Create Procedure sp_nhacungcap_select_one.sql
-- nhacungcap select one
-- Author:		Sok Kim Thanh
-- Create date: <07/11/2023>
-- update date: 10-12-2023
drop procedure if exists sp_nhacungcap_select_one
go
CREATE PROCEDURE sp_nhacungcap_select_one
	@MANCC CHAR(11)
AS
BEGIN
	SELECT * from nhacungcap where MANCC = @MANCC --like ch�nh x�c m� 100%
END
GO
