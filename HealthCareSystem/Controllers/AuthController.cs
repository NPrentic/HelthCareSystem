using HealthCareSystem.Core;
using HealthCareSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareSystem.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }
        // GET api/values
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            TokenModel loginInfo = await authRepository.SearchUserByCredentials(user);

            if (loginInfo != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, loginInfo.Name),
                    new Claim(ClaimTypes.Role, loginInfo.Role),
                };

                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44314",
                    audience: "https://localhost:44314",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString,
                               FacilityId = loginInfo.Facility.Id,
                               FacilityName = loginInfo.Facility.Name ,
                               loginInfo.Title,
                               loginInfo.Role,
                               loginInfo.Id,
                               loginInfo.Name});
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
