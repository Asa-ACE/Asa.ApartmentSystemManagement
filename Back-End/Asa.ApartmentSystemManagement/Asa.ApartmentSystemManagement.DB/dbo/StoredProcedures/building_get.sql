CREATE PROCEDURE [dbo].[building_get]
	@building_id int

AS
BEGIN
	SELECT [BuildingId], [Name], [NumberOfUnits]
	FROM [dbo].[Building]
	WHERE [BuildingID] = @building_id
END
