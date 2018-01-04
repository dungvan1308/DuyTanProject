USE [GYM]
GO

/****** Object:  StoredProcedure [dbo].[proc_InsertUser]    Script Date: 5/16/2016 10:48:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE  PROCEDURE [dbo].[proc_InsertUser]
	@USERNAME varchar(50),
	@FULLNAME nvarchar(200),
	@GROUPID varchar(5),
	@EmployeeID varchar(5),
	@CREATEBY varchar(5),
	@OUTUSERID varchar(5) out
	
AS
DECLARE @myERROR int -- Local @@ERROR
       , @myRowCount int -- Local @@ROWCOUNT
       , @UserID varchar(5),
	   @RowID   int 

SET NOCOUNT ON 




-- Check User da ton t
	set @OUTUSERID=(select top 1 USERID  from USERS where USERNAME=@USERNAME )
if @OUTUSERID is not null 
	begin 
		set @OUTUSERID='99999'
		--print @OUTUSERID
		return 0 
	end 
else
	begin 
		
			SET DATEFORMAT DMY 

			--set @UserID=(select RIGHT('00000'+ cast((lastNum+1) as varchar),5) from Inventory where TableName='USERS')
			--set @OutUserID =@UserID

			INSERT INTO [dbo].[USERS] (
				
				--[USERID],
				[USERNAME],
				[FULLNAME],
				[GROUPID],
				EmployeeID,
				CREATEBY,
				CREATEDATE
				
			) VALUES (
				
				--@UserId,
				@USERNAME,
				@FULLNAME,
				@GROUPID,
				@EmployeeID,
				@CREATEBY,
				CURRENT_TIMESTAMP
			)

			SET @RowID = SCOPE_IDENTITY()
			SET @UserID  = RIGHT('00000'+ cast(SCOPE_IDENTITY() as varchar),5) 
			set @OUTUSERID  = @UserID
			update USERS set UserId=@UserId where RowID=@RowID
	
end 




GO


