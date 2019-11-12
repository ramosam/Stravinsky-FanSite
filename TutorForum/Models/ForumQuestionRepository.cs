using System;
using System.Collections.Generic;
using TutorForum.Models;

namespace TutorForum.Models
{
    public class ForumQuestionRepository
    {
        private static List<ForumQuestion> forumQuestions = new List<ForumQuestion>();
        public static List<ForumQuestion> ForumQuestions { get { return forumQuestions; } }

        static ForumQuestionRepository()
        {
            AddTestData();
        }

        private static void AddTestData()
        {
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
                Replies = new List<Reply>(),
                
                
            };

            forumQuestions.Add(fq1);

            // Add replies
            Reply r1 = new Reply
            {
                QuestionPost = fq1,
                DateAdded = new DateTime(2017, 1, 4),
                Responder = new Member
                {
                    UserName = "FirstReplyUser",
                },
                ReplyBody = "Did you try to .ToString the date object?",
                Keywords = { "ToString", "date" },
                Rating = 3,
            };

            Reply r2 = new Reply
            {
                QuestionPost = fq1,
                DateAdded = new DateTime(2017, 1, 5),
                Responder = new Member
                {
                    UserName = "SecondReplyUser",
                },
                ReplyBody = "Try adding a date string formatter.  I used this " +
                " to get year-month-day:  dateObj.ToString('yyyy - MM - dd')",
                Keywords = { "ToString", "date" },
                Rating = 5,
            };

            // Add replies to forum question
            fq1.Replies.Add(r1);
            fq1.Replies.Add(r2);

            // Add forum question to the Repository list
            forumQuestions.Add(fq1);
        }

        

    }
}
