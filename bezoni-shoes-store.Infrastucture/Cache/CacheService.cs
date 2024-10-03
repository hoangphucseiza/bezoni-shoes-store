using bezoni_shoes_store.Application.Common.Interfaces.Cache;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Infrastucture.Cache
{
    public class CacheService : ICacheService
    {
        private ObjectCache _memoryCache = MemoryCache.Default;

        public T GetData<T>(string key)
        {
           T item = (T)_memoryCache.Get(key);
            return item;
        }

        public object RemoveData(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                return _memoryCache.Remove(key);
            }
            return null;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            if(!string.IsNullOrEmpty(key))
            {
                
                _memoryCache.Set(key, value, expirationTime);
                return true;
            }
            return false;
        }
    }
}
