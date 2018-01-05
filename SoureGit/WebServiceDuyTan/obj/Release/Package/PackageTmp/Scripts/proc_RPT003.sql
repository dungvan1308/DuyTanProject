--RPT003: Danh sach hop dong chua thanh toan du
USE [GYM]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE  PROCEDURE [dbo].[RPT003] 

AS
	
SET DATEFORMAT DMY 
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

select  ROW_NUMBER ( ) over (order by ContractID ) STT, ContractID, ContractName, FromDate, ToDate, Term, (PriceWithDiscount-Paid) PENDINGPAID
from Contract
where PriceWithDiscount-Paid >0

GO