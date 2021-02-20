CREATE TABLE [dbo].[Charge]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ExpanseID] INT NOT NULL, 
    [PersonID] INT NOT NULL, 
    [money] DECIMAL NOT NULL, 
    [Payment] DECIMAL NOT NULL
)
