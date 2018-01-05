USE [GYM]
GO

/****** Object:  StoredProcedure [dbo].[proc_LoginUser]    Script Date: 5/15/2016 9:08:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[proc_LoginUser]
	@UserName varchar(50),
	@Password nvarchar(200)
AS

begin 

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

declare @userId varchar(5)




set @userId = 
(
	SELECT
		top(1) UserId
	FROM
		USERS
	WHERE
		UserName = @UserName and Password=@Password
)

if @userId is not null 

	begin 

		insert into LogIn(UserID,LogIn,Status) values (@userId,SYSDATETIME(),'1')

		SELECT
			UserId,UserName,FullName,GroupId,Password,IsChangePass ,Lock
		FROM
			USERS
		WHERE
			UserName = @UserName and Password=@Password
	end 
	
else 

print  @userId

	SELECT
		UserId,UserName,FullName,GroupId,Password,IsChangePass ,Lock
	FROM
		USERS
	WHERE
		UserName = @UserName and Password=@Password

end 



	
GO

