using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SecretProject.BusinessProject.Models;
using SecretProject.DAL.Infrastructure;
using SecretProject.Web.Services;
using SecretProject.Web.Services.Interfaces;

namespace SecretProject.Web.Infrastructure.Authentication
{
    public class PasswordValidator : IPasswordValidator<IdentityUser>
    {
        private readonly ILocalizationService localizationService;

        public PasswordValidator(ILocalizationService localizationService)
        {
            this.localizationService = localizationService;
        }

        public async Task<IdentityResult> ValidateAsync(UserManager<IdentityUser> manager, IdentityUser user, string password)
        {
            var success = PasswordHasher.Verify(password, user.PasswordHash);

            if (!success)
            {
                var failedMessage = await localizationService.LocalizeAsync(LocalizationKey.Authentification_EmailOrPasswordIsWrong, CancellationToken.None);
                var identityError = new IdentityError() { Code = "DefaultError", Description = failedMessage};
                return IdentityResult.Failed(identityError);
            }

            return IdentityResult.Success;
        }
    }
}
