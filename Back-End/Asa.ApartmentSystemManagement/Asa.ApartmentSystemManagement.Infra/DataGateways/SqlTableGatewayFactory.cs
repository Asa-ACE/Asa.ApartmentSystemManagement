
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
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

        public IBuildingTableGateway CreateBuildingTableGateway() => new BuildingTableGateway(_connectionString);


        public IExpenseTableGateway CreateExpenseTableGateway() => new ExpenseTableGateway(_connectionString);


        public IOwnershipTableGateway CreateOwnershipTableGateway() => new OwnershipTableGateway(_connectionString);


        public IPersonTableGateway CreatePersonTableGateway() => new PersonTableGateway(_connectionString);


        public ITenancyTableGateway CreateTenancyTableGateway() => new TenancyTableGateway(_connectionString);


        public IUnitTableGateway CreateUnitTableGateway() => new UnitTableGateway(_connectionString);

    }
}