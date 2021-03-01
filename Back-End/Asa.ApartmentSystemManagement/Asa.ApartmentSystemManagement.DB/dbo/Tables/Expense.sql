CREATE TABLE [dbo].[Expense]
(
	[ExpenseID] INT NOT NULL PRIMARY KEY, 
    [BuildingID] INT NOT NULL, 
    [CategoryID] INT NOT NULL, 
    [From] DATE NOT NULL, 
    [To] DATE NOT NULL, 
    [Amount] DECIMAL(10,2) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Expense_Category] FOREIGN KEY ([CategoryID]) REFERENCES [ExpenseCategory]([CategoryID]), 
    CONSTRAINT [FK_Expense_Building] FOREIGN KEY ([BuildingID]) REFERENCES [Building]([BuildingID])
)