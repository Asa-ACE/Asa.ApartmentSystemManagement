CREATE PROCEDURE [dbo].[SpUpdateTenancy]
	@oldFrom date,
	@unitId int,
	@username varchar(50),
	@from date,
	@to date,
	@numberOfPeople tinyint
AS
	BEGIN
    SET NOCOUNT ON;
	Update [dbo].[Tenancy]
	SET UnitID = @unitId, PersonID = (SELECT PersonID FROM Person WHERE UserName = @username), [From] = @from, [To] = @to, NumberOfPeopel = @numberOfPeople
	WHERE [From]=@oldFrom AND [UnitID] = @unitId
END
