CREATE PROCEDURE [dbo].[SpGetUserIdByUserName]
	@username varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [PersonID]
	FROM [dbo].[Person]
	WHERE [UserName] = @username
END
