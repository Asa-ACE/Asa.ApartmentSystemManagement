using Asa.ApartmentSystemManagement.API.Tools;
using Asa.ApartmentSystemManagement.ApplicationServices;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Request;
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
    //[Authorize]
    [Route("[controller]")]
    [EnableCors("React")]
    public class FormulaTypeController : ControllerBase
    {
        private BaseInfoApplicationService _baseInfoApplicationService;
        private ChargeApplicationService _chargeApplicationService;

        public FormulaTypeController(IOptions<AppSetting> appSetting)
        {
            _baseInfoApplicationService = new BaseInfoApplicationService(appSetting.Value.ConnectionString);
            _chargeApplicationService = new ChargeApplicationService(appSetting.Value.ConnectionString);
        }

        [HttpGet]
        public async Task<IActionResult> GetFormulas()
        {
            var formulas = await _chargeApplicationService.GetFormulasAsync();
            return Ok(formulas);
        }
    }
}
