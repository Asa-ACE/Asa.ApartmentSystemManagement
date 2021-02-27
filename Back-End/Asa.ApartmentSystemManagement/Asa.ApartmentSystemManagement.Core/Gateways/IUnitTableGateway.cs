using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways
{
    public interface IUnitTableGateway
    {
        Task<int> InsertUnitAsync(UnitDTO unit);
        Task<UnitDTO> GetUnitByIdAsync(int id);
        Task<IEnumerable<UnitDTO>> GetUnitsByBuildingIdAsync(int id);
    }
}
