CREATE PROCEDURE [dbo].[SpAdminCreate]
	@userId int,
	@buildingId int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Admin]
				([BuildingID],
				 [PersonID])
			VALUES
				(@buildingId,
				 @userId)
	SELECT SCOPE_IDENTITY()
END

