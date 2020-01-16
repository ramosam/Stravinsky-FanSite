using System;
using System.Collections.Generic;
<<<<<<< Updated upstream
using System.ComponentModel.DataAnnotations;
=======
using Microsoft.AspNetCore.Identity;
>>>>>>> Stashed changes

namespace TutorForum.Models
{
    public class Tutor
    {
        public int TutorID { get; set; }
        private List<string> expertise = new List<string>();
<<<<<<< Updated upstream

        [StringLength(32, MinimumLength = 8)]
        [Required]
        public string UserName { get; set; }


=======
        public string UserName { get; set; }
>>>>>>> Stashed changes
        public string Password { get; set; }
        public string Title { get; set; }


        public List<string> Expertise { get { return expertise; } }

    }
}
