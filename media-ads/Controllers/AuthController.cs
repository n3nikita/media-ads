using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using media_ads.ViewModels;
using MediaAds.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace media_ads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var identity = GetIdentity(user);

            if (user is null)
                return Unauthorized();

            var jwt = new JwtSecurityToken(
                issuer: JwtOptions.ISSUER,
                audience: JwtOptions.AUDIENCE,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(JwtOptions.LIFETIME),
                claims: identity.Claims,
                signingCredentials: new SigningCredentials(JwtOptions.SecurityKey, SecurityAlgorithms.HmacSha256)
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JsonResult(encodedJwt);
        }

        private ClaimsIdentity GetIdentity(LoginViewModel user)
        {
            //var hashProvider = new Md5HashProvider();
            //password = hashProvider.GetMd5Hash(password);

            //var user = db.Users.FirstOrDefault(x => x.Username == username && x.Password == password);

            if (user is null)
                return null;

            var claims = new List<Claim>
            {
                new Claim("name", user.Username),
                new Claim("role", "admin") // role from db
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "token",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
    }
}