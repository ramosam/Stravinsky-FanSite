using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using TutorForum.Repositories;


namespace TutorForum.Models
{
    public class ForumQuestionRepository : IRepository
    {
        private AppDbContext context;
        public ForumQuestionRepository(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        public List<ForumQuestion> ForumQuestions
        {
            get
            {
                var forumQuestions = context.ForumQuestions
                    .Include(fq => fq.Questioner)
                    .Include(fq => fq.Replies)
                        .ThenInclude(r => r.Responder)
                    .ToList();
                return forumQuestions;
            }
        }

        public List<FAQuestion> FAQuestions
        {
            get
            {
                var faqs = context.FAQuestions
                    .ToList();
                return faqs;
            }
        }

       
        public List<Reply> Replies
        {
            get
            {
                var replies = context.Replies
                    .Include(r => r.Responder)
                    .ToList();
                return replies;
            }
        }
        
       
        public List<Tutor> Tutors
        {
            get
            {
                var tutors = context.Tutors.ToList();
                return tutors;
            }
        }

       
        public List<Member> Members
        {
            get
            {
                var members = context.Members.ToList();
                return members;
            }
        }


        public void AddMember(Member m)
        {
            context.Members.Add(m);
            context.SaveChanges();
        }
        

        public void AddForumQuestion(ForumQuestion fq)
        {
            fq.FindKeywords();
            context.ForumQuestions.Add(fq);
            context.SaveChanges();
        }

        public void AddReply(Reply r)
        {
            context.Replies.Add(r);
            context.SaveChanges();
        }


        public void AddFAQuestion(FAQuestion q)
        {
            context.FAQuestions.Add(q);
            context.SaveChanges();
        }


        public void AddTutor(Tutor t)
        {
            context.Tutors.Add(t);
            context.SaveChanges();
        }
        

        //public List<ForumQuestion> GetForumQuestionsByQuestioner(string userName)
        //{
        //    ForumQuestion fq = context.ForumQuestions.
        //    return forumQuestions.FindAll(fq => fq.Questioner.UserName == userName);
        //}

        public List<ForumQuestion> GetForumQuestionsByKeyword(string keyword)
        {
            // Create bucket for fqs
            List<ForumQuestion> questionsByKeyword = new List<ForumQuestion>();

            // Create lowercase version of user search string
            string lowerKeyword = keyword;
            // Separate into lowercase string array based on spaces
            // Note: Punctuation affects keyword
            string[] words = lowerKeyword.Split(' ');

            /* For each word in keyword, loop to see if there are any fqs
             * with keyword matches.
             * 
             * Next, make sure that there are no duplicate entries.
             * 
             * Then, if there is a match and is unique, add that fq to the
             * result bucket list.
             */
            // Get list of current questions
            var currentForumQs = context.ForumQuestions.ToList();
             // For each word
            for (int i = 0; i < words.Length; i++)
            {
                // For each question
                for (int q = 0; q < currentForumQs.Count; q++)
                {
                    // Find match
                    if (currentForumQs[q].Keywords.Contains(words[i]))
                    {
                        // Add to bucket
                        questionsByKeyword.Add(currentForumQs[q]);
                    }
                }
            }

            List<ForumQuestion> singleQByKeyword =  RemoveDuplicates(questionsByKeyword);


            return singleQByKeyword; 
        }

        private List<ForumQuestion> RemoveDuplicates(List<ForumQuestion> origFQList)
        {
            // Create shortList bucket
            List<ForumQuestion> shortList = new List<ForumQuestion>();
            // Create list for header comparison
            List<string> headerCheckList = new List<string>();
            // Loop through each question 
            for (int i = 0; i < origFQList.Count; i++)
            {
                // Check if unique
                if (!headerCheckList.Contains(origFQList[i].QuestionHeader))
                {
                    // Add to checkList
                    headerCheckList.Add(origFQList[i].QuestionHeader);
                    // Add to collection bucket
                    shortList.Add(origFQList[i]);
                }
            }
            // Return shortened list
            return shortList;
        }

    }
}
