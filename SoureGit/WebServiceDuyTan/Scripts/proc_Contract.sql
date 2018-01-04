/****** Object:  StoredProcedure [dbo].[proc_SelectContact]    Script Date: 5/21/2016 11:46:38 AM ******/
DROP PROCEDURE [dbo].[proc_SelectContact]
GO

/****** Object:  StoredProcedure [dbo].[proc_SelectContact]    Script Date: 5/21/2016 11:46:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_SelectContact]
	@RowID int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[RowID],
	[ContractID],
	[ContractName],
	[FromDate],
	[ToDate],
	[ContractDate],
	[CustID],
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
	[Status],
	[CreateBy],
	[CreateDate],
	[ModifyBy],
	[ModifyDate]
FROM
	[dbo].[Contact]
WHERE
	[ContractID] = @RowID

--endregion

GO

/****** Object:  StoredProcedure [dbo].[proc_SelectContactsDynamic]    Script Date: 5/21/2016 11:47:19 AM ******/
DROP PROCEDURE [dbo].[proc_SelectContactsDynamic]
GO

/****** Object:  StoredProcedure [dbo].[proc_SelectContactsDynamic]    Script Date: 5/21/2016 11:47:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_SelectContactsDynamic] 
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[RowID],
	[ContractID],
	[ContractName],
	[FromDate],
	[ToDate],
	[ContractDate],
	[CustID],
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
	[Status],
	[CreateBy],
	[CreateDate],
	[ModifyBy],
	[ModifyDate]
FROM
	[dbo].[Contact]
WHERE 1=1 ' 
	if @WhereCondition is not null and LEN(@WhereCondition) > 2
	begin 
		set @SQL = @SQL + ' and ' + @WhereCondition
	end 
IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL

--endregion

GO

/****** Object:  StoredProcedure [dbo].[proc_UpdateContact]    Script Date: 5/21/2016 11:47:48 AM ******/
DROP PROCEDURE [dbo].[proc_UpdateContact]
GO

/****** Object:  StoredProcedure [dbo].[proc_UpdateContact]    Script Date: 5/21/2016 11:47:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_UpdateContact]
	@RowID int,
	@ContractID varchar(5),
	@ContractName nvarchar(100),
	@FromDate date,
	@ToDate date,
	@ContractDate date,
	@CustID varchar(5),
	@CategoryID varchar(2),
	@ProductID varchar(5),
	@Term int,
	@TermPromotion int,
	@Price numeric(18, 0),
	@Discount numeric(18, 0),
	@PriceWithDiscount numeric(18, 0),
	@Paid numeric(18, 0),
	@PaymentMethodID char(1),
	@Seller varchar(5),
	@Trainer varchar(5),
	@MaxAssigned int,
	@Assigned int,
	@AssignToMember nvarchar(5),
	@Status char(1),
	@CreateBy varchar(5),
	@CreateDate date,
	@ModifyBy nvarchar(5),
	@ModifyDate date
AS

SET NOCOUNT ON

UPDATE [dbo].[Contact] SET
	[ContractID] = @ContractID,
	[ContractName] = @ContractName,
	[FromDate] = @FromDate,
	[ToDate] = @ToDate,
	[ContractDate] = @ContractDate,
	[CustID] = @CustID,
	[CategoryID] = @CategoryID,
	[ProductID] = @ProductID,
	[Term] = @Term,
	[TermPromotion] = @TermPromotion,
	[Price] = @Price,
	[Discount] = @Discount,
	[PriceWithDiscount] = @PriceWithDiscount,
	[Paid] = @Paid,
	[PaymentMethodID] = @PaymentMethodID,
	[Seller] = @Seller,
	[Trainer] = @Trainer,
	[MaxAssigned] = @MaxAssigned,
	[Assigned] = @Assigned,
	[AssignToMember] = @AssignToMember,
	[Status] = @Status,
	[CreateBy] = @CreateBy,
	[CreateDate] = @CreateDate,
	[ModifyBy] = @ModifyBy,
	[ModifyDate] = @ModifyDate
WHERE
	[RowID] = @RowID

--endregion

GO

/****** Object:  StoredProcedure [dbo].[proc_InsertContractHistory]    Script Date: 5/21/2016 3:34:11 PM ******/
DROP PROCEDURE [dbo].[proc_InsertContractHistory]
GO

/****** Object:  StoredProcedure [dbo].[proc_InsertContractHistory]    Script Date: 5/21/2016 3:34:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_InsertContractHistory]
	@RowID int,
	@CreateHisBy nvarchar(5) 
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
INSERT INTO [Contract_History] ([RowID],[ContractID],[ContractName],[FromDate],[ToDate],[ContractDate],[CustID],[CategoryID],[ProductID]
      ,[Term],[TermPromotion],[Price],[Discount],[PriceWithDiscount],[Paid],[PaymentMethodID],[Seller],[Trainer]
      ,[MaxAssigned],[Assigned],[AssignToMember],[Status],[CreateBy],[CreateDate],[ModifyBy],[ModifyDate], [CreateHisBy])
SELECT [RowID],[ContractID],[ContractName],[FromDate],[ToDate],[ContractDate],[CustID],[CategoryID],[ProductID]
      ,[Term],[TermPromotion],[Price],[Discount],[PriceWithDiscount],[Paid],[PaymentMethodID],[Seller],[Trainer]
      ,[MaxAssigned],[Assigned],[AssignToMember],[Status],[CreateBy],[CreateDate],[ModifyBy],[ModifyDate], @CreateHisBy 
  FROM [Contact]
  where RowID = @RowID
GO
