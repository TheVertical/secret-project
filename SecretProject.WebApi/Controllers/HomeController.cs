using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretProject.VisualElements.Elements;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;
using SecretProject.Services;
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

        [HttpGet(Name ="Get")]
        public JsonResult Get()
        {
            return visualRedactor.GetBackbone() as JsonResult;
        }
    }
}
