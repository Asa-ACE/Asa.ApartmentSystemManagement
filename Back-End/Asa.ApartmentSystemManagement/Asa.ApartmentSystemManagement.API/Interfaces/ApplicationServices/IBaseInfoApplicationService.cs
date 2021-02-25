using Asa.ApartmentSystemManagement.API.Model;
using Asa.ApartmentSystemManagement.API.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.API.Interfaces.ApplicationServices
{
    public interface IBaseInfoApplicationService
    {
        IEnumerable<BuildingResponse> GetBuildings(int userId);
        void CreateBuilding(string name, int numberOfUnits);
        void ChangeBuildingName(int id, string newName);

        IEnumerable<UnitResponse> GetUnits(int buildingId);
        void CreateUnit(int buildingId, decimal area, int unitNumber, string description);
    }
}
