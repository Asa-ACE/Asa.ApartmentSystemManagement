Create table [dbo].[Unit] 
(
	[UnitID] int identity(1,1) PRIMARY KEY not null,
	[BuildingID] int not null,
	[Area] decimal not null,
	[Number] smallint not null,
	[Description] nvarchar(250), 
    CONSTRAINT [FK_Unit_Building] FOREIGN KEY ([BuildingID]) REFERENCES [Building]([BuildingID])
)
GO