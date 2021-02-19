CREATE PROCEDURE [dbo].[building_create]
@name nvarchar(50),
@number_of_units int

AS
BEGIN

INSERT INTO [dbo].[Building]
           ([Name]
           ,[NumberOfUnits])
     VALUES
           (@name
           ,@number_of_units)
select SCOPE_IDENTITY()
END