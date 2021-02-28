CREATE TABLE [dbo].[ExpenseCategory]
(
	[CategoryID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL UNIQUE, 
    [FormulaType] NVARCHAR(20) NOT NULL, --there are just 5 FormulaType
    [IsForOwner] BIT NOT NULL
)