using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthController(JwtConfiguration configuration, IUserRepository UserRepository)
        {
            this._configuration = configuration;
            this._userRepository = UserRepository;
        }

        [HttpPost]
        [Route("token")]
        public IActionResult GenerateToken([FromBody]LoginModel credentials)
        {
            string md5Password = CreateMD5(credentials.Password);
            if (!_userRepository.IsUserExists(credentials.Login, md5Password))
            {
                Response.StatusCode = StatusCodes.Status401Unauthorized;
                return NotFound(new AccessToken() { Success = false });
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, credentials.Login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.SecretKey));

            var expireDate = DateTime.Now.AddMinutes(_configuration.TokenExpirationTime);
            var signs = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(_configuration.Issuer, _configuration.ValidAudience, claims, expires: expireDate, signingCredentials: signs);

            string tokenKey = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new AccessToken()
            {
                Success = true,
                Token = tokenKey,
                ExpireDate = token.ValidTo
            });
        }

        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
