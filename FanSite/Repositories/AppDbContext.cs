using FanSite.Models;
using Microsoft.EntityFrameworkCore;

namespace FanSite.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
           DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UserStory> UserStories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MediaRef> MediaRefs { get; set; }

    }
}
