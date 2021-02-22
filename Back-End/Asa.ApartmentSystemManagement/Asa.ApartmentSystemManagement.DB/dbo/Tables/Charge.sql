CREATE TABLE [dbo].[Charge]
(
	[ChargeID] INT NOT NULL PRIMARY KEY, 
    [From] DATE NOT NULL, 
    [To] DATE NOT NULL, 
    [UnitID] INT NOT NULL, 
    [Amount] INT NOT NULL, 
    [PersonID] INT NOT NULL, 
    CONSTRAINT [FK_Charge_Unit] FOREIGN KEY ([UnitID]) REFERENCES [Unit]([UnitID]), 
    CONSTRAINT [FK_Charge_Person] FOREIGN KEY ([PersonID]) REFERENCES [Person]([PersonID])
)
