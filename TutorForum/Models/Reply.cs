using System;
using System.Collections.Generic;

namespace TutorForum.Models
{
    public class Reply
    {
        // Which question the Reply is associated with
        public ForumQuestion QuestionPost { get; set; }

        // The dateTime that the reply was added to the post.
        public DateTime DateAdded { get; set; }

        // The member that wrote the post
        public Member Responder { get; set; }

        // The reply body that the member wrote
        public string ReplyBody { get; set; }

        // The double rating of the reply as the answer is voted upon
        public double Rating { get; set; }

        // The keywords associated with the Reply
        public List<string> Keywords { get; set; }

        // TODO: Write the methods for updating the reply's rating
        public void UpdateRating()
        {

        }

        // TODO: Write the FindKeywords method
        public void FindKeywords()
        {

        }

    }
}
