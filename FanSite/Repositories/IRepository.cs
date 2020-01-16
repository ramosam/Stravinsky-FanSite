using System;
using System.Collections.Generic;
using FanSite.Models;

namespace FanSite.Repositories
{
    public interface IRepository
    {
        List<UserStory> UserStories { get; }
        void AddUserStory(UserStory userStory);
        void AddComment(UserStory userStory, Comment comment);
        UserStory GetUserStoryByPost(string post);
        UserStory GetUserStoryByUser(string user);
        void SortUserStoryByTitle();
        void SortUserStoryByUserName();
    }
}
