USE [GYM]
GO

/****** Object:  StoredProcedure [dbo].[proc_UpdateCustomer]    Script Date: 5/5/2016 11:24:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_UpdateCustomer]
	
	@CustID varchar(5),
	@RefCust nvarchar(200),
	@CustName nvarchar(200),
	@Address nvarchar(200),
	@CityID varchar(10),
	@DistrictID varchar(10),
	@WardID varchar(10),
	@CountryID varchar(5),
	@BirthDay date,
	@BirthPlace varchar(10),
	@IdentityType char(1),
	@IdentityValue varchar(20),
	@IdentityDate date,
	@IdentityPlace nvarchar(100),
	@Type char(1),
	@GroupCustID varchar(5),
	@HomePhone varchar(20),
	@Mobile varchar(11),
	@Email varchar(100),
	@Status char(1),
	@RefInfo nvarchar(200),
	--@RewardPoint numeric(18, 0),
	@Presenter nvarchar(50),
	@Picture image,
	@OpenDate date,
	--@CreateDate datetime,
	@ModifiedBy varchar(5)
	--@ModifiedDate datetime
AS

SET NOCOUNT ON

UPDATE [dbo].[Customer] SET
	
	[RefCust] = @RefCust,
	[CustName] = @CustName,
	[Address] = @Address,
	[CityID] = @CityID,
	[DistrictID]=@DistrictID,
	[WardID]=@WardID,
	[CountryID] = @CountryID,
	[BirthDay] = @BirthDay,
	[BirthPlace] = @BirthPlace,
	[IdentityType] = @IdentityType,
	[IdentityValue] = @IdentityValue,
	[IdentityDate] = @IdentityDate,
	[IdentityPlace] = @IdentityPlace,
	[Type] = @Type,
	[GroupCustID] = @GroupCustID,
	[HomePhone] = @HomePhone,
	[Mobile] = @Mobile,
	[Email] = @Email,
	[Status] = @Status,
	[RefInfo] = @RefInfo,
	--[RewardPoint] = @RewardPoint,
	[Presenter] = @Presenter,
	[Picture] = @Picture,
	[OpenDate] = @OpenDate,
	--[CreateBy] = @CreateBy,
	--[CreateDate] = @CreateDate,
	[ModifiedBy] = @ModifiedBy,
	
	[ModifiedDate] =SYSDATETIME()
WHERE
	[CustID] = @CustID

--endregion


GO


