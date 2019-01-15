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
create PROCEDURE dbo.[sp_GetDriversToBeNotified]

AS
BEGIN

	SET NOCOUNT ON;

		SELECT 	DISTINCT [ID],[DriverName],[Latitude],[Longitude],[DeviceID],[Expires],[Notified]
		FROM dbo.[Drivers]  (NOLOCK)
		WHERE [Expires] <= dateadd(minute, 10, getdate())
		 AND ([Notified] = 0 or [Notified] is null)
        ORDER BY [Expires]

END
GO


