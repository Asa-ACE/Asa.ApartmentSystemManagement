CREATE PROCEDURE [dbo].[SpPersonGet]
@personId int

AS
BEGIN
	SET NOCOUNT ON;
	SELECT [PersonID], [FirstName], [LastName], [PhoneNumber], [UserName]
	FROM [dbo].[Person]
	WHERE [PersonId] = @personId
END
