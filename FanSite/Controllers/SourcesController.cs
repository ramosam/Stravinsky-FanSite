using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using FanSite.Models;
using FanSite.Repositories;


namespace FanSite.Controllers
{
    public class SourcesController : Controller
    {
        IRepository repo;
        public SourcesController(IRepository r)
        {
            repo = r;
        }

        public IActionResult Sources()
        {
            // This is part of the project's restructuring to accomodate CS296N learning objectives.
            // Original project had too much of a customer user model embedded and this project had
            // less code that was tied up with user data.  
            // Moved MediaRef repository into the controller so I could remove the extra repository.

            List<MediaRef> mediaRefs = new List<MediaRef>();
            MediaRef wikipediaMR = new MediaRef
            {
                SourceName = "Wikipedia",
                LinkURL = "https://en.wikipedia.org/wiki/Igor_Stravinsky",
                MediaType = "URL",
            };
            MediaRef gramophoneMR = new MediaRef
            {
                SourceName = "Gramophone",
                LinkURL = "https://www.gramophone.co.uk/feature/welcome-to-stravinskys-world",
                MediaType = "URL",
            };
            MediaRef ucPressMR = new MediaRef
            {
                SourceName = "Journal of the American Musicological Society",
                LinkURL = "https://jams.ucpress.edu/content/62/2/323",
                MediaType = "URL",
            };

            mediaRefs.Add(wikipediaMR);
            mediaRefs.Add(gramophoneMR);
            mediaRefs.Add(ucPressMR);

            ViewData["latestMediaCount"] = mediaRefs.Count;
            return View("Sources", mediaRefs);
        }

        public IActionResult Stories()
        {
            List<UserStory> userStories = repo.UserStories;
            return View(userStories);
        }


        [HttpPost]
        public RedirectToActionResult AddStory(string user, string storyPost )
        {
            UserStory uStory = new UserStory
            {
                StoryPost = storyPost,
                Name = user
            };
            uStory.Name = user;
            // Temporary - data will be sent to the server
            repo.AddUserStory(uStory);
            repo.SortUserStoryByUserName();

            return RedirectToAction("Stories");
        }

        [HttpPost]
        public RedirectToActionResult AddStoryNoSort(string user, string storyPost)
        {
            UserStory uStory = new UserStory
            {
                Name = user,
                StoryPost = storyPost
            };


            // Temporary - data will be sent to the server
            repo.AddUserStory(uStory);
            

            return RedirectToAction("Stories");
        }

        public IActionResult AddStory()
        {
            return View();
        }

        public IActionResult AddComment(string storypost)
        {
            return View("AddComment", HttpUtility.HtmlDecode(storypost));
        }

        [HttpPost]
        public RedirectToActionResult AddComment(string storypost,
                                                 string user,
                                                 string commentText)
        {
            UserStory uStory = repo.GetUserStoryByPost(storypost);

            Comment comment = new Comment()
            {
                CommentText = commentText,
                Name = user,
            };

            repo.AddComment(uStory, comment);

            return RedirectToAction("Stories");
        }


    }
}
