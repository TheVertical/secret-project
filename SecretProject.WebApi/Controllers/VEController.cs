using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretProject.DAL.Contexts;
using SecretProject.DAL.DataInitiazation;
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
    public class VEController : ControllerBase, IDisposable
    {
        private ILogger<VEController> logger;
        private IVisualRedactor visualRedactor;
        private readonly sBaseContext context;

        public VEController(ILogger<VEController> logger, IVisualRedactor visualRedactor, sBaseContext context)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.visualRedactor = visualRedactor;
            this.context = context ?? throw new ArgumentNullException(nameof(context));
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
        [HttpGet("visual/elements/{id}")]
        public JsonResult GetAVisualElement(string id)
        {
            return visualRedactor.GetVisualElementByName(id) as JsonResult;
        }
        [HttpGet("visual/viewmodels")]
        public JsonResult GetJsonElement()
        {
            return visualRedactor.GetAllViewModels() as JsonResult;
        }

        [HttpPost]
        [Route("visual/RedeployDatabase")]
        public IActionResult RedeployDatabase()
        {
            try
            {
                DataInitiazer.RecreateDatabase(context);
                DataInitiazer.InitializeData(context);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        public void Dispose()
        {
            logger = null;
            visualRedactor = null;
        }
    }
#endif
}
