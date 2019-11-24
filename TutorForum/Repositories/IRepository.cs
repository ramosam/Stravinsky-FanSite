using System.Collections.Generic;
using TutorForum.Models;

namespace TutorForum.Repositories
{
    public interface IRepository
    {
        List<ForumQuestion> ForumQuestions { get; }
        void AddForumQuestion(ForumQuestion fq);
        ForumQuestion GetForumQuestionByQuestioner(string userName);
        List<ForumQuestion> GetForumQuestionsByKeyword(string keyword);
    }
}
