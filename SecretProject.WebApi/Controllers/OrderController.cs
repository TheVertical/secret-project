using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Models.Order;
using SecretProject.VisualElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SecretProject.WebApi.Controllers
{
    [ApiController]
    [Route("orders/")]
    public class OrderController : ControllerBase
    {
        private ILogger<CatalogController> logger;
        private IVisualRedactor visualRedactor;
        private IRepository repository;
        private readonly DbContext context;
        #region Mock

        #endregion
        public OrderController(ILogger<CatalogController> logger, IVisualRedactor visualRedactor, IRepository repository, DbContext context)
        {
            this.logger = logger;
            this.visualRedactor = visualRedactor;
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        [Route("details/{id:int}")]
        public async Task<IActionResult> GetOrderDetails(int id)
        {
            var order =(await context.Set<Order>().Include(o => o.OrderDetails).Include(o => o.OrderItems).Where(o => o.Id == id).ToListAsync()).FirstOrDefault();
            if (order == null)
                return BadRequest();
            return visualRedactor.GetFormattedElement(order) as JsonResult;
        }
        [HttpPost]
        [Route("accept")]
        public IActionResult RegisterOrder([FromBody]string json)
        {
            //JsonDocument.Parse(json);
            return BadRequest();
        }
    }
}
