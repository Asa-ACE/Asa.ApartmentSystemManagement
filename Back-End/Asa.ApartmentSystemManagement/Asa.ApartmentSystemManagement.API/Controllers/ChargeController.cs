﻿using Asa.ApartmentSystemManagement.API.Tools;
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
        public async Task<IActionResult> AddCharge([FromRoute] int buildingId,[FromBody] CreateChargeRequest charge)
        {
            charge.BuildingId = buildingId;
            var id = await _chargeApplicationService.CreateChargeAsync(charge);
            return Ok(id);
        }

        [HttpPost]
        [Route("{chargeId:int}/calculate")]
        public async Task<IActionResult> CalculateCharge([FromRoute] int chargeId)
        {
            await _chargeApplicationService.CalculateChargeAsync(chargeId);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetCharges([FromRoute] int buildingId)
        {
            var charges = await _chargeApplicationService.GetChargesAsync(buildingId);
            return Ok(charges);
        }

        [HttpPut]
        [Route("{chargeId:int}")]
        public async Task<IActionResult> UpdateCharge([FromRoute] int chargeId, [FromRoute] int buildingId,  [FromBody] CreateChargeRequest charge)
        {
            charge.BuildingId = buildingId;
            await _chargeApplicationService.UpdateChargeAsync(chargeId, charge);
            return Ok();
        }

    }
}
