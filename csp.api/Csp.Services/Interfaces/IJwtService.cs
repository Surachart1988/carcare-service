using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Csp.Services.Interfaces
{
    public interface IJwtService
    {
        string GetExpirationDate();
        string GenerateSecurityToken(Dictionary<string, string> parameters);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
