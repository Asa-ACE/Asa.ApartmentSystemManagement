CREATE TABLE [dbo].[Person]
(
	[PersonID] int identity(1,1) PRIMARY KEY not null,
	[FristName] nvarchar(20) not null,
	[LastName] nvarchar(20) not null,
	[PhoneNumber] varchar(11) UNIQUE not null, 
    [UserName] VARCHAR(50) UNIQUE NOT NULL, 
    [Password] VARCHAR(50) UNIQUE NOT NULL
)
GO
