using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using Asa.ApartmentSystemManagement.Core.ChargeCalculation.Domain;
using Asa.ApartmentSystemManagement.Core.ChargeCalculation.Domain.CalculationFormula;
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
            CalculationFormulaFactory.Initiate();
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
                chargeItems.AddRange(formula.Calculate(calculationInfo.Amount, shareInfos, calculationInfo.ExpenseId, calculationInfo.IsForOwner));
			}
            var gateway = _gatewayFactory.CreateChargeItemTableGateway();
            await gateway.InsertChargeItemsAsync(chargeItems, chargeId);
		}

		public async Task<IEnumerable<UnitChargeDTO>> GetOwnedUnitChargesAsync(int unitId, int userId)
		{
            var gateway = _gatewayFactory.CreateChargeItemTableGateway();
            var unitCharges = await gateway.GetOwnedUnitChargesAsync(unitId, userId);
            return unitCharges;
		}

        public async Task<IEnumerable<UnitChargeDTO>> GetRentedUnitChargesAsync(int unitId, int userId)
        {
            var gateway = _gatewayFactory.CreateChargeItemTableGateway();
            var unitCharges = await gateway.GetRentedUnitChargesAsync(unitId, userId);
            return unitCharges;
        }

        private async Task<IEnumerable<CalculationDTO>> GetExpensesAsync(int chargeId)
        {
            var gateway = _gatewayFactory.CreateExpenseTableGateway();
            IEnumerable<CalculationDTO> expenses = await gateway.GetCalculationInfosByChargeIdAsync(chargeId);
            return expenses;
        }

        public async Task UpdateChargeAsync(int chargeId, ChargeDTO chargeDTO)
        {
            var gateway = _gatewayFactory.CreateChargeTableGateway();
            chargeDTO.Id = chargeId;
            await gateway.UpdateChargeAsync(chargeDTO);

        }

        private async Task<IEnumerable<ShareInfo>> GetShareInfosAsync(CalculationDTO calculationInfo)
		{
            if(calculationInfo.IsForOwner)
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

        public async Task<IEnumerable<FormulaName>> GetFormulas()
        {
            return await Task.Run(()=>CalculationFormulaFactory.GetAll());
        }
        public async Task<IEnumerable<ChargeDTO>> GetChargesAsync(int buildingId)
        {
            var gateway = _gatewayFactory.CreateChargeTableGateway();
            var charges = await gateway.GetChargesAsync(buildingId);
            return charges;
        }

    }
}
