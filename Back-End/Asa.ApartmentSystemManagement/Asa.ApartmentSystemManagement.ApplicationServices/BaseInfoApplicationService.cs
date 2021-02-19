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
		ITableGatewayFactory tableGatewayFactory;

        public BaseInfoApplicationService(string connectionString)
        {
			tableGatewayFactory = new SqlTableGatewayFactory(connectionString);
        }

        public async Task<int> CreateBuilding(string name, int numberofUnits)
        {
            BuildingManager buildingManager = new BuildingManager(tableGatewayFactory);
            var buildingDto = new BuildingDTO { Name = name, NumberOfUnits = numberofUnits };
            await buildingManager.AddBuilding(buildingDto);
            return buildingDto.Id;
        }
    }
}
