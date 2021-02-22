CREATE PROCEDURE [dbo].[SpPersonCreate]
    @firstName nvarchar(20),
    @lastName nvarchar(20),
    @phoneNumber char(11),
    @userName varchar(50),
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
           (@firstName,
            @lastName,
            @phoneNumber,
            @userName,
            @password)
select SCOPE_IDENTITY()
END
