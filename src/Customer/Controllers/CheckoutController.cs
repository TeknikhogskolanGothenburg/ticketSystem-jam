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
        public EventSummary b;
        public TicketEventDate es;


        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Puts chosen ticket (= eventSummary) in the Checkout view and saves it in a CartSummary-object.
        /// </summary>
        /// <param name="buttonclick"></param>
        /// <returns> Returns actual cart to the buyer.</returns>

        public IActionResult Checkout(string buttonclick)
        {
            if (value == null)
            {
                value = new Value();
            }
            if (ticketApi == null)
            {
                ticketApi = new TicketApi();
            }

            if (buttonclick != null)
            {
                int id = int.Parse(buttonclick);
                EventSummary eventSummary = ticketApi.GetSummary(id);
                value.CartSummary.Add(eventSummary);
                return View("Checkout", value);
            }
            else
            {
                return View("Checkout", value);
            }
        }
        /// <summary>
        /// On buttonclick, the ticket is removed from the view and removed from the CartSummary-object.
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns>Returns to the Checkout view with the updated tickets.</returns>

        public IActionResult DeleteTicketFromCart(int eventID)
        {
            for (int i = 0; i < value.CartSummary.Count; i++)
            {
                if (i == eventID)
                {
                    value.CartSummary.Remove(value.CartSummary[i]);
                    return View("Checkout", value);
                }
            }
            return View("Checkout", value);
        }

        /// <summary>
        /// On GoToPayment-buttonclick, the shippinginformation stored in TicketBuyer is sent to SQL and given a TransactionID. Then we loop the Shoppingcart in three steps: 
        /// Adding a seatID to the ticketeventdate. Adding a ticketID to the seatID. Last, connecting the ticketID to the TransactionID.
        /// </summary>
        /// <param name="ticketBuyer"></param>
        /// <returns>Returns an orderconfirmation.</returns>
        public IActionResult GoToPayment(TicketTransaction ticketBuyer)
        {

            value.TicketBuyer = ticketApi.TicketTransactionAdd(ticketBuyer);  // Lägger till köpare = TransactionID

            foreach (EventSummary id in value.CartSummary)
            {
                SeatsAtEventDate e = ticketApi.PurchasedSeats(id);  // Lägger till SeatID
                Tickets x = ticketApi.PurchasedTickets(e);         // Lägger till TicketID

                TicketToTransaction ticketToTransaction = new TicketToTransaction();
                ticketToTransaction.TransactionID = value.TicketBuyer.TransactionID;
                ticketToTransaction.TicketID = x.TicketId;

                ticketApi.AddTicketBuyer(ticketToTransaction);  // Kopplar TicketID + TransactionID  
            }

            return View("PurchaseCompleted", value);
        }

    }
}
