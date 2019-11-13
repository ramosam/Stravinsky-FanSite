using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutorForum.Models;

namespace TutorForum.Controllers
{
    public class ForumController : Controller
    {
        // Set up home page
        public IActionResult Forum()
        {
            
            List<ForumQuestion> testData = ForumQuestionRepository.ForumQuestions;

            return View(ForumQuestionRepository.ForumQuestions);
        }

        public IActionResult KnowledgeBase()
        {

            return View(KnowledgeBaseRepository.KBs); 
        }

    }
}
