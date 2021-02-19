CREATE PROCEDURE [dbo].[building_update]
	@buildingId int,
	@name nvarchar(50),
	@numberOfUnits smallint
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Building]
	SET [Name] = @name, NumberOfUnits = @numberOfUnits
	WHERE
	BuildingID = @buildingId
END

