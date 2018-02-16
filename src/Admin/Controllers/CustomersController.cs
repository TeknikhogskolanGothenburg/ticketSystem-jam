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

        public ActionResult FindCustomer(string searchString)
        {
            value = new Value();
            if (searchString != null)
            {
                value.TicketTransaction = ticketApi.GetCustomer(searchString);
            }
            return View(value);
        }

        [HttpPost]
        public ActionResult CustomerInfo(int id)
        {
            value.TicketBuyer = ticketApi.GetTicketTransactions(id);
            return View();
        }
    }
}