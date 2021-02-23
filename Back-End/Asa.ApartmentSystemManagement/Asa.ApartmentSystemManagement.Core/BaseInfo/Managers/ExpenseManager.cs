using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.Managers
{
    public class ExpenseManager
    {
        ITableGatewayFactory _gatewayFactory;

        public ExpenseManager(ITableGatewayFactory gatewayFactory)
        {
            _gatewayFactory = gatewayFactory;
        }

        public async Task AddExpense(ExpenseDTO expense)
        {
            ValidateExpense(expense);
            var gateway = _gatewayFactory.CreateExpenseTableGateway();
            var id = await gateway.InsertExpenseAsync(expense);
            expense.ExpenseId = id;
        }

        private void ValidateExpense(ExpenseDTO expense)
        {
            if (expense.To < expense.From)
            {
                throw new ArgumentOutOfRangeException("Starting date cannot be less than Finish date.");
            }
        }
        public async Task CreateCharge(DateTime from, DateTime to, int buildingId)
        {
            IEnumerable<UnitDTO> units = await GetUnitsByBuilding(buildingId);
            IEnumerable<ExpenseDTO> expenses = await GetExpenses(from, to, buildingId);
            foreach (ExpenseDTO expense in expenses)
            {
                bool isForOwner = await IsForOwner(expense);
            }
        }

        private async Task<bool> IsForOwner(ExpenseDTO expense)
        {
            var gateway = _gatewayFactory.CreateExpenseCategoryTableGateway();
            ExpenseCategoryDTO category = await gateway.GetExpenseCategoryById(expense.CategoryId);
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
