using System.Collections.Generic;
using TutorForum.Models;

namespace TutorForum.Repositories
{
    public interface IRepository
    {
        List<ForumQuestion> ForumQuestions { get; }
        List<FAQuestion> FAQuestions { get; }
        List<Reply> Replies { get; }
        List<Tutor> Tutors { get; }
        List<Member> Members { get; }
        //List<ForumQuestion> GetForumQuestionsByQuestioner(string userName);
        List<ForumQuestion> GetForumQuestionsByKeyword(string keyword);
        void AddForumQuestion(ForumQuestion fq);
        void AddMember(Member member);
        void AddReply(Reply r);
        void AddFAQuestion(FAQuestion q);
        void AddTutor(Tutor t);
    }
}
