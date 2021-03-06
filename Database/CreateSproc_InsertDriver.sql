USE [ValetDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_Driver_Insert]    Script Date: 4/21/2017 3:14:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Grace Carrillo
-- Create date: 18 April 2016
-- Description:	insert sproc
-- =============================================
CREATE PROCEDURE [dbo].[sp_Driver_Insert]
	@DriverName nvarchar(200),
	@Latitude float,
	@Longitude float,
	@DeviceID nvarchar(100),
	@Expires datetime

AS
BEGIN

	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	IF EXISTS (SELECT 1 FROM dbo.[Drivers] where [DeviceID] = @DeviceID)
	BEGIN
		UPDATE dbo.[Drivers]
		   SET [Expires] = @Expires
		WHERE [DeviceID] = @DeviceID
	END
	ELSE
	BEGIN
		INSERT INTO dbo.[Drivers] ( [DriverName],[Latitude],[Longitude],[DeviceID], [Expires])
		     VALUES (@DriverName, @Latitude, @Longitude, @DeviceID, @Expires)	
	END
END
