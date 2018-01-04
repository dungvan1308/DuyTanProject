--RPT001: Danh sach the sap den han trong vong n ngay

USE [GYM]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER  PROCEDURE [dbo].[RPT001] 
/*@EXPDATE INT*/
AS
	
SET DATEFORMAT DMY 
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

select  ROW_NUMBER ( ) over (order by a.CUSTID ) STT,a.CUSTID, a.CUSTNAME, a.ADDRESS, a.Mobile, DATEDIFF(DAY, b.FromDate, b.ToDate) EXPDATE
from Customer a
join Contract b on a.CustID = b.CustID
where DATEDIFF(DAY, b.FromDate, b.ToDate) <= 10 /*@EXPDATE*/

GO