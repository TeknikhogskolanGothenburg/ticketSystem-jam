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
        public static int infoNumber;
        public static string infoMessage;


        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Checks if there is an existing purchaseobject. If not, a purchaseobject (value) and an Apiobject, is created.
        /// Then the database is called and existing Events is returned.
        /// </summary>
        /// <returns>Returns the Eventobjects to the view.</returns>
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
        /// <summary>
        /// Gives the customer a more detailed description on buttonclick.
        /// If the Id is clicked for the first time, a loop is getting its description from the EventSummaries-object.
        /// It it is clicked for the second time, message and number id deleted and the description is deleted from the view.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a description to the Customer.</returns>

        public IActionResult ShowInfo(int id)
        {
            if(id == infoNumber) {
                infoMessage = "";
                infoNumber = 0;
                return View("Tickets", value);
            }

            infoNumber = id;
            infoMessage = "";

            foreach (EventSummary x in value.EventSummaries)
            {
                if(x.TicketEventDateID == id)
                {
                    infoMessage = x.EventHtmlDescription;
                    ViewBag.InfoMessage = infoMessage;
                }
            }
            return View("Tickets", value);
        }

        /// <summary>
        /// Searchfield. If the Customer want to search for specific event, input is made and checked by a LIKE-sql query, 
        /// returning every event with the same lettercombination. If no comparison, it returns empty.
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns>Return every event that matches the inputstring.</returns>
        public IActionResult Search(string searchText)
        {
            if (searchText != null)
            {
                value.EventSummaries = ticketApi.GetSearchSummary(searchText);
                return View("Tickets", value);
            }
            else
            {
                return View("Tickets", value);
            }
        }

        public IActionResult GetAllEventDates()
        {
            ticketApi.GetAllEventDates();
            return View(value);
        }

    }
}
