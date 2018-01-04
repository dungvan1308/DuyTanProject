--PRT004: Danh sach khach hang theo san pham
USE [GYM]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE  PROCEDURE [dbo].[RPT004] 

AS
	
SET DATEFORMAT DMY 
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

select  ROW_NUMBER ( ) over (order by a.CustID ) STT, a.CustID, a.CustName, a.Address,a.Mobile, c.ProgramID, c.ProgramName
from Customer a
left join Contract b on a.CustID = b.CustID
left join Programs c on b.CategoryID = c.CategoryID

GO