
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Request;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using Asa.ApartmentSystemManagement.Core.ChargeCalculation.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.ApplicationServices
{
    public class ChargeApplicationService
    {
        ITableGatewayFactory _tableGatewayFactory;
        ChargeManager _chargeManager;
        public async Task<int> CreateChargeAsync(CreateChargeRequest charge)
		{
            var gateway = _tableGatewayFactory.CreateChargeTableGateway();

		}
    }
}
