CREATE TABLE [dbo].[Expanse]
(
	[ExpanseID] INT NOT NULL PRIMARY KEY, 
    [BuildingID] INT NOT NULL, 
    [CategoryID] INT NOT NULL, 
    [From] DATE NOT NULL, 
    [To] DATE NOT NULL, 
    [Amount] DECIMAL NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Expanse_Category] FOREIGN KEY ([CategoryID]) REFERENCES [ExpanseCategory]([CategoryID]), 
    CONSTRAINT [FK_Expanse_Building] FOREIGN KEY ([BuildingID]) REFERENCES [Building]([BuildingID])
)
