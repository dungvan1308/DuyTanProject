USE [GYM]
GO

/****** Object:  StoredProcedure [dbo].[proc_SelectCustomer]    Script Date: 5/5/2016 11:24:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[proc_SelectCustomer]
	@CustID varchar(5)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[RowID],
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
	[Picture],
	[OpenDate],
	[CreateBy],
	[CreateDate],
	[ModifiedBy],
	[ModifiedDate]
FROM
	[dbo].[CUSTOMER]
WHERE
	[CustID] = @CustID


GO


