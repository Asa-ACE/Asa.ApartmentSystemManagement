CREATE PROCEDURE [dbo].[SpDeleteChargeItems]
	@chargeId INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [dbo].[ChargeItem]
	WHERE [ChargeID] = @chargeId
END
