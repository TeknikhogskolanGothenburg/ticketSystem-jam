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
    public class TicketEventDatesController : Controller
    {
        TicketApi ticketApi = new TicketApi();
        static Value value;

        // GET: TicketEventDates
        /// <summary>
        /// Method that uploads all Events and Venues for further action from the Administrator.
        /// </summary>
        /// <returns>Returns the view for further choices.</returns>
        public ActionResult TicketEventDates()
        {
            if (value == null)
            {
                value = new Value();
            }
            if (ticketApi == null)
            {
                ticketApi = new TicketApi();
            }
            value.Events = ticketApi.GetAllEvents();
            value.Venues = ticketApi.GetAllVenues();
            value.TicketEventDate = ticketApi.GetAllEventDates();
            return View(value);
        }

        // GET: TicketEventDates/Details/5   
        /// <summary>
        /// Method that uploads all existing TicketEvents.
        /// </summary>
        /// <returns>Returns all TicketEvents to the Administrator.</returns>
        public ActionResult AddTicketEventDate()
        {
            value.EventSummaries = ticketApi.GetAllSummary();
            return View(value);
        }

        /// <summary>
        /// Method that connects an event with a venue and a date, and saves it in the database.
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="venueID"></param>
        /// <param name="dateTime"></param>
        /// <returns>Returns to the AddTicketEventDate method, that shows all ticketevents.</returns>
        [HttpPost]
        public ActionResult CreateTicketEventDate(int eventID, int venueID, DateTime dateTime)
        {
            TicketEventDate newDate = new TicketEventDate
            {
                TicketEventID = eventID,
                VenueId = venueID,
                EventStartDateTime = dateTime
            };
            ticketApi.EventDatesAdd(newDate);
            return Redirect("AddTicketEventDate");
        }

        /// <summary>
        /// Method that uploads all TicketEventDates to the view.
        /// </summary>
        /// <returns>Returns an actual TicketEventDates list. </returns>
        public ActionResult DeleteTicketEventDate()
        {
            value.EventSummaries = ticketApi.GetAllSummary();
            return View(value);
        }

        /// <summary>
        /// Method that deletes selcted TicketEventDate from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns an updated list.</returns>
        [HttpPost]
        public ActionResult RemoveTicketEventDate(int id)
        {
            ticketApi.DeleteEventDates(id);
            return Redirect("DeleteTicketEventDate");
        }
    }
}