CREATE TABLE [dbo].[ChargeItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ExpanseID] INT NOT NULL, 
    [PersonID] INT NOT NULL, 
    [Amount] DECIMAL NOT NULL, 
    [ChargeID] INT NOT NULL, 
    CONSTRAINT [FK_Charge_Person] FOREIGN KEY ([PersonID]) REFERENCES [Person]([PersonID]), 
    CONSTRAINT [FK_Charge_Expanse] FOREIGN KEY ([ExpanseID]) REFERENCES [Expanse]([ExpanseID]), 
    CONSTRAINT [FK_ChargeItem_Charge] FOREIGN KEY ([ChargeID]) REFERENCES [Charge]([Id])
)
