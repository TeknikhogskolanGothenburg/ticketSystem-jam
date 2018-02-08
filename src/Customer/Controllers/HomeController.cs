using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Customer.Models;
using ClassLibrary;
using TicketSystem.RestApiClient;

namespace Customer.Controllers
{
    public class HomeController : Controller
    {
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
            TicketEvent value = new TicketEvent();
            TicketApi a = new TicketApi();
            value.EventName = a.TicketGet();
           
            return View(value);
        }
    }
}
