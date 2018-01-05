USE [GYM]
GO

/****** Object:  StoredProcedure [dbo].[proc_SelectUser]    Script Date: 5/16/2016 10:46:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-------------------------------------------------------------------

CREATE PROCEDURE [dbo].[proc_SelectUser]
	@USERID varchar(5)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

select USERID,USERNAME,FULLNAME,A.GROUPID,EMPLOYEEID, GROUPNAME,PASSWORD,ISCHANGEPASS,LOCK,A.CREATEBY,A.CREATEDATE,A.MODIFIEDBY,A.MODIDIEDDATE
from USERS A
left join GROUPUSER B on A.GROUPID = B.GROUPID
where USERID=@USERID
	
	
	

GO


