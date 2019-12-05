using System;
using System.Collections.Generic;

namespace TutorForum.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        private List<ForumQuestion> questionsAsked = new List<ForumQuestion>();
        private List<Reply> answers = new List<Reply>();

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }

        public List<ForumQuestion> QuestionsAsked { get { return questionsAsked; } }
        public List<Reply> Answers {  get { return answers; } }

    }

}
