
using Asa.ApartmentSystemManagement.API.Tools;
using Asa.ApartmentSystemManagement.ApplicationServices;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    [EnableCors("React")]
    public class UnitController : ControllerBase
    {
        private BaseInfoApplicationService _baseInfoApplicationService;
        private ChargeApplicationService _chargeApplicationService;
        public UnitController(IOptions<AppSetting> appSetting)
        {
            _baseInfoApplicationService = new BaseInfoApplicationService(appSetting.Value.ConnectionString);
            _chargeApplicationService = new ChargeApplicationService(appSetting.Value.ConnectionString);
        }

        //Owner
        [HttpGet]
        [Route("Owned")]
        public async Task<IActionResult> GetOwnedUnits()
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var units = await _baseInfoApplicationService.GetOwnedUnitsAsync(userId);
            return Ok(units);
        }

        [HttpGet]
        [Route("Owned/{unitId:int}/Charge")]
        public async Task<IActionResult> GetOwnedUnitCharges([FromRoute] int unitId)
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var charges = await _chargeApplicationService.GetOwnedUnitChargesAsync(unitId, userId);
            return Ok(charges);
        }

        //Tenant
        [HttpGet]
        [Route("Rented")]
        public async Task<IActionResult> GetRentedUnits()
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var units = await _baseInfoApplicationService.GetRentedUnitsAsync(userId);
            return Ok(units);
        }

        [HttpGet]
        [Route("Rented/{unitId:int}/Charge")]
        public async Task<IActionResult> GetRentedUnitCharges([FromRoute] int unitId)
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var charges = await _chargeApplicationService.GetRentedUnitChargesAsync(userId, unitId);
            return Ok(charges);
        }

    }
}
