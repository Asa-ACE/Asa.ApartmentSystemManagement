CREATE PROCEDURE [dbo].[person_update]
	@person_id int,
    @first_name nvarchar(20),
    @last_name nvarchar(20),
    @phone_number varchar(11),
    @user_name varchar(50),
    @password varchar(50)

AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Person]
	SET FirstName = @first_name, LastName = @last_name, PhoneNumber = @phone_number, UserName = @user_name, [Password] = @password
	WHERE
	PersonID = @person_id;
END
