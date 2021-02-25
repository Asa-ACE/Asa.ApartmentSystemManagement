using Asa.ApartmentSystemManagement.API.Interfaces.ApplicationServices;
using Asa.ApartmentSystemManagement.API.Model;
using Asa.ApartmentSystemManagement.API.Model.Request;
using Asa.ApartmentSystemManagement.API.Model.Response;
using Asa.ApartmentSystemManagement.API.Tools;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Asa.ApartmentSystemManagement.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class BuildingController : ControllerBase
    {
        private IBaseInfoApplicationService _baseInfoApplicationService;
        public BuildingController(IBaseInfoApplicationService baseInfoApplicationService)
        {
            _baseInfoApplicationService = baseInfoApplicationService;
        }
        [HttpGet]
        public IEnumerable<BuildingResponse> GetBuildings()
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]) ;
            var buildings =  _baseInfoApplicationService.GetBuildings(userId);
            return buildings;
        }
        [HttpPost]
        public void AddBuilding([FromBody] BuildingRequest buildingInfo)
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var name = buildingInfo.Name;
            var numberOfUnits = buildingInfo.NumberOfUnits;
            _baseInfoApplicationService.CreateBuilding(name, numberOfUnits);
        }
        [HttpPatch]
        [Route("{id:int}")]
        public void ChangeBuildingName([FromRoute] int id , [FromQuery] string newName)
        {
            _baseInfoApplicationService.ChangeBuildingName(id, newName);
        }

        [HttpGet]
        [Route("{buildingId:int}/Units")]
        public IEnumerable<UnitResponse> GetUnits([FromRoute] int buildingId)
        {
            var units = _baseInfoApplicationService.GetUnits(buildingId);
            return units;
        }

        [HttpPost]
        [Route("{buildingId:int}/Units")]
        public void AddUnit([FromRoute] int buildingId , [FromBody] UnitRequest unitInfo )
        {
            _baseInfoApplicationService.CreateUnit(buildingId, unitInfo.Area, unitInfo.UnitNumber, unitInfo.Description);
        }
    }
}
