using JobsApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ListingDTO Get(int id)
        {
            //Testing Get
            List<ListingDTO> listings = new List<ListingDTO>();

            for (int i = 0; i < 10; i++)
            {
                listings.Add(new ListingDTO()
                {
                    UserId = Guid.NewGuid(),
                    Title = $"Title for {id}",
                    ContactInfo = i.ToString(),
                    Description = $"Description for {id}",
                    Images = new List<string>() { "Image1" },
                    ListingTime = DateTime.Now.AddDays(i),
                    Location = DateTime.Now.AddDays(i).DayOfWeek.ToString()
                });
            }

            // If Id isn't found
            ListingDTO def = new ListingDTO()
            {
                UserId = new Guid(),
                Title = $"ID {id} NOT FOUND",
                Description = string.Empty,
                Images = new(),
                ListingTime = DateTime.MinValue,
                Location = string.Empty,
                ContactInfo = string.Empty
            };

            return listings.FirstOrDefault(l => l.ContactInfo == id.ToString()) ?? def;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] ListingDTO post)
        {
            Debug.WriteLine(JsonConvert.SerializeObject(post));
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
