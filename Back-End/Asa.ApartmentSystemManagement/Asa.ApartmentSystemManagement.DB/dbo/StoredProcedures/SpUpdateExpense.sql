CREATE PROCEDURE [dbo].[SpUpdateExpense]
	@expenseId int ,
	@buildingId int ,
	@categoryId int ,
	@from date ,
	@to date ,
	@amount decimal,
	@name nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[Expense]
	SET  [BuildingID] = @buildingId , [CategoryID] = @categoryId , [From] = @from , [To] = @to , [Amount] = @amount , [Name] = @name 
	WHERE [ExpenseID] = @expenseId
END
