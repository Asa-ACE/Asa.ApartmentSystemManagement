
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using Asa.ApartmentSystemManagement.Core.Gateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Infra.DataGateways
{
    public class SqlTableGatewayFactory : ITableGatewayFactory
    {
        string _connectionString;

        public SqlTableGatewayFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IAdminTableGateway CreateAdminTableGateway() => new AdminTableGateway(_connectionString);

        public IBuildingTableGateway CreateBuildingTableGateway() => new BuildingTableGateway(_connectionString);

        public IChargeItemTableGateway CreateChargeItemTableGateway() => new ChargeItemTableGateway(_connectionString);


        public IChargeTableGateway CreateChargeTableGateway() => new ChargeTableGateway(_connectionString);


        public IExpenseCategoryTableGateway CreateExpenseCategoryTableGateway() => new ExpenseCategoryTableGateway(_connectionString);


        public IExpenseTableGateway CreateExpenseTableGateway() => new ExpenseTableGateway(_connectionString);


        public IOwnershipTableGateway CreateOwnershipTableGateway() => new OwnershipTableGateway(_connectionString);


        public IPersonTableGateway CreatePersonTableGateway() => new PersonTableGateway(_connectionString);


        public ITenancyTableGateway CreateTenancyTableGateway() => new TenancyTableGateway(_connectionString);


        public IUnitTableGateway CreateUnitTableGateway() => new UnitTableGateway(_connectionString);


    }
}