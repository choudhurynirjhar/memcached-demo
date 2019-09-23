using Enyim.Caching;

namespace Memched.Demo
{
    internal interface ICacheRepository
    {
        void Set<T>(string key, T value);
    }

    internal class CacheRepository : ICacheRepository
    {
        private readonly IMemcachedClient memcachedClient;

        public CacheRepository(IMemcachedClient memcachedClient)
        {
            this.memcachedClient = memcachedClient;
        }

        public void Set<T>(string key, T value)
        {
            // Setting cache expiration for an hour
            memcachedClient.Set(key, value, 60 * 60);
        }
    }
}
