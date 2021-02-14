CREATE TABLE [dbo].[Expanse]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [buildingID] INT NOT NULL, 
    [CategoryID] INT NOT NULL, 
    [From] DATE NOT NULL, 
    [To] DATE NOT NULL, 
    [money] DECIMAL NOT NULL, 
    [name] NVARCHAR(50) NOT NULL
)
