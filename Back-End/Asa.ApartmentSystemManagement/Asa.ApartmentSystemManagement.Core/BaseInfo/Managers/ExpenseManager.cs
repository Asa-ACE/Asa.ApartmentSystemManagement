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

        public async Task<ExpenseDTO> GetExpenseByIdAsync(int id)
        {
            var gateway = _gatewayFactory.CreateExpenseTableGateway();
            return await gateway.GetExpenseByIdAsync(id).ConfigureAwait(false); 

        }

        public async Task<IEnumerable<ExpenseDTO>> GetExpensesAsync(int buildingId)
        {
            var gateway = _gatewayFactory.CreateExpenseTableGateway();
            return await gateway.GetExpensesAsync(buildingId);
        }

        public async Task<IEnumerable<ExpenseDTO>> GetExpensesByBuildingIdAndDateAsync(DateTime from, DateTime to, int buildingId)
        {
            var gateway = _gatewayFactory.CreateExpenseTableGateway();
            return await gateway.GetExpensesByBuildingIdAndDateAsync(from, to, buildingId).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ExpenseCategoryDTO>> GetExpenseCategoriesAsync()
        {
            var gateway = _gatewayFactory.CreateExpenseCategoryTableGateway();
            var expenseCategories = await gateway.GetExpenseCategoriesAsync();
            return expenseCategories;
        }
    }
}
