using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretProject.BusinessProject.Models;
using SecretProject.Web.Helpers;
using SecretProject.Web.Infrastructure;
using SecretProject.Web.Services;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SecretProject.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LocalizationController : ControllerBase
    {
        private readonly LocalizationService localizationService;

        public LocalizationController(LocalizationService localizationService)
        {
            this.localizationService = localizationService;
        }

        [HttpGet]
        public async Task<JsonResult> GetMainLiterals(Guid languageId, CancellationToken cancellationToken = default)
        {
            var literals = await localizationService.GetLiterals<LocalizationKey>(languageId, cancellationToken);
            return new JsonResult(literals);
        }

        [HttpGet]
        public async Task<IActionResult> GetDefaultLanguage([FromRoute]Guid? userId, CancellationToken cancellationToken = default)
        {
            var defaultLanguage = await localizationService.GetDefaultLanguageAsync(userId, cancellationToken);
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
