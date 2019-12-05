using System;
using System.Collections.Generic;

namespace TutorForum.Models
{
    public class Reply
    {
        public int ReplyID { get; set; }
        // Which question the Reply is associated with
        public ForumQuestion QuestionPost { get; set; }

        // The dateTime that the reply was added to the post.
        public DateTime DateAdded { get; set; }

        // The member that wrote the post
        public Member Responder { get; set; }

        // The reply body that the member wrote
        public string ReplyBody { get; set; }

        // The double rating of the reply as the answer is voted upon
        private double rating = 0;
        public double Rating { get { return rating; } }

        // The keywords associated with the Reply
        private List<string> keywords = new List<string>();
        public List<string> Keywords { get { return keywords; } }


        public void AddRating()
        {
            rating += 1;
        }

        public void SubtractRating()
        {
            rating -= 1;
        }

        public void FindKeywords()
        {
            KeywordList keywordList = new KeywordList();
            // Initialize a bucket to hold the keywords found
            List<string> thisQuestionsKeywords = new List<string>();
            // Start with header - cannot be null
            string[] headerKeywords = ReplyBody.Split(' ');

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

            // Add all the found keywords (hopefully) to the FQ's keyword list
            keywords.AddRange(thisQuestionsKeywords);
        }


    }
}
