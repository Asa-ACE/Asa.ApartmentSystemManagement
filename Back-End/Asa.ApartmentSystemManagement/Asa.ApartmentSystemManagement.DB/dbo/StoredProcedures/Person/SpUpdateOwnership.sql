CREATE PROCEDURE [dbo].[SpUpdateOwnership]
	@oldFrom date,
    @unitId int,
    @username varchar(50),
    @from date,
    @to date 
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Ownership]
	SET UnitID = @unitId,  PersonID = (SELECT PersonID FROM Person WHERE UserName = @username), [From] = @from, [To] = @to
	WHERE [From] = @oldFrom AND [UnitID] = @unitId
END
