using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TutorForum.Models;
using TutorForum.Repositories;

namespace TutorForum.Controllers
{
    public class HomeController : Controller
    {

        IRepository repo;
        public HomeController(IRepository r)
        {
            repo = r;
        }

        // Set up home page
        public IActionResult Index()
        {
            return View();
        }

        // Set up About page
        public IActionResult About()
        {
            List<Tutor> tutors = repo.Tutors;
            return View(tutors);
        }


        // Bump the Privacy page down
        public IActionResult Privacy()
        {
            return View();
        }


    }
}
