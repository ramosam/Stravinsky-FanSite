using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using TutorForum.Models;
using TutorForum.Repositories;

namespace TutorForum.Controllers
{
    public class ForumController : Controller
    {
        
        IRepository repo;
        public ForumController(IRepository r)
        {
            repo = r;
        }

        // Set up home page
        public IActionResult Forum()
        {
            return View(repo.ForumQuestions);
        }

        public IActionResult KnowledgeBase()
        {
            return View(repo.FAQuestions); 
        }

        public ActionResult SearchByKeyword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KeywordResults(string userSearchString)
        {
            // Empty fqList
            List<IQuestion> fqResults = new List<IQuestion>();

            // Check if user entered anything
            if (userSearchString != null)
            {
                // Grab the userSting to process
                fqResults = repo.GetIQuestionsByKeyword(userSearchString.ToLower());
            }
            
            return View("KeywordResults", fqResults);
        }

        public IActionResult AddForumQuestion()
        {
            return View();
        }

        public IActionResult AddForumReply(string questionheader)
        {
            return View("AddForumReply", HttpUtility.HtmlDecode(questionheader));
            //return View();
        }

        [HttpPost]
        public RedirectToActionResult AddForumQuestion(string questioner, string questionHeader, string questionBody)
        {
            if (questioner == null || questionHeader == null || questionBody == null)
            {
                return RedirectToAction("AddForumQuestion");
            } else
            {
                Member newMem = new Member
                {
                    UserName = questioner,
                };
                ForumQuestion newFQ = new ForumQuestion
                {
                    Questioner = newMem,
                    QuestionHeader = questionHeader,
                    QuestionBody = questionBody,
                    DateAdded = System.DateTime.Now,
                };

                newFQ.FindKeywords();
                repo.AddMember(newMem);
                repo.AddForumQuestion(newFQ, newMem);
            }
            

            return RedirectToAction("Forum", repo.ForumQuestions);
        }



        [HttpPost]
        public RedirectToActionResult AddForumReply(string questionheader, string responder, string replyBody)
        {
            ForumQuestion fq = repo.FindForumQuestionByQuestionHeader(questionheader);
            Member newMem = repo.Members.Find(m => m.UserName == responder);
            if (newMem == null)
            {
                newMem = new Member
                {
                    UserName = responder
                };
                repo.AddMember(newMem);
            }

            Reply reply = new Reply
            {
                ReplyBody = replyBody,
                Responder = newMem
            };

            repo.AddReply(fq, reply, newMem);

            return RedirectToAction("Forum", repo.ForumQuestions);
        }
    }
}
