-- Author:		Sok Kim Thanh
-- Create date: <10/12/2023 9:33 SA>
go
drop procedure if exists sp_nhanvien_search
go
CREATE PROCEDURE sp_nhanvien_search
	@keyword nvarchar(100) = N''
AS
BEGIN 
	SELECT MANV, Hotennv, ngaysinh, gioitinh, luong, sdtnv from nhanvien where HOTENNV like '%' + isnull(@keyword,HOTENNV) + '%'--like ch�nh x�c m� 100%
END;
go
select * from nhanvien
exec sp_nhanvien_search '' --test ok
