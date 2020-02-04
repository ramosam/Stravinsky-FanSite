using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stravinsky.Models;
using Stravinsky.Repositories;

namespace Stravinsky.Controllers
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

        [Authorize(Roles="Member")]
        [HttpPost]
        public RedirectToActionResult AddStory(UserStory storyForm)
        {
            if (ModelState.IsValid)
            {
                UserStory uStory = new UserStory
                {
                    StoryPost = storyForm.StoryPost,
                    Name = storyForm.Name
                };

                repo.AddUserStory(uStory);
                
            }
            repo.SortUserStoryByUserName();
            return RedirectToAction("Stories");
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        public RedirectToActionResult AddStoryNoSort(UserStory storyForm)
        {
            if (ModelState.IsValid)
            {
                UserStory uStory = new UserStory
                {
                    StoryPost = storyForm.StoryPost,
                    Name = storyForm.Name
                };

                repo.AddUserStory(uStory);
            }

            return RedirectToAction("Stories");
        }

        [Authorize(Roles = "Member")]
        public IActionResult AddStory()
        {
            return View();
        }

        [Authorize(Roles = "Member")]
        public IActionResult AddComment(string storypost)
        {
            CommentViewModel cvm = new CommentViewModel{
                StoryPost = storypost
            };

            return View("AddComment", cvm);
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        public RedirectToActionResult AddComment(CommentViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                UserStory uStory = repo.GetUserStoryByPost(cvm.StoryPost);

                Comment comment = new Comment()
                {
                    CommentText = cvm.CommentText,
                    Name = cvm.Name,
                };

                repo.AddComment(uStory, comment);
            }

            return RedirectToAction("Stories");
        }


    }
}
