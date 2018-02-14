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
        Value value = new Value();

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
            value.Venues = ticketApi.GetAllVenues();
            return View(value);
        }

        // GET: TicketEventDates/Details/5
        public ActionResult AddTicketEventDate(TicketEventDate ticketEventDate)
        {
            return View();
        }

    }
}