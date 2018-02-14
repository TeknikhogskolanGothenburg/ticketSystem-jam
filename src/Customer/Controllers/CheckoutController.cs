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
    public class CheckoutController : Controller
    {
        public static Value value;
        public static TicketApi ticketApi;
        public SeatsAtEventDate SeatsAtEventDate;
        public TicketEvent TicketEvent;
        public  EventSummary b;
        public TicketEventDate es;


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Checkout(int id)
        {
            if (value == null)
            {
                value = new Value();    // får inte med mig Cart och CartSummary vid buttonclick till Go To Cart
            }
            if (ticketApi == null)          // detta är en nödlösning för att komma vidare.
            {
                ticketApi = new TicketApi();
            }
            EventSummary es = ticketApi.GetSummary(1);
            TicketEventDate b = ticketApi.GetEventDates(1);
            value.Cart.Add(b);

            value.CartSummary.Add(es);
            return View("Checkout", value);
        }

        public IActionResult DeleteTicketFromCart(List<EventSummary> item)
        {

             // gör metod


            return View();
        }
        public IActionResult TicketsAddToCart(int id)
        {
            id = 1;
            EventSummary es = ticketApi.GetSummary(id);  // försökte lägga Jakobs metod i denna Controller. Tänkte att det skulle underlätta
            TicketEventDate b = ticketApi.GetEventDates(id); // att få med sig innehållet i value, men jag fastnar hela tiden
            value.Cart.Add(b);                      // på rad 57 "object not set to an instance of...."
           
            value.CartSummary.Add(es);
            // return RedirectToRoute("Checkout/Checkout", value);

            return View("Checkout", value);


        }
        public IActionResult GoToPayment()
        {

           
            //gör metod

            return View();
        }

    }
}
