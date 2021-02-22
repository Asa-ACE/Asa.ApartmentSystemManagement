CREATE TABLE [dbo].[ExpanseCategory]
(
	[CategoryID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL UNIQUE, 
    [FormulaType] TINYINT NOT NULL, --there are just 5 FormulaType
    [IsForOwner] BIT NOT NULL
)
