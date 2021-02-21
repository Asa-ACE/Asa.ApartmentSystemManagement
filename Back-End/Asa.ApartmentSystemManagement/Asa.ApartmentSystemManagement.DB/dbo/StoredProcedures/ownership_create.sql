CREATE PROCEDURE [dbo].[ownership_create]
    @unit_id int,
    @person_id int,
    @from date,
    @to date

AS
BEGIN

INSERT INTO [dbo].[Ownership]
           ([UnitID]
           ,[PersonID]
           ,[From]
           ,[To])
     VALUES
           (@unit_id
           ,@person_id
           ,@from
           ,@to)
select SCOPE_IDENTITY()
END
