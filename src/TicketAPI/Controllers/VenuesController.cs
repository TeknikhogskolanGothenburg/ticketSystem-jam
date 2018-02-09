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

        TicketDatabase tdb = new TicketDatabase();
        // GET: api/Venues
        [HttpGet]
        public List<Venue> Get()
        {
            List<Venue> values = tdb.GetAllVenues();
            return values;
        }

        // GET: api/Venues/Arenans namn
        [HttpGet("{venueName}")]
        public Venue Get(string venueName)
        {
            Venue venue = tdb.GetVenues(venueName);
            return venue;
        }

        //test
        // POST: api/Venues
        /// <summary>
        /// Post-method for Administrators to insert Venues to the SQL-database.
        /// </summary>
        /// <param name="values"></param>
        [HttpPost]
        public void Post([FromBody]Venue venue)
        {
            tdb.VenuesAdd(venue);
        }

        // PUT: api/Venues/5
        [HttpPut("{venueName}")]
        public void Put(string venueName, [FromBody]ClassLibrary.Venue venue)
        {
            tdb.VenuesUpdate(venueName, venue);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
            tdb.DeleteVenue(id);
        }
    }
}
