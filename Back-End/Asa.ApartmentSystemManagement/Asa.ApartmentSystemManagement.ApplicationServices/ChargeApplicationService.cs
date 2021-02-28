﻿
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Mapper;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Request;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Response;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using Asa.ApartmentSystemManagement.Core.ChargeCalculation.Managers;
using Asa.ApartmentSystemManagement.Infra.DataGateways;
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

		public ChargeApplicationService(string connectionString)
		{
            _tableGatewayFactory = new SqlTableGatewayFactory(connectionString);
            _chargeManager = new ChargeManager(_tableGatewayFactory);
		}

        public async Task<int> CreateChargeAsync(CreateChargeRequest chargeRequest)
		{
            var charge = chargeRequest.ToDTO();
            await _chargeManager.InsertChargeAsync(charge).ConfigureAwait(false);
            return charge.Id;
		}
        
        public async Task CalculateChargeAsync(int chargeId)
		{
            await _chargeManager.CalculateChargeAsync(chargeId);
		}

        public async Task<IEnumerable<GetUnitChargeResponse>> GetUnitChargesAsync(int unitId, int userId)
		{
            var charges = await _chargeManager.GetUnitChargesAsync(unitId, userId);
		}
    }
}
