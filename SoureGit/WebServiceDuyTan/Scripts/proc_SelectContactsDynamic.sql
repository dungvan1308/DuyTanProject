USE [GYM]
GO

/****** Object:  StoredProcedure [dbo].[proc_SelectContactsDynamic]    Script Date: 5/16/2016 10:46:00 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

alter PROCEDURE [dbo].[proc_SelectContractsDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)
DECLARE @SQLROWNUM NVARCHAR(3250)


SET @SQL = '

	[ContractID],
	[ContractName],
	A.CustID,
	C.CustName,
	C.Address,
	[FromDate],
	[ToDate],
	[ContractDate],
	
	[CategoryID],
	[ProductID],
	[Term],
	[TermPromotion],
	[Price],
	[Discount],
	[PriceWithDiscount],
	[Paid],
	[PaymentMethodID],
	[Seller],
	[Trainer],
	[MaxAssigned],
	[Assigned],
	[AssignToMember],
	B.DESCRIPTIONS DESC_STATUS,
	A.CreateBy,
	A.CreateDate,
	[ModifyBy],
	[ModifyDate]

FROM
	[dbo].[Contract] A
left join ALLCODE B on A.Status = B.FIELDVALUE and B.TABLENAME=''CONTRACT'' and B.FIELDNAME=''STATUS''
left join Customer C on A.CustID = C.CustID
WHERE 1=1' 


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
			SET @SQLROWNUM = ' select ROW_NUMBER ( ) over (order by ContractID) STT , ' 
		END 

SET @SQL = @SQLROWNUM + @SQL
print @SQL
EXEC sp_executesql @SQL





GO


