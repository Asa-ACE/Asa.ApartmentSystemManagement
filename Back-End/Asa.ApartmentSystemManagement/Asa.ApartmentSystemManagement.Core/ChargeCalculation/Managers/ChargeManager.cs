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



        public async Task<int> InsertChargeAsync(ChargeDTO charge)
        {

            
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
