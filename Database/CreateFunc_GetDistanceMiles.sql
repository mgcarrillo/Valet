USE ValetDB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Grace Carrillo
-- Create date: 18 April 2016
-- Description:	Determine distance in miles between 2 geographical points (longitude/latitude)

CREATE FUNCTION dbo.[udf_GetDistanceMiles]
(
	@latA FLOAT
	,@lonA FLOAT
	,@latB FLOAT
	,@lonB FLOAT
)
RETURNS FLOAT
AS
BEGIN
	-- Declare the return variable here
	DECLARE @distance FLOAT;

	-- perform all the math
	   DECLARE @R FLOAT;
	   SET @R = 6371;
       DECLARE @pi FLOAT;
	   SET @pi = 3.1415927;
	   DECLARE @kilometerToMiles FLOAT;
	   SET @kilometerToMiles = 0.621371;

       DECLARE @lat_alpha FLOAT, @lat_beta FLOAT;
       DECLARE @lon_alpha FLOAT, @lon_beta FLOAT;
       DECLARE @fi FLOAT, @p FLOAT, @d FLOAT;

       /* Converts degrees to radians */
       SET @lat_alpha = @pi * @latA / 180;
       SET @lat_beta = @pi * @latB / 180;
       SET @lon_alpha = @pi * @lonA / 180;
       SET @lon_beta = @pi * @lonB / 180;

       /* Calculate angles */
       SET @fi = ABS(@lon_alpha - @lon_beta);

       /* Calculates the third side of the spherical triangle */
       SET @p = ACOS(SIN(@lat_beta) * SIN(@lat_alpha) + COS(@lat_beta) * COS(@lat_alpha) * COS(@fi));

	   --print 'distance is ' + convert(varchar, @p * @R )

       /* Calculates the distance to the surface-- i.e., Earth R = ~ 6371 km */
       SET @distance = --CEILING(
						@p * @R * @kilometerToMiles; -- if we use the raw value, this is the distance in kilometers

	-- Return the result of the function
	RETURN @distance;

END
GO

