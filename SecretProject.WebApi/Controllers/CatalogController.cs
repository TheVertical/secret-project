using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Models;
using SecretProject.BusinessProject.Models.Good;
using SecretProject.VisualElements;
using SecretProject.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretProject.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class CatalogController : ControllerBase, IDisposable
    {
        private ILogger<CatalogController> logger;
        private IVisualRedactor visualRedactor;
        private IRepository repository;
        private readonly DbContext context;

        public CatalogController(ILogger<CatalogController> logger, IVisualRedactor visualRedactor, IRepository repository, DbContext context)
        {
            this.logger = logger;
            this.visualRedactor = visualRedactor;
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        [Route("categories")]
        [Route("categories/{id:int}")]
        public async Task<IActionResult> GetCategories(int? id)
        {
            if (id == null)
            {
                var groups = await repository.GetAllAsync<NomenclatureGroup, int>(group => group.Id, true);
                var groupViewModels = groups.Select(g => new NomenclatureGroupViewModel(g));
                if (groupViewModels == null)
                    return BadRequest();
                return visualRedactor.GetFormattedElement(groupViewModels) as JsonResult;
            }
            NomenclatureGroupViewModel categoryViewModel = new NomenclatureGroupViewModel(await repository.GetByIdAsync<NomenclatureGroup>(id.Value));
            return visualRedactor.GetFormattedElement(categoryViewModel) as JsonResult;

        }
        [HttpGet]
        [Route("product/{id:int}")]
        public async Task<JsonResult> GetProducts(int? id)
        {
            int _id = id != null ? id.Value : 1;
            NomenclatureViewModel vm = new NomenclatureViewModel(await repository.GetByIdAsync<Nomenclature>(_id));
            return visualRedactor.GetFormattedElement(vm) as JsonResult;
        }
        /// <summary>
        /// Получить номенклатуры по фильтрам
        /// </summary>
        /// <param name="categoryId">ид категории</param>
        /// <param name="count">количество (не более 20 за раз)</param>
        /// <returns></returns>
        [HttpGet]
        [Route("product")]
        public async Task<IActionResult> GetPoducts(
            [FromQuery]bool? needTotalCount,
            [FromQuery]int? manufacturerId,
            [FromQuery]int? categoryId,
            [FromQuery] int? count,
            [FromQuery]int? from,
            [FromQuery]float? minValue,
            [FromQuery]float? maxValue)
        {
            float maxCost = -1;
            float minCost = -1;
            int allNomByQuery = -1;
            int amount = count != null && count < 20 ? count.Value : 20;

            IEnumerable<Nomenclature> noms = null;

            IQueryable<Nomenclature> query = context.Set<Nomenclature>().OrderBy(n => n.Id);
            if (manufacturerId != null)
                query = query.Where(p => p.ManufacturerId == manufacturerId);

            if (categoryId != null)
                query = query.Where(p => p.NomenclatureGroupId == categoryId);

            if(needTotalCount != null && needTotalCount.Value)
                allNomByQuery = await query.CountAsync();

            if (from != null)
                query = query.Where(p => p.Id > from);

            if (minValue != null)
            {
                query = query.Where(p => p.Cost >= minValue);
                minCost = minValue.Value;
            }
            if (maxValue != null)
            {
                query = query.Where(p => p.Cost <= maxValue);
                maxCost = maxValue.Value;
            }
            noms = await query.Take(amount).ToListAsync();
            var nomViewModes = noms.Select(n => new NomenclatureViewModel(n));
            NomenclatureResult nomResult = new NomenclatureResult(allNomByQuery, maxCost, minCost,nomViewModes);
            return visualRedactor.GetFormattedElement(nomResult) as JsonResult;
        }
        /// <summary>
        /// Получить номенклатуры по определенной акцие
        /// </summary>
        /// <param name="promotion">рабочее название скидки</param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("product/discounted")]
        public async Task<IActionResult> GetDiscountedProducts([FromQuery] string promotion, [FromQuery] int? count)
        {
            IEnumerable<NomenclatureViewModel> noms = null;
            int amount = count != null && count < 20 ? count.Value : 20;
            if (!String.IsNullOrEmpty(promotion))
            {
                //var promotions = await repository.GetAsync<Promotion>(amount,prom => prom.WorkTitle == promotion);
                var promotions = await context.Set<Promotion>().Where(prom => prom.WorkTitle == promotion).Include("DiscountedNomenclatures").Take(1).ToListAsync();
                var prom = promotions.FirstOrDefault();
                if (prom == null)
                    return BadRequest();
                noms = prom.DiscountedNomenclatures.Select(nom => new NomenclatureViewModel(nom));
            }
            else
                return BadRequest();
            return visualRedactor.GetFormattedElement(noms) as JsonResult;
        }

        public void Dispose()
        {
            logger = null;
            visualRedactor = null;
            repository = null;
        }
    }
}
