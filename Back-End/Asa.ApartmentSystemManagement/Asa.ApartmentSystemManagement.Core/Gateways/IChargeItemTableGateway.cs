using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.Gateways
{
	public interface IChargeItemTableGateway
	{
		Task InsertChargeItemsAsync(IEnumerable<ChargeItemDTO> chargeItems, int chargeId);
        Task<IEnumerable<UnitChargeDTO>> GetOwnedUnitChargesAsync(int unitId, int userId);
        Task<IEnumerable<UnitChargeDTO>> GetRentedUnitChargesAsync(int unitId, int userId);
    }
}
