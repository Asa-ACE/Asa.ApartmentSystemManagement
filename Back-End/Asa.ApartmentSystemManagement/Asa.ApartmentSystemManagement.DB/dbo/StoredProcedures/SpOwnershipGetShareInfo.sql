﻿CREATE PROCEDURE [dbo].[SpOwnershipGetShareInfo]
    @buildingId int,
    @from date,
    @to date

AS
BEGIN
    SET NOCOUNT ON;

    SELECT U.BuildingID, U.UnitID,O.PersonID,U.Area ,DATEDIFF(DAY,IIF(@from<O.[From], O.[From], @from), IIF(@to>O.[To], O.[To], @to)) AS [Days]
	FROM [Ownership] AS O 
		INNER JOIN [Unit] AS U ON O.UnitID=U.UnitID
	WHERE U.BuildingID = @buildingId
	AND	  O.[From]<@to AND O.[To] > @from

END
