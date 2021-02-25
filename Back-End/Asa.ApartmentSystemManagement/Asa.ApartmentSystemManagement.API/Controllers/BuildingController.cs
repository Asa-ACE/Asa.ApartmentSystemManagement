using Asa.ApartmentSystemManagement.API.Interfaces.ApplicationServices;
using Asa.ApartmentSystemManagement.API.Model;
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
        public void AddBuilding([FromBody] BuildingRequest BuildingInfo)
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var name = BuildingInfo.Name;
            var numberOfUnits = BuildingInfo.NumberOfUnits;
            _baseInfoApplicationService.CreateBuilding(name, numberOfUnits);
        }
    }
}
