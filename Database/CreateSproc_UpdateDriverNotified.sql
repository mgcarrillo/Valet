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
create PROCEDURE dbo.[sp_DriverNotified]
	@driverId INT

AS
BEGIN

	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	UPDATE dbo.[Drivers] 
		SET [Notified] = 1
		WHERE [ID] = @driverId

END
GO
