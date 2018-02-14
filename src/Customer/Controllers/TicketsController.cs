using System.Diagnostics;
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
        private EventSummary sum;
        private List<EventSummary> shoppingCart;

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
           var  ShoppingCart = new List<EventSummary>();
            shoppingCart = ShoppingCart;
             sum = ticketApi.GetSummary(2);//byt id manuellt tills vi löst länken från View till hit.
            shoppingCart.Add(sum);
           
            //skapa shoppingcart och adda (value)
            // return View(); för att fortsätta shoppa.
            return RedirectToAction("Tickets");
        }


    }
}
