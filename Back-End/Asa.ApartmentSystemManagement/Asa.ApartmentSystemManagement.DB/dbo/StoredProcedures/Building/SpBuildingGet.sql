CREATE PROCEDURE [dbo].[SpBuildingGet]
	@buildingId int

AS
BEGIN
	SET NOCOUNT ON;
	SELECT [BuildingID], [Name], [NumberOfUnits], [Address]
	FROM [dbo].[Building]
	WHERE [BuildingID] = @buildingId
END