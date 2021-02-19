CREATE PROCEDURE [dbo].[unit_get]
	@unit_id int
AS
BEGIN
	SELECT [BuildingID], [UnitID], [Area], [Number], [Description]
	FROM [dbo].[Unit]
	WHERE [UnitID] = @unit_id
END
