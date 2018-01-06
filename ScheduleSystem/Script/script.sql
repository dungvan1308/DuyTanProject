USE [DUYTAN]
GO

/****** Object:  Table [dbo].[JourneyCar]    Script Date: 1/6/2018 4:04:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[JourneyCar](
	[LicenseCard] [varchar](20) NULL,
	[Lat] [decimal](9, 6) NULL,
	[Lon] [decimal](9, 6) NULL,
	[ImportDatetime] [varchar](14) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Heading] [decimal](4, 1) NULL CONSTRAINT [DF__JourneyCa__Headi__08362A7C]  DEFAULT (NULL),
	[Speed] [decimal](4, 1) NULL CONSTRAINT [DF__JourneyCa__Speed__092A4EB5]  DEFAULT (NULL),
	[MaxSpeed] [decimal](4, 1) NULL CONSTRAINT [DF__JourneyCa__MaxSp__0A1E72EE]  DEFAULT (NULL),
	[sDateTime] [datetime] NULL CONSTRAINT [DF__JourneyCa__sDate__0B129727]  DEFAULT (NULL),
	[TotalMil] [decimal](10, 1) NULL CONSTRAINT [DF__JourneyCa__Total__0C06BB60]  DEFAULT (NULL),
	[CurrentMil] [decimal](10, 1) NULL CONSTRAINT [DF__JourneyCa__Curre__0CFADF99]  DEFAULT (NULL),
	[TotalTripTime] [varchar](10) NULL CONSTRAINT [DF__JourneyCa__Total__0DEF03D2]  DEFAULT (NULL),
	[NDT] [varchar](10) NULL CONSTRAINT [DF__JourneyCar__NDT__0EE3280B]  DEFAULT (NULL),
	[EquipmentID] [varchar](20) NULL CONSTRAINT [DF__JourneyCa__Equip__0FD74C44]  DEFAULT (NULL),
	[CompanyName] [varchar](100) NULL CONSTRAINT [DF__JourneyCa__Compa__10CB707D]  DEFAULT (NULL),
	[ConnectedFrom] [datetime] NULL CONSTRAINT [DF__JourneyCa__Conne__11BF94B6]  DEFAULT (NULL),
	[Duration] [varchar](20) NULL CONSTRAINT [DF__JourneyCa__Durat__12B3B8EF]  DEFAULT (NULL),
	[LiveStatus] [varchar](100) NULL CONSTRAINT [DF__JourneyCa__LiveS__13A7DD28]  DEFAULT (NULL),
	[sColor] [varchar](50) NULL CONSTRAINT [DF__JourneyCa__sColo__149C0161]  DEFAULT (NULL),
	[IDLE] [varchar](10) NULL CONSTRAINT [DF__JourneyCar__IDLE__1590259A]  DEFAULT (NULL),
	[Engine] [varchar](10) NULL CONSTRAINT [DF__JourneyCa__Engin__168449D3]  DEFAULT (NULL),
	[Door] [varchar](20) NULL CONSTRAINT [DF__JourneyCar__Door__17786E0C]  DEFAULT (NULL),
	[AreaName] [varchar](200) NULL CONSTRAINT [DF__JourneyCa__AreaN__186C9245]  DEFAULT (NULL),
	[Fuel] [int] NULL CONSTRAINT [DF__JourneyCar__Fuel__1960B67E]  DEFAULT (NULL),
	[MayLanh] [varchar](10) NULL CONSTRAINT [DF__JourneyCa__MayLa__1A54DAB7]  DEFAULT (NULL),
	[MMC_ID] [varchar](10) NULL CONSTRAINT [DF__JourneyCa__MMC_I__1B48FEF0]  DEFAULT (NULL),
	[CarGroupName] [varchar](50) NULL CONSTRAINT [DF__JourneyCa__CarGr__1C3D2329]  DEFAULT (NULL),
	[MaTaiXe] [varchar](20) NULL CONSTRAINT [DF__JourneyCa__MaTai__1D314762]  DEFAULT (NULL),
	[FullName] [nvarchar](100) NULL CONSTRAINT [DF__JourneyCa__FullN__1E256B9B]  DEFAULT (NULL),
	[Phone] [varchar](20) NULL CONSTRAINT [DF__JourneyCa__Phone__1F198FD4]  DEFAULT (NULL),
	[LoaiXe] [nvarchar](100) NULL CONSTRAINT [DF__JourneyCa__LoaiX__200DB40D]  DEFAULT (NULL),
	[HanKiemDinh] [datetime] NULL CONSTRAINT [DF__JourneyCa__HanKi__2101D846]  DEFAULT (NULL),
 CONSTRAINT [PK_JourneyCar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


-- =============================================


USE [DUYTAN]
GO

/****** Object:  Table [dbo].[ScheduleSystem]    Script Date: 1/6/2018 4:04:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ScheduleSystem](
	[JobName] [varchar](50) NOT NULL,
	[FrequencyType] [varchar](10) NULL,
	[FrequencyValue] [varchar](80) NULL,
	[StartTime] [char](8) NULL,
	[EndTime] [char](8) NULL,
	[IntervalTime] [int] NULL,
	[Channel] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[JobName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO




-- =============================================

USE [DUYTAN]
GO

/****** Object:  Table [dbo].[ScheduleProperty]    Script Date: 1/6/2018 4:05:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ScheduleProperty](
	[JobName] [varchar](50) NOT NULL,
	[PropertyName] [varchar](50) NOT NULL,
	[PropertyValue] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

-- =============================================
INSERT INTO [dbo].[ScheduleSystem]
           ([JobName]
           ,[FrequencyType]
           ,[FrequencyValue]
           ,[StartTime]
           ,[EndTime]
           ,[IntervalTime]
           ,[Channel])
     VALUES
           ('JourneyCarJob','daily',null,'15:28:00','23:00:00', '300', null)
		   
		

-- =============================================


		

USE [DUYTAN]
GO
/****** Object:  StoredProcedure [dbo].[usp_JourneyCar]    Script Date: 1/6/2018 4:03:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<phutt>
-- Create date: <20171231>
-- Description:	<Get all schedule will execute in day>
-- =============================================
ALTER PROCEDURE [dbo].[usp_JourneyCar]
	@Activity varchar(20)='',
	@LicenseCard varchar(20)='',
	@Lat decimal(9,6)=0,
	@Lon decimal(9,6)=0,
	@Heading decimal(4,1) = null,
	@Speed decimal(4,1) = null,
	@MaxSpeed decimal(4,1) =null,
	@sDateTime datetime = null,
	@TotalMil decimal(10,1) = null,
	@CurrentMil decimal(10,1) = null,
	@TotalTripTime varchar(10) ='',
	@NDT varchar(10) ='',
	@EquipmentID varchar(20) ='',
	@CompanyName varchar(100) ='',
	@ConnectedFrom datetime = null,
	@Duration varchar(20) ='',
	@LiveStatus varchar(100) ='',
	@sColor varchar(50) ='',
	@IDLE varchar(10) ='',
	@Engine varchar(10) ='',
	@Door varchar(20) ='',
	@AreaName varchar(200) ='',
	@Fuel int=0,
	@MayLanh varchar(10) ='',
	@MMC_ID varchar(20) ='',
	@CarGroupName varchar(50) ='',
	@MaTaiXe varchar(20) ='',
	@FullName nvarchar(100) ='',
	@Phone varchar(20) ='',
	@LoaiXe nvarchar(100) ='',
	@HanKiemDinh datetime,
	@ImportDatetime varchar(14)=''
AS
BEGIN
	SET NOCOUNT ON;
	if @Activity='ImportData' 
	begin
		insert into JourneyCar
		(
			LicenseCard,
			Lat,
			Lon,
			Heading,
			Speed,
			MaxSpeed,
			sDateTime,
			TotalMil,
			CurrentMil,
			TotalTripTime,
			NDT,
			EquipmentID,
			CompanyName,
			ConnectedFrom,
			Duration,
			LiveStatus,
			sColor,
			IDLE,
			Engine,
			Door,
			AreaName,
			Fuel,
			MayLanh,
			MMC_ID,
			CarGroupName,
			MaTaiXe,
			FullName,
			Phone,
			LoaiXe,
			HanKiemDinh,
			ImportDatetime
			)
		values
		(
			@LicenseCard,
			@Lat,
			@Lon,
			@Heading,
			@Speed,
			@MaxSpeed,
			@sDateTime,
			@TotalMil,
			@CurrentMil,
			@TotalTripTime,
			@NDT,
			@EquipmentID,
			@CompanyName,
			@ConnectedFrom,
			@Duration,
			@LiveStatus,
			@sColor,
			@IDLE,
			@Engine,
			@Door,
			@AreaName,
			@Fuel,
			@MayLanh,
			@MMC_ID,
			@CarGroupName,
			@MaTaiXe,
			@FullName,
			@Phone,
			@LoaiXe,
			@HanKiemDinh,
			@ImportDatetime
		)
		select 1
	end
END
