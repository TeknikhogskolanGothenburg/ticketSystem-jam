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
        Value value = new Value();
        // GET: Venues

        public IActionResult Venues(int Foo)
        {
            TicketApi a = new TicketApi();
            if (Foo == 0)
            {
                value.Venues = a.VenueGet();
                return View(value);
            }
            else
            {
                a.VenueDelete(Foo);
                value.Venues = a.VenueGet();
                return View(value);
            }
        }

        //TicketApi a = new TicketApi();
        //a.VenueDelete(Foo);
        //    value.Venues = a.VenueGet();
        //    return View(value);

    }
}