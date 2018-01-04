--RPT002:  Danh sach hop dong sap den han thanh toan
USE [GYM]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE  PROCEDURE [dbo].[RPT002] 

AS
	
SET DATEFORMAT DMY 
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

select  ROW_NUMBER ( ) over (order by ContractID ) STT, ContractID, ContractName, ToDate, DATEDIFF(DAY, FromDate, ToDate) DATENUM
from Contract
where DATEDIFF(DAY, FromDate, ToDate) <= 10

GO