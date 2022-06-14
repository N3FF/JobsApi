using ApiLibrary;
using JobsApi.Data.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace JobsApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly JobsContext _db;

        private const int FIRST_PAGE = 1;
        private const int DEFAULT_PAGE_SIZE = 10;
        private const int MIN_PAGE_SIZE = 1;
        private const int MAX_PAGE_SIZE = 50;

        public ListingController(JobsContext db)
        {
            _db = db;
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobListingDTO>> View(int id)
        {
            var listing = await _db.JobListings.FindListingAsync(id);

            return listing == null ? NotFound() : Ok(listing);
        }


        // GET api/<ValuesController>/Page?current=1&size=10
        [HttpGet("Page")]
        public async Task<ActionResult<List<JobListingDTO>>> Browse(int current = FIRST_PAGE, int size = DEFAULT_PAGE_SIZE)
        {
            if (current < FIRST_PAGE)
            {
                return NotFound();
            }

            size = ValidatePageSize(size);

            var results = await _db.JobListings
                            .GetPage(current, size)
                            .ToListAsync();

            return Ok(results);
        }


        // GET api/<ValuesController>?category=0&page=1&size=10
        [HttpGet("Search/Category/{category}")]
        public async Task<ActionResult<List<JobListingDTO>>> CategorySearch(JobCategories category, int page = FIRST_PAGE, int size = DEFAULT_PAGE_SIZE)
        {
            if (page < FIRST_PAGE) 
            { 
                return NotFound(); 
            } 
            
            size = ValidatePageSize(size);

            var results = await _db.JobListings
                            .Where(j => j.Categories == category)
                            .GetPage(page, size)
                            .ToListAsync();

            return Ok(results);
        }


        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] JobListingDTO listing)
        {
            if (ModelState.IsValid)
            {
                _db.JobListings.Add(listing);
                await _db.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }


        // PUT api/<ValuesController>/Update/5
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] JobListingDTO updated)
        {
            var listing = await _db.JobListings.FindAsync(id);

            if (ModelState.IsValid && listing != null)
            {
                _db.JobListings.Update(listing, updated);
                await _db.SaveChangesAsync();

                return Ok(listing);
            }
            return NotFound();
        }


        // DELETE api/<ValuesController>/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var listing = await _db.JobListings.FindAsync(id);

            if (listing != null)
            {
                _db.JobListings.Remove(listing);
                await _db.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }



        private int ValidatePageSize(int size)
        {
            return (size < MIN_PAGE_SIZE || size > MAX_PAGE_SIZE) ? DEFAULT_PAGE_SIZE : size;
        }
    }
}
