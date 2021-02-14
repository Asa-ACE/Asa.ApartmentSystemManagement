CREATE TABLE [dbo].[ExpanseCategory]
(
	[CategoryID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [FormulaType] TINYINT NOT NULL, 
    [IsForOwner] BIT NOT NULL
)
