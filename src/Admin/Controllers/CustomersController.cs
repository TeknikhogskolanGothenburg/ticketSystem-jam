using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary;
using TicketSystem.RestApiClient;

namespace Admin.Controllers
{
   
    public class CustomersController : Controller
    {
        TicketApi ticketApi = new TicketApi();
        static Value value = new Value();

        // GET: Customer
        public ActionResult Customers()
        {
            return View();
        }

        /// <summary>
        /// Method searches the stringinput with a SELECT - LIKE query, returning all hit-results.
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>Returns every Customer that matches the inputstring.</returns>
        public ActionResult FindCustomer(string searchString)
        {
            value = new Value();
            if (searchString != null)
            {
                value.TicketTransaction = ticketApi.GetCustomer(searchString);
            }
            return View(value);
        }
        /// <summary>
        /// Method that get Customerinfo based on selected TransactionID
        /// </summary>
        /// <param name="id">TransactionID</param>
        /// <returns>TicketEventDateID, EventName, EventHtmlDescription, VenueName, EventStartDateTime</returns>
        [HttpPost]
        public ActionResult CustomerInfo(int id)
        {
            value.TicketBuyer = ticketApi.GetTicketTransactions(id);
            value.EventSummaries = ticketApi.FindTicketBuyer(id);
            return View(value);
        }
        /// <summary>
        /// Method that deletes Ticket based on selected TicketEventDateID.
        /// </summary>
        /// <param name="id">TicketEventDateID</param>
        /// <returns>Redirects to FindCustomer</returns>

        [HttpPost]
        public ActionResult RemoveCustomerTicket(int id)
        {
            ticketApi.DeleteEventDates(id);
            return Redirect("FindCustomer");
        }
    }
}