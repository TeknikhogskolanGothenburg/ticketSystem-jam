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

        

            /// <summary>
            /// Method that creates a venueobject and uploads all existing Venues.
            /// </summary>
            /// <returns>Return the view for further choises.</returns>
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
        /// <summary>
        /// Method that takes an id and deletes that Venue in the database. Then it returns an updates list to the view.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns an updated venuelist after delete is made.</returns>
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
        /// <summary>
        /// Method that adds a Venueobject to the database, and then returns a list of venues to the view.
        /// </summary>
        /// <param name="venue"></param>
        /// <returns>Returns all venues.</returns>
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
        /// <summary>
        /// Method that takes the selected id and edited input and stores it in the database. Then it returns an updated list to the view.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="venue"></param>
        /// <returns>Returns a fresh venuelist after editing.</returns>
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
        /// <summary>
        /// Method that takes the selected id and redirects it to the EditVenue-method.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Redirects the Administrator to the Editview.</returns>

        public IActionResult DropdownChanged(int id)
        {
            value.Venue = ticketApi.GetVenues(id);
            return RedirectToAction("EditVenues", "Venues");
        }
    }
}

