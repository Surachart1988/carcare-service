using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Api.Models
{
    public class AuthModel
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public string expiresIn { get; set; }
        public string RefreshToken { get; set; }
    }
}
