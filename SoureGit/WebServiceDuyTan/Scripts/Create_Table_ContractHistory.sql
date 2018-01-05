EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'MaxAssigned'

GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'Seller'

GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'PaymentMethodID'

GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'Paid'

GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'PriceWithDiscount'

GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'Discount'

GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'Price'

GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'TermPromotion'

GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'Term'

GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'CategoryID'

GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'ContractDate'

GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'ToDate'

GO

EXEC sys.sp_dropextendedproperty @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'FromDate'

GO

ALTER TABLE [dbo].[Contract_History] DROP CONSTRAINT [DF_Contract_History_CreateHis]
GO

/****** Object:  Table [dbo].[Contract_History]    Script Date: 5/21/2016 3:24:15 PM ******/
DROP TABLE [dbo].[Contract_History]
GO

/****** Object:  Table [dbo].[Contract_History]    Script Date: 5/21/2016 3:24:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Contract_History](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RowID] [int] NOT NULL,
	[ContractID] [varchar](5) NOT NULL,
	[ContractName] [nvarchar](100) NULL,
	[FromDate] [date] NULL,
	[ToDate] [date] NULL,
	[ContractDate] [date] NULL,
	[CustID] [varchar](5) NULL,
	[CategoryID] [varchar](2) NULL,
	[ProductID] [varchar](5) NULL,
	[Term] [int] NULL,
	[TermPromotion] [int] NULL,
	[Price] [numeric](18, 0) NULL,
	[Discount] [numeric](18, 0) NULL,
	[PriceWithDiscount] [numeric](18, 0) NULL,
	[Paid] [numeric](18, 0) NULL,
	[PaymentMethodID] [char](1) NULL,
	[Seller] [varchar](5) NULL,
	[Trainer] [varchar](5) NULL,
	[MaxAssigned] [int] NULL,
	[Assigned] [int] NULL,
	[AssignToMember] [nvarchar](5) NULL,
	[Status] [char](1) NULL,
	[CreateBy] [varchar](5) NULL,
	[CreateDate] [date] NULL,
	[ModifyBy] [nvarchar](5) NULL,
	[ModifyDate] [date] NULL,
	[CreateHisDate] [date] NULL,
	[CreateHisBy] [nvarchar](5) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Contract_History] ADD  CONSTRAINT [DF_Contract_History_CreateHis]  DEFAULT (getdate()) FOR [CreateHisDate]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngay  bat dau ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'FromDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngay ket thuc' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'ToDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ngay ki hop dong' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'ContractDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'STM, Start, Bronze, Sliver' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'CategoryID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ki han hop dong ( 1 Thang, 2 Thang...)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'Term'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ki han khuyen mai ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'TermPromotion'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gia tri hop dong ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'Price'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Phan tram chiet khau' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'Discount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gia tri hop dong sau giam  gia ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'PriceWithDiscount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'So tien thanh toan' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'Paid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Phuong thuc thanh toan' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'PaymentMethodID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nguoi ban hang' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'Seller'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'So lan chuyen nhuong toi da' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contract_History', @level2type=N'COLUMN',@level2name=N'MaxAssigned'
GO

