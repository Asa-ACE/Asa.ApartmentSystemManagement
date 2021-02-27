CREATE PROCEDURE [dbo].[SpBuildingGet]
	@buildingId int

AS
BEGIN
	SET NOCOUNT ON;
	SELECT [BuildingId], [Name], [NumberOfUnits], [Address]
	FROM [dbo].[Building]
	WHERE [BuildingId] = @buildingId
END