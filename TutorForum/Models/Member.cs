using System;
using System.Collections.Generic;

namespace TutorForum.Models
{
    public class Member
    {
        private double rating = 0;
        private List<ForumQuestion> questionsAsked = new List<ForumQuestion>();
        private List<Reply> answers = new List<Reply>();

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }

        public double Rating { get { return rating; } }
        public List<ForumQuestion> QuestionsAsked { get { return questionsAsked; } }
        public List<Reply> Answers {  get { return answers; } }


        public void DetermineOverallRating()
        {
            // Create accumulator
            // Go through all the answers
            // count the valid ratings
            // add the ratings
            // determine average
            // update rating




            /*get {
                double average = 0;
                for (int i = 0; i < ratings.Count; i++)
                {
                    if (ratings[i] > 0)
                    {
                        average += ratings[i];
                    }
                }
                average /= ratings.Count;
                int intAverage = (int)Math.Floor(average);
                return intAverage;
            }*/



        }



    }

}
