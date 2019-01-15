USE [ValetDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Grace Carrillo
-- Create date: 18 April 2016
-- Description:	Get parking details by operator id
-- =============================================
create PROCEDURE dbo.[sp_GetAllOperators]

AS
BEGIN

	SET NOCOUNT ON;

		SELECT [OperatorName],[Latitude],[Longitude],[Address1],[City],[StateID],[Zip], [Phone], [WebsiteUrl],
              [NumberOfSpaces],[InitialFee],[InitialHours],[HourlyFee],[AcceptsCash],[AcceptsCredit],
			  [CoveredParking],[Open24Hours],[HourOpen],[HourClosed],[EventParking],[ParkingGarage]
		FROM dbo.[Operators]  (NOLOCK)

END
GO
