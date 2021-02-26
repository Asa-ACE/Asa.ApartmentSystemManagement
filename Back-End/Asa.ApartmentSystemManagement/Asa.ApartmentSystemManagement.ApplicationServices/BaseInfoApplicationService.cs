using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Managers;
using Asa.ApartmentSystemManagement.Infra.DataGateways;
using System;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.ApplicationServices
{
	public class BaseInfoApplicationService
	{
		ITableGatewayFactory _tableGatewayFactory;
        BuildingManager _buildingManager;

        public BaseInfoApplicationService(string connectionString)
        {
			_tableGatewayFactory = new SqlTableGatewayFactory(connectionString);
            _buildingManager = new BuildingManager(_tableGatewayFactory);
        }

        public async Task<int> CreateBuildingAsync(string name, int numberofUnits, string address)
        {
            var buildingDto = new BuildingDTO { Name = name, NumberOfUnits = numberofUnits, Address = address };
            await _buildingManager.AddBuildingAsync(buildingDto);
            return buildingDto.Id;
        }

        public async Task<int> CreateUnitAsync(int buildingId, decimal area, int number, string description)
        {
            var unitDto = new UnitDTO { BuildingId = buildingId, Area = area, UnitNumber = number, Description = description };
            await _buildingManager.AddUnitAsync(unitDto);
            return unitDto.Id;
        }

        public async Task<int> CreateOwnershipAsync(int personId, int unitId, DateTime from, DateTime to)
        {
            var ownerDto = new OwnershipDTO { PersonId = personId, UnitId = unitId, From = from, To = to };
            await _buildingManager.AddOwnershipAsync(ownerDto);
            return ownerDto.Id;
        }

        public async Task<int> CreateTenancyAsync(int personId, int unitId, DateTime from, DateTime to, int numberOfPeople)
        {
            var tenantDto = new TenancyDTO { PersonId = personId, UnitId = unitId, From = from, To = to, NumberOfPeople = numberOfPeople };
            await _buildingManager.AddTenancyAsync(tenantDto).ConfigureAwait(false);
            return tenantDto.TenancyId;
        }

        public async Task<BuildingDTO> GetBuildingByIdAsync(int id)
        {
            return await _buildingManager.GetBuildingByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<UnitDTO> GetUnitByIdAsync(int id)
        {
            return await _buildingManager.GetUnitByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<UnitDTO> GetUnitByBuildingIdAsync(int buildingId)
        {
            return (UnitDTO)await _buildingManager.GetUnitByBuildingIdAsync(buildingId).ConfigureAwait(false);
        }

        public async Task<OwnershipDTO> GetOwnerPaymentAsync(int unitId, DateTime from, DateTime to)
        {
            return (OwnershipDTO)await _buildingManager.GetOwnerPaymentsAsync(unitId, from, to).ConfigureAwait(false);
        }

        public async Task<TenancyDTO> GetTenancyAsync(int unitId)
        {
            return await _buildingManager.GetTenancyAsync(unitId).ConfigureAwait(false);
        }

        public async Task UpdateBuildingAsync(BuildingDTO buildingDTO)
        {
            await _buildingManager.UpdateBuildingNameAsync(buildingDTO.Id, buildingDTO.Name).ConfigureAwait(false);
        }

        public async Task UpdatOwnershipAsync(OwnershipDTO ownershipDTO)
        {
            var owner = new OwnershipDTO
            {
                Id = ownershipDTO.Id,
                PersonId = ownershipDTO.PersonId,
                From = ownershipDTO.From,
                To = ownershipDTO.To,
                UnitId = ownershipDTO.UnitId
            };
            await _buildingManager.UpdateOwnershipAsync(owner).ConfigureAwait(false);
        }

        public async Task UpdateTenancyAsync(TenancyDTO tenancyDTO)
        {
            var tenant = new TenancyDTO
            {
                TenancyId = tenancyDTO.TenancyId,
                PersonId = tenancyDTO.PersonId,
                UnitId = tenancyDTO.UnitId,
                From = tenancyDTO.From,
                To = tenancyDTO.To,
                NumberOfPeople = tenancyDTO.NumberOfPeople
            };
            await _buildingManager.UpdateTenancyAsync(tenant).ConfigureAwait(false);
        }

        public async Task RemoveBuildingAsync(int id)
        {
            await _buildingManager.RemoveBuildingAsync(id).ConfigureAwait(false);
        }
    }
}
