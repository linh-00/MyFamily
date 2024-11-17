using Inc.MyFamily.Application.DTOs;
using Inc.MyFamily.Application.Interfaces.Services;
using Inc.MyFamily.Shared.Enuns;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Inc.MyFamily.Application.Services
{
    public class AuthTokenService : IAuthTokenService
    {
        public static IConfiguration _ApplicationConfig;

        public AuthTokenService(IConfiguration applicationConfig)
        {
            _ApplicationConfig = applicationConfig;
        }

        public async Task<BearerTokenDTO> BuildToken(int Id, string FullName, int FamilyId, ETypeAuth typeAuth)
        {
            List<Claim> claims = new List<Claim>() {
               new Claim(JwtRegisteredClaimNames.UniqueName, Id.ToString()),
               new Claim(JwtRegisteredClaimNames.FamilyName, FamilyId.ToString()),
               new Claim(JwtRegisteredClaimNames.Name, FullName),
               new Claim(ClaimTypes.Role, typeAuth.ToString())
            };

            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_ApplicationConfig.GetSection("JWT")["Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // TEMPO DE EXPIRAÇÃO DO TOKEN: 1 HORA
            var expiration = DateTime.UtcNow.AddHours(23);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            var response = new BearerTokenDTO()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };

            return response;
        }
    }
}
