USE [GYM]
GO

/****** Object:  StoredProcedure [dbo].[proc_SelectCustomersDynamic]    Script Date: 5/5/2016 11:24:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[proc_SelectCustomersDynamic]
	@WhereCondition nvarchar(max) =null,
	@OrderByExpression nvarchar(max) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)
DECLARE @SQLROWNUM NVARCHAR(3250)

SET @SQL = '
	
	[CustID],
	[RefCust],
	[CustName],
	[Address],
	[CityID],
	[DistrictID],
	[WardID],
	[CountryID],
	[BirthDay],
	[BirthPlace],
	[IdentityType],
	[IdentityValue],
	[IdentityDate],
	[IdentityPlace],
	[Type],
	[GroupCustID],
	[HomePhone],
	[Mobile],
	[Email],
	[Status],
	[RefInfo],
	[RewardPoint],
	[Presenter],
	--[Picture],
	[OpenDate],
	[CreateBy],
	[CreateDate],
	[ModifiedBy],
	[ModifiedDate]
FROM
	[dbo].[CUSTOMER]
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
			SET @SQLROWNUM = ' select ROW_NUMBER ( ) over (order by CUSTID) STT , ' 
		END 

SET @SQL = @SQLROWNUM + @SQL
print @SQL
EXEC sp_executesql @SQL



GO


