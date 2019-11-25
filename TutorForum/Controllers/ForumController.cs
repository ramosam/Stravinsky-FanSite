using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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

            // Check if user entered anything
            if (userSearchString != null)
            {
                // split string for multiple word check
                string[] userInputs = userSearchString.Split(' ');
                fqResults = repo.GetForumQuestionsByKeyword(userInputs[0].ToLower());
            }
            else
            {
                fqResults = repo.ForumQuestions;
            }
            
            return View("KeywordResults", fqResults);
        }

        public IActionResult AddForumQuestion()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult AddForumQuestion(string questioner, string forumQuestionHeader, string forumQuestionBody)
        {
            Member newMem = new Member
            {
                UserName = questioner,
            };
            ForumQuestion newFQ = new ForumQuestion
            {
                Questioner = newMem,
                ForumQuestionHeader = forumQuestionHeader,
                ForumQuestionBody = forumQuestionBody,
                DateAdded = System.DateTime.Now,
                Replies = new List<Reply>(),
                Keywords = new List<string>()
            };
            newFQ.FindKeywords();
            repo.AddForumQuestion(newFQ);

            return RedirectToAction("Forum", repo.ForumQuestions);
        }

    }
}
