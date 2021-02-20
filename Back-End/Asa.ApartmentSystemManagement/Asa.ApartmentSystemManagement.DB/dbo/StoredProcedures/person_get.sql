CREATE PROCEDURE [dbo].[person_get]
@person_id int

AS
BEGIN
	SELECT [PersonId], [FirstName], [LastName], [PhoneNumber], [UserName]
	FROM [dbo].[Person]
	WHERE [PersonID] = @person_id
END
