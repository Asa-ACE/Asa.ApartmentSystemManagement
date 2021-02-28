CREATE PROCEDURE [dbo].[SpGetCharges]
	@buildingId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [ChargeID], [From], [To]
	FROM [Charge]
	WHERE [BuildingId] = @buildingId
END
