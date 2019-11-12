using System;
using System.Collections.Generic;

namespace TutorForum.Models
{
    public class FAQuestion
    {
        public DateTime DateAdded { get; set; }
        public string FAQuestionTitle { get; set; }
        public string FAQAnswerBody { get; set; }
        
        public List<string> Keywords { get; set; }

        // TODO: Write the FindKeywords
        public void FindKeywords()
        {

        }
    }
}
