CREATE PROCEDURE [dbo].[SpDeleteExpense]
	@expenseId int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [dbo].[Expense]
	WHERE [ExpenseID] = @expenseId
END
