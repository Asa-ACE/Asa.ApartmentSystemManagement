
using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.ChargeCalculation.Domain
{
    class BuildingCharge
    {
        ITableGatewayFactory _gatewayFactory;
        DateTime _from;
        DateTime _to;
        int _buildingId;
        List<Expense> _expenses;

        public BuildingCharge(ITableGatewayFactory gatewayFactory,DateTime from,DateTime to, int buildingId)
        {
            _gatewayFactory = gatewayFactory;
            _from = from;
            _to = to;
            _buildingId = buildingId;
        }



        public async Task GetExpenses()
        {
            var gateway = _gatewayFactory.CreateExpenseTableGateway();
            IEnumerable<ExpenseDTO> expensesDTO = await gateway.GetExpensesByBuildingIdAndDate(_from, _to, _buildingId);
            foreach (var expenseDTO in expensesDTO)
            {
                _expenses.Add(new Expense(expenseDTO));
            }
        }
    }
}
