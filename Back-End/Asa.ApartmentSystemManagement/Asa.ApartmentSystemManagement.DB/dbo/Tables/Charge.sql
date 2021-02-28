CREATE TABLE [dbo].[Charge]
(
	[ChargeID] INT NOT NULL PRIMARY KEY, 
    [From] DATE NOT NULL, 
    [To] DATE NOT NULL, 
    [BuildingID] INT NOT NULL,  
    CONSTRAINT [FK_Charge_Unit] FOREIGN KEY ([BuildingID]) REFERENCES [Building]([BuildingID]), 
)
