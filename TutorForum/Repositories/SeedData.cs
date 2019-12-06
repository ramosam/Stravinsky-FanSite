using System;
using System.Linq;
using TutorForum.Models;
using TutorForum.Repositories;


namespace TutorForum.Repositories
{
    public class SeedData
    {
        
        public static void Seed(AppDbContext context)
        {
            if (!context.ForumQuestions.Any())
            {
                // Make Users 
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

                context.Members.Add(m1);
                context.Members.Add(m2);
                context.Members.Add(m3);
                context.Members.Add(m4);



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

                ForumQuestion fq2 = new ForumQuestion
                {
                    Questioner = m2,
                    DateAdded = new DateTime(2019, 4, 7),
                    QuestionHeader = "Null pointer references when the .cshtml page tries to render Comment objects.",
                    QuestionBody = "The debugger shows that there is a comment object, but the user name is Null.",

                };
                // Populate keywords
                fq1.FindKeywords();
                fq2.FindKeywords();
                // Moving adding and updating forumQuestions and users after replies are accounted for.
                context.ForumQuestions.Add(fq1);
                context.ForumQuestions.Add(fq2);
                m1.QuestionsAsked.Add(fq1);
                m2.QuestionsAsked.Add(fq2);


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
                // Add replies to context
                context.Replies.Add(r1);
                context.Replies.Add(r2);
                // Add replies to members
                m3.Answers.Add(r1);
                m4.Answers.Add(r2);

                // Add reply to ForumQ
                fq1.AddReply(r1);
                fq1.AddReply(r2);



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
                context.FAQuestions.Add(faq1);
                context.FAQuestions.Add(faq2);
                context.FAQuestions.Add(faq3);


                // Make Tutors
                Tutor t1 = new Tutor
                {
                    UserName = "Splinter",
                    Password = "Ninjutsu",
                    Title = "Moderator",
                    Expertise = { "C#", "Python" }
                };
                context.Tutors.Add(t1);

                // Save everything
                context.SaveChanges();

            }
        }
    }
}
