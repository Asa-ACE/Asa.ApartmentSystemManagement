CREATE PROCEDURE [dbo].[person_create]
@first_name nvarchar(20),
@last_name nvarchar(20),
@phone_number varchar(11)

AS
BEGIN

INSERT INTO [dbo].[Person]
           ([FristName]
           ,[LastName]
           ,[PhoneNumber])
     VALUES
           (@first_name
           ,@last_name
           ,@phone_number)
select SCOPE_IDENTITY()
END
