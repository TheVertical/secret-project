using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretProject.VisualElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretProject.WebApi.Controllers
{
#if DEBUG
    [ApiController]
    //[Route("[controller]")]
    //[Route("[controller]/[action]")]
    public class VEController : Controller
    {
        private readonly ILogger<VEController> logger;
        private readonly IVisualRedactor visualRedactor;

        public VEController(ILogger<VEController> logger, IVisualRedactor visualRedactor)
        {
            this.logger = logger;
            this.visualRedactor = visualRedactor;
        }

        [Route("[controller]")]
        public JsonResult GetBackbone()
        {
            return visualRedactor.GetBackbone() as JsonResult;
        }

        //[HttpGet(Name = "ES")]
        [Route("[controller]/es")]
        public JsonResult GetAllVisualElements()
        {
            return visualRedactor.GetAllVisualElements() as JsonResult;
        }
    }
#endif
}
