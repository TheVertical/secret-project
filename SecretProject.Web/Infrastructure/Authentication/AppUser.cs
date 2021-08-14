using Microsoft.AspNetCore.Identity;

namespace SecretProject.Web.Infrastructure.Authentication
{
    public class AppUser : IdentityUser
    {
        public bool IsAdmin { get; set; }
    }
}
