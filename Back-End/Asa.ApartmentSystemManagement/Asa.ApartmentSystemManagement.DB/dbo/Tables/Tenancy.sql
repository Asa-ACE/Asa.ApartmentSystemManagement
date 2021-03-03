CREATE TABLE [dbo].[Tenancy]
(
	[TenancyID] int identity(1,1) PRIMARY KEY not null,
	[UnitID] int not null,
	[PersonID] int not null,
	[From] date UNIQUE not null,
	[To] date UNIQUE,
	[NumberOfPeopel] tinyint not null, --NumberOfPeopel cant br greater than 256
    CONSTRAINT [FK_Tenancy_Unit] FOREIGN KEY ([UnitID]) REFERENCES [Unit]([UnitID]),
    CONSTRAINT [FK_Tenancy_Person] FOREIGN KEY ([PersonID]) REFERENCES [Person]([PersonID]),
	CONSTRAINT [UQ_Tenancy1] UNIQUE([From], [UnitID]),
	CONSTRAINT [UQ_Tenancy2] UNIQUE([To], [UnitID])

)
GO