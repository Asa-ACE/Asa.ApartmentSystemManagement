CREATE TABLE [dbo].[Admin]
(
	[AdminID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PersonID] INT NOT NULL, 
    [BuildingID] INT NOT NULL, 
    CONSTRAINT [FK_Admin_Person] FOREIGN KEY ([PersonID]) REFERENCES [Person]([PersonID]), 
    CONSTRAINT [FK_Admin_Building] FOREIGN KEY ([BuildingID]) REFERENCES [Building]([BuildingID])
)
