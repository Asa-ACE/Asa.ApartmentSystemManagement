CREATE PROCEDURE [dbo].[SpGetExpenses]
	@buildingId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [ExpenseID], [CategoryID], [From], [To], [Amount], [Name]
	FROM [dbo].[Expense]
	WHERE [BuildingID] = @buildingId
END