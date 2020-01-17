using System.Collections.Generic;
using Stravinsky.Models;

namespace Stravinsky.Repositories
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
