CREATE PROCEDURE [dbo].[SpGetExpense]
	@expenseId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [BuildingID], [CategoryID], [From], [To], [Amount], [Name]
	FROM [dbo].[Expense]
	WHERE [ExpenseID] = @expenseId
END
