
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




    }
}
