using System;
using System.Collections.Generic;

namespace TutorForum.Models
{
    public class KeywordList
    {
        public List<string> UsefulKeywords = new List<string>
        {
            "method", "code", "block", "statements", "definition", "argument", "parameter", "out", "ref", "initialize", "public", "static", "void", "declared", "access", "global", "ToString", "date"
        };

        public List<string> NotUsefulKeywords = new List<string>
        {
            "no", "yes", "I", "you", "the", "a", "it", "its", "it's", "they", "them", "there", "their", "your", "yours", "is", "what", "how", "because", "and", "any", "more", "of", "have", "not", "tried", "when", "to", "or", "are", "in", "an", "by", "why", "be", "that", "but", "as", "I'm", "am", "me", "my", "mine", "you're", "can", "can't", "cannot", "do", "does", "doesn't", "don't", 
        };



        public void AddUsefulKeyword(string newKeyword) => UsefulKeywords.Add(newKeyword);
        public void AddNotUsefulKeyword(string newKeyword) => NotUsefulKeywords.Add(newKeyword);
    }
}
