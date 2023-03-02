using Identity.Backend.AuthToken;
using Identity.Backend.Data;
using Identity.Backend.Models;
using Identity.Common;
using Identity.WebApi.Models;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Threading;

namespace Identity.Backend.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthDbContext _dbContext;
        private readonly IOptions<AuthOptions> _authOptions;

        public AuthController(AuthDbContext dbContext,
            IOptions<AuthOptions> authOptions)
        {
            _dbContext = dbContext;
            _authOptions = authOptions;
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login([FromBody] LoginModel request,
            CancellationToken cancellationToken)
        {
            var user = await _dbContext.Accounts
                .FirstOrDefaultAsync(user =>
                user.Email == request.Email && user.Password == request.Password,
                cancellationToken);

            if (user == null)
            {
                return StatusCode(401);
            }
            var token = GenerateJWT(user);
            return Ok(new { access_token = token, id = user.Id });
        }

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Registation([FromBody] LoginModel request,
            CancellationToken cancellationToken)
        {
            var user = new Account
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                Password = request.Password,
                Roles = "User"
            };
            await _dbContext.Accounts.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            var token = GenerateJWT(user);
            return Ok(new { access_token = token, id = user.Id });
        }

        [HttpGet]

        public async Task<IActionResult> Check()
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            
            if (token == null)
                return StatusCode(401);
            var handler = new JwtSecurityTokenHandler();
            var validation = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = _authOptions.Value.Issuer,
                ValidateAudience = true,
                ValidAudience = _authOptions.Value.Audience,
                ValidateLifetime = true,
                IssuerSigningKey = _authOptions.Value.GetSymmetricSecurityKey(),
                ValidateIssuerSigningKey = true
            };
           var result = await handler.ValidateTokenAsync(token, validation);
            //var jsonToken = handler.ReadJwtToken(token);
            if(result.IsValid)
            return Ok(new { access_token = token });
            else
            return StatusCode(401);
        }


        private string GenerateJWT(Account account)
        {
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.Email, account.Email),
                new Claim(JwtRegisteredClaimNames.Sub, account.Id.ToString()),
                new Claim("role", account.Roles)
            };

            var token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience, claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}