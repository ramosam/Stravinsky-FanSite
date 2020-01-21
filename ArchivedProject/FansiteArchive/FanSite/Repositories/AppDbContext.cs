using FanSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FanSite.Repositories
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
