CREATE PROCEDURE [dbo].[SpExpenseCreate]
@buildingId int,
@categoryId int,
@from date,
@to date,
@amount decimal(10,2),
@name nvarchar(50)

AS
BEGIN
SET NOCOUNT ON;
INSERT INTO [dbo].[Expense]
           ([BuildingID]
           ,[CategoryID]
           ,[From]
           ,[To]
           ,[Amount]
           ,[Name])
     VALUES
           (@buildingId
           ,@categoryId
           ,@from
           ,@to
           ,@amount
           ,@name)
select SCOPE_IDENTITY()
END
