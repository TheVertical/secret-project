using System;
using Microsoft.AspNetCore.Identity;

namespace SecretProject.Web.Infrastructure.Authentication
{
    public class AppUser : IdentityUser
    {
        public Guid LanguageId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
