using Identity.Backend.Data;
using Identity.Backend.Models;
using Identity.Common;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Identity.Backend.AuthToken
{
    public class TokenInitializer
    {
        private readonly IOptions<AuthOptions> _authOptions;

        public TokenInitializer(IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions;
        }
        public string GenerateJWT(Account account)
        {
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, account.Email),
                new Claim(JwtRegisteredClaimNames.Sub, account.Id.ToString())
            };
            claims.Add(new Claim("role", account.Roles));

            var token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience, claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
