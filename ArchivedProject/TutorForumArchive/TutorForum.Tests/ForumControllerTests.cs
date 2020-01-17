using Xunit;
using TutorForum.Repositories;
using TutorForum.Controllers;
using TutorForum.Models;
using System.Collections.Generic;

namespace TutorForum.Tests
{
    public class ForumControllerTest
    {
        [Fact]
        public void AddForumQuestionTest()
        {
            // Verifies that a new Forum question automatically adds a new question to the end of the Forum Questions.
            // Arrange
            var repo = new FakeRepository();
            var forumController = new ForumController(repo);

            // Act
            forumController.AddForumQuestion("questionerUser", "questionHeader", "questionBody");

            // Assert Forum Question gets added as last item in collection.
            int numCurrentItems = repo.ForumQuestions.Count;
            Assert.Equal("questionHeader", repo.ForumQuestions[numCurrentItems - 1].QuestionHeader);

        }

        [Fact]
        public void AddForumQuestionMemberTest()
        {
            // Verifies that a new Forum Question automaticall adds a new member to the end of the Members.
            // Arrange
            var repo = new FakeRepository();
            var forumController = new ForumController(repo);

            // Act
            forumController.AddForumQuestion("questionerUser", "questionHeader", "questionBody");

            // Assert Forum Question gets added as last item in collection.
            int numMembers = repo.Members.Count;
            Assert.Equal("questionerUser", repo.Members[numMembers - 1].Name);
        }

        [Fact]
        public void AddForumReplyTest()
        {
            // Verifies that a forum reply adds a new Reply to the end of the Replies.
            // Arrange
            var repo = new FakeRepository();
            var forumController = new ForumController(repo);

            // Act
            string header = "Null pointer references when the.cshtml page tries to render Comment objects.";
            string responder = "Donato di Niccolò di Betto Bardi";
            string replyBody = "I would recommend using lambda expressions to access the collection of comments.";
            forumController.AddForumReply(header, responder, replyBody);

            // Assert reply added to end of replies
            List<Reply> replies = repo.Replies;
            Assert.Equal(replyBody, replies[replies.Count - 1].ReplyBody);


        }

        [Fact]
        public void AddForumReplyTestNewMember()
        {
            // Verifies that a responder that does not exist in collection is added to Members
            // Arrange
            var repo = new FakeRepository();
            var forumController = new ForumController(repo);

            // Act
            string header = "Null pointer references when the.cshtml page tries to render Comment objects.";
            string responder = "Donato";
            string replyBody = "I would recommend using lambda expressions to access the collection of comments.";
            forumController.AddForumReply(header, responder, replyBody);

            // Assert reply added to end of replies
            List<Member> members = repo.Members;
            Assert.Equal(responder, members[members.Count - 1].Name);


        }

    }
}
