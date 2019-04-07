using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.ViewModels;
using MediaAds.Core;
using MediaAds.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Web.Services;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository repository) => _userRepository = repository;
        

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var identity = await GetIdentity(user);

            if (identity is null)
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

        private async Task<ClaimsIdentity> GetIdentity(LoginViewModel userModel)
        {
            var hashProvider = new Md5HashService();
            userModel.Password = hashProvider.GetMd5Hash(userModel.Password);

            var user = await _userRepository.GetUserByCredentials(userModel.Username, userModel.Password);

            if (user is null)
                return null;

            var claims = new List<Claim>
            {
                new Claim("name", user.Username),
                new Claim("role", user.Role.Name)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "token",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
    }
}