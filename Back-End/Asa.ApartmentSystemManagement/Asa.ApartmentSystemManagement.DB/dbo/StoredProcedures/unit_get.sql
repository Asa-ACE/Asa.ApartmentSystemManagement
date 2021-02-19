CREATE PROCEDURE [dbo].[unit_get]
	@building_id int
AS
BEGIN
	SELECT [BuildingID], [UnitID], [Area], [Number], [Description]
	FROM [dbo].[Unit]
	WHERE [BuildingID] = @building_id
END
