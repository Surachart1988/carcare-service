using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Csp.Api.Helper
{
    public class CacheService : ICacheService
    {
        private IDistributedCache _cache;
        private Dictionary<string, List<string>> _cacheKey;


        public string RedisConnection { get; set; }


        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
            _cacheKey = new Dictionary<string, List<string>>();
        }


        public  T GetCacheValue<T>(string key) where T : class
        {
            string result = _cache.GetString(key);
            if (String.IsNullOrEmpty(result))
            {
                return null;
            }
            T deserializedObj = JsonConvert.DeserializeObject<T>(result);
            return deserializedObj;
        }

        public void SetCacheValue<T>(string source, string key, T value) where T : class
        {
            DistributedCacheEntryOptions cacheEntryOptions = new DistributedCacheEntryOptions()
                                                                    .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                                                                    .SetAbsoluteExpiration(DateTime.Now.AddHours(6));


            if (_cacheKey.ContainsKey(source))
            {
                var list = _cacheKey[source];
                list.Add(key);
                
            } else
            {
                var list = new List<string>();
                list.Add(key);
                _cacheKey.Add(source, list);
            }

            string result = JsonConvert.SerializeObject(value);
            _cache.SetString(key, result);
        }

        public void ClearCache(string source)
        {
            if (_cacheKey.ContainsKey(source))
            {
                foreach (var item in _cacheKey[source])
                    _cache.Remove(item);

                _cacheKey.Remove(source);
            }            
        }
    }
}
