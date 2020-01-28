using Xunit;
using Stravinsky.Repositories;
using Stravinsky.Controllers;
using Stravinsky.Models;

namespace Stravinsky.Tests
{
    public class SourcesTest
    {
        [Fact]
        public void TestAddStory()
        {
            // Arrange
            var repo = new FakeRepository();
            var sourcesController = new SourcesController(repo);

            // Act
            UserStory uStory = new UserStory
            {
                StoryPost = "TestStoryPost",
                Name = "A_User"
            };
            UserStory uStory2 = new UserStory
            {
                StoryPost = "TestStoryPost",
                Name = "B_User"
            };
            sourcesController.AddStory(uStory2);
            sourcesController.AddStory(uStory);
            
            // Assert
            Assert.Equal("A_User", repo.UserStories[0].Name);
            Assert.Equal("TestStoryPost", repo.UserStories[0].StoryPost);
        }

        [Fact]
        public void TestAddStoryNoSortByUserName()
        {
            // Arrange
            var repo = new FakeRepository();
            var sourcesController = new SourcesController(repo);

            // Act
            UserStory uStory = new UserStory
            {
                StoryPost = "TestStoryPost",
                Name = "B_User"
            };
            sourcesController.AddStoryNoSort(uStory);
            UserStory uStory2 = new UserStory
            {
                StoryPost = "A_User is expected to be last in the list",
                Name = "A_User"
            };
            sourcesController.AddStoryNoSort(uStory2);

            // Assert
            Assert.Equal("A_User", repo.UserStories[repo.UserStories.Count - 1].Name);
            Assert.Equal("A_User is expected to be last in the list", repo.UserStories[repo.UserStories.Count - 1].StoryPost);
        }

        [Fact]
        public void TestAddCommentGetUserStoryByPost()
        {
            // Arrange
            var repo = new FakeRepository();
            var sourcesController = new SourcesController(repo);

            // Act

            sourcesController.AddComment("Fake StoryPost1", "newCommentUser", "newCommentText");

            // Assert
            /* Assert that the newest comment is correctly associated
             * with the first story post in the fake repository and
             * should be the first item in the comment list.
             */

            Assert.Equal("Fake StoryPost1", repo.UserStories[0].StoryPost);
            Assert.Equal("newCommentUser", repo.UserStories[0].Comments[0].Name);
        }
    }
}
