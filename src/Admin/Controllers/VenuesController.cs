using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.RestApiClient;

namespace Admin.Controllers
{
    public class VenuesController : Controller
    {
        // GET: Venues

        public IActionResult Venues()
        {
            Value value = new Value();
            TicketApi a = new TicketApi();
            value.Venues = a.VenueGet();
            return View(value);
        }

        [HttpPost]
        public IActionResult DeleteVenue(int Foo)
        {
            TicketApi a = new TicketApi();
            a.VenueDelete(Foo);
            return View();
        }

    }
}