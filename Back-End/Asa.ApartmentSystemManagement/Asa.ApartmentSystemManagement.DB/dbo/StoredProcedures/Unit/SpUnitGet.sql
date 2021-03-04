CREATE PROCEDURE [dbo].[SpUnitGet]
	@unitId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [BuildingID], [UnitID], [Area], [Number]
	FROM [dbo].[Unit]
	WHERE [UnitID] = @unitId
END
