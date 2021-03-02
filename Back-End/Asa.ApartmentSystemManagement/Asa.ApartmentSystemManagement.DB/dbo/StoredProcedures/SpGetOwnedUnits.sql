CREATE PROCEDURE [dbo].[SpGetOwnedUnits]
	@personId int
AS
BEGIN
SET NOCOUNT ON
	SELECT [BuildingID] , [Area] , [Number] , [Description] , U.[UnitID] 
	FROM [dbo].[Unit] AS U
	INNER JOIN [dbo].[Ownership] AS O ON O.UnitID = U.UnitID 
	WHERE O.PersonID = @personId 
END
