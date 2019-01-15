USE [ValetDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Grace Carrillo
-- Create date: 18 April 2016
-- Description:	Get dealers within radius of a long/lat
-- =============================================
create PROCEDURE dbo.[sp_GetParkingInRadius]
	@myLat FLOAT,
	@myLong FLOAT,
	@radius FLOAT
AS
BEGIN

	SET NOCOUNT ON;

		--SET @mylat = 40.663846;
		--SET @mylong = -111.906766;
		--SET @someLong = -112 -- -113.589373; -- debugging
		--SET @someLat = 41 --37.07858;

		SELECT [OperatorName],[Latitude],[Longitude],[Address1],[City],[StateID],[Zip],[Phone],[WebsiteUrl],
              [NumberOfSpaces],[InitialFee],[InitialHours],[HourlyFee],[AcceptsCash],[AcceptsCredit],
			  [CoveredParking],[Open24Hours],[HourOpen],[HourClosed],[EventParking],[ParkingGarage]
				,dbo.[udf_GetDistanceMiles] (@mylat, @mylong, Latitude, Longitude) as [Distance]
		FROM dbo.[Operators]  (NOLOCK)
		WHERE dbo.[udf_GetDistanceMiles] (@mylat, @mylong, Latitude, Longitude) <= @radius


END
GO
