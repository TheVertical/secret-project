using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Models;
using SecretProject.BusinessProject.Models.Good;
using SecretProject.VisualElements;
using SecretProject.WebApi.Infrastructure;
using SecretProject.WebApi.Services;
using SecretProject.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SecretProject.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class CartController : ControllerBase
    {
        private ILogger<CartController> logger;
        private readonly IVisualRedactor visualRedactor;

        private SessionHelper sessionHelper => new SessionHelper(logger, HttpContext.Session);
        private IRepository repository;
        private readonly DbContext context;

        public CartController(ILogger<CartController> logger, IVisualRedactor visualRedactor, IRepository repository, DbContext context)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.visualRedactor = visualRedactor ?? throw new ArgumentNullException(nameof(visualRedactor));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetCartLineList()
        {
            Cart cart = GetCart();
            var lines = cart.Lines;
            return visualRedactor.GetFormattedElement(lines) as JsonResult;
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddToCart([FromQuery]int nomenclatureId,[FromQuery]int amount)
        {
            Nomenclature nomenclature = await repository.GetByIdAsync<Nomenclature>(nomenclatureId);
            if (nomenclature != null)
            {
                Cart cart = GetCart();
                cart.AddItem(nomenclature, amount);
                SaveCart(cart);
            }
            else
                return BadRequest("Nomenclature was not found!");
            return Ok();
        }

        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> RemoveLineFromCart([FromQuery] int nomenclatureId)
        {
            Nomenclature nomenclature = await repository.GetByIdAsync<Nomenclature>(nomenclatureId);
            if (nomenclature != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(nomenclature);
                SaveCart(cart);
            }
            else
                return BadRequest("Nomenclature was not found!");
            return Ok();
        }

        private Cart GetCart()
        {
            Cart cart = sessionHelper.Get<Cart>() ?? new Cart();
            return cart;
        }
        private void SaveCart(Cart cart)
        {
            sessionHelper.Save<Cart>(cart);
        }
    }
}
