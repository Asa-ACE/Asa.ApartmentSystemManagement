CREATE PROCEDURE [dbo].[SpGetExpensesByChargeId]
	@chargeId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [ExpenseID], ec.[IsForOwner], ec.[FormulaType], e.[Amount], e.[From], e.[To], e.[BuildingID]
	FROM [dbo].[Charge] c
	INNER JOIN [dbo].[Expense] e ON e.BuildingID = c.BuildingID AND e.[To] >= c.[From] and e.[To] < c.[To]
	INNER JOIN [dbo].[ExpenseCategory] ec ON ec.CategoryID = e.CategoryID
	WHERE c.ChargeID = @chargeId
END