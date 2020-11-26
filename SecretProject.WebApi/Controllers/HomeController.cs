using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretProject.VisualElements.Elements;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;
using SecretProject.Services;

namespace SecretProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly VisualRedactor visualRedactor;

        public HomeController(ILogger<HomeController> logger, VisualRedactor visualRedactor)
        {
            this.logger = logger;
            this.visualRedactor = visualRedactor;
        }

        private int counter = 0;
        public int Counter { get { counter++; return counter; } }
        [HttpGet]
        public JsonResult Get()
        {
            return visualRedactor.GetExplicitMockBackgone();
        }

#if DEBUG
        [HttpGet(Name = "GetAllVisualElements")]
        public JsonResult GetAllVisualElements()
        {
            return visualRedactor.GetAllJsonVisualObjects();
        }
#endif
    }
}
