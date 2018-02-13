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

        // "Index"
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
            value.Venues = ticketApi.GetAllVenues();
            return View(value);
        }

        // Delete
        public IActionResult DeleteVenues(int id)
        {
            if(id != 0)
            {
                ticketApi.DeleteVenues(id);
                value.Venues = ticketApi.GetAllVenues();
                return View(value);
            }
            else
            {
                return View(value);
            }
        }

        // Add
        public IActionResult AddVenues(Venue venue)
        {
            if(venue.VenueName == null)
            {
                return View(value);
            }
            else
            {
                ticketApi.VenueAdd(venue);
                value.Venues = ticketApi.GetAllVenues();
                return View(value);
            }
        }

        // Edit
        public IActionResult EditVenues(int id, Venue venue)
        {
            if(id == 0)
            {
                return View(value);
            }
            else
            {
                ticketApi.VenuesUpdate(id, venue);
                value.Venues = ticketApi.GetAllVenues();
                return View(value);
            }
        }


        public IActionResult DropdownChanged(int id)
        {
            value.Venue = ticketApi.GetVenues(id);
            return RedirectToAction("EditVenues", "Venues");
        }
    }
}

