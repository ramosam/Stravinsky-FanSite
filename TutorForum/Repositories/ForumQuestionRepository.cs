using System;
using System.Collections.Generic;
using TutorForum.Repositories;
using TutorForum.Models;

namespace TutorForum.Models
{
    public class ForumQuestionRepository : IRepository
    {
        private static List<ForumQuestion> forumQuestions = new List<ForumQuestion>();
        public List<ForumQuestion> ForumQuestions { get { return forumQuestions; } }

        private static List<FAQuestion> kbs = new List<FAQuestion>();
        public List<FAQuestion> KBs
        {
            get
            {
                if (kbs.Count == 0)
                {
                    AddSeedData();
                }
                return kbs;
            }
        }

        public ForumQuestionRepository()
        {
            if (forumQuestions.Count == 0)
            {
                AddTestData();
            }
            
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
                Replies = new List<Reply>(),
                Keywords = new List<string> { "error", "print", "DateTime", "object", "website", "date" }
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
                Replies = new List<Reply>(),
                Keywords = new List<string> { "conspiracy", "terrible" }
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
                Replies = new List<Reply>(),
                Keywords = new List<string> { "conspiracy", "terrible" }
            };

            forumQuestions.Add(fq1);
            forumQuestions.Add(fq2);
            forumQuestions.Add(fq3);
        }

        public void KnowledgeBaseRepository()
        {
            AddSeedData();
        }

        private void AddSeedData()
        {

            FAQuestion faq1 = new FAQuestion
            {
                // Date
                DateAdded = new DateTime(2019, 2, 28),
                // Title
                FAQuestionTitle = "What is a method and why do I have to call it?",
                // Body
                FAQAnswerBody = "A method is a code block that contains a series " +
                "of statements. A program causes the statements to be executed " +
                "by calling the method and specifying any required method " +
                "arguments. In C#, every executed instruction is performed in " +
                "the context of a method. The Main method is the entry point " +
                "for every C# application and it's called by the common " +
                "language runtime (CLR) when the program is started. " +
                "The method definition specifies the names and types of any" +
                " parameters that are required. When calling code calls the" +
                " method, it provides concrete values called arguments for each" +
                " parameter. The arguments must be compatible with the " +
                "parameter type but the argument name (if any) used in the " +
                "calling code doesn't have to be the same as the parameter " +
                "named defined in the method. ",
                // Keywords
                Keywords = new List<string>
                {
                    "method", "code", "block", "statements", "definition",
                },
            };

            FAQuestion faq2 = new FAQuestion
            {
                DateAdded = new DateTime(2019, 10, 9),
                // Title
                FAQuestionTitle = "What is the difference between ref & out " +
                "parameters?",
                // Body
                FAQAnswerBody = "An argument passed as ref must be initialized" +
                " before passing to the method whereas the out parameter needs not " +
                "to be initialized before passing to a method. ",
                // Keywords
                Keywords = new List<string>
                {
                    "argument", "parameter", "out", "ref", "initialize",
                },
            };

            FAQuestion faq3 = new FAQuestion
            {
                DateAdded = new DateTime(2018, 3, 15),
                // Title
                FAQuestionTitle = "What is the difference between public, " +
                "static, and void?",
                // Body
                FAQAnswerBody = "Public declared variables or methods are " +
                "accessible anywhere in the application. Static declared " +
                "variables or methods are globally accessible without creating " +
                "an instance of the class. Static member are by default not" +
                " globally accessible it depends upon the type of access " +
                "modified used. The compiler stores the address of the method " +
                "as the entry point and uses this information to begin" +
                " execution before any objects are created. And Void is a " +
                "type modifier that states that the method or variable does " +
                "not return any value. ",
                // Keywords
                Keywords = new List<string>
                {
                    "public", "static", "void", "declared", "access", "global"
                },
            };

            // Adding  questions to repo
            kbs.Add(faq1);
            kbs.Add(faq2);
            kbs.Add(faq3);


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
                    UserName = "ReplyUser2",
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

        public void AddForumQuestion(ForumQuestion fq) => forumQuestions.Add(fq);
    

        public List<ForumQuestion> GetForumQuestionsByQuestioner(string userName)
        {
            return forumQuestions.FindAll(fq => fq.Questioner.UserName == userName);
        }

        public List<ForumQuestion> GetForumQuestionsByKeyword(string keyword)
        {
            List<ForumQuestion> questionsByKeyword = new List<ForumQuestion>();
            foreach (var fq in forumQuestions)
            {
                foreach (var fqKeyword in fq.Keywords)
                {
                    if (fqKeyword == keyword)
                    {
                        questionsByKeyword.Add(fq);
                        
                    }
                }
            }
            return questionsByKeyword; 
        }
    }
}
