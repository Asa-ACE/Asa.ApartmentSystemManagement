CREATE PROCEDURE [dbo].[building_remove]
	@building_id int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM [dbo].[Building]
	WHERE BuildingID = @building_id
END