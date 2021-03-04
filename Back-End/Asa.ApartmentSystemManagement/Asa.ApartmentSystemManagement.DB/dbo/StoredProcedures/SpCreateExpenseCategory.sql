CREATE PROCEDURE [dbo].[SpCreateExpenseCategory]
	@name nvarchar(50),
	@formulaType nvarchar(100),
	@isForOwner bit
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[ExpenseCategory]
				([Name],
				[FormulaType],
				[IsForOwner])
			VALUES
				(@name,
				@formulaType,
				@isForOwner)
	SELECT SCOPE_IDENTITY()
END

