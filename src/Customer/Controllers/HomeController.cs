using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{

    /// <summary>
    /// Shows the StartPage to the Consumer.
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}