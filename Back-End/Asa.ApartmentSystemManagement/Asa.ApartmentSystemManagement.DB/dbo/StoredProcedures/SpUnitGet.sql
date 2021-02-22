CREATE PROCEDURE [dbo].[SpUnitGet]
	@unitId int
AS
BEGIN
	SELECT [BuildingID], [UnitID], [Area], [Number], [Description]
	FROM [dbo].[Unit]
	WHERE [UnitID] = @unitId
END
