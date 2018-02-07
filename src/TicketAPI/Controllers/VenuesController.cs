﻿using System.Collections.Generic;
using ClassLibrary;
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
            TicketDatabase v = new TicketDatabase();
            List<Venue> values = v.VenuesFindAll();
            return values;
        }

        // GET: api/Venues/5
        [HttpGet("{id}")]
        public Venue Get(string id)
        {
            TicketDatabase v = new TicketDatabase();
            Venue venue = v.VenuesFind(id);
            return venue;

        }
         

        // POST: api/Venues
        /// <summary>
        /// Post-method for Administrators to insert Venues to the SQL-database.
        /// </summary>
        /// <param name="values"></param>
        [HttpPost]
        public void Post([FromBody]Venue values)
        {
            TicketDatabase addVenue = new TicketDatabase();
            addVenue.VenueAdd(values.VenueName, values.Address, values.City, values.Country);

            // Förslag på inputsträngar. OBS! ANVÄND INTE Å Ä Ö, med nedan kod.
            // Content-Type: application/json           
            // Postinput  {"VenueName":"Frihamnen arena", "Address":"Frihamnen 1", "City":"Goteborg", "Country":"Sverige"}

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
