using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SecretProject.Web.Infrastructure.Authentication
{
    public class CustomUserValidator<TUser> : UserValidator<TUser>
        where TUser : class
    {
        public CustomUserValidator() : base() { }

        public override Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
        {
            return base.ValidateAsync(manager, user);
        }
    }
}
