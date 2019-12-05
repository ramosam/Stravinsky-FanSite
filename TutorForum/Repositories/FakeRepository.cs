using System;
using System.Collections.Generic;
using TutorForum.Models;

namespace TutorForum.Repositories
{
    public class FakeRepository : IRepository
    {
        private List<ForumQuestion> forumQuestions = new List<ForumQuestion>();
        public List<ForumQuestion> ForumQuestions { get { return forumQuestions; } }

        private List<FAQuestion> fAQuestions = new List<FAQuestion>();
        public List<FAQuestion> FAQuestions { get { return fAQuestions; } }

        private List<Reply> replies = new List<Reply>();
        public List<Reply> Replies { get { return replies; } }

        private List<Tutor> tutors = new List<Tutor>();
        public List<Tutor> Tutors { get { return tutors; } }

        private List<Member> members = new List<Member>();
        public List<Member> Members { get { return members; } }


        public FakeRepository()
        {
            if (forumQuestions.Count == 0) { AddTestData(); }
        }


        public void AddMember(Member m) => members.Add(m);


        public void AddForumQuestion(ForumQuestion fq, Member member)
        {
            member.QuestionsAsked.Add(fq);
            forumQuestions.Add(fq);
        }

        public void AddReply(ForumQuestion fq, Reply r)
        {
            replies.Add(r);
            fq.AddReply(r);
        }


        public void AddFAQuestion(FAQuestion q) => fAQuestions.Add(q);


        public void AddTutor(Tutor t) => tutors.Add(t);


        //public List<ForumQuestion> GetForumQuestionsByQuestioner(string userName)
        //{
        //    return forumQuestions.FindAll(fq => fq.Questioner.UserName == userName);
        //}

        public List<IQuestion> GetIQuestionsByKeyword(string keyword)
        {
            // Create bucket for fqs
            List<IQuestion> questionsByKeyword = new List<IQuestion>();

            // Create lowercase version of user search string
            string lowerKeyword = keyword;
            // Separate into lowercase string array based on spaces
            // Note: Punctuation affects keyword
            string[] words = lowerKeyword.Split(' ');

            /* For each word in keyword, loop to see if there are any fqs
             * with keyword matches.
             * 
             * Next, make sure that there are no duplicate entries.
             * 
             * Then, if there is a match and is unique, add that fq to the
             * result bucket list.
             */
            // For each word
            for (int i = 0; i < words.Length; i++)
            {
                // For each question
                for (int q = 0; q < forumQuestions.Count; q++)
                {
                    // Find match
                    if (forumQuestions[q].Keywords.Contains(words[i]))
                    {
                        // Add to bucket
                        questionsByKeyword.Add(forumQuestions[q]);
                    }
                }
            }

            List<IQuestion> singleQByKeyword = RemoveDuplicates(questionsByKeyword);


            return singleQByKeyword;
        }

        private List<IQuestion> RemoveDuplicates(List<IQuestion> origFQList)
        {
            // Create shortList bucket
            List<IQuestion> shortList = new List<IQuestion>();
            // Create list for header comparison
            List<string> headerCheckList = new List<string>();
            // Loop through each question 
            for (int i = 0; i < origFQList.Count; i++)
            {
                // Check if unique
                if (!headerCheckList.Contains(origFQList[i].QuestionHeader))
                {
                    // Add to checkList
                    headerCheckList.Add(origFQList[i].QuestionHeader);
                    // Add to collection bucket
                    shortList.Add(origFQList[i]);
                }
            }
            // Return shortened list
            return shortList;
        }


