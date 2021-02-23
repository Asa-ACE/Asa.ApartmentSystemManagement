CREATE PROCEDURE [dbo].[SpTenancyCreate]
	@unitId int,
	@personId int,
	@from date,
	@to date,
	@numberOfPeople tinyint
AS
	BEGIN
    SET NOCOUNT ON;
INSERT INTO [dbo].[Tenancy]
           ([UnitID]
           ,[PersonID]
           ,[From]
           ,[To]
           ,[NumberOfPeopel])
     VALUES
           (@unitId,
			@personId,
			@from,
			@to,
			@numberOfPeople)
select SCOPE_IDENTITY()
END
