CREATE PROCEDURE [dbo].[SpGetRentedUnits]
	@personId int
AS
BEGIN
SET NOCOUNT ON
	SELECT [BuildingID] , [Area] , [Number], U.[UnitID] 
	FROM [dbo].[Unit] AS U
	INNER JOIN [dbo].[Tenancy] AS T ON T.UnitID = U.UnitID
	WHERE T.PersonID = @personId
END