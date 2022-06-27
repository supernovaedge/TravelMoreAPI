using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TravelMoreAPI.Entities;
using TravelMoreAPI.Models;

namespace TravelMoreAPI
{
    public class TokenCreationService : ITokenCreationService
    {
        private readonly JwtTokenOptions _jwtOptions;

        public TokenCreationService(IOptions<JwtTokenOptions> jwtOptions)
        {
             _jwtOptions = jwtOptions.Value;
        }



        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("UserId", user.UserId.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    _jwtOptions.Key));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
