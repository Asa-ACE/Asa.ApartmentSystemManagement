CREATE PROCEDURE [dbo].[SpPersonUpdate]
	@personId int,
    @firstName nvarchar(20),
    @lastName nvarchar(20),
    @phoneNumber char(11),
    @userName varchar(50),
    @password varchar(50)

AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Person]
	SET FirstName = @firstName, LastName = @lastName, PhoneNumber = @phoneNumber, UserName = @userName, [Password] = @password
	WHERE
	PersonID = @personId;
END
