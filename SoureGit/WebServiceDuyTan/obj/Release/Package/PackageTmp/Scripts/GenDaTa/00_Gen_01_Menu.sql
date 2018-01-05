
/*
		DUNGNV	:	27/06/2016
		Purpose	:	Gen script MENU
 */


select 'insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values(''' 
	+ MENUID + ''',N''' + MENUNAME + ''',''' + isnull(PARENTID,'') + ''',N''' + isnull(MODULE,'') + ''',' + cast( MENUORDER as varchar) + ',''' + isnull(AU,'') + ''')' SCRIPTS
from MENU
order by MENUORDER


/*
--select * from MENU

--begin tran 

--delete from MENU


insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0000',N'Người dùng','',N'',0,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0001',N'Nhóm người dùng','TL0000',N'',1,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0002',N'Người dùng','TL0000',N'USERS',2,'1')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0003',N'Phân quyền','TL0000',N'',3,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0004',N'Thiết lập mật  khẩu','TL0000',N'',4,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0005',N'Đang làm việc','TL0000',N'',5,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0100',N'Nhân viên','',N'',6,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0101',N'Nhân viên','TL0100',N'EMPLOYEE',7,'1')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0102',N'Tính lương','TL0100',N'',8,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0300',N'Khách hàng','',N'',9,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0301',N'Thêm mới','TL0300',N'',10,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0302',N'Đăng ký vân tay','TL0300',N'',11,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0303',N'Quản lý','TL0300',N'CUSTOMER',12,'1')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0304',N'Xác thực vân tay','TL0300',N'',13,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0400',N'Sản phẩm','',N'',14,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0401',N'Thêm mới','TL0400',N'',15,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0402',N'Quản lý','TL0400',N'PROGRAM',16,'1')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0500',N'Hợp đồng','',N'',17,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0501',N'Thêm mới','TL0500',N'',18,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0502',N'Quản lý','TL0500',N'CONTRACT',19,'1')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('TL0503',N'Giao dịch','TL0500',N'',20,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('MN0100',N'Hệ thống','',N'',21,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('MN0102',N'Sao lưu dữ liệu','MN0100',N'',22,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('MN0103',N'Khôi phục dữ liệu','MN0100',N'',23,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('MN0000',N'Quản lý','',N'',24,' ')
insert into MENU(MENUID,MENUNAME,PARENTID,MODULE,MENUORDER,AU) values('MN0006',N'Báo cáo','MN0000',N'',30,' ')


*/
