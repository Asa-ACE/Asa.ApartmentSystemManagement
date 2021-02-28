using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.ChargeCalculation.Managers
{
    public class ChargeManager
    {
        ITableGatewayFactory _gatewayFactory;

        public ChargeManager(ITableGatewayFactory gatewayFactory)
        {
            _gatewayFactory = gatewayFactory;
        }



        public async Task CreateCharge(DateTime from, DateTime to, int buildingId)
        {
            IEnumerable<UnitDTO> units = await GetUnitsByBuilding(buildingId);
            IEnumerable<ExpenseDTO> expenses = await GetExpenses(from, to, buildingId);
            IEnumerable<ChargeItemDTO> allChargeItems = null;
            foreach (ExpenseDTO expense in expenses)
            {
                bool isForOwner = await IsForOwner(expense);
                int formula = await GetFormula(expense);
                if (isForOwner)
                {
                    IEnumerable<ShareInfo> allPayments = null;
                    foreach (UnitDTO unit in units)
                    {
                        IEnumerable<ShareInfo> Payments = await GetOwnerPayments(unit.Id, expense.From, expense.To);
                        allPayments.Union(Payments);
                    }
                    IEnumerable<ChargeItemDTO> chargeItems = CalculateChargeItems(expense.Amount, allPayments, formula, units.Count());
                    allChargeItems.Union(chargeItems);
                }
            }
        }



        private IEnumerable<ChargeItemDTO> CalculateChargeItems(decimal amount, IEnumerable<ShareInfo> allOwnerPayments, int formula, int numberOfUnits)
        {
            throw new Exception();

        }



        private async Task<int> GetFormula(ExpenseDTO expense)
        {
            var gateway = _gatewayFactory.CreateExpenseCategoryTableGateway();
            ExpenseCategoryResponse category = await gateway.GetExpenseCategoryById(expense.CategoryId);
            return category.FormulaType;
        }

        private async Task<IEnumerable<ShareInfo>> GetOwnerPayments(int UnitId, DateTime from, DateTime to)
        {
            var gateway = _gatewayFactory.CreateOwnershipTableGateway();
            IEnumerable<ShareInfo> ownerPayments = await gateway.GetOwnerPayments(UnitId, from, to);
            return ownerPayments;
        }

        private async Task<bool> IsForOwner(ExpenseDTO expense)
        {
            var gateway = _gatewayFactory.CreateExpenseCategoryTableGateway();
            ExpenseCategoryResponse category = await gateway.GetExpenseCategoryById(expense.CategoryId);
            return category.IsForOwner;
        }

        private async Task<IEnumerable<ExpenseDTO>> GetExpenses(DateTime from, DateTime to, int buildingId)
        {
            var gateway = _gatewayFactory.CreateExpenseTableGateway();
            IEnumerable<ExpenseDTO> expenses = await gateway.GetExpensesByBuildingIdAndDate(from, to, buildingId);
            return expenses;
        }

        private async Task<IEnumerable<UnitDTO>> GetUnitsByBuilding(int buildingId)
        {
            var gateway = _gatewayFactory.CreateUnitTableGateway();
            IEnumerable<UnitDTO> units = await gateway.GetUnitByBuildingId(buildingId);
            return units;
        }
    }
}
