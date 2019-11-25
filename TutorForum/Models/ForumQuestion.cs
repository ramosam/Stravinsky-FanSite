using System;
using System.Collections.Generic;

namespace TutorForum.Models
{
    public class ForumQuestion
    {
        public Member Questioner { get; set; }
        public DateTime DateAdded { get; set; }
        public string ForumQuestionHeader { get; set; }
        public string ForumQuestionBody { get; set; }
        public List<string> Keywords { get; set; }
        public List<Reply> Replies { get; set; }
        public Reply HighestRatedAnswer { get { return FindHighestRatedAnswer(); } }

        public Reply FindHighestRatedAnswer()
        {
            // TODO: Write method to locate highest rated answer on the forum question
            Reply reply = new Reply();
            return reply;
        }

        // TODO: Write the FindKeywords method
        public void FindKeywords()
        {

        }



        // TODO: Sort by rating
    }
}
