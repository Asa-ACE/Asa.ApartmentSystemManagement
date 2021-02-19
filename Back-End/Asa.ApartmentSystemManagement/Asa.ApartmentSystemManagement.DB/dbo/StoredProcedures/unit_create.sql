CREATE PROCEDURE [dbo].[unit_create]
	@building_id int,
	@area decimal,
	@unit_number smallint,
	@description nvarchar(250)
AS
BEGIN
	INSERT INTO [dbo].[Unit]
				([BuildingID],
				 [Area],
				 [Number],
				 [Description]
				)
		VALUES
				(@building_id,
				 @area,
				 @unit_number,
				 @description)
SELECT SCOPE_IDENTITY()
END
