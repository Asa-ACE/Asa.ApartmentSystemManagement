CREATE TABLE [dbo].[ChargeItem]
(
	[ChargeItemID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ExpanseID] INT NOT NULL, 
    [PersonID] INT NOT NULL, 
    [ChargeID] INT NOT NULL,
    [Amount] DECIMAL(5, 2) NOT NULL, 
    [UnitID] INT NOT NULL, 
    CONSTRAINT [FK_ChargeItem_Person] FOREIGN KEY ([PersonID]) REFERENCES [Person]([PersonID]), 
    CONSTRAINT [FK_ChargeItem_Expanse] FOREIGN KEY ([ExpanseID]) REFERENCES [Expense]([ExpenseID]), 
    CONSTRAINT [FK_ChargeItem_Unit] FOREIGN KEY ([UnitID]) REFERENCES [Unit]([UnitID]),
    CONSTRAINT [FK_ChargeItem_Charge] FOREIGN KEY ([ChargeID]) REFERENCES [Charge]([ChargeID])
)
