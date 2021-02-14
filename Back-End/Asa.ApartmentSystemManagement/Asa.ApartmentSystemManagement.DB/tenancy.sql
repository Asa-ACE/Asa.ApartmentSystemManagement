﻿Create table [dbo].[Tenancy]
(
	[TenancyID] int identity(1,1) PRIMARY KEY not null,
	[UnitID] int not null,
	[PersonID] int not null,
	[From] date UNIQUE not null,
	[To] date UNIQUE,
	[NumberOfPeopel] tinyint not null, 
    CONSTRAINT [FK_Tenancy_Unit] FOREIGN KEY ([UnitID]) REFERENCES [Unit]([UnitID]),
    CONSTRAINT [FK_Tenancy_Person] FOREIGN KEY ([PersonID]) REFERENCES [Person]([PersonID])
)
GO