CREATE PROCEDURE [dbo].[SpBuildingsGetAll]
	@userId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Building].[BuildingID], [Name], [NumberOfUnits], [Address]
	FROM [dbo].[Building]
	INNER JOIN [Admin] ON [Admin].[BuildingID] = [Building].[BuildingID]
	WHERE [PersonID] = @userId;
END
