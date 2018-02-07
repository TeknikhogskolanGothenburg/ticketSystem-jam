using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary;
using TicketSystem.DatabaseRepository;

namespace TicketAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/TicketEventDates")]
    public class TicketEventDatesController : Controller
    {
        // GET: api/TicketEventDates
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TicketEventDates/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/TicketEventDates
        /// <summary>
        /// Post-method to link EventId and VenueId with Date.
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody]TicketEventDate value)
        {
            TicketDatabase addEventDate = new TicketDatabase();
            addEventDate.EventDateAdd(value.TicketEventID, value.VenueId, value.EventStartDateTime);

            // Förslag på inputsträngar. 
            // Content-Type: application/json           
            // Postinput  {"TicketEventID":"1", "VenueId":"1", "EventStartDateTime":"2018-05-20"}
            // Postinput  {"TicketEventID":"2", "VenueId":"1", "EventStartDateTime":"2018-04-10"}
            // Postinput  {"TicketEventID":"1", "VenueId":"2", "EventStartDateTime":"2018-06-21"}
        }

        // PUT: api/TicketEventDates/5
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
