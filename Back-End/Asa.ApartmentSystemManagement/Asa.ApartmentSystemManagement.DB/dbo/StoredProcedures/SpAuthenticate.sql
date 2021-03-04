CREATE PROCEDURE [dbo].[SpAuthenticate]
	@username nvarchar(50),
	@password nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [PersonID], [FirstName], [LastName], [UserName], [Password],[PhoneNumber]
	FROM [dbo].[Person]
	WHERE [UserName] = @username AND [Password] = @password
END
