using System;
using System.Collections.Generic;

namespace TutorForum.Models
{
    public class Tutor
    {
        private List<string> expertise = new List<string>();
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public List<string> Expertise { get { return expertise; } }

    }
}
