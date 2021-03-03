CREATE PROCEDURE [dbo].[SpUpdateOwnership]
	@oldFrom date,
    @unitId int,
    @personId int,
    @from date,
    @to date 
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Ownership]
	SET UnitID = @unitId, PersonID = @personId, [From] = @from, [To] = @to
	WHERE [From] = @oldFrom AND [UnitID] = @unitId
END
