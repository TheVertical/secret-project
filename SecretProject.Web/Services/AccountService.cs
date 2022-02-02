using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using SecretProject.BusinessProject;
using SecretProject.BusinessProject.Models;
using SecretProject.BusinessProject.ViewModels.UserData;
using SecretProject.Web.Services.Interfaces;

namespace SecretProject.Web.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ILocalizationService localizationService;

        public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILocalizationService localizationService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.localizationService = localizationService;
        }

        public async Task<ClaimsPrincipal> SignIn(AuthenticationAccountViewModel viewModel,
            CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(viewModel.Email);

            if (user == null)
            {
                return null;
            }

            var isPasswordValid = await userManager.CheckPasswordAsync(user, viewModel.Password);
            var canSignIn = await signInManager.CanSignInAsync(user);
            if (!isPasswordValid || !canSignIn)
            {
                return null;
            }

            await signInManager.SignInAsync(user, true, JwtBearerDefaults.AuthenticationScheme);

            return await signInManager.CreateUserPrincipalAsync(user);
            
        }

        public async Task SignOut()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterNew(RegistrationAccountViewModel viewModel, CancellationToken cancellationToken)
        {

            var user = await userManager.FindByNameAsync(viewModel.Email);
            if (user != null)
            {
                var error = new IdentityError
                {
                    Description = await localizationService.LocalizeAsync(LocalizationKey.Authorization_UserExists,
                        cancellationToken)
                };
                return IdentityResult.Failed(error);
            }

            var emailSymbolIndex = viewModel.Email.IndexOf('@');
            var userName = viewModel.Email.Remove(emailSymbolIndex);

            user = new IdentityUser
            {
                UserName = userName,
                Email = viewModel.Email,
                NormalizedUserName = viewModel.FirstName,
            };
            var result = await userManager.CreateAsync(user, viewModel.Password);

            return result;
        }

        public async Task<Guid> GetDefaultAccountLanguage(Guid? userId, CancellationToken cancellationToken)
        {
            return Constants.LanguageCodeIds["RU"];
        }
    }
}
