using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Customer.Models;
using ClassLibrary;
using TicketSystem.RestApiClient;

namespace Customer.Controllers
{
    public class HomeController : Controller
    {
        private static Value value;
        private static TicketApi ticketApi;
        public SeatsAtEventDate SeatsAtEventDate;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Shop()
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

        public IActionResult GetAllEvents()
        {
         
            ticketApi.GetAllEvents();
            return View( value);// testat både Redirect och View på alla . Vi får gå igenom vad skillnaden är.
        }

        public IActionResult GetAllEventDates()
        {
  
            ticketApi.GetAllEventDates();
            return RedirectToAction("Shop", "Home");
        }

        public IActionResult GetAllVenues()
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


    }
}
