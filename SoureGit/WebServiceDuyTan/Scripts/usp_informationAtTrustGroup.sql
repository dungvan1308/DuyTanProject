USE [DUYTAN2]
GO
/****** Object:  StoredProcedure [dbo].[usp_informationAtTrustGroup]    Script Date: 1/12/2018 1:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_informationAtTrustGroup]
AS
begin
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED

	declare @data int
	set @data = cast(convert(varchar(8),getdate()-1,112) as int)

	select '1' STT, t.VehicleNumber as VehicleNumber, e.EmployeeName as DriverName ,'0905505048' Phone ,  
		CONVERT(VARCHAR(5),j.StartTimePlan1,108) StartTimePlan1, p1 .PlaceName DeliveryPlace1, CONVERT(VARCHAR(5),j.ArrivalTimePlan1,108) as ArivalTimePlan1, 
		CONVERT(VARCHAR(5),j.StartTimePlan2,108) StartTimePlan2, p2.PlaceName DeliveryPlace2, CONVERT(VARCHAR(5),j.ArrivalTimePlan2,108) as ArivalTimePlan2, 
		CONVERT(VARCHAR(5),j.StartTimePlan3,108) StartTimePlan3, p3.PlaceName DeliveryPlace3, CONVERT(VARCHAR(5),j.ArrivalTimePlan3,108) as ArivalTimePlan3 
	from [dbo].[Trust] t with (nolock) 
	--inner join DUYTAN.[dbo].[JourneyCarGPS] a with (nolock) on t.VehicleNumber = a.LicenseCard
	inner join DUYTAN2.dbo.Journey j with (nolock)  on t.VehicleNumber = j.VehicleNumber
	inner join dbo.EMPLOYEE e with (nolock)  on j.Driver = e.EmployeeID
	left join DUYTAN2.dbo.Place p1 with (nolock)  on j.DeliveryPlace1 = p1.PlaceID
	left join DUYTAN2.dbo.Place p2 with (nolock)  on j.DeliveryPlace2 = p2.PlaceID
	left join DUYTAN2.dbo.Place p3 with (nolock)  on j.DeliveryPlace3 = p3.PlaceID	
	where  (cast(REPLACE(j.JourneyDate,'-','') as int)) = @data	
		--and importdate = @data
end