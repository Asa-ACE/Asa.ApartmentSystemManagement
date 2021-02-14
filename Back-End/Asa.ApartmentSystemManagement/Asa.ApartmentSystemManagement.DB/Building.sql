Create table [dbo].[Building] 
(
	BuildinID int identity(1,1) PRIMARY KEY NOT null,
	Name nvarchar(50) NOT null,
	NumberOfUnits SMALLINT NOT null
)
GO
