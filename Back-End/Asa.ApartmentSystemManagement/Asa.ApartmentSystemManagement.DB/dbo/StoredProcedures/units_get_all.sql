CREATE PROCEDURE [dbo].[units_get_all]
	@building_id int
AS
BEGIN
	SELECT [UnitID], [Area], [Number], [Description]
	FROM [dbo].[Unit]
	WHERE [BuildingID] = @building_id
END