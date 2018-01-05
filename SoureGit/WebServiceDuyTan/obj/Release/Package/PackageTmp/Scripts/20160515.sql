SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_InsertUpdateProgram]
	@RowID int,
	@ProgramID varchar(5),
	@ProgramName nvarchar(100),
	@Description nvarchar(100),
	@CategoryID varchar(2),
	@Term int,
	@TermCD char(1),
	@Training_sessions int,
	@Price numeric(18, 0),
	@EffectDate date,
	@FromTime time,
	@ToTime time,
	@Active char(1)
AS

SET NOCOUNT ON
IF EXISTS(SELECT ROWID FROM [Programs] WHERE [RowID] = @RowID)
BEGIN
	UPDATE [dbo].[Programs] SET
		[ProgramID] = @ProgramID,
		[ProgramName] = @ProgramName,
		[Description] = @Description,
		[CategoryID] = @CategoryID,
		[Term] = @Term,
		[TermCD] = @TermCD,
		[Training_sessions] = @Training_sessions,
		[Price] = @Price,
		[EffectDate] = @EffectDate,
		[FromTime] = @FromTime,
		[ToTime] = @ToTime,
		[Active] = @Active
	OUTPUT INSERTED.* 
	WHERE
		[RowID] = @RowID
END
ELSE
BEGIN
	INSERT INTO [dbo].[Programs] (
		[ProgramID],
		[ProgramName],
		[Description],
		[CategoryID],
		[Term],
		[TermCD],
		[Training_sessions],
		[Price],
		[EffectDate],
		[FromTime],
		[ToTime],
		[Active]
	) OUTPUT INSERTED.* VALUES (
		@ProgramID,
		@ProgramName,
		@Description,
		@CategoryID,
		@Term,
		@TermCD,
		@Training_sessions,
		@Price,
		@EffectDate,
		@FromTime,
		@ToTime,
		@Active
	)
END
SET @RowID = SCOPE_IDENTITY()


INSERT INTO ALLCODE VALUES ('CATEGORY', 'E', N'Erobik', 'PROGRAM', 0);
INSERT INTO ALLCODE VALUES ('CATEGORY', 'F', N'Fitness', 'PROGRAM', 1);
INSERT INTO ALLCODE VALUES ('CATEGORY', 'M', N'Massage', 'PROGRAM', 2);
INSERT INTO ALLCODE VALUES ('CATEGORY', 'Y', N'Yoga', 'PROGRAM', 3);
INSERT INTO ALLCODE VALUES ('CATEGORY', 'O', N'Khác', 'PROGRAM', 4);

INSERT INTO ALLCODE VALUES ('TERM', 'D', N'Ngày', 'PROGRAM', 0);
INSERT INTO ALLCODE VALUES ('TERM', 'W', N'Tuần', 'PROGRAM', 1);
INSERT INTO ALLCODE VALUES ('TERM', 'M', N'Tháng', 'PROGRAM', 2);
INSERT INTO ALLCODE VALUES ('TERM', 'Y', N'Năm', 'PROGRAM', 3);
INSERT INTO ALLCODE VALUES ('TERM', 'C', N'Chuyên đề', 'PROGRAM', 4);
INSERT INTO ALLCODE VALUES ('FROMTIME', '07:00', N'Thời gian bắt đầu hoạt động', 'PROGRAM', 0);
INSERT INTO ALLCODE VALUES ('TOTIME', '21:00', N'Thời gian ngưng hoạt động', 'PROGRAM', 0);