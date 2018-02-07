using System.Collections.Generic;
using ClassLibrary;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DatabaseRepository;

namespace TicketAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Venues")]
    public class VenuesController : Controller
    {
        
        private TicketDatabase tdb;

        // GET: api/Venues
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Venues/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
         

        // POST: api/Venues
        /// <summary>
        /// Post-method for Administrators to insert Venues to the SQL-database.
        /// </summary>
        /// <param name="values"></param>
        [HttpPost]
        public void Post([FromBody]Venue values)
        {
            tdb = new TicketDatabase();

            // Content-Type: application/json           
            // Postinput  {"VenueName":"Frihamnen", "Address":"Frihamnen", "City":"Goteborg", "Country":"Sverige"}
            tdb.VenueAdd(values.VenueName, values.Address, values.City, values.Country);
           
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
