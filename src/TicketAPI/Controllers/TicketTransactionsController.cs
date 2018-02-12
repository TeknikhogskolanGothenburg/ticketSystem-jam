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
    [Route("api/TicketTransactions")]
    public class TicketTransactionsController : Controller
    {
        // GET: api/TicketTransactions
        [HttpGet]
        public List<TicketTransaction> Get()
        {
            return GetAllTicketTransactions();
        }

        // GET: api/TicketTransactions/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return GetTicketTransactions(id);
        }
        
        // POST: api/TicketTransactions
        [HttpPost]
        public void Post([FromBody]TicketTransaction ticketTransaction)
        {
            return TicketTransactionsAdd(ticketTransaction);
        }
        
        // PUT: api/TicketTransactions/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TicketTransaction ticketTransaction)
        {
            return TicketTransactionUpdate(id, ticketTransaction);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            return DeleteTicketTransactions(id);
        }
    }
}
