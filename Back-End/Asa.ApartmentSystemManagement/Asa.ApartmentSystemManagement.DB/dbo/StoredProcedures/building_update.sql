CREATE PROCEDURE [dbo].[building_update]
	@building_id int,
	@name nvarchar(50),
	@number_of_units smallint
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Building]
	SET [Name] = @name, NumberOfUnits = @number_of_units
	WHERE
	BuildingID = @building_id
END

