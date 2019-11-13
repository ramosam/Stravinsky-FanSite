using System;
using System.Collections.Generic;

namespace TutorForum.Models
{
    public static class ForumQuestionRepository
    {
        private static List<ForumQuestion> forumQuestions = new List<ForumQuestion>();
        public static List<ForumQuestion> ForumQuestions { get { return forumQuestions; } }

        static ForumQuestionRepository()
        {
            AddTestData();
        }

        private static void AddTestData()
        {
            // Get a list of three generic replies
            List<Reply> replyList = CreateGenericReplies();

            // TODO: Add keywords to forum questions
            // Make the first question
            ForumQuestion fq1 = new ForumQuestion
            {
                // Create generic question
                Questioner = new Member
                {
                    UserName = "FirstUser",
                },
                DateAdded = new DateTime(2017, 1, 1),
                ForumQuestionHeader = "Year, Month, and Day parameters " +
                "describe an un-representable DateTime Exception",
                ForumQuestionBody = "I'm getting this error when I try to " +
                "print a DateTime object on my website.",
                Replies = new List<Reply>()
            };
            // Add two replies
            fq1.Replies.Add(replyList[0]);
            fq1.Replies.Add(replyList[1]);

            // Make second forum question
            ForumQuestion fq2 = new ForumQuestion
            {
                // Create generic question
                Questioner = new Member
                {
                    UserName = "SecondUser",
                },
                DateAdded = new DateTime(2017, 1, 1),
                ForumQuestionHeader = "Something new should get posted here " +
                "because this won't suffice",
                ForumQuestionBody = "I'm starting to think that this is all " +
                "just a terrible conspiracy.",
                Replies = new List<Reply>()
            };
            // Add one reply
            fq2.Replies.Add(replyList[2]);

            // Add third question with no replies
            ForumQuestion fq3 = new ForumQuestion
            {
                // Create generic question
                Questioner = new Member
                {
                    UserName = "ThirdUser",
                },
                DateAdded = new DateTime(2017, 1, 1),
                ForumQuestionHeader = "Something else  should get posted here " +
                "because this won't suffice",
                ForumQuestionBody = "I'm starting to think that this is all " +
                "just a terrible conspiracy.",
                Replies = new List<Reply>()
            };

            forumQuestions.Add(fq1);
            forumQuestions.Add(fq2);
            forumQuestions.Add(fq3);
        }

        private static List<Reply> CreateGenericReplies()
        {
            List<Reply> replyList = new List<Reply>();

            Reply r1 = new Reply()
            {
                DateAdded = new DateTime(2017, 1, 4),
                Responder = new Member()
                {
                    UserName = "ReplyUser1"
                },
                ReplyBody = "Have you tried adding a .ToString?",
                Keywords = new List<string> { "ToString", "date" }, 
                Rating = 3
            };

            Reply r2 = new Reply()
            {
                DateAdded = new DateTime(2017, 1, 5),
                Responder = new Member
                {
                    UserName = "SecondReplyUser",
                },
                ReplyBody = "Try adding a date string formatter.  I used this " +
   " to get year-month-day:  dateObj.ToString('yyyy - MM - dd')",
                Keywords = new List<string> { "ToString", "date" },
                Rating = 5,
            };

            Reply r3 = new Reply()
            {
                DateAdded = new DateTime(2018, 10, 10),
                Responder = new Member()
                {
                    UserName = "ReplyUser3"
                },
                ReplyBody = "Have you tried turning it off and on again?",
                Rating = 0
            };

            replyList.Add(r1);
            replyList.Add(r2);
            replyList.Add(r3);

            return replyList;
        }

    }
}
