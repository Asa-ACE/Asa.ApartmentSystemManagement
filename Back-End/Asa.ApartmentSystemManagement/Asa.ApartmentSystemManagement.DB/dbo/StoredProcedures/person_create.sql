CREATE PROCEDURE [dbo].[person_create]
    @first_name nvarchar(20),
    @last_name nvarchar(20),
    @phone_number varchar(11),
    @user_name varchar(50),
    @password varchar(50)

AS
BEGIN
INSERT INTO [dbo].[Person]
           ([FirstName]
           ,[LastName]
           ,[PhoneNumber]
           ,[UserName]
           ,[Password])
     VALUES
           (@first_name
           ,@last_name
           ,@phone_number
           ,@user_name
           ,@password)
select SCOPE_IDENTITY()
END
