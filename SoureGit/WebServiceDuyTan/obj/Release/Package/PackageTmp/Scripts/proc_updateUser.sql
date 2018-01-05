USE [GYM]
GO

/****** Object:  StoredProcedure [dbo].[proc_updateUser]    Script Date: 5/16/2016 10:47:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE  PROCEDURE [dbo].[proc_updateUser]
			@USERNAME varchar(50),
			@FULLNAME nvarchar(200),
			@GROUPID varchar(5),
			@EmployeeID varchar(5),
			@LOCK bit ,
			@MODIFIEDBY varchar(5)
	
AS 

SET NOCOUNT ON

BEGIN TRANSACTION 

UPDATE [Users]
   SET 
      [FULLNAME] =@FULLNAME, 
      [GROUPID]=@GROUPID,
      [LOCK]=@LOCK,
	  EmployeeID=@EmployeeID,
      [ModifiedBy] =@MODIFIEDBY, 
      [ModidiedDate] =CURRENT_TIMESTAMP
     
    
 WHERE [USERNAME ]=@USERNAME 
 
if @@ERROR <>  0  goto HANDLE_ERROR

COMMIT TRAN 
	return 0 

HANDLE_ERROR:
    ROLLBACK TRAN
    RETURN -1
	




GO


