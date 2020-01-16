using Xunit;
using FanSite.Repositories;
using FanSite.Controllers;
using FanSite.Models;

namespace FanSite.Tests
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
            sourcesController.AddStory("A_User", "TestStoryPost");
            // Assert
            Assert.Equal("A_User", repo.UserStories[0].UserName.Name);
            Assert.Equal("TestStoryPost", repo.UserStories[0].StoryPost);
        }

        [Fact]
        public void TestAddStoryNoSortByUserName()
        {
            // Arrange
            var repo = new FakeRepository();
            var sourcesController = new SourcesController(repo);

            // Act
            sourcesController.AddStoryNoSort("AUser", "AUser is expected to be last in the list");
            

            // Assert
            Assert.Equal("AUser", repo.UserStories[repo.UserStories.Count - 1].UserName.Name);
            Assert.Equal("AUser is expected to be last in the list", repo.UserStories[repo.UserStories.Count - 1].StoryPost);
        }

        //[Fact]
        //public void TestAddCommentGetUserStoryByPost()
        //{
        //    // Arrange
        //    var repo = new FakeRepository();
        //    var sourcesController = new SourcesController(repo);

        //    // Act

        //    sourcesController.AddComment("Fake StoryPost1", "newCommentUser", "newCommentText");

        //    // Assert
        //    /* Assert that the newest comment is correctly associated
        //     * with the first story post in the fake repository and
        //     * should be the first item in the comment list.
        //     */

        //    Assert.Equal("Fake StoryPost1", repo.UserStories[0].StoryPost);
        //    Assert.Equal("newCommentUser", repo.UserStories[0].Comments[0].UserName.Name);
        //}


    }
}
