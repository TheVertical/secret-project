using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SecretProject.BusinessProject.ViewModels.UserData;
using SecretProject.Web.Infrastructure.Authentication;
using SecretProject.Web.Services.Interfaces;

namespace SecretProject.Web.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly LocalizationService localizationService;

        public UserService(UserManager<AppUser> userManager, LocalizationService localizationService)
        {
            this.userManager = userManager;
            this.localizationService = localizationService;
        }

        public async Task<IdentityResult> CreateNewAccount(RegistrationAccountViewModel appUserRegistrationViewModel)
        {
            var user = await userManager.FindByNameAsync(appUserRegistrationViewModel.Email);
            if (user != null)
            {
                return null;
            }

            user = new AppUser
            {
                Email = appUserRegistrationViewModel.Email,
                UserName = appUserRegistrationViewModel.FirstName,
                NormalizedUserName = appUserRegistrationViewModel.FirstName,
            };
            var result = await userManager.CreateAsync(user, appUserRegistrationViewModel.Password);

            return result;
        }
    }

}
