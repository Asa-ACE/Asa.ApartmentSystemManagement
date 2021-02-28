CREATE PROCEDURE [dbo].[SpGetOwnersCalculationInfo]
	@chargeId INT
AS
BEGIN
	SELECT	e.ExpenseID,
			e.Amount,
			ec.FormulaType [FormulaType],
			DATEDIFF(DAY, o.[To], o.[From]) [Days],
			u.Area [Area], 
			o.PersonID [PersonId],
			u.UnitID [UnitId], 
			u.BuildingID [BuildingId], 
			0  [NumberOfPeople]
	FROM [Charge] AS c
	INNER JOIN [Expense] AS e ON e.BuildingID = c.BuildingID AND e.[To] >= c.[From] AND e.[To] <= c.[To]
	INNER JOIN [ExpenseCategory] AS ec ON ec.CategoryID = e.CategoryID
	INNER JOIN  [Unit] AS u ON u.BuildingID = e.BuildingID
	INNER JOIN [Ownership] AS o ON u.UnitID = o.UnitID AND NOT(o.[From] > c.[To] OR o.[To] < c.[From])
	ORDER BY e.ExpenseID
END
