using System;
using System.Collections.Generic;
<<<<<<< Updated upstream
using System.ComponentModel.DataAnnotations;
=======
using Microsoft.AspNetCore.Identity;
>>>>>>> Stashed changes

namespace TutorForum.Models
{
    public class Member
    {
        //public int MemberID { get; set; }
        private List<ForumQuestion> questionsAsked = new List<ForumQuestion>();
        private List<Reply> answers = new List<Reply>();

<<<<<<< Updated upstream
        [StringLength(32, MinimumLength = 8)]
        [Required]
        public string UserName { get; set; }


=======
        public string Name { get; set; }
>>>>>>> Stashed changes
        public string Password { get; set; }
        public string Title { get; set; }

        public List<ForumQuestion> QuestionsAsked { get { return questionsAsked; } }
        public List<Reply> Answers {  get { return answers; } }

    }

}
