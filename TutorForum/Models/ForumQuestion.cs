using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TutorForum.Models
{
    public class ForumQuestion : IQuestion
    {
        public int ForumQuestionID { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 8)]
        public Member Questioner { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        [UIHint("Question Header")]
        [StringLength(250, MinimumLength = 20, ErrorMessage = "Your header must be between 20 and 250 characters.")]
        public string QuestionHeader { get; set; }

        [Required]
        [UIHint("Question Body")]
        [StringLength(1000, MinimumLength = 20)]
        public string QuestionBody { get; set; }

        private List<string> keywords = new List<string>();
        public List<string> Keywords { get { return keywords; } }

        private List<Reply> replies = new List<Reply>();
        public List<Reply> Replies { get { return replies; } }

        public void AddReply(Reply r)
        {
            replies.Add(r);
        }


        public void FindKeywords()
        {
            KeywordList keywordList = new KeywordList();
            // Initialize a bucket to hold the keywords found
            List<string> thisQuestionsKeywords = new List<string>();
            // Start with header - cannot be null
            string[] headerKeywords = QuestionHeader.Split(' ');

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
            string[] bodyKeywords = QuestionBody.Split(' ');
            for (int b = 0; b < bodyKeywords.Length; b += 1)
            {
                string lowercaseVersion = bodyKeywords[b].ToLower();
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
