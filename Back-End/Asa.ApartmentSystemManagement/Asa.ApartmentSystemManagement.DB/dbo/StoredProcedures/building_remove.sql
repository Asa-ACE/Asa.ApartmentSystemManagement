CREATE PROCEDURE [dbo].[building_remove]
	@buildingId int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM [dbo].[Building]
	WHERE BuildingID = @buildingId
END
