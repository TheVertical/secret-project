﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Models.Good;
using SecretProject.VisualElements;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SecretProject.WebApi.Controllers
{
    public class PromotionController : ControllerBase
    {
        private ILogger<CatalogController> logger;
        private IVisualRedactor visualRedactor;
        private IRepository repository;
        private readonly DbContext context;

        public PromotionController(ILogger<CatalogController> logger, IVisualRedactor visualRedactor, IRepository repository, DbContext context)
        {
            this.logger = logger;
            this.visualRedactor = visualRedactor;
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        [Route("promotions")]
        [Route("promotions/{id:int?}")]
        public async Task<IActionResult> GetPromotion(int? id)
        {
            Promotion promotion = null;
            var result = id == null ? await repository.GetAsync<Promotion>(1, p => p.WorkTitle == "Спец") : await repository.GetAsync<Promotion>(1, p => p.Id == id);
            promotion = result.FirstOrDefault();
            if (promotion == null)
                return BadRequest();
            return visualRedactor.GetFormattedElement(promotion) as JsonResult;
        }
    }
}
