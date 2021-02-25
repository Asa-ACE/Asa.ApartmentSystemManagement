﻿CREATE PROCEDURE [dbo].[SpPersonGet]
@personId int

AS
BEGIN
	SELECT [PersonId], [FirstName], [LastName], [PhoneNumber], [UserName]
	FROM [dbo].[Person]
	WHERE [PersonID] = @personId
END