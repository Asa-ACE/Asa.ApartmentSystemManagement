Create table [Ownership]
(
	OwnershipID int identity(1,1) PRIMARY KEY not null,
	UnitID int not null,
	PersonID int not null,
	[From] date UNIQUE not null,
	[to] date UNIQUE
)
GO