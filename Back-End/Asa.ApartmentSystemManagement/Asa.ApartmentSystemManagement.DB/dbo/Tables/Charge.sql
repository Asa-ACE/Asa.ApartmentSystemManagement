CREATE TABLE [dbo].[Charge]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ExpanseID] INT NOT NULL, 
    [PersonID] INT NOT NULL, 
    [money] DECIMAL NOT NULL, 
    [Payment] DECIMAL NOT NULL, 
    CONSTRAINT [FK_Charge_Person] FOREIGN KEY ([PersonID]) REFERENCES [Person]([PersonID]), 
    CONSTRAINT [FK_Charge_Expanse] FOREIGN KEY ([ExpanseID]) REFERENCES [Expanse]([ExpanseID])
)
