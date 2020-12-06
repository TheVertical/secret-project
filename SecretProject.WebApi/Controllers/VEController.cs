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
    public class VEController : ControllerBase,IDisposable
    {
        private ILogger<VEController> logger;
        private IVisualRedactor visualRedactor;

        public VEController(ILogger<VEController> logger, IVisualRedactor visualRedactor)
        {
            this.logger = logger;
            this.visualRedactor = visualRedactor;
        }

        [Route("visual/backbone")]
        public IActionResult GetBackbone()
        {
            return visualRedactor.GetBackbone() as JsonResult;
        }
        [Route("visual/all")]
        public JsonResult GetAllVisualElements()
        {
            return visualRedactor.GetAllVisualElements() as JsonResult;
        }
        [HttpGet("visual/{id}")]
        public JsonResult GetAVisualElement(string id)
        {
            return visualRedactor.GetVisualElementByName(id) as JsonResult;
        }
        [HttpGet("visual/viewmodels")]
        public JsonResult GetJsonElement()
        {
            return visualRedactor.GetAllViewModels() as JsonResult;
        }

        public void Dispose()
        {
            logger = null;
            visualRedactor = null;
        }
    }
#endif
}
