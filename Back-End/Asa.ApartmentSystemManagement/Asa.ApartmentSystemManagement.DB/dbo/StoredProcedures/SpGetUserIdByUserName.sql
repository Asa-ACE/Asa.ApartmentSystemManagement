CREATE PROCEDURE [dbo].[SpGetUserIdByUserName]
@userName nvarchar(50)

AS
BEGIN
	SET NOCOUNT ON;
	SELECT PersonID 
	FROM [dbo].[Person] 
	WHERE [UserName] = @userName
END
