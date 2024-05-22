using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MultiProjectStructure.BussinesLogic.Services;
using MultiProjectStructure.Database.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiProjectStructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMemoryCache _memoryCache;

        public BookController(IBookService bookService, IMemoryCache memoryCache)
        {
            _bookService = bookService;
            _memoryCache = memoryCache;
        }
        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookService.GetAll();
        }

        // GET api/<BookController>/5
        //[ResponseCache(Duration = 60)]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string cachekey = $"Book:Get:{id}";
            if (!_memoryCache.TryGetValue(cachekey, out string cachedData))
            {
                Task.Delay(3000).Wait();
                cachedData = "book" + id;
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                _memoryCache.Set(cachekey, cachedData, cacheOptions);
            }
            
            return cachedData;
        }
        [HttpGet("Get2/{id}")]
        public string Get2(int id)
        {
            string cachekey = $"Book:Get:{id}";
            if (!_memoryCache.TryGetValue(cachekey, out string cachedData))
            {
                Task.Delay(3000).Wait();
                cachedData = "book" + id;
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                _memoryCache.Set(cachekey, cachedData, cacheOptions);
            }

            return cachedData;
        }
        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            _bookService.Add(book);
        }

        //// PUT api/<BookController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<BookController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
