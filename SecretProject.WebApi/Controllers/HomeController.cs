using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretProject.VisualElements;

namespace SecretProject.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IVisualRedactor visualRedactor;

        public HomeController(ILogger<HomeController> logger, IVisualRedactor visualRedactor)
        {
            this.logger = logger;
            this.visualRedactor = visualRedactor;
        }

        public ViewResult Index()
        {
            return View("React");
        }

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
