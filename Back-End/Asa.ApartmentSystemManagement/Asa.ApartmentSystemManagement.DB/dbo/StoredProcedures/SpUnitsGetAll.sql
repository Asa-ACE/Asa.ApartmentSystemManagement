CREATE PROCEDURE [dbo].[SpUnitsGetAll]
	@buildingId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [UnitID], [Area], [Number], [Description]
	FROM [dbo].[Unit]
	WHERE [BuildingID] = @buildingId
END