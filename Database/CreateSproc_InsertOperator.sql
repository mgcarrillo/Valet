USE [ValetDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Grace Carrillo
-- Create date: 18 April 2016
-- Description:	insert sproc
-- =============================================
create PROCEDURE dbo.[sp_Operator_Insert]
	@OperatorName nvarchar(200),
	@Latitude float,
	@Longitude float,
	@Address1 nvarchar(200),
	@City nvarchar(100),
	@State char(2),
	@Zip char(12),
	@Phone char(12),
	@WebsiteUrl nvarchar(200),
	@NumberOfSpaces int,
	@InitialFee decimal(8,2),
	@InitialHours int,
	@HourlyFee decimal(8,2),
	@AcceptsCash bit,
	@AcceptsCredit bit,
	@CoveredParking bit,
	@Open24Hours bit,
	@HourOpen int,
	@HourClosed int,
	@EventParking bit,
	@ParkingGarage bit
AS
BEGIN

	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	INSERT INTO dbo.[Operators]
			 ( [OperatorName],[Latitude],[Longitude],[Address1],[City],[StateID],[Zip], [Phone], [WebsiteUrl],
              [NumberOfSpaces],[InitialFee],[InitialHours],[HourlyFee],[AcceptsCash],[AcceptsCredit],
			  [CoveredParking],[Open24Hours],[HourOpen],[HourClosed],[EventParking],[ParkingGarage] )
		VALUES (@OperatorName, @Latitude, @Longitude, @Address1, @City, @State, @Zip, @Phone, @WebsiteUrl,
		        @NumberOfSpaces, @InitialFee, @InitialHours, @HourlyFee, @AcceptsCash, @AcceptsCredit,
				@CoveredParking, @Open24Hours, @HourOpen, @HourClosed, @EventParking, @ParkingGarage )

END
GO
