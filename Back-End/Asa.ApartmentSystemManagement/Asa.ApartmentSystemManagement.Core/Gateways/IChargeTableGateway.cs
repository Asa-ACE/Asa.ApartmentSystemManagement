using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways
{
	public interface IChargeTableGateway
	{
		Task<int> InsertChargeAsync(ChargeDTO charge);
		Task<IEnumerable<CalculationDTO>> GetCalculationInfosAsync(int chargeId);
		Task DeleteChargeAsync(int chargeId);
		Task UpdateChargeAsync(ChargeDTO charge);
		Task<ChargeDTO> GetChargeAsync(int chargeId);
	}
}
