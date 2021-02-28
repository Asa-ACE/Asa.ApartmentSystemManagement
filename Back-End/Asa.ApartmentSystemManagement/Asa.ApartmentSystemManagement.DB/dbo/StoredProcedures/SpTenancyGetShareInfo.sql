CREATE PROCEDURE [dbo].[SpTenancyGetShareInfo]
    @buildingId int,
    @from date,
    @to date

AS
BEGIN
    SET NOCOUNT ON;

    SELECT U.BuildingID, U.UnitID,O.PersonID,U.Area ,O.NumberOfPeopel,DATEDIFF(DAY,IIF(@from<O.[From], O.[From], @from), IIF(@to>O.[To], O.[To], @to)) AS [Days]
	FROM [Tenancy] AS O 
		INNER JOIN [Unit] AS U ON O.UnitID=U.UnitID
	WHERE U.BuildingID = @buildingId
	AND	  O.[From]<@to AND O.[To] > @from

END
