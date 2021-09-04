using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecretProject.BusinessProject.ViewModels.UserData;
using System.Threading.Tasks;
using SecretProject.Web.Infrastructure;
using SecretProject.Web.Services.Interfaces;

namespace SecretProject.Web.Controllers
{
    [ApiController]
    [Route("api/{controller}/{action}")]
    public class AuthorizationController : Controller
    {
        private readonly IUserService userService;

        public AuthorizationController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAccount(RegistrationAccountViewModel appUserRegistrationViewModel)
        {
            IdentityResult identityResult;
            try 
            {
                identityResult = await userService.CreateNewAccount(appUserRegistrationViewModel);
            }
            catch (Exception e)
            {
                var errorInformation = new ExtraInformation(e);
                return new JsonResult(errorInformation);
            }

            if (!identityResult.Succeeded)
            {
                return new JsonResult(new ExtraInformation(identityResult.Errors));
            }

            return new JsonResult(identityResult);
        }
    }
}
