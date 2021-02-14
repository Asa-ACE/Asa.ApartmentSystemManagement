Create table [dbo].[Ownership]
(
	[OwnershipID] int identity(1,1) PRIMARY KEY NOT null,
	[UnitID] int NOT null,
	[PersonID] int NOT null,
	[From] date NOT null,
	[To] date, 
    CONSTRAINT [FK_Ownership_Unit] FOREIGN KEY ([UnitID]) REFERENCES [Unit]([UnitID]), 
    CONSTRAINT [FK_Ownership_Person] FOREIGN KEY ([PersonID]) REFERENCES [Person]([PersonID])
)
GO