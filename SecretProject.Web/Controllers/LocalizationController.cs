using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretProject.BusinessProject.Models;
using SecretProject.Web.Infrastructure;
using SecretProject.Web.Services;
using SecretProject.Web.Services.Interfaces;

namespace SecretProject.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LocalizationController : ControllerBase
    {
        private readonly ILocalizationService localizationService;

        public LocalizationController(ILocalizationService localizationService)
        {
            this.localizationService = localizationService;
        }

        [HttpGet]
        public async Task<JsonResult> GetMainLiterals(Guid languageId, CancellationToken cancellationToken = default)
        {
            var literals = await localizationService.GetLiterals<LocalizationKey>(languageId, cancellationToken);
            return new JsonResult(literals);
        }
    }
}
