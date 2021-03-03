CREATE PROCEDURE [dbo].[SpUnitsGetAll]
	@buildingId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [UnitID], [Area], [Number]
	FROM [dbo].[Unit]
	WHERE [BuildingID] = @buildingId
END