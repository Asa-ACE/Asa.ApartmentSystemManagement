using Asa.ApartmentSystemManagement.Core.BaseInfo.DTOs;
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

        public async Task AddBuilding(BuildingDTO building)
        {
            ValidateBuilding(building);
            var gateway = _gatewayFactory.CreateBuildingTableGateway();
            var id = await gateway.InsertBuildingAsync(building);
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

        public async Task AddUnit(UnitDTO unit)
        {
            ValidateUnit(unit);
            var gateway = _gatewayFactory.CreateUnitTableGateway();
            var id = await gateway.InsertUnitAsync(unit);
            unit.Id = id;
        }

        private void ValidateUnit(UnitDTO unit)
        {
            if(unit.Area < 20)
            {
                throw new ArgumentOutOfRangeException("Unit area cannot be less than 20!");
            }
        }

        public async Task UpdateBuildingName(int id, string name)
		{
            var gateway = _gatewayFactory.CreateBuildingTableGateway();
            var building = await gateway.GetBuildingById(id);
            building.Name = name;
            ValidateBuilding(building);
            await gateway.UpdateBuilding(building);
		}

    }
}
