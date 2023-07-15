using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretProject.VisualElements;

namespace SecretProject.Web.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IVisualRedactor visualRedactor;

        public HomeController(ILogger<HomeController> logger, IVisualRedactor visualRedactor)
        {
            this.logger = logger;
            this.visualRedactor = visualRedactor;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return visualRedactor.GetBackbone() as JsonResult;
        }

        public JsonResult Error()
        {
            return null;
        }
    }
}
