CREATE PROCEDURE [dbo].[SpBuildingCreate]
@name nvarchar(50),
@numberOfUnits int,
@address nvarchar(200)

AS
BEGIN

INSERT INTO [dbo].[Building]
           ([Name]
           ,[NumberOfUnits]
           ,[Address])
     VALUES
           (@name
           ,@numberOfUnits
           ,@address)
select SCOPE_IDENTITY()
END