using System;
using System.Collections.Generic;

namespace TutorForum.Models
{
    public interface IQuestion
    {
        DateTime DateAdded { get; }
        List<string> Keywords { get; }
        string QuestionHeader { get; }
        string QuestionBody { get; }
        void FindKeywords();


    }
}
