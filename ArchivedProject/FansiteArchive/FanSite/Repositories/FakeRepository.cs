using System;
using System.Collections.Generic;
using FanSite.Models;

namespace FanSite.Repositories
{
    public class FakeRepository : IRepository
    {
        private  List<UserStory> userStories = new List<UserStory>();
        public List<UserStory> UserStories { get { return userStories; } }

        public FakeRepository()
        {
            if (userStories.Count == 0) { AddTestData(); }
        }

        public void AddUserStory(UserStory userStory) => userStories.Add(userStory);

        public void AddComment(UserStory userStory, Comment comment)
        {
            userStory.Comments.Add(comment);
        }

        public UserStory GetUserStoryByPost(string storypost)
        {
            UserStory uStory = userStories.Find(u => u.StoryPost == storypost);
            return uStory;
        }

        public UserStory GetUserStoryByUser(string user)
        {
            UserStory uStory = userStories.Find(u => u.Name == user);
            return uStory;
        }

        public void SortUserStoryByTitle() => UserStories.Sort((uS1, uS2) => string.Compare(uS1.StoryPost, uS2.StoryPost, StringComparison.Ordinal));

        public void SortUserStoryByUserName() => UserStories.Sort((uS1, uS2) => string.Compare(uS1.Name, uS2.Name, StringComparison.Ordinal));

        void AddTestData()
        {
            // story 1, user 1
            UserStory uStory1 = new UserStory()
            {
                Name = "Fake User1",
                StoryPost = "Fake StoryPost1"
            };
            userStories.Add(uStory1);


            // story 2, user 2
            UserStory uStory2 = new UserStory()
            {
                Name = "Fake User2",
                StoryPost = "Fake StoryPost2"
            };

            // new comment from user
            Comment comment = new Comment()
            {
                CommentText = "Fake Comment",
                Name = "Fake CommentUser1",
            };
            // Adding comment to story 2
            uStory2.Comments.Add(comment);
            
            userStories.Add(uStory2);


            // story 3, user 3
            UserStory uStory3 = new UserStory()
            {
                Name = "Fake User3",
                StoryPost = "Fake StoryPost3"
            };
            userStories.Add(uStory3);
            
        }

    }
}