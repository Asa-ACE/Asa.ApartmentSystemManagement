CREATE PROCEDURE [dbo].[SpGetCharges]
	@buildingId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [ChargeID], [From], [To]
	FROM [dbo].[Charge]
	WHERE [BuildingID] = @buildingId
END
