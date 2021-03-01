CREATE PROCEDURE [dbo].[SpGetAllExpenseCategories]
AS
BEGIN
SET NOCOUNT ON
	SELECT [CategoryID], [FormulaType], [IsForOwner], [Name]
	FROM [dbo].[ExpenseCategory]
END
