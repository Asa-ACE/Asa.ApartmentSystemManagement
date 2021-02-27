﻿using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.Managers
{
    public class BuildingManager
    {
        ITableGatewayFactory _gatewayFactory;
        public BuildingManager(ITableGatewayFactory gatewayFactory)
        {
            _gatewayFactory = gatewayFactory;
        }

        public async Task AddBuildingAsync(BuildingDTO building)
        {
            ValidateBuilding(building);
            var gateway = _gatewayFactory.CreateBuildingTableGateway();
            var id = await gateway.InsertBuildingAsync(building).ConfigureAwait(false);
            building.Id = id;
        }

        private void ValidateBuilding(BuildingDTO building)
        {
            if(building.Name == "")
            {
                throw new ArgumentNullException("Building Cannot be empty!");
            }
            if(building.NumberOfUnits < 2)
            {
                throw new ArgumentOutOfRangeException("Building cannot have less than two units!");
            }
        }

        public async Task<BuildingDTO> GetBuildingByIdAsync(int id)
        {
            var gateway = _gatewayFactory.CreateBuildingTableGateway();
            var building = await gateway.GetBuildingByIdAsync(id).ConfigureAwait(false);
            var result = new BuildingDTO
            {
                Id = id,
                Name = building.Name,
                NumberOfUnits = building.NumberOfUnits,
                Address = building.Address
            };
            return result;

        }

        public async Task UpdateBuildingNameAsync(int id, string name)
        {
            var gateway = _gatewayFactory.CreateBuildingTableGateway();
            var building = await gateway.GetBuildingByIdAsync(id);
            building.Name = name;
            ValidateBuilding(building);
            await gateway.UpdateBuildingAsync(building);
        }

        public async Task RemoveBuildingAsync(int id)
        {
            var gateway = _gatewayFactory.CreateBuildingTableGateway();
            await gateway.RemoveBuildingAsync(id).ConfigureAwait(false);

        }

        public async Task AddUnitAsync(UnitDTO unit)
        {
            ValidateUnit(unit);
            var gateway = _gatewayFactory.CreateUnitTableGateway();
            var id = await gateway.InsertUnitAsync(unit);
            unit.Id = id;
        }

        public async Task<IEnumerable<BuildingDTO>> GetBuildingsAsync(int userId)
        {
            var gateway = _gatewayFactory.CreateBuildingTableGateway();
            var buildings = await gateway.GetBuildingsAsync(userId);
            return buildings;
        }

        private void ValidateUnit(UnitDTO unit)
        {
            if(unit.Area < 20)
            {
                throw new ArgumentOutOfRangeException("Unit area cannot be less than 20!");
            }
        }

        public async Task<UnitDTO> GetUnitByIdAsync(int id)
        {
            var gateway = _gatewayFactory.CreateUnitTableGateway();
            var unit = await gateway.GetUnitByIdAsync(id);
            var result = new UnitDTO
            {
                Id = unit.Id,
                UnitNumber = unit.UnitNumber,
                BuildingId = unit.BuildingId,
                Area = unit.Area,
                Description = unit.Description
            };
            return result;
        }

        public async Task<IEnumerable<PersonDTO>> GetOwnersByUnitIdAsync(int unitId)
        {
            var gateway = _gatewayFactory.CreatePersonTableGateway();
            return await gateway.GetOwnersByUnitIdAsync(unitId);
        }

        public async Task<IEnumerable<UnitDTO>> GetUnitsByBuildingIdAsync(int buildingId)
        {
            var gateway = _gatewayFactory.CreateUnitTableGateway();
            return await gateway.GetUnitsByBuildingIdAsync(buildingId).ConfigureAwait(false);
        }

        public async Task<IEnumerable<PersonDTO>> GetTenantsByUnitIdAsync(int unitId)
        {
            var gateway = _gatewayFactory.CreatePersonTableGateway();
            return await gateway.GetTenantsByUnitIdAsync(unitId).ConfigureAwait(false);
        }

        public async Task AddOwnershipAsync(OwnershipDTO ownership)
		{
            var gateway = _gatewayFactory.CreateOwnershipTableGateway();
            ValidateOwership(ownership);
            var id = await gateway.InsertOwnershipAsync(ownership).ConfigureAwait(false);
            ownership.Id = id;
		}

        public async Task UpdateOwnershipAsync(OwnershipDTO ownershipDTO)
        {
            var gateway = _gatewayFactory.CreateOwnershipTableGateway();
            await gateway.UpdateOwnershipAsync(ownershipDTO);
        }

        public async Task<IEnumerable<OwnershipDTO>> GetOwnerPaymentsAsync(int unitId, DateTime from, DateTime to)
        {
            var gateway = _gatewayFactory.CreateOwnershipTableGateway();
            return (IEnumerable<OwnershipDTO>)await gateway.GetOwnerPaymentsAsync(unitId, from, to);

        }

		private void ValidateOwership(OwnershipDTO ownership)
		{
			throw new NotImplementedException();
		}
        public async Task AddTenancyAsync(TenancyDTO tenancy)
        {
            var gateway = _gatewayFactory.CreateTenancyTableGateway();
            ValidateTenancy(tenancy);
            var id = await gateway.InsertTenancyAsync(tenancy);
            tenancy.PersonId = id;
        }

        private void ValidateTenancy(TenancyDTO tenancy)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateTenancyAsync(TenancyDTO tenancyDTO)
        {
            var gateway = _gatewayFactory.CreateTenancyTableGateway();
            var tenant = await gateway.GetTenancyAsync(tenancyDTO.UnitId);
            var result = new TenancyDTO
            {
                PersonId = tenant.PersonId,
                TenancyId = tenant.TenancyId,
                UnitId = tenant.UnitId,
                From = tenant.From,
                To = tenant.To,
                NumberOfPeople = tenant.NumberOfPeople
            };
            await gateway.UpdateTenancyAsync(result).ConfigureAwait(false);
        }

        public async Task<TenancyDTO> GetTenancyAsync(int unitId)
        {
            var gateway = _gatewayFactory.CreateTenancyTableGateway();
            var tenant = await gateway.GetTenancyAsync(unitId).ConfigureAwait(false);
            var result = new TenancyDTO
            {
                PersonId = tenant.PersonId,
                TenancyId = tenant.TenancyId,
                UnitId = tenant.UnitId,
                From = tenant.From,
                To = tenant.To,
                NumberOfPeople = tenant.NumberOfPeople
            };
            return result;
        }
    }
}
