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

        public IActionResult GoToPayment(TicketTransaction TicketBuyer)  
        {
            
           
            ticketApi.TicketTransactionAdd(TicketBuyer);  // Lägger till köpare = TransactionID
            

            foreach (EventSummary id in value.CartSummary)
            {
                SeatsAtEventDate e = ticketApi.PurchasedSeats(id);  // Lägger till SeatID
               ticketApi.PurchasedTickets(e);                          // Lägger till TicketID
                
                ticketApi.AddTicketBuyer(value.TicketBuyer, value.Tickets);  // Kopplar TicketID + TransactionID  FUNKAR EJ
            }
          

            return View("Checkout", value);
        }

    }
}
