using System;
using System.ComponentModel.DataAnnotations;

namespace Stravinsky.Models
{
    public class CommentViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 8)]
        [UIHint("Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 10)]
        [UIHint("Comment")]
        public string CommentText { get; set; }

        public string StoryPost { get; set; }
    }

}
