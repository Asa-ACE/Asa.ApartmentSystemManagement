CREATE TABLE [dbo].[Expanse Category]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NVARCHAR(50) NOT NULL, 
    [formulaType] TINYINT NOT NULL, 
    [IsForOwner] BIT NOT NULL
)
