using Asa.ApartmentSystemManagement.ApplicationServices;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Request;
using Asa.ApartmentSystemManagement.ApplicationServices.Model.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("React")]
    public class UserController : ControllerBase
    {
        private UserApplicationService _userApplicationService;
        AppSetting _appSetting;
        public UserController(IOptions<AppSetting> appSetting)
        {
            _appSetting = appSetting.Value;
            _userApplicationService = new UserApplicationService(_appSetting.ConnectionString);
        }

        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest authInfo)
        {
            var user = await _userApplicationService.AuthenticateUser(authInfo);
            if(user == null)
            {
                return BadRequest(new { message = "Username or password is invalid :(" });
            }
            GenerateJwtToken(user);
            return Ok(user);
        }

        private void GenerateJwtToken(UserResponse user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
        }

    }
}
