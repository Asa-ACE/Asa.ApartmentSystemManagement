CREATE PROCEDURE [dbo].[SpExpenseGetByDate]
	@buildingId int,
	@from date,
	@to date

AS
BEGIN
	SET NOCOUNT ON;
	SELECT [ExpenseID],[BuildingID],[CategoryID],[From],[To],[Amount],[Name]
	FROM [dbo].[Expense]
	WHERE [BuildingId] = @buildingId and [To] >= @from and [To]<@to
END