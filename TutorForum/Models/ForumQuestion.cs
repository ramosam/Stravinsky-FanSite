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
            KeywordList keywordList = new KeywordList();
            // Initialize a bucket to hold the keywords found
            List<string> thisQuestionsKeywords = new List<string>();
            // Start with header - cannot be null
            string[] headerKeywords = ForumQuestionHeader.Split(' ');

            // Find useful header keywords and convert to lowercase
            for (int i = 0; i < headerKeywords.Length; i += 1)
            {
                // Create variable to hold lowercase version through each loop
                string lowercaseVersion = headerKeywords[i].ToLower();
                // If not already in list and is useful
                if (!thisQuestionsKeywords.Contains(lowercaseVersion) && !keywordList.NotUsefulKeywords.Contains(lowercaseVersion))
                {
                    thisQuestionsKeywords.Add(lowercaseVersion);
                }
            }


            // Then, collect words from Body
            string[] bodyKeywords = ForumQuestionBody.Split(' ');
            for (int b = 0; b < bodyKeywords.Length; b += 1)
            {
                string lowercaseVersion = bodyKeywords[b].ToLower();
                if (!thisQuestionsKeywords.Contains(lowercaseVersion) && !keywordList.NotUsefulKeywords.Contains(lowercaseVersion))
                {
                    thisQuestionsKeywords.Add(lowercaseVersion);
                }
            }

            // Add all the found keywords (hopefully) to the FQ's keyword list
            Keywords.AddRange(thisQuestionsKeywords);
        }



        // TODO: Sort by rating
    }
}
