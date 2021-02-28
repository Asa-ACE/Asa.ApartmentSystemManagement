CREATE PROCEDURE [dbo].[SpPersonGet]
@personId int

AS
BEGIN
	SET NOCOUNT ON;
	SELECT [PersonId], [FirstName], [LastName], [PhoneNumber], [UserName]
	FROM [dbo].[Person]
	WHERE [PersonId] = @personId
END
