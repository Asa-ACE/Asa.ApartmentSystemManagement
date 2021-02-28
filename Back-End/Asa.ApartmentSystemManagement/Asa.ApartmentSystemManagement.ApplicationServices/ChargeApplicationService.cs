using Asa.ApartmentSystemManagement.ApplicationServices.Model.Mapper;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Response;
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

        public ChargeApplicationService(ITableGatewayFactory tableGatewayFactory, ChargeManager chargeManager)
        {
            _tableGatewayFactory = tableGatewayFactory;
            _chargeManager = chargeManager;
        }

        public async Task<IEnumerable<ChargeResponse>> GetChargesAsync(int builidingId)
        {
            var charges = await _chargeManager.GetChargesAsync(builidingId);
            return charges.ToModel();
        }
    }
}
