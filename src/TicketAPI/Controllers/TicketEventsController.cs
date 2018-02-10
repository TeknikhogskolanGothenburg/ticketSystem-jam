using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DatabaseRepository;
using Newtonsoft.Json;
using ClassLibrary;

namespace TicketAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/TicketEvents")]
    public class TicketEventsController : Controller
    {
        TicketDatabase tdb = new TicketDatabase ();

        // GET: api/TicketEvents
        [HttpGet]
        public List<TicketEvent> Get()
        {
            return tdb.GetAllEvents();
        }

        // GET: api/TicketEvents/5
        [HttpGet("{id}")]
        public TicketEvent Get(int id)
        {
            return tdb.GetEvents(id);
        }

        // POST: api/TicketEvents
        [HttpPost]
        public TicketEvent Post([FromBody]TicketEvent ticketEvent)
        {
            return tdb.EventsAdd(ticketEvent);
        }

        // PUT: api/TicketEvents/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TicketEvent ticketEvent)
        {
            tdb.EventsUpdate(id, ticketEvent);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            tdb.DeleteEvents(id);
        }
    }
}
