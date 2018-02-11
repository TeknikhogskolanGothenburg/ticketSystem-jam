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
            Value value = new Value();
            TicketApi a = new TicketApi();
            value.Events = a.EventGet();

            return View(value);
        }
        [HttpPost]  //Min tanke är att när kunden klickar på BUY-knappen slussas man till "Tickets PurchasedTickets" och en Seat läggs till i sql.
        // sen ska den Redirecta till "ConfirmEventWithSeat" och göra en "Http.Put" och koppla TicketEventDateID med SeatID.
        public IActionResult BookSeat(TicketEventDate ticketEventDate)
        {
            try
            {
                SeatsAtEventDate.TicketEventDateId = ticketEventDate.TicketEventDateID;
                // int SeatID = 1;

                if (value == null)
                {
                    value = new Value();
                }
                if (ticketApi == null)
                {
                    ticketApi = new TicketApi();
                }

                value.Tickets = ticketApi.PurchasedTickets(SeatsAtEventDate);
                return View();
                //return RedirectToAction(ConfirmEventWithSeat(value.Tickets.SeatId));
            }
            catch
            {
                return View();

            }
        }
    }
}
