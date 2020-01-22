using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Stravinsky.Models
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options) { }
        public DbSet<UserStory> UserStories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MediaRef> MediaRefs { get; set; }
        //public DbSet<AppUser> AppUsers { get; set; }
    }
}
