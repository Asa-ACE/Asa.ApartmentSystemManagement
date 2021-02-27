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
        int CreateBuilding(string name, int numberOfUnits, string address);
        void ChangeBuildingName(int id, string newName);

        IEnumerable<UnitResponse> GetUnits(int buildingId);
        void CreateUnit(int buildingId, decimal area, int unitNumber, string description);

        IEnumerable<OwnerResponse> GetOwners(int unitId);
        void AddOwner(int unitId, int personId, DateTime from, DateTime? to);
        void ChangeOwnerInfo(int ownerId, int personId, DateTime from, DateTime? to);

        IEnumerable<TenantResponse> GetTenants(int unitId);
        void AddTenant(int unitId, int personId, DateTime from, DateTime? to , int numberOfPeople);
        void ChangeTenantInfo(int tenantId, int personId , DateTime from, DateTime? to , int numberOfPeople);
    }
}
