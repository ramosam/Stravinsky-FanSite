using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using FanSite.Models;

namespace FanSite.Repositories
{
    public class Repository : IRepository
    {

        private AppDbContext context;

        public List<UserStory> UserStories
        {
            get
            {
                var userStories = context.UserStories
                    .Include(story => story.Comments)
                    .ToList();

                return userStories;
            }
        }

        public Repository(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        public void AddUserStory(UserStory userStory)
        {
            context.UserStories.Add(userStory);
            context.SaveChanges();
        }

        public void AddComment(UserStory uS, Comment comment)
        {
            context.Comments.Add(comment);
            uS.Comments.Add(comment);
            context.UserStories.Update(uS);
            context.SaveChanges();
        }

        public UserStory GetUserStoryByPost(string storypost)
        {
            UserStory uStory = context.UserStories.FirstOrDefault(u => u.StoryPost == storypost);
            return uStory;
        }

        public UserStory GetUserStoryByUser(string user)
        {
            UserStory uStory = context.UserStories.FirstOrDefault(u => u.Name == user);
            return uStory;
        }

        public void SortUserStoryByTitle()
        {
            context.UserStories.OrderBy(userStory => userStory.StoryPost);
        }

        public void SortUserStoryByUserName()
        {
            context.UserStories.OrderBy(userStory => userStory.Name);
        }

    }
}
