using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebSSEDemo.Models;

namespace WebSSEDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult ServerSentEvents()
        {
            Random random = new Random();
            string _event = "message";
            string data = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            if (random.Next(0, 10) % 3 == 0)
            {
                data = "新消息";
                _event = "NewMsg";
            }

            Response.ContentType = "text/event-stream";
            return Content($"retry:{1000}\nevent:{_event}\nid:{DateTime.Now.Ticks}\ndata:{data}\n\n");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
