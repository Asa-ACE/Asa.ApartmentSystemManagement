using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways
{
    public interface IExpenseCategoryTableGateway
    {
        Task<int> InsertExpenseCategoryAsync(ExpenseCategoryDTO expenseCategory);
        Task<IEnumerable<ExpenseCategoryDTO>> GetExpenseCategoriesAsync();
        Task UpdateExpenseCategoryAsync(ExpenseCategoryDTO expenseCategory);
    }
}
