CREATE PROCEDURE [dbo].[SpBuildingUpdate]
	@buildingId int,
	@name nvarchar(50),
	@numberOfUnits smallint,
	@address nvarchar(200)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Building]
	SET [Name] = @name, NumberOfUnits = @numberOfUnits, [Address] = @address
	WHERE
	BuildingID = @buildingId
END

