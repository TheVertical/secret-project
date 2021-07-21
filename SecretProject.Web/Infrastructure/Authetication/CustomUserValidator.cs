using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretProject.WebApi.Infrastructure.Authetication
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
