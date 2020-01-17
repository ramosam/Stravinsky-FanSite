using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FanSite.Models
{
    public class UserStory
    {
        public int UserStoryID { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 10)]
        [UIHint("Story")]
        public string StoryPost { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8)]
        [UIHint("Name")]
        public string Name { get; set; }
        private List<Comment> comments = new List<Comment>();
        public List<Comment> Comments { get { return comments; } }
    }
}