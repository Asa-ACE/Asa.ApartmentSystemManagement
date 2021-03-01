CREATE PROCEDURE [dbo].[SpInsertChargeItem]
	@chargeId INT,
	@expenseId INT,
	@personId INT,
	@unitId INT,
	@amount DECIMAL(5,2)
AS
BEGIN
	INSERT INTO [dbo].[ChargeItem](
		[ChargeID],
		[ExpanseID],
		[PersonID],
		[UnitID],
		[Amount])
	VALUES(
		@chargeId,
		@expenseId,
		@personId,
		@unitId,
		@amount)
END
