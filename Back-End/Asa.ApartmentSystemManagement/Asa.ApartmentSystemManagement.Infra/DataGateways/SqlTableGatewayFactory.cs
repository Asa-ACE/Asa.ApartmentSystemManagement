
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

        public IBuildingTableGateway CreateBuildingTableGateway()
        {
            throw new NotImplementedException();
        }

        public IOwnershipTableGateway CreateOwnershipTableGateway()
        {
            throw new NotImplementedException();
        }

        public IUnitTableGateway CreateUnitTableGateway()
        {
            throw new NotImplementedException();
        }
    }
}