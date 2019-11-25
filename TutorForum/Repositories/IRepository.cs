using System.Collections.Generic;
using TutorForum.Models;

namespace TutorForum.Repositories
{
    public interface IRepository
    {
        List<ForumQuestion> ForumQuestions { get; }
        List<FAQuestion> KBs { get; }
        void AddForumQuestion(ForumQuestion fq);
        List<ForumQuestion> GetForumQuestionsByQuestioner(string userName);
        List<ForumQuestion> GetForumQuestionsByKeyword(string keyword);
    }
}
