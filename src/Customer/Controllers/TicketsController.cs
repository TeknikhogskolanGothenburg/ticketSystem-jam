﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Customer.Models;
using ClassLibrary;
using TicketSystem.RestApiClient;
using System.Resources;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;


namespace Customer.Controllers
{
    public class TicketsController : Controller
    {
        private static Value value;
        private static TicketApi ticketApi;
        public SeatsAtEventDate SeatsAtEventDate;
        public TicketEvent TicketEvent;
   
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tickets()
        {
            if (value == null)
            {
                value = new Value();
            }
            if (ticketApi == null)
            {
                ticketApi = new TicketApi();
            }

            value.EventSummarylist = ticketApi.GetAllSummary();

           //  List<EventSummary> sum = ticketApi.GetAllSummary();
            return View(value);
        }

        public IActionResult GetAllEventDates()
        {
            ticketApi.GetAllEventDates();
            return View(value);
        }
        public IActionResult GetSummary(int id)
        {
            id = 1;
            value.EventSummaryprop = ticketApi.GetSummary(id);
            return View(value);
        }


    }
}
