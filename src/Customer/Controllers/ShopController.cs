//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using ClassLibrary;
//using TicketSystem.RestApiClient;

//namespace Customer.Controllers
//{
//    public class ShopController : Controller
//    {
//        private static Value value;
//        private static TicketApi ticketApi;
//        public SeatsAtEventDate SeatsAtEventDate;


//        public ActionResult Shop()
//        {
//            Value value = new Value();
//            TicketApi a = new TicketApi();
//            value.Events = a.GetAllEvents();

//            return View(value);
//        }
//        // POST: Home/Shop
//        [HttpPost] 
       
//        //[HttpPut]
   

//        // POST: Home/Shop
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                // TODO: Add update logic here

//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Shop/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: Shop/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
//        // GET: Shop/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }
//        // GET: Shop
//        public ActionResult Index()
//        {
//            return View();
//        }

//        // GET: Shop/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: Shop/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//    }
//}