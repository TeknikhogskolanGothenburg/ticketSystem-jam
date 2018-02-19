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
    public class EventsController : Controller
    {
        private static Value value;
        private static TicketApi ticketApi;

        // GET: Events
        /// <summary>
        /// Startmethod that creates an Eventsobject and Apiobject, and then returns to the view for further action from the Admin.
        /// </summary>
        /// <returns>Returns the Administrator view.</returns>
        public IActionResult Events()
        {
            if (value == null)
            {
                value = new Value();
            }
            if (ticketApi == null)
            {
                ticketApi = new TicketApi();
            }


            return View(value);
        }

        // Delete
        /// <summary>
        /// Method that calls all existing Events to the view, and deletes selected Event, then gets a new Evenlist with the remaining Events.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the actual Eventlist.</returns>
        public IActionResult DeleteEvents(int id)
        {
            if (id == 0)
            {
                value.Events = ticketApi.GetAllEvents();
                return View(value);
            }
            else
            {
                ticketApi.DeleteEvent(id);
                value.Events = ticketApi.GetAllEvents();
                return View(value);
            }
        }

        // Add
        /// <summary>
        /// Method that saves input to a ticketEventobject and saves it in SQL.
        /// </summary>
        /// <param name="ticketEvent"></param>
        /// <returns>Returns an updates Eventlist.</returns>
        public IActionResult AddEvents(TicketEvent ticketEvent)
        {
            if (ticketEvent.EventName != null)
            {
                ticketApi.EventsAdd(ticketEvent);
                value.Events = ticketApi.GetAllEvents();
                return View(value);
            }
            else
            {
                ViewBag.StatusMessage = "";
                return View(value);
            }
        }

        // Edit
        /// <summary>
        /// Method that updates the existing event in the database, with new inputstring. The updates list is the returned to the view.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ticketEvent"></param>
        /// <returns>Returns an updated eventlist.</returns>
        public IActionResult EditEvents(int id, TicketEvent ticketEvent)
        {            
            if (id == 0)
            {
                value.Events = ticketApi.GetAllEvents();
                return View(value);
            }
            else
            {
                ticketApi.EventsUpdate(id, ticketEvent);
                value.Events = ticketApi.GetAllEvents();
                return View(value);
            }
        }
    }
}