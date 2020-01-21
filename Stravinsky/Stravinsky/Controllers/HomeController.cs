using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stravinsky.Models;

namespace Stravinsky.Controllers
{
    public class HomeController : Controller
    {
       
        public ViewResult Index()
        {
            ViewBag.HomePageTitle = "Stravinsky";
            return View();
        }

        public ViewResult History()
        {
            ViewBag.HistoryTitle = "Once upon a time";
            return View();
        }

  


        //public ViewResult Index() =>
        //    View(new Dictionary<string, object>
        //    { ["Placeholder"] = "Placeholder" });

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
