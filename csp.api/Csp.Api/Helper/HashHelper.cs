using System.Security.Cryptography;
using System.Text;

namespace Csp.Api.Helper {
    public static class HashHelper {
        
        public static string TextToHash(string data)
        {
            var sh = SHA1.Create();
            var hash = new StringBuilder();
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] b = sh.ComputeHash(bytes);
            foreach (byte a in b)
            {
                var h = a.ToString("x2");
                hash.Append(h);
            }
            return hash.ToString();
        }

    }

}