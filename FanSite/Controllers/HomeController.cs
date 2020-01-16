using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace FanSite.Controllers
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

    }
}
