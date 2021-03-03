CREATE PROCEDURE [dbo].[SpChargeUpdate]
	@chargeId int,
	@buildingId int,
	@from date,
	@to date
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Charge]
	SET [BuildingID] = @buildingId, [From] = @from, [To] = @to
	WHERE
	[ChargeID] = @chargeId
END
