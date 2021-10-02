using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SecretProject.Web.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("[controller]/[action]")]
    public class AdminController : Controller
    {

        private readonly UserManager<IdentityUser> userManager;
        public AdminController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpGet]
        public IActionResult ListUsers() => Json(userManager.Users);
    }
}
