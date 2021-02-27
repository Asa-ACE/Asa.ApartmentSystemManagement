CREATE PROCEDURE [dbo].[SpOwnershipCreate]
    @unitId int,
    @personId int,
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
            (@unitId,
            @personId,
            @from,
            @to)
select SCOPE_IDENTITY()
END
