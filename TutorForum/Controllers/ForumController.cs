using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using TutorForum.Models;
using TutorForum.Repositories;

namespace TutorForum.Controllers
{
    public class ForumController : Controller
    {
        // Set up home page
        IRepository repo;
        public ForumController(IRepository r)
        {
            repo = r;
        }


        public IActionResult Forum()
        {
            return View(repo.ForumQuestions);
        }

        public IActionResult KnowledgeBase()
        {
            return View(KnowledgeBaseRepository.KBs); 
        }

        public ActionResult SearchByKeyword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KeywordResults(string userSearchString)
        {
            // keyword search
            // split string for multiple word check
            return View("KeywordResults", repo.ForumQuestions);
        }

    }
}
