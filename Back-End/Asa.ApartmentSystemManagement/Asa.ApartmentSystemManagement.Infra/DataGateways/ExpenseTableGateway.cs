using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Infra.DataGateways
{
    public class ExpenseTableGateway : IExpenseTableGateway
    {
        private string connectionString;

        public ExpenseTableGateway(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Task<ExpenseDTO> GetExpenseById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExpenseDTO>> GetExpensesByBuildingIdAndDate(DateTime from, DateTime to, int buildingId)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertExpenseAsync(ExpenseDTO expense)
        {
            throw new NotImplementedException();
        }
    }
}
