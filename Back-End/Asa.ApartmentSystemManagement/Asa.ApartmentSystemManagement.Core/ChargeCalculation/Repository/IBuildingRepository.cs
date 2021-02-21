using ASa.ApartmentManagement.Core.ChargeCalculation.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.ChargeCalculation.Repository
{
    public interface IBuildingRepository
    {
        Task<Building> GetBuildingById(int BuildingID);
    }
}
