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
        public IActionResult TicketsAdd(string buttonclick)
        {
            int id = int.Parse(buttonclick);
            TicketEventDate e = ticketApi.GetEventDates(id);  // att göra: fixa att buttonclicket får med sig id
            value.Cart.Add(e);
            EventSummary es = ticketApi.GetSummary(id);
            value.CartSummary.Add(es);
            //return RedirectToRoute(
            //    (new
            //    {
            //        controller = "Checkout",
            //        action = "Checkout"

            //    }, value));



             return View("Tickets",value);


        }

        public IActionResult GetAllEventDates()
        {
            ticketApi.GetAllEventDates();
            return View(value);
        }
        public IActionResult GetSummary(int id)
        {
           ////var  ShoppingCart = new List<EventSummary>();
           //// shoppingCart = ShoppingCart;
           ////  sum = ticketApi.GetSummary(2);//byt id manuellt tills vi löst länken från View till hit.
           //// shoppingCart.Add(sum);
           
            //skapa shoppingcart och adda (value)
            // return View(); för att fortsätta shoppa.
            return RedirectToAction("Tickets");
        }


    }
}
