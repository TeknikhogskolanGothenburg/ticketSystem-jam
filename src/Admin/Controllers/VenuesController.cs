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
        private static Value value;
        private static TicketApi ticketApi;

        public IActionResult Venues()
        {
            if(value == null)
            {
                value = new Value();
            }
            if(ticketApi == null)
            {
                ticketApi = new TicketApi();
            }

            value.Venues = ticketApi.VenueGet();
            return View(value);
        }

        public IActionResult DeleteVenue(int id)
        {
            ticketApi.VenueDelete(id);
            return RedirectToAction("Venues", "Venues");
        }

        public IActionResult AddVenue(Venue venue)
        {
            ticketApi.VenueAdd(venue);
            return RedirectToAction("Venues", "Venues");
        }

    }
}


// Hej
// Är du från Africa eller?

// - Det Angola inte daj!