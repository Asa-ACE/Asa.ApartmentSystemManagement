CREATE PROCEDURE [dbo].[SpCreateCharge]
	@buildingId INT,
	@from DATE,
	@to DATE
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Charge]
				([BuildingID],
				[From],
				[To])
			VALUES
				(@buildingId,
				@from,
				@to)
	SELECT SCOPE_IDENTITY()
END
RETURN 0
