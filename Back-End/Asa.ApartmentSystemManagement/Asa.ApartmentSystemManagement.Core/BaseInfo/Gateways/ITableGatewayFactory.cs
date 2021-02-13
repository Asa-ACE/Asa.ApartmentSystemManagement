using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentSystemManagement.Core.Gateways
{
    public interface ITableGatewayFactory
    {
        IBuildingTableGateway CreateBuildingTableGateway();
        IUnitTableGateway CreateUnitTableGateway();
    }
}
