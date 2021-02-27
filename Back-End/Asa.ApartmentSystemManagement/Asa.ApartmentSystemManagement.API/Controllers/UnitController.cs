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
    public class UnitController : ControllerBase 
    {
        private IBaseInfoApplicationService _baseInfoApplicationService;
        private IChargeApplicationService _chargeApplicationService;
        public UnitController(IBaseInfoApplicationService baseInfoApplicationService, IChargeApplicationService chargeApplicationService)
        {
            _baseInfoApplicationService = baseInfoApplicationService;
            _chargeApplicationService = chargeApplicationService;
        }

        //Owner
        [HttpGet]
        [Route("Owner")]
        public IEnumerable<UnitResponse> GetUnitsIOwn()
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var units = _baseInfoApplicationService.GetUnitsIOwn(userId);
            return units;
        }
        [HttpGet]
        [Route("Owner/{unitId:int}/Charges")]
        public IEnumerable<ChargeAndChargeItemResponse> GetChargesInUnitIOwn([FromRoute] int unitId)
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var charges = _chargeApplicationService.GetChargesInUnitIOwn(userId, unitId);
            return charges;
        }

        //Tenant
        [HttpGet]
        [Route("Tenant")]
        public IEnumerable<UnitResponse> GetUnitsIRent()
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var units = _baseInfoApplicationService.GetUnitsIRent(userId);
            return units;
        }
        [HttpGet]
        [Route("Tenant/{unitId:int}/Charges")]
        public IEnumerable<ChargeAndChargeItemResponse> GetChargesInUnitIRent([FromRoute] int unitId)
        {
            var userId = Convert.ToInt32(HttpContext.Items["User"]);
            var charges = _chargeApplicationService.GetChargesInUnitIRent(userId, unitId);
            return charges;
        }

    }
}
