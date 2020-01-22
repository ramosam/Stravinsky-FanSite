using System;
using System.Linq;
using Stravinsky.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Stravinsky.Repositories
{
    public class SeedData
    {
        public static void Seed(AppIdentityDbContext context)
        {
            if (!context.UserStories.Any())
            {
                // story 1, user 1

                UserStory uStory1 = new UserStory()
                {
                    Name = "Barbara_Walters",
                    StoryPost = "It would be nice to feel that we are a better world, a world of more compassion and a world of more humanity, and to believe in the basic goodness of man."
                };
                context.UserStories.Add(uStory1);

                // story 2, user 2
                UserStory uStory2 = new UserStory()
                {
                    Name = "John_Cage",
                    StoryPost = "I can't understand why people are frightened of new ideas. I'm frightened of the old ones."
                };

                // new comment from user
                Comment comment = new Comment()
                {
                    CommentText = "A person often meets his destiny on the road he took to avoid it.",
                    Name = "Jean_de_La_Fontaine",
                };
                // Adding comment to story 2
                context.Comments.Add(comment);
                uStory2.Comments.Add(comment);
                context.UserStories.Add(uStory2);


                // story 3, user 3
                UserStory uStory3 = new UserStory()
                {
                    Name = "Martha_Graham",
                    StoryPost = "What people in the world think of you is really none of your business."
                };
                context.UserStories.Add(uStory3);

                context.SaveChanges();

            }
        }
    }
}
