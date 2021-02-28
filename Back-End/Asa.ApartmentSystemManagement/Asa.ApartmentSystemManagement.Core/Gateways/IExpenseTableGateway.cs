using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
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
        Task<IEnumerable<ExpenseDTO>> GetExpensesByChargeIdAsync(int chargeId);
        Task<IEnumerable<ExpenseDTO>> GetExpensesByBuildingIdAndDate(DateTime from, DateTime to, int buildingId);
        Task<IEnumerable<ExpenseDTO>> GetExpensesAsync(int buildingId);
    }
}
