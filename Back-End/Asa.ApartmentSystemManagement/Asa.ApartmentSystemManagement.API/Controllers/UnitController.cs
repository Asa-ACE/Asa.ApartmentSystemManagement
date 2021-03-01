
using Asa.ApartmentSystemManagement.API.Tools;
using Asa.ApartmentSystemManagement.ApplicationServices;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Response;
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
    public class UnitController : ControllerBase 
    {
        private BaseInfoApplicationService _baseInfoApplicationService;
        private ChargeApplicationService _chargeApplicationService;
        public UnitController(string connectionString)
        {
            _baseInfoApplicationService = new BaseInfoApplicationService(connectionString);
            _chargeApplicationService = new ChargeApplicationService(connectionString);
        }

        //Owner
        [HttpGet]
        [Route("Owner")]
        public async Task<IActionResult> GetOwnedUnits()
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var units = await _baseInfoApplicationService.GetOwnedUnitsAsync(userId);
            return Ok(units);
        }

        [HttpGet]
        [Route("Owner/{unitId:int}/Charges")]
        public async Task<IActionResult> GetOwnedUnitCharges([FromRoute] int unitId)
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var charges = await _chargeApplicationService.GetOwnedUnitChargesAsync(unitId, userId);
            return Ok(charges);
        }

        //Tenant
        [HttpGet]
        [Route("Tenant")]
        public async Task<IActionResult> GetRentedUnits()
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var units = await _baseInfoApplicationService.GetRentedUnitsAsync(userId);
            return Ok(units);
        }

        [HttpGet]
        [Route("Tenant/{unitId:int}/Charges")]
        public async Task<IActionResult> GetRentedUnitCharges([FromRoute] int unitId)
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var charges = await _chargeApplicationService.GetRentedUnitChargesAsync(userId, unitId);
            return Ok(charges);
        }

    }
}
