using Csp.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Csp.Services.Services
{
    public class JwtService : IJwtService
    {
        private readonly string _secret;
        private readonly string _expDate;
        private readonly string _refreshExpDate;

        public string GetExpirationDate()
        {
            return _expDate;
        }

        public JwtService(IConfiguration config)
        {
            _secret = config.GetSection("JwtConfig").GetSection("client_secret").Value;
            _expDate = config.GetSection("JwtConfig").GetSection("tokenExpirationInSecond").Value;
            _refreshExpDate = config.GetSection("JwtConfig").GetSection("refreshTokenExpirationInSecond").Value;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        //public string GenerateSecurityToken(string loginName, string firstname, string lastname, string userId)
        public string GenerateSecurityToken(Dictionary<string, string> parameters)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // Expires = DateTime.UtcNow.AddSeconds(double.Parse(_expDate)),
                Expires = DateTime.Now.AddSeconds(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
            };

            tokenDescriptor.Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name, parameters["LoginName"]),
                new Claim("Firstname", parameters["FirstName"]),
                new Claim("Lastname", parameters["LastName"]),
                new Claim("UserId", parameters["UserId"]),
                new Claim("PositionId", parameters["PositionId"]),
                new Claim("PostionName", parameters["PositionName"])

            });

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var key = Encoding.ASCII.GetBytes(_secret);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),

                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };


            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var x = tokenHandler.CanReadToken(token);

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }
    }
}
