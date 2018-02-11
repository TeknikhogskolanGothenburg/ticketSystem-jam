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
        TicketDatabase tdb = new TicketDatabase { };

        // GET: api/TicketEventDates
        [HttpGet]
        public List<TicketEventDate> Get()
        {
            return tdb.GetAllEventDates();
        }

        // GET: api/TicketEventDates/5
        [HttpGet("{id}")]
        public TicketEventDate Get(string id)
        {
            return tdb.GetEventDates(id);
        }        

        [HttpPost]
        public TicketEventDate Post([FromBody]TicketEventDate ticketEventDate)
        {
            return tdb.EventDatesAdd(ticketEventDate);                      
        }

        // PUT: api/TicketEventDates/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TicketEventDate ticketEventDate)
        {
            tdb.EventDatesUpdate(id, ticketEventDate);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            tdb.DeleteEventDates(id);
        }
    }
}
