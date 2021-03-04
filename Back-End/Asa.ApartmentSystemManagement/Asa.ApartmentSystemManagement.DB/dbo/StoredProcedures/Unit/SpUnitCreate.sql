CREATE PROCEDURE [dbo].[SpUnitCreate]
	@buildingId int,
	@area decimal(18,2),
	@unitNumber smallint
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Unit]
				([BuildingID],
				 [Area],
				 [Number]
				)
		VALUES
				(@buildingId,
				 @area,
				 @unitNumber)
SELECT SCOPE_IDENTITY()
END
