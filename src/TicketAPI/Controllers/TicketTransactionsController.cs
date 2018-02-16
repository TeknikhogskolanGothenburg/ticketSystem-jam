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
        TicketDatabase tdb = new TicketDatabase { };
        // GET: api/TicketTransactions
        [HttpGet]
        public List<TicketTransaction> Get()
        {
            return tdb.GetAllTicketTransactions();
        }

        // GET: api/TicketTransactions/5
        [HttpGet("{id}")]
        public TicketTransaction Get(int id)
        {
            return tdb.GetTicketTransactions(id);
        }

        // POST: api/TicketTransactions
        [HttpPost]
        public TicketTransaction Post([FromBody]TicketTransaction ticketTransaction)
        {
            return tdb.TicketTransactionsAdd(ticketTransaction);
        }

        // PUT: api/TicketTransactions/5
        [HttpPut("{id}")]
        public TicketTransaction Put(int id, [FromBody]TicketTransaction ticketTransaction)
        {
            return tdb.TicketTransactionUpdate(id, ticketTransaction);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            tdb.DeleteTicketTransactions(id);
        }

        [HttpGet("User/{query}")]
        public List<TicketTransaction> Get(string query)
        {
            return tdb.GetCustomer(query);
        }

        //[HttpGet("User/{id}")]
        //public List<EventSummary> GetTickets(int id)
        //{
        //    return tdb.FindTicketBuyer(id);
        //}

        [HttpPost("Seat")]
        public SeatsAtEventDate Post([FromBody]EventSummary eventSummary)
        {
            return tdb.PurchasedSeats(eventSummary);
        }


        [HttpPost("Ticket")]
        public Tickets Post([FromBody]SeatsAtEventDate seatsAtEventDate)
        {
            return tdb.PurchasedTickets(seatsAtEventDate);
        }

        [HttpPost]
        public TicketToTransaction Post([FromBody]TicketTransaction ticketTransaction, Tickets ticket)
        {
            return tdb.AddTicketBuyer(ticketTransaction, ticket);
        }
    }
}
