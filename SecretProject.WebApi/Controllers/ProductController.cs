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
using SecretProject.BusinessProject.Models.Nomeclature;
using System.Linq;

namespace SecretProject.WebApi.Controllers
{
    [ApiController]
    [Route("Catalog")]
    [Route("Catalog/[action]")]
    [Route("Catalog/[action]/{id}")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> logger;
        private readonly VisualRedactor visualRedactor;
        private readonly IRepository<Nomenclature> repository;

        public ProductController(ILogger<ProductController> logger, VisualRedactor visualRedactor, IRepository<Nomenclature> repository)
        {
            this.logger = logger;
            this.visualRedactor = visualRedactor;
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        //[HttpGet(Name = "Products")]
        //[Route("[controller]/[action]/{id}:int")]
        public JsonResult GetProduct(int id)
        {
            var nomViewModel = repository.GetById(id);
            return visualRedactor.GetVisualElementJson(nomViewModel);
        }

        //[Route("[controller]")]
        //[Route("[controller]/{count:int}")]
        public JsonResult GetProducts(int count = 20)
        {
            var nomViewModels = repository.Get(count,(e) => { return true; }).Select(nom => new NomenclatureViewModel(nom));
            return visualRedactor.GetVisualElementJson(nomViewModels);
        }

        //[HttpGet(Name = "SpecialsProducts")]
        public JsonResult GetDiscountedProducts()
        {
            var nomViewModels = repository.GetAll(nom => nom.Promotion != null,false).Select(nom => new NomenclatureViewModel(nom));
            return visualRedactor.GetVisualElementJson(nomViewModels);
        }


        

    }
}
