/****** Object:  StoredProcedure [dbo].[proc_InsertEnroll]    Script Date: 5/19/2016 8:51:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_InsertEnroll]
	@CUSTID varchar(5)
AS

SET NOCOUNT ON

BEGIN TRANSACTION 
SET DATEFORMAT DMY 	

INSERT INTO [dbo].[ENROLL] (
	[CUSTID], [ENROLLDATE]
) OUTPUT Inserted.ENROLLID VALUES (
	@CUSTID, SYSDATETIME()
)

	COMMIT TRAN 
		return 0 
	if @@ERROR <>  0  goto HANDLE_ERROR
	HANDLE_ERROR:
		ROLLBACK TRAN		
		RETURN @@ERROR

GO

/****** Object:  StoredProcedure [dbo].[proc_InsertUpdateFingerPrint]    Script Date: 5/19/2016 8:52:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_InsertUpdateFingerPrint]
	@FINGERID	varchar(5),
	@CUSTID		varchar(100),	
	@FPIMAGE	varchar(MAX),
	@CREATEBY	varchar(5)
AS

DECLARE @myERROR int -- Local @@ERROR
       , @myRowCount int -- Local @@ROWCOUNT
       

SET NOCOUNT ON
BEGIN TRANSACTION 

IF EXISTS(SELECT [FINGERID] FROM [dbo].[FINGERPRINT] WHERE [CUSTID] = @CUSTID)
BEGIN
	UPDATE [dbo].[FINGERPRINT] SET 
		[FPIMAGE] =@FPIMAGE, 
		[MODIFIEDBY] = @CREATEBY,
		[MODIFIEDDATE] = SYSDATETIME() 
	OUTPUT INSERTED.FINGERID 
	WHERE
		[CUSTID] = @CUSTID
		COMMIT TRAN 
			return 0 
		if @@ERROR <>  0  goto HANDLE_ERROR
END
ELSE
BEGIN
SET DATEFORMAT DMY 
	INSERT INTO [dbo].[FINGERPRINT] (		
		[CUSTID],		
		[FPIMAGE],
		[CREATEBY],
		[CREATEDATE],
		[MODIFIEDBY],
		[MODIFIEDDATE]
	) OUTPUT INSERTED.FINGERID VALUES (	
		@CUSTID,
		@FPIMAGE,
		@CREATEBY,
		SYSDATETIME(), --@CREATEDATE,
		@CREATEBY,
		SYSDATETIME()--@MODIFIEDDATE
	)
	COMMIT TRAN 
	return 0 
	if @@ERROR <>  0  goto HANDLE_ERROR

END
HANDLE_ERROR:
				ROLLBACK TRAN				
				RETURN @myERROR
--END


GO

/****** Object:  StoredProcedure [dbo].[proc_SelectFingerPrint]    Script Date: 5/21/2016 4:06:18 PM ******/
DROP PROCEDURE [dbo].[proc_SelectFingerPrint]
GO

/****** Object:  StoredProcedure [dbo].[proc_SelectFingerPrint]    Script Date: 5/21/2016 4:06:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_SelectFingerPrint] 
	@FINGERID varchar(5) = NULL,
	@CUSTID varchar(5) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT [FINGERPRINT].*, ToDate, [Status]
FROM [dbo].[FINGERPRINT] INNER JOIN [dbo].[CONTACT] ON [FINGERPRINT].CUSTID = [CONTACT].CustID
WHERE (@FINGERID <> '' AND [FINGERID] = @FINGERID) 
	OR (@CUSTID <> '' AND [FINGERPRINT].[CUSTID] = @CUSTID)
	OR (@FINGERID = '' AND @CUSTID = '' AND 1=1)

GO



