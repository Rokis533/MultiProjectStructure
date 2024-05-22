using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MultiProjectStructure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly string _cacheKey = "expensiveData";

        public DataController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet("noncached")]
        public async Task<IActionResult> GetNonCachedData()
        {
            var data = await GetExpensiveData();
            return Ok(data);
        }

        [HttpGet("cached")]
        public async Task<IActionResult> GetCachedData()
        {
            if (!_memoryCache.TryGetValue(_cacheKey, out string cachedData))
            {
                cachedData = await GetExpensiveData();
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                _memoryCache.Set(_cacheKey, cachedData, cacheOptions);
            }
            return Ok(cachedData);
        }

        private Task<string> GetExpensiveData()
        {
            Task.Delay(3000).Wait();
            return Task.FromResult("This is expensive data");
        }
    }
}
