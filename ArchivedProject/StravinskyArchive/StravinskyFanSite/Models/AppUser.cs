using Microsoft.AspNetCore.Identity;

namespace StravinskyFanSite.Models
{
    public class AppUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
