CREATE PROCEDURE [dbo].[SpUpdateExpenseCategory]
	@categoryId int ,
	@name nvarchar(50),
	@formulaType nvarchar(20),
	@isForOwner bit
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[ExpenseCategory]
	SET [Name] = @name , [FormulaType] = @formulaType , [IsForOwner] = @isForOwner
	WHERE CategoryID = @categoryId
END
