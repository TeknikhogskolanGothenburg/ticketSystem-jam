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
        public ActionResult AddTicketEventDate()
        {
            value.EventSummaries = ticketApi.GetAllSummary();
            return View(value);
        }

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

        [HttpPost]
        public ActionResult DeleteTicketEventDate(int eventID)
        {
            return View();
        }
    }
}