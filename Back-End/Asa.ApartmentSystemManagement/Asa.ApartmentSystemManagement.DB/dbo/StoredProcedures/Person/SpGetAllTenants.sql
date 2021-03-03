CREATE PROCEDURE [dbo].[SpGetAllTenants]
	@unitId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Person].[PersonID], [FirstName], [LastName], [PhoneNumber], [UserName]
	FROM [Person]
	INNER JOIN [Tenancy] ON [Tenancy].[PersonID] = [Person].[PersonID]
	WHERE [UnitID] = @unitId
END