        private void AddTestData()
        {
            Member m1 = new Member
            {
                UserName = "Michelangelo di Lodovico Buonarroti Simoni",
                Password = "SistineChapel",
                Title = "Member"

            };

            Member m2 = new Member
            {
                UserName = "Donato di Niccolò di Betto Bardi",
                Password = "StGeorge",
                Title = "Member"

            };

            Member m3 = new Member
            {
                UserName = "Leonardo da Vinci",
                Password = "VitruvianMan",
                Title = "Member"

            };

            Member m4 = new Member
            {
                UserName = "Raffaello Sanzio da Urbino",
                Password = "ThreeGraces",
                Title = "Member"

            };

            AddMember(m1);
            AddMember(m2);
            AddMember(m3);
            AddMember(m4);


            // Make Forum Questions
            ForumQuestion fq1 = new ForumQuestion
            {
                Questioner = m1,
                DateAdded = new DateTime(2017, 1, 1),
                QuestionHeader = "Year, Month, and Day parameters " +
            "describe an un-representable DateTime Exception",
                QuestionBody = "I'm getting this error when I try to " +
            "print a DateTime object on my website.",

            };
            // Populate keywords
            fq1.FindKeywords();

            ForumQuestion fq2 = new ForumQuestion
            {
                Questioner = m2,
                DateAdded = new DateTime(2019, 4, 7),
                QuestionHeader = "Null pointer references when the .cshtml page tries to render Comment objects.",
                QuestionBody = "The debugger shows that there is a comment object, but the user name is Null.",

            };
            // Populate keywords
            fq2.FindKeywords();




            // Make Replies
            Reply r1 = new Reply()
            {
                DateAdded = new DateTime(2017, 1, 4),
                Responder = m3,
                ReplyBody = "Have you tried adding a .ToString?",

            };
            Reply r2 = new Reply()
            {
                DateAdded = new DateTime(2017, 1, 5),
                Responder = m4,
                ReplyBody = "Try adding a date string formatter.  I used this " +
" to get year-month-day:  dateObj.ToString('yyyy - MM - dd')",
            };
            // Find keywords in replies
            r1.FindKeywords();
            r2.FindKeywords();

            // Add replies to forum questions
            AddReply(fq1, r1);
            AddReply(fq1, r2);
            // Add replies to context
            AddForumQuestion(fq1, m1);
            AddForumQuestion(fq2, m2);


            // Make FAQs/Kbs
            FAQuestion faq1 = new FAQuestion
            {
                // Date
                DateAdded = new DateTime(2019, 2, 28),
                // Title
                QuestionHeader = "What is a method and why do I have to call it?",
                // Body
                QuestionBody = "A method is a code block that contains a series " +
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

            };


            FAQuestion faq2 = new FAQuestion
            {
                DateAdded = new DateTime(2019, 10, 9),
                // Title
                QuestionHeader = "What is the difference between ref & out " +
            "parameters?",
                // Body
                QuestionBody = "An argument passed as ref must be initialized" +
            " before passing to the method whereas the out parameter needs not " +
            "to be initialized before passing to a method. ",

            };


            FAQuestion faq3 = new FAQuestion
            {
                DateAdded = new DateTime(2018, 3, 15),
                // Title
                QuestionHeader = "What is the difference between public, " +
            "static, and void?",
                // Body
                QuestionBody = "Public declared variables or methods are " +
            "accessible anywhere in the application. Static declared " +
            "variables or methods are globally accessible without creating " +
            "an instance of the class. Static member are by default not" +
            " globally accessible it depends upon the type of access " +
            "modified used. The compiler stores the address of the method " +
            "as the entry point and uses this information to begin" +
            " execution before any objects are created. And Void is a " +
            "type modifier that states that the method or variable does " +
            "not return any value. ",

            };
            // Add keywords
            faq1.FindKeywords();
            faq2.FindKeywords();
            faq3.FindKeywords();
            // Add FAQs to context
            AddFAQuestion(faq1);
            AddFAQuestion(faq2);
            AddFAQuestion(faq3);


            // Make Tutors
            Tutor t1 = new Tutor
            {
                UserName = "Splinter",
                Password = "Ninjutsu",
                Title = "Moderator",
                Expertise = { "C#", "Python" }
            };
            AddTutor(t1);


        }

    }
}
