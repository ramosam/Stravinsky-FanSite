//using System;
//using System.Collections.Generic;

//namespace TutorForum.Models
//{
//    public static class KnowledgeBaseRepository
//    {
//        private static List<FAQuestion> kbs = new List<FAQuestion>();
//        public static List<FAQuestion> KBs {  get { return kbs; } }

//        static KnowledgeBaseRepository()
//        {
//            AddSeedData();
//        }

//        private static void AddSeedData()
//        {

//            FAQuestion faq1 = new FAQuestion
//            {
//                // Date
//                DateAdded = new DateTime(2019, 2, 28),
//                // Title
//                FAQuestionTitle = "What is a method and why do I have to call it?",
//                // Body
//                FAQAnswerBody = "A method is a code block that contains a series " +
//                "of statements. A program causes the statements to be executed " +
//                "by calling the method and specifying any required method " +
//                "arguments. In C#, every executed instruction is performed in " +
//                "the context of a method. The Main method is the entry point " +
//                "for every C# application and it's called by the common " +
//                "language runtime (CLR) when the program is started. " +
//                "The method definition specifies the names and types of any" +
//                " parameters that are required. When calling code calls the" +
//                " method, it provides concrete values called arguments for each" +
//                " parameter. The arguments must be compatible with the " +
//                "parameter type but the argument name (if any) used in the " +
//                "calling code doesn't have to be the same as the parameter " +
//                "named defined in the method. ",
//                // Keywords
//                Keywords = new List<string>
//                {
//                    "method", "code", "block", "statements", "definition",
//                },
//            };

//            FAQuestion faq2 = new FAQuestion
//            {
//                DateAdded = new DateTime(2019, 10, 9),
//                // Title
//                FAQuestionTitle = "What is the difference between ref & out " +
//                "parameters?",
//                // Body
//                FAQAnswerBody = "An argument passed as ref must be initialized" +
//                " before passing to the method whereas the out parameter needs not " +
//                "to be initialized before passing to a method. ",
//                // Keywords
//                Keywords = new List<string>
//                {
//                    "argument", "parameter", "out", "ref", "initialize",
//                },
//            };

//            FAQuestion faq3 = new FAQuestion
//            {
//                DateAdded = new DateTime(2018, 3, 15),
//                // Title
//                FAQuestionTitle = "What is the difference between public, " +
//                "static, and void?",
//                // Body
//                FAQAnswerBody = "Public declared variables or methods are " +
//                "accessible anywhere in the application. Static declared " +
//                "variables or methods are globally accessible without creating " +
//                "an instance of the class. Static member are by default not" +
//                " globally accessible it depends upon the type of access " +
//                "modified used. The compiler stores the address of the method " +
//                "as the entry point and uses this information to begin" +
//                " execution before any objects are created. And Void is a " +
//                "type modifier that states that the method or variable does " +
//                "not return any value. ",
//                // Keywords
//                Keywords = new List<string>
//                {
//                    "public", "static", "void", "declared", "access", "global"
//                },
//            };

//            // Adding  questions to repo
//            kbs.Add(faq1);
//            kbs.Add(faq2);
//            kbs.Add(faq3);


//        }

//    }
//}
