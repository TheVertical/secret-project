using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretProject.VisualElements;
using System;
using System.Collections.Generic;
using System.IO;
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
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.visualRedactor = visualRedactor;
        }
        [Route("visual/clear")]
        public IActionResult Clear([FromQuery]string page)
        {
            bool success = false;
            if (!String.IsNullOrEmpty(page))
                success =  visualRedactor.Clear(page);
            if (success)
                return Ok();
            else
                return BadRequest();
        }
        [Route("visual/backbone")]
        public IActionResult GetBackbone()
        {
            var fs = visualRedactor.GetBackbone() as FileStream;
            return File(fs, "application/json"); 
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
