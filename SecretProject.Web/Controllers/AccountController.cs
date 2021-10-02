using System;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecretProject.BusinessProject.ViewModels.UserData;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using SecretProject.BusinessProject.Models;
using SecretProject.Web.Infrastructure;
using SecretProject.Web.Services;
using SecretProject.Web.Services.Interfaces;

namespace SecretProject.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly ILocalizationService localizationService;

        public AccountController(IAccountService accountService, ILocalizationService localizationService)
        {
            this.accountService = accountService;
            this.localizationService = localizationService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(AuthenticationAccountViewModel viewModel, CancellationToken cancellationToken = default)
        {
            var principal = await accountService.SignIn(viewModel, cancellationToken);

            if (principal != null)
            {
                await HttpContext.SignInAsync(principal);
                return Json(new ExtraInformation(true));
            }

            var result = new ExtraInformation(false,
                message: await localizationService.LocalizeAsync(
                    LocalizationKey.Authentification_EmailOrPasswordIsWrong, cancellationToken),
                type: ExtraInformationType.Info);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await accountService.SignOut();
            var result = new ExtraInformation(false);
            return Json(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegistrationAccountViewModel appUserRegistrationViewModel, CancellationToken cancellationToken = default)
        {
            IdentityResult identityResult;

            try 
            {
                identityResult = await accountService.RegisterNew(appUserRegistrationViewModel , cancellationToken);
            }
            catch (Exception e)
            {
                var errorInformation = new ExtraInformation(null, message: e.Message, type: ExtraInformationType.Error);
                return new JsonResult(errorInformation);
            }

            if (!identityResult.Succeeded)
            {
                return new JsonResult(new ExtraInformation(false, message: identityResult.Errors.ToString(), type:ExtraInformationType.Error));
            }

            var result = identityResult.Succeeded
                ? new ExtraInformation(true,
                    message: await localizationService.LocalizeAsync(
                        LocalizationKey.Authorization_AccountWasCreatedSuccessfully, cancellationToken))
                : new ExtraInformation(false, message: identityResult.Errors.ToString(),
                    type: ExtraInformationType.Error);

            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetDefaultLanguage([FromRoute] Guid? userId, CancellationToken cancellationToken = default)
        {
            var defaultLanguage = await accountService.GetDefaultAccountLanguage(userId, cancellationToken);
            string message = await localizationService.LocalizeAsync(LocalizationKey.Success, cancellationToken);

            var result = new ExtraInformation
            {
                Message = message,
                Data = defaultLanguage,
            };

            return new JsonResult(result);
        }
    }
}
