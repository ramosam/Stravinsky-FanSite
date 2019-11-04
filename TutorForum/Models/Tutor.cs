using System;
using System.Collections.Generic;

namespace TutorForum.Models
{
    public class Tutor
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public List<string> expertise { get; set; }

    }
}
