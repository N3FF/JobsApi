using JobsApi.Data.Enums;
using JobsApi.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobsApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        public JobsContext _db { get; }

        public ListingController(JobsContext db)
        {
            _db = db;
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobListing>> View(int id)
        {
            var listing = await _db.JobListings.FindAsync(id);

            if(listing == null)
            {
                return NotFound();
            }

            return Ok(listing);
        }


        // GET api/<ValuesController>/Page/5
        [HttpGet("Page/{index}")]
        public async Task<ActionResult<List<JobListing>>> Browse(int index = 1)
        {
            if (index < 1)
            {
                return NotFound();
            }

            index = index - 1;
            const int PAGE_SIZE = 2;
            int count = await _db.JobListings.CountAsync();

            if (count > PAGE_SIZE * index)
            {
                var listings = await _db.JobListings.Skip(index * PAGE_SIZE).Take(PAGE_SIZE).ToListAsync();
                return Ok(listings);
            }

            return Ok(new List<JobListing>());
        }


        // GET api/<ValuesController>?category=0&index=1
        [HttpGet]
        public async Task<ActionResult<List<JobListing>>> Search(PostCategories category, int index = 1)
        {
            if (index < 1)
            {
                return NotFound();
            }

            index = index - 1;
            const int PAGE_SIZE = 2;
            int count = await _db.JobListings.CountAsync();

            if (count > PAGE_SIZE * index)
            {
                return Ok(await _db.JobListings.Where(j => j.Categories == category).Skip(index * PAGE_SIZE).Take(PAGE_SIZE).ToListAsync());
            }

            return Ok(new List<JobListing>());
        }


        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] JobListing listing)
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
        public async Task<ActionResult> Put(int id, [FromBody] JobListing update)
        {
            var listing = await _db.JobListings.FindAsync(id);
            if (ModelState.IsValid && listing != null)
            {
                listing.Title = update.Title;
                listing.Description = update.Description;
                listing.Categories = update.Categories;
                listing.Location = update.Location;
                listing.ContactInfo = update.ContactInfo;
                listing.ImageUris = update.ImageUris;
                _db.JobListings.Update(listing);
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
    }
}
