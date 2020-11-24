using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SecretProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NomController : Controller
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ILogger<WeatherForecastController> logger;
        private readonly IRepository<Nomenclature> repository;

        public NomController(ILogger<WeatherForecastController> logger, IRepository<Nomenclature> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.logger = logger;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(JsonSerializer.Serialize(repository.GetAll<int>(ex => ex.Id, true).Select(n => new NomenclatureViewModel { Id = n.Id, Name = n.Name, Description = n.Description })));
        }
    }
}
