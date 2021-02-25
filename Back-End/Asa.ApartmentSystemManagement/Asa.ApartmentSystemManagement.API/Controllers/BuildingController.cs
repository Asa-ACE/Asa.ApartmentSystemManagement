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
        public  IEnumerable<BuildingResponse> GetBuildings()
        {
            var UserId = Convert.ToInt32(HttpContext.Items["User"]) ;
            var Buildings =  _baseInfoApplicationService.GetBuildings(UserId);
            return Buildings;
        }
        
    }
}
