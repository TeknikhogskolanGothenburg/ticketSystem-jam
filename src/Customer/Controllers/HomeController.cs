using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Customer.Models;
using ClassLibrary;
using TicketSystem.RestApiClient;
using System.Resources;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;

namespace Customer.Controllers
{
    public class HomeController : Controller
    {
        private static Value value;
        private static TicketApi ticketApi;
        public SeatsAtEventDate SeatsAtEventDate;
        public TicketEvent TicketEvent;
        //private readonly IHomeDataProvider _homeDataProvider;
        //private readonly ResourceManager _resourceManager;
        //private readonly IStringLocalizer _localizer;
        //private readonly ILogger _logger;

        //public HomeController(IHomeDataProvider homeDataProvider,
        //    ResourceManager resourceManager,
        //    IStringLocalizer<HomeController> localizer,
        //    ILogger<HomeController> logger)
        //{
        //    _homeDataProvider = homeDataProvider;
        //    _resourceManager = resourceManager;
        //    _localizer = localizer;
        //    _logger = logger;

        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var resourceManager = HttpContext.RequestServices.GetService(typeof(ResourceManager)) as ResourceManager;
          //  _logger.LogInformation(BuildLogInfo(nameof(), "Message"));
          //  ViewData["Message"] = (_localizer["Message"]);
            ViewData["Message"] = "About";
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
            if (value == null)
            {
                value = new Value();
            }
            if (ticketApi == null)
            {
                ticketApi = new TicketApi();
            }

            value.Events = ticketApi.GetAllEvents();
            return View(value);
        }
        public IActionResult English()
        {
           
            return View();
        }

        public IActionResult Svenska()
        {

            return View();
        }

        public IActionResult GetEvents()
        {
            
            
               
                value.Events = ticketApi.GetAllEvents();
            
                return View(value);
            
         
        }

        public IActionResult GetAllEventDates(TicketEventDate TicketEventDates)
        {
  
            ticketApi.GetAllEventDates();
            return View(value);
        }

        //public IActionResult GetAllVenues()
        //{
        //    if (value == null)
        //    {
        //        value = new Value();
        //    }
        //    if (ticketApi == null)
        //    {
        //        ticketApi = new TicketApi();
        //    }
        //    value.Venues = ticketApi.GetAllVenues();
        //    return View(value);
        //}
        //public ActionResult GetAllEvents()
        //{
        //    ticketApi = new TicketApi();
        //    value = new Value();

        //    ticketApi.GetAllEvents();

        //    return View(value);
        //}


    }
}
