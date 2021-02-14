Create table dbo.Unit 
(
UnitID int identity(1,1) PRIMARY KEY not null,
BuildinID int not null,
area decimal not null,
Number smallint not null,
[Description] nvarchar(250)
)
GO