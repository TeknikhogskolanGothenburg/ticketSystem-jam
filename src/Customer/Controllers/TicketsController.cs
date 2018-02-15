using Microsoft.AspNetCore.Mvc;
using ClassLibrary;
using TicketSystem.RestApiClient;


namespace Customer.Controllers
{
    public class TicketsController : Controller
    {
        public static Value value;
        public static TicketApi ticketApi;
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

            value.EventSummaries = ticketApi.GetAllSummary();
            ViewBag.Message = "";
            return View(value);
        }

        public IActionResult GetAllEventDates()
        {
            ticketApi.GetAllEventDates();
            return View(value);
        }

    }
}
