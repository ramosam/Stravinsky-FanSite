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
            return View(repo.KBs); 
        }

        public ActionResult SearchByKeyword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KeywordResults(string userSearchString)
        {
            // Empty local list
            List<ForumQuestion> fqResults = new List<ForumQuestion>();
            // split string for multiple word check
            string[] userInputs = userSearchString.Split(' ');
            // iterate over each word found
            for (int i = 0; i < userInputs.Length; i++)
            {
                // Add collection of results
                fqResults.AddRange(repo.GetForumQuestionsByKeyword(userInputs[i]));
            }
            
            return View("KeywordResults", fqResults);
        }

    }
}
