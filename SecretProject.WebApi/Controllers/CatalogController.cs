using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretProject.VisualElements.Elements;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;
using SecretProject.Services;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Models;
using SecretProject.WebApi.ViewModels;
using SecretProject.BusinessProject.Models.Good;
using System.Linq;
using SecretProject.VisualElements;
using System.Threading.Tasks;

namespace SecretProject.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class CatalogController : ControllerBase,IDisposable
    {
        private ILogger<CatalogController> logger;
        private IVisualRedactor visualRedactor;
        private IRepository repository;

        public CatalogController(ILogger<CatalogController> logger, IVisualRedactor visualRedactor, IRepository repository)
        {
            this.logger = logger;
            this.visualRedactor = visualRedactor;
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet,Route("categories/{id:int}")]
        public IActionResult GetCategories(int? id)
        {
            if (id == null)
            {
                var groups = repository.GetAll<NomenclatureGroup, int>(group => group.Id, true).Select(g => new NomenclatureGroupViewModel(g));

                if (groups == null)
                    BadRequest();
                return visualRedactor.GetFormattedElement(groups) as JsonResult;
            }
            var group = new NomenclatureGroupViewModel( repository.GetById<NomenclatureGroup>(id.Value));
            return visualRedactor.GetFormattedElement(group) as JsonResult;

        }
        [HttpGet,Route("{categories}")]
        public JsonResult GetProduct(int id)
        {
            var nomViewModel = repository.GetById<Nomenclature>(id);
            return visualRedactor.GetFormattedElement(nomViewModel) as JsonResult;
        }

        //[HttpGet("{}")]
        public async Task<JsonResult> GetProducts(int? count = 20)
        {
            var result = await repository.GetAllAsync<Nomenclature,bool>(nom => nom.Amount > 0,false);
            return visualRedactor.GetFormattedElement(result) as JsonResult;
        }
        [HttpPost("all")]
        public async Task<JsonResult> GetProducts()
        {
            var result = await repository.GetAllAsync<Nomenclature,bool>(nom => nom.ManufacturerId != null, true);
            return visualRedactor.GetFormattedElement(result) as JsonResult;
        }

        //[HttpGet(Name = "SpecialsProducts")]
        public JsonResult GetDiscountedProducts()
        {
            var nomViewModels = repository.GetAll<Nomenclature,bool>(nom => nom.Promotion != null,false).Select(nom => new NomenclatureViewModel(nom));
            return visualRedactor.GetFormattedElement(nomViewModels) as JsonResult;
        }

        public void Dispose()
        {
            logger = null;
            visualRedactor = null;
            repository = null;
        }
    }
}
