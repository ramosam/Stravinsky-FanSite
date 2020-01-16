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
                var tutors = context.Tutors
                    .ToList();
                return tutors;
            }
        }

       
        //public List<Member> Members
        //{
        //    get
        //    {
        //        //var members = context.Members
        //        //    .ToList();
        //        //return members;
        //    }
        //}


        public void AddMember(Member m)
        {
            //context.Members.Add(m);
            context.SaveChanges();
        }
        

        public void AddForumQuestion(ForumQuestion fq, Member member)
        {
            // Make sure that there are keywords
            fq.FindKeywords();
            // Find match
            context.ForumQuestions.Add(fq);
            member.QuestionsAsked.Add(fq);
            //context.Members.Update(member);
            context.SaveChanges();
        }

        public void AddReply(ForumQuestion fq, Reply r, Member replyMember)
        {
            context.Replies.Add(r);
            fq.AddReply(r);
            context.ForumQuestions.Update(fq);
            replyMember.Answers.Add(r);
            //context.Members.Update(replyMember);
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
        

        public List<IQuestion> GetIQuestionsByKeyword(string keyword)
        {
            // Create bucket for fqs
            List<IQuestion> questionsByKeyword = new List<IQuestion>();

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
            var currentFAQs = context.FAQuestions.ToList();
            List<IQuestion> currentIQs = new List<IQuestion>();
            currentIQs.AddRange(currentForumQs);
            currentIQs.AddRange(currentFAQs);


             // For each word
            for (int i = 0; i < words.Length; i++)
            {
                // For each question
                for (int q = 0; q < currentIQs.Count; q++)
                {
                    // Make sure that there are keywords
                    currentIQs[q].FindKeywords();
                    // Find match
                    if (currentIQs[q].Keywords.Contains(words[i]))
                    {
                        // Add to bucket
                        questionsByKeyword.Add(currentIQs[q]);
                    }
                }
            }

            List<IQuestion> singleQByKeyword =  RemoveDuplicates(questionsByKeyword);


            return singleQByKeyword; 
        }

        private List<IQuestion> RemoveDuplicates(List<IQuestion> origFQList)
        {
            // Create shortList bucket
            List<IQuestion> shortList = new List<IQuestion>();
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

        public ForumQuestion FindForumQuestionByQuestionHeader(string questionHeader)
        {
            List<ForumQuestion> forumQuestions = context.ForumQuestions.ToList();
            ForumQuestion fq = forumQuestions.Find(q => q.QuestionHeader == questionHeader);
            return fq;
        }
    }
}
