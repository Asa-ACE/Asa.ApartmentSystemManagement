CREATE PROCEDURE [dbo].[SpGetOwnedUnitsChargeItems]
	@unitId int ,
	@personId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT CI.[ChargeItemID], E.[Name], E.[From], E.[To], CI.[Amount], C.[From] AS [ChargeFrom], C.[To] AS [ChargeTo], C.[ChargeID]
	FROM [dbo].[ChargeItem] AS CI
	INNER JOIN [dbo].[Expense] AS E ON E.ExpenseID = CI.ExpanseID
	INNER JOIN [dbo].[Charge] AS C ON C.ChargeID = CI.ChargeID
	INNER JOIN [dbo].[ExpenseCategory] AS EC ON EC.CategoryID = E.CategoryID AND EC.IsForOwner = 1
	WHERE CI.UnitID = @unitId AND CI.PersonID = @personId
	ORDER BY C.ChargeID
END
