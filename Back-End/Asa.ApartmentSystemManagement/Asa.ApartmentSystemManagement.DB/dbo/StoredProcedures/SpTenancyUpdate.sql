﻿CREATE PROCEDURE [dbo].[SpTenancyUpdate]
	@tenancyId int,
	@unitId int,
	@personId int,
	@from date,
	@to date,
	@numberOfPeople tinyint
AS
	BEGIN
    SET NOCOUNT ON;
	Update [dbo].[Tenancy]
	SET UnitID = @unitId, PersonID = @personId, [From] = @from, [To] = @to, NumberOfPeopel = @numberOfPeople
	WHERE TenancyID = @tenancyId
select SCOPE_IDENTITY()
END
