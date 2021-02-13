using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.Gateways
{
    public interface IBuildingTableGateway
    {
        Task<int> InsertBuildingAsync(BuildingDTO);
    }
}
