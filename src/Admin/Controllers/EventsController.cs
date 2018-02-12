﻿using System;
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
            value.Events = ticketApi.GetAllEvents();
            return View(value);
        }

        // Delete
        public IActionResult DeleteEvents(int id)
        {
            if (id == 0)
            {
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
        public IActionResult AddEvents(TicketEvent ticketEvent)
        {
            if (ticketEvent.EventName != null)
            {
                ticketApi.EventsAdd(ticketEvent);
                value.Events = ticketApi.GetAllEvents();
                if (Response.StatusCode == 200)
                {
                    ViewBag.StatusMessage = "Event Added!";
                }
                else
                {
                    ViewBag.StatusMessage = "Something went wrong...";
                }
                return View(value);
            }
            else
            {
                ViewBag.StatusMessage = "";
                return View(value);
            }
        }

        // GET: Events/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

    }
}