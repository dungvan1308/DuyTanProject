USE [GYM]
GO

/****** Object:  StoredProcedure [dbo].[proc_SelectUserDynamic]    Script Date: 5/16/2016 10:47:05 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[proc_SelectUserDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED


DECLARE @SQL nvarchar(3250)
DECLARE @SQLROWNUM NVARCHAR(3250)


SET @SQL = '
	USERID,USERNAME,FULLNAME,EMPLOYEEID,GROUPNAME,LOCK,A.CREATEBY,A.CREATEDATE,A.MODIFIEDBY,A.MODIDIEDDATE
from USERS A
left join GROUPUSER B on A.GROUPID = B.GROUPID
WHERE 1=1 '

if @WhereCondition is not null and LEN(@WhereCondition) > 2
	begin 
		set @SQL = @SQL + ' and ' + @WhereCondition
	end 
-- Order by 
IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) >2
		BEGIN
			SET @SQLROWNUM = ' select ROW_NUMBER ( ) over (order by ' + @OrderByExpression + ') STT , ' 
		END 
ELSE
		BEGIN 
			SET @SQLROWNUM = ' select ROW_NUMBER ( ) over (order by USERID) STT , ' 
		END 

SET @SQL = @SQLROWNUM + @SQL
print @SQL
EXEC sp_executesql @SQL





GO


