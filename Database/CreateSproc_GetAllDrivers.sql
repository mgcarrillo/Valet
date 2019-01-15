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
create PROCEDURE dbo.[sp_GetAllDrivers]

AS
BEGIN

	SET NOCOUNT ON;

		SELECT 	[DriverName],[Latitude],[Longitude],[DeviceID]
		FROM dbo.[Drivers]  (NOLOCK)

END
GO
