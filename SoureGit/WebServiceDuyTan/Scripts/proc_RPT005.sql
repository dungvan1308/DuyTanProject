--RPT005: Doanh so tu ngay den ngay
USE [GYM]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE  PROCEDURE [dbo].[RPT005] 
/*
@FRDATE DATE,
@TODATE DATE
*/
AS
	
SET DATEFORMAT DMY 
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

select  ROW_NUMBER ( ) over (order by a.CustID ) STT, a.CustID, a.CustName, b.ContractName, b.FromDate, b.ToDate, COALESCE(b.Paid, 0) PRICE
from Customer a
left join Contract b on a.CustID = b.CustID
/*where b.fromdate between @FRDATE AND @TODATE
AND b.todate between @FRDATE AND @TODATE*/

GO

--EXEC RPT006 @FRDATE = [01/01/2015] , @TODATE = [30/12/2016]