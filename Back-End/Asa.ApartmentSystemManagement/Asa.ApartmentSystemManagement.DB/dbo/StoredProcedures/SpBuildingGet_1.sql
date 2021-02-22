CREATE PROCEDURE [dbo].[SpBuildingGet]
	@buildingId int

AS
BEGIN
	SELECT [BuildingId], [Name], [NumberOfUnits]
	FROM [dbo].[Building]
	WHERE [BuildingID] = @buildingId
END