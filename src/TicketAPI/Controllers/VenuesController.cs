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
        [HttpGet("{id}")]
        public Venue Get(int id)
        {
            Venue venue = tdb.GetVenues(id);
            return venue;
        }

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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Venue venue)
        {
            tdb.VenuesUpdate(id, venue);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            tdb.DeleteVenue(id);
        }
    }
}
