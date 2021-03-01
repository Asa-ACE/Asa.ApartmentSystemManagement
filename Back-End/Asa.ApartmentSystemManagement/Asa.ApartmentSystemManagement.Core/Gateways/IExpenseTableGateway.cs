using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways
{
    public interface IExpenseTableGateway
    {
        Task<int> InsertExpenseAsync(ExpenseDTO expense);
        Task<ExpenseDTO> GetExpenseByIdAsync(int id);
        Task<IEnumerable<CalculationDTO>> GetCalculationInfosByChargeIdAsync(int chargeId);
        Task<IEnumerable<ExpenseDTO>> GetExpensesAsync(int buildingId);
        Task UpdateExpenseAsync(ExpenseDTO expense);
        Task DeleteExpenseAsync(int expenseId);
    }
}
