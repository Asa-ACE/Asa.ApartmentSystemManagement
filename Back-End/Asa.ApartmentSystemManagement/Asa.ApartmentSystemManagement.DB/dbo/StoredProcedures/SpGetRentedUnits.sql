CREATE PROCEDURE [dbo].[SpGetRentedUnits]
	@personId int
AS
BEGIN
SET NOCOUNT ON
	SELECT [buildingID] , [Area] , [Number] , [Description] , U.[UnitID] 
	FROM [dbo].[Unit] AS U
	INNER JOIN [dbo].[Tenancy] AS T ON T.UnitID = U.UnitId 
	WHERE T.PersonID = @personId 
END