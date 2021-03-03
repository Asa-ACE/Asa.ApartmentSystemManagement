CREATE PROCEDURE [dbo].[SpGetAllOwners]
	@unitId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Person].[PersonID], [FirstName], [LastName], [PhoneNumber], [UserName]
	FROM [Person]
	INNER JOIN [Ownership] ON [Ownership].[PersonID] = [Person].[PersonID]
	WHERE [UnitID] = @unitId
END

