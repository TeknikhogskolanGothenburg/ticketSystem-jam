using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary;
using TicketSystem.RestApiClient;

namespace Customer.Controllers
{
    public class ShopController : Controller
    {
        private static Value value;
        private static TicketApi ticketApi;
        public SeatsAtEventDate SeatsAtEventDate;



        // POST: Home/Shop
        [HttpPost]  //Min tanke är att när kunden klickar på BUY-knappen slussas man till "Tickets PurchasedTickets" och en Seat läggs till i sql.
        // sen ska den Redirecta till "ConfirmEventWithSeat" och göra en "Http.Put" och koppla TicketEventDateID med SeatID.
        public ActionResult BookSeat(int buttonclick)
        {
            try
            {
                SeatsAtEventDate.TicketEventDateId = buttonclick;
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
        //[HttpPut]
        public ActionResult ConfirmEventWithSeat(Tickets SeatId)
        {
        //    try
        //    {
  
        //    }
        //    catch
        //    {
                return View();
        //    }
        }

        // POST: Home/Shop
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Shop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shop/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: Shop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }

        // GET: Shop/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Shop/Create
        public ActionResult Create()
        {
            return View();
        }

    }
}