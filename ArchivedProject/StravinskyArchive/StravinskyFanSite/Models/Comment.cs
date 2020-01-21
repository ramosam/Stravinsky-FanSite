using System.ComponentModel.DataAnnotations;

namespace StravinskyFanSite.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 8)]
        [UIHint("Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 10)]
        [UIHint("Comment")]
        public string CommentText { get; set; }
    }
}
