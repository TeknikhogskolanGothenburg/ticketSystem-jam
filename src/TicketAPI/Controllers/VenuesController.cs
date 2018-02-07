using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DatabaseRepository;

namespace TicketAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Venues")]
    public class VenuesController : Controller
    {
        // GET: api/Venues
        [HttpGet]
        public List<Venue> Get()
        {
            TicketDatabase findVenues = new TicketDatabase();
            List<Venue> values = findVenues.VenuesFindAll();
            return values;
        }

        // GET: api/Venues/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "hej";
        }
        
        // POST: api/Venues
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Venues/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
