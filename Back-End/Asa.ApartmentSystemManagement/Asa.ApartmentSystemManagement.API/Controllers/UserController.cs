using Asa.ApartmentSystemManagement.API.Interfaces.ApplicationServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IBaseInfoApplicationService _baseInfoApplicationService;
        public UserController(IBaseInfoApplicationService baseInfoApplicationService)
        {
            _baseInfoApplicationService = baseInfoApplicationService;
        }
    }
}
