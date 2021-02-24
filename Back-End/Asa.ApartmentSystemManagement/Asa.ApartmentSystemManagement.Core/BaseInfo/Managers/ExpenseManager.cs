using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
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
            IEnumerable<ChargeItemDTO> allChargeItems = null;
            foreach (ExpenseDTO expense in expenses)
            {
                bool isForOwner = await IsForOwner(expense);
                int formula = await GetFormula(expense);
                if (isForOwner)
                {
                    IEnumerable<OwnerPaymentDTO> allOwnerPayments = null;
                    foreach (UnitDTO unit in units)
                    {
                        IEnumerable<OwnerPaymentDTO> ownerPayments = await GetOwnerPayments(unit.Id,expense.From,expense.To);
                        allOwnerPayments.Union(ownerPayments);
                    }
                    IEnumerable<ChargeItemDTO> chargeItems = CalculateChargeItems(expense.Amount, allOwnerPayments,formula,units.Count());
                    allChargeItems.Union(chargeItems);
                }
            }
        }



        private IEnumerable<ChargeItemDTO> CalculateChargeItems(decimal amount, IEnumerable<OwnerPaymentDTO> allOwnerPayments,int formula,int numberOfUnits)
        {
            throw new Exception();
            switch (formula)
            {
                case 1:
                    CalculateOwnerPaymentByEqual(amount*numberOfUnits,allOwnerPayments);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }

        private void CalculateOwnerPaymentByEqual(decimal amount, IEnumerable<OwnerPaymentDTO> allOwnerPayments)
        {
            throw new NotImplementedException();
        }

        private async Task<int> GetFormula(ExpenseDTO expense)
        {
            var gateway = _gatewayFactory.CreateExpenseCategoryTableGateway();
            ExpenseCategoryDTO category = await gateway.GetExpenseCategoryById(expense.CategoryId);
            return category.FormulaType;
        }

        private async Task<IEnumerable<OwnerPaymentDTO>> GetOwnerPayments(int UnitId, DateTime from, DateTime to)
        {
            var gateway = _gatewayFactory.CreateOwnershipTableGateway();
            IEnumerable<OwnerPaymentDTO> ownerPayments = await gateway.GetOwnerPayments(UnitId,from,to);
            return ownerPayments;
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
