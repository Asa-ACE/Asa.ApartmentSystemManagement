CREATE PROCEDURE [dbo].[SpExpenseGetByDate]
	@chargeId int

AS
BEGIN
	SET NOCOUNT ON;
	SELECT [ExpenseID], e.[BuildingID], [CategoryID], e.[From], e.[To], [Amount], [Name]
	FROM [dbo].[Charge] c
	INNER JOIN [dbo].[Expense] e ON e.BuildingID = c.BuildingID AND e.[To] >= c.[From] and e.[To] < c.[To]
	WHERE c.ChargeID = @chargeId
END