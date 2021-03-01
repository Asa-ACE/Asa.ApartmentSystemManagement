CREATE PROCEDURE [dbo].[SpGetExpenseCategory]
	@expenseCategoryId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [CategoryID],[Name],[FormulaType],[IsForOwner]
	FROM [dbo].[ExpenseCategory]
	WHERE [CategoryID] = @expenseCategoryId
END
