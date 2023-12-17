﻿-- Create Procedure sp_quyentruycap_select_all.sql
-- Tài khoản select all
-- Author:		Sok Kim Thanh
-- Create date: <14/12/2023>

drop procedure if exists sp_cbo_quyentruycap_select_all
go
CREATE PROCEDURE sp_cbo_quyentruycap_select_all
AS
BEGIN
	SELECT qtc.maqtc, qtc.TENQTC FROM quyentruycap qtc
END
GO
 