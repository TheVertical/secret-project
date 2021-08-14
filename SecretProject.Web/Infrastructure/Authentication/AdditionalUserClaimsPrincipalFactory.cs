using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace SecretProject.Web.Infrastructure.Authentication
{
    public class AdditionalUserClaimsPrincipalFactory
        : UserClaimsPrincipalFactory<AppUser, IdentityRole>
    {
        public AdditionalUserClaimsPrincipalFactory(
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        { }

        public override async Task<ClaimsPrincipal> CreateAsync(AppUser user)
        {
            var principal = await base.CreateAsync(user);
            var identity = (ClaimsIdentity)principal.Identity;

            var claims = new List<Claim>();
            if (!user.IsAdmin)
            {
                claims.Add(new Claim(JwtClaimTypes.Role, "user"));
            }
            else
            {
                claims.Add(new Claim(JwtClaimTypes.Role, "admin"));
            }

            identity.AddClaims(claims);
            return principal;
        }
    }
}