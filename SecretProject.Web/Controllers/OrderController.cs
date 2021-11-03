using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Models.Good;
using SecretProject.BusinessProject.Models.Order;
using SecretProject.VisualElements;
using SecretProject.WebApi.Infrastructure;
using SecretProject.WebApi.ViewModels;

namespace SecretProject.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class OrderController : ControllerBase
    {
        private ILogger<CatalogController> logger;
        private readonly Cart cart;
        private IVisualRedactor visualRedactor;
        private IRepository repository;
        private readonly DbContext context;
        #region Mock

        #endregion
        public OrderController(ILogger<CatalogController> logger, Cart cart, IVisualRedactor visualRedactor, IRepository repository, DbContext context)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.cart = cart ?? throw new ArgumentNullException(nameof(cart));
            this.visualRedactor = visualRedactor ?? throw new ArgumentNullException(nameof(visualRedactor));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        [Route("details/{id:int}")]
        public async Task<IActionResult> GetOrderDetails(Guid id)
        {
            var order = (await context.Set<Order>().Include(o => o.OrderDetails).Include(o => o.OrderItems).Where(o => o.Id == id).ToListAsync()).FirstOrDefault();
            if (order == null)
                return BadRequest();
            return visualRedactor.GetFormattedElement(order) as JsonResult;
        }
        [HttpPost]
        [Route("accept")]
        [Consumes("application/json")]
        public async Task<IActionResult> RegisterOrder([FromBody] OrderViewModel orderViewModel)
        {
            if (orderViewModel == null)
                return BadRequest();
            if (orderViewModel.OrderItems == null || orderViewModel.OrderItems.Count == 0)
                return BadRequest();

            Order order = new Order();
            OrderDetails details = new OrderDetails();
            foreach (var item in orderViewModel.OrderItems)
            {
                if (item.ActualCount <= 0)
                    return BadRequest();

                Nomenclature nomenclature = await context.Set<Nomenclature>().FindAsync(item.NomenclatureId);

                if (nomenclature == null)
                    return BadRequest();

                if (nomenclature.Amount < item.ActualCount)
                {
                    //TODO Что делать если количество заказанное пользователем больше того, которое есть на складе;
                }
                OrderItem orderItem = new OrderItem(nomenclature,item.ActualCount);
                order.OrderItems.Add(orderItem);
            }

            //if (orderViewModel.UserId != null)
            //{
            //    User user = await context.Set<User>().Include(u => u.DeliveryAdresses).Where(u => u.Id == orderViewModel.UserId).FirstOrDefaultAsync();
            //    details.GetInfoDataByUser(user);
            //}
            //else
            //{
            details.FirstNameCustomer = orderViewModel.Info.FirstNameCustomer;
            details.LastNameCustomer = orderViewModel.Info.LastNameCustomer;

            details.IsWithDelivery = orderViewModel.Info.IsWithDelivery;

            details.PhoneNumber = orderViewModel.Info.PhoneNumber;
            details.AdditionalPhoneNumber = orderViewModel.Info.AdditionalNumber;

            details.City = orderViewModel.Info.City;
            details.Street = orderViewModel.Info.Street;
            details.BuildNumber = orderViewModel.Info.Building;
            details.BuildLiteral = orderViewModel.Info.BuildLiteral;
            details.Entrance = orderViewModel.Info.Entrance;
            details.Floor = orderViewModel.Info.Floor;
            details.ApartmentNumber = orderViewModel.Info.AppartmentNumber;
            //}
            order.OrderDetails = details;
            order.PaymentMethod = orderViewModel.PaymentMethod;
            order.Status = orderViewModel.Status;
            await context.Set<Order>().AddAsync(order);
            context.SaveChanges();
            return Ok();
        }
    }
}
