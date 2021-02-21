CREATE PROCEDURE [dbo].[ownership_update]
	@ownership_id int,
    @unit_id int,
    @person_id int,
    @from date,
    @to date
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Ownership]
	SET UnitID = @unit_id, PersonID = @person_id, [From] = @from, [To] = @to
	WHERE
	OwnershipID = @ownership_id
END
