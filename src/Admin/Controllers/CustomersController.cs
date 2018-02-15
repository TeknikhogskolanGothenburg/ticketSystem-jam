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
            value.TicketTransaction = ticketApi.GetAllTicketTransactions();
            return View(value);
        }
                
        public ActionResult FindCustomer(string name)
        {
            value.TicketTransaction = ticketApi.GetAllTicketTransactions();
            if (name )
            return View();
        }


        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }



        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

    }
}