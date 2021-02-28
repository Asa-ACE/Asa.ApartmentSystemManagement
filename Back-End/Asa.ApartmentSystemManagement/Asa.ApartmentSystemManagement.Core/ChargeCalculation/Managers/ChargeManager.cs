﻿using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using Asa.ApartmentSystemManagement.Core.DTOs;
using ASa.ApartmentManagement.Core.ChargeCalculation.Domain;
using ASa.ApartmentManagement.Core.ChargeCalculation.Domain.CalculationFormula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.ChargeCalculation.Managers
{
    public class ChargeManager
    {
        ITableGatewayFactory _gatewayFactory;

        public ChargeManager(ITableGatewayFactory gatewayFactory)
        {
            _gatewayFactory = gatewayFactory;
        }



        public async Task InsertChargeAsync(ChargeDTO charge)
        {
            var gateway = _gatewayFactory.CreateChargeTableGateway();
            int id = await gateway.InsertChargeAsync(charge);
            charge.Id = id;
        }

		public async Task CalculateChargeAsync(int chargeId)
		{
            var calculationInfos = await GetExpensesAsync(chargeId);
            List<ChargeItemDTO> chargeItems = new List<ChargeItemDTO>();
			foreach (var calculationInfo in calculationInfos)
			{

                var shareInfos = await GetShareInfosAsync(calculationInfo);
                IFormula formula = CalculationFormulaFactory.Create(calculationInfo.FormulaName);
                chargeItems.Concat(formula.Calculate(calculationInfo.Amount, shareInfos, calculationInfo.ExpenseId, calculationInfo.IsForOwner));
			}
            var gateway = _gatewayFactory.CreateChargeItemTableGateway();
		}

		private async Task<IEnumerable<CalculationDTO>> GetExpensesAsync(int chargeId)
        {
            var gateway = _gatewayFactory.CreateExpenseTableGateway();
            IEnumerable<CalculationDTO> expenses = await gateway.GetCalculationInfosByChargeIdAsync(chargeId);
            return expenses;
        }

        private async Task<IEnumerable<ShareInfo>> GetShareInfosAsync(CalculationDTO calculationInfo)
        {
            if (calculationInfo.IsForOwner)
            {
                var gateway = _gatewayFactory.CreateOwnershipTableGateway();
                var shareInfos = await gateway.GetOwnerShareInfoAsync(calculationInfo.BuildingId, calculationInfo.From, calculationInfo.To);
                return shareInfos;
            }
            else
            {
                var gateway = _gatewayFactory.CreateTenancyTableGateway();
                var shareInfos = await gateway.GetTenantShareInfoAsync(calculationInfo.BuildingId, calculationInfo.From, calculationInfo.To);
                return shareInfos;
            }
        }
    }
}
