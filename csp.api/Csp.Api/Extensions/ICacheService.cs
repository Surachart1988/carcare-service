using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Api.Helper
{
    public interface ICacheService
    {
        public T GetCacheValue<T>(string key) where T : class;
        public void SetCacheValue<T>(string source, string key, T value) where T : class;
        public void ClearCache(string source);
    }
}
