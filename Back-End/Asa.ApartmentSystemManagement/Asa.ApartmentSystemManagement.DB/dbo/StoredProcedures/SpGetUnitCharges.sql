CREATE PROCEDURE [dbo].[SpGetUnitCharges]
	@unitId INT,
	@personId INT
AS
BEGIN
	SELECT C.[ChargeID], C.[From], C.[To], E.[Name], CI.[Amount]
	FROM [dbo].[Charge] AS C
	INNER JOIN [dbo].[Unit] AS U ON U.BuildingID = C.BuildingID
	INNER JOIN [dbo].[ChargeItem] AS CI ON CI.ChargeID = C.ChargeID
	INNER JOIN [dbo].[Expense] AS E ON E.ExpenseID = CI.ExpanseID
END
