USE [GYM]
GO

/****** Object:  StoredProcedure [dbo].[proc_ResetUser]    Script Date: 5/16/2016 10:48:09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE  PROCEDURE [dbo].[proc_ResetUser]
			@USERNAME varchar(50),
			@PASSWORD nvarchar(200),
			@MODIFIEDBY nvarchar(5)
		
	
AS 

SET NOCOUNT ON

BEGIN TRANSACTION 

UPDATE [Users]
   SET 
      [PASSWORD] =@PASSWORD, 
      [MODIFIEDBY] =@MODIFIEDBY, 
      [MODIDIEDDATE] =CURRENT_TIMESTAMP
     
    
 WHERE [USERNAME]=@USERNAME
 
if @@ERROR <>  0  goto HANDLE_ERROR

COMMIT TRAN 
	return 0 

HANDLE_ERROR:
    ROLLBACK TRAN
    RETURN -1
	

	


GO


