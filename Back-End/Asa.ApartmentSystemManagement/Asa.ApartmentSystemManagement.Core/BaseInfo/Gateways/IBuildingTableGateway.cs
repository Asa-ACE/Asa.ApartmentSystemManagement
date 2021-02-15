using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways
{
    public interface IBuildingTableGateway
    {
        Task<int> InsertBuildingAsync(BuildingDTO building);
        Task<BuildingDTO> GetBuildingById(int id);
        Task UpdateName(int id,string name);
        Task RemoveBuildingById(int id);
    }
}
