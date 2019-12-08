using TutorForum.Models;
using Microsoft.EntityFrameworkCore;

namespace TutorForum.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
           DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<FAQuestion> FAQuestions { get; set; }
        public DbSet<ForumQuestion> ForumQuestions { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        
    }
}
