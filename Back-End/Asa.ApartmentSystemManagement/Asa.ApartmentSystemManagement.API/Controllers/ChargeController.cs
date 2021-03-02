using Asa.ApartmentSystemManagement.API.Tools;
using Asa.ApartmentSystemManagement.ApplicationServices;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Request;
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
    [Route("building/{buildingId:int}/[controller]")]
    [EnableCors("React")]
    public class ChargeController : ControllerBase
    {
        private BaseInfoApplicationService _baseInfoApplicationService;
        private ChargeApplicationService _chargeApplicationService;

        public ChargeController(IOptions<AppSetting> appSetting)
        {
            _baseInfoApplicationService = new BaseInfoApplicationService(appSetting.Value.ConnectionString);
            _chargeApplicationService = new ChargeApplicationService(appSetting.Value.ConnectionString);
        }

        //charge
        [HttpPost]
        [Route("Charge")]
        public async Task<IActionResult> AddCharge([FromBody] CreateChargeRequest charge)
        {
            var chargeId = Convert.ToInt32(HttpContext.Items["User"]);
            var buildingId = charge.BuildingId;
            var from = charge.From;
            var to = charge.To;
            var id = await _chargeApplicationService.CreateChargeAsync(charge);
            return Ok(id);
        }

    }
}
