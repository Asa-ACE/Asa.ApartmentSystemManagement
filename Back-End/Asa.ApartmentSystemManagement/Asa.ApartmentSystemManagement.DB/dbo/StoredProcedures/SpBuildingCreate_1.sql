CREATE PROCEDURE [dbo].[SpBuildingCreate]
@name nvarchar(50),
@numberOfUnits int

AS
BEGIN

INSERT INTO [dbo].[Building]
           ([Name]
           ,[NumberOfUnits])
     VALUES
           (@name
           ,@numberOfUnits)
select SCOPE_IDENTITY()
END