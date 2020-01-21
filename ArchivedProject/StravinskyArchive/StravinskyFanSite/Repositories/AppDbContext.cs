using StravinskyFanSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace StravinskyFanSite.Repositories
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(
           DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UserStory> UserStories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MediaRef> MediaRefs { get; set; }

    }
}
