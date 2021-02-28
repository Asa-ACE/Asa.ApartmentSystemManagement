using Asa.ApartmentSystemManagement.Core.Gateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways
{
    public interface ITableGatewayFactory
    {
        IBuildingTableGateway CreateBuildingTableGateway();
        IUnitTableGateway CreateUnitTableGateway();
        IOwnershipTableGateway CreateOwnershipTableGateway();
        IPersonTableGateway CreatePersonTableGateway();
        IExpenseTableGateway CreateExpenseTableGateway();
        ITenancyTableGateway CreateTenancyTableGateway();
        IExpenseCategoryTableGateway CreateExpenseCategoryTableGateway();
        IChargeTableGateway CreateChargeTableGateway();
    }
}