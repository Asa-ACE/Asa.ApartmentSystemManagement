CREATE PROCEDURE [dbo].[SpUnitCreate]
	@buildingId int,
	@area decimal(18,2),
	@unitNumber smallint,
	@description nvarchar(250)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Unit]
				([BuildingID],
				 [Area],
				 [Number],
				 [Description]
				)
		VALUES
				(@buildingId,
				 @area,
				 @unitNumber,
				 @description)
SELECT SCOPE_IDENTITY()
END
