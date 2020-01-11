using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TutorForum.Models
{
    public class Tutor
    {
        public int TutorID { get; set; }
        private List<string> expertise = new List<string>();

        [StringLength(32, MinimumLength = 8)]
        [Required]
        public string UserName { get; set; }


        public string Password { get; set; }
        public string Title { get; set; }


        public List<string> Expertise { get { return expertise; } }

    }
}
