CREATE TABLE [dbo].[Building] 
(
	[BuildingID] int IDENTITY PRIMARY KEY NOT null,
	[Name] nvarchar(50) NOT null,
	[NumberOfUnits] SMALLINT NOT null, 
    [Address] NVARCHAR(200) NOT NULL UNIQUE
)
GO
