using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DatabaseRepository;
using Newtonsoft.Json;

namespace TicketAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/TicketEvents")]
    public class TicketEventsController : Controller
    {
        // GET: api/TicketEvents
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value", "value2" };
        }

        // GET: api/TicketEvents/5
        [HttpGet("{id}")]
        public List<ClassLibrary.TicketEvent> Get(string id)
        {
            TicketDatabase ticket = new TicketDatabase();
            return ticket.EventFind(id);
        }
        
        // POST: api/TicketEvents
        [HttpPost]
        public void Post([FromBody]ClassLibrary.TicketEvent ticketEvent)
        {            
            TicketDatabase ticket = new TicketDatabase();
            ticket.EventAdd(ticketEvent.EventName, ticketEvent.EventHtmlDescription);
        }
        
        // PUT: api/TicketEvents/5
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
