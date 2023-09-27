using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using WebApi_Curewell.Models;

namespace WebApi_Curewell.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly CurewellDbContext _dbContext;

        public AuthController(CurewellDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LogDetail user)
        {
            if (user is null)
            {
                return BadRequest("Invalid client request");
            }

            // Retrieve user data from the database
            var dbUser = _dbContext.LogDetails.SingleOrDefault(u => u.UserName == user.UserName && u.UserPassword == user.UserPassword);

            if (dbUser != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, dbUser.UserName));
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                

                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5001",
                    audience: "http://localhost:5001",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new AuthenticatedResponse { Token = tokenString });
            }

            return Unauthorized();
        }
    }
}