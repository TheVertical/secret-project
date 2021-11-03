using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Models.Good;
using SecretProject.VisualElements;
using SecretProject.WebApi.Infrastructure;
using SecretProject.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SecretProject.Web.ViewModels;

namespace SecretProject.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class CartController : ControllerBase
    {
        private ILogger<CartController> logger;
        private readonly IVisualRedactor visualRedactor;

        private Cart cart { get; set; }
        private IRepository repository;
        private readonly DbContext context;

        public CartController(ILogger<CartController> logger, Cart cart, IVisualRedactor visualRedactor, IRepository repository, DbContext context)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.cart = cart ?? throw new ArgumentNullException(nameof(CartController.cart));
            this.visualRedactor = visualRedactor ?? throw new ArgumentNullException(nameof(visualRedactor));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetCartLineList(CancellationToken cancellationToken = default)
        {
            var lines = cart.Lines.ToList();
            List<CartLineViewModel> cartLines = new List<CartLineViewModel>();
            foreach (var l in lines)
            {
                Nomenclature nomenclature = await repository.GetByIdAsync<Nomenclature>(l.NomenclatureId, cancellationToken);
                if (nomenclature != null)
                {
                    NomenclatureViewModel viewModel = new NomenclatureViewModel(nomenclature);
                    CartLineViewModel line = new CartLineViewModel(viewModel, l.Amount);
                    cartLines.Add(line);
                }
            }
            CartResult result = new CartResult
            {
                FullCost = cart.ComputeToValue(),
                Lines = cartLines
            };

            return visualRedactor.GetFormattedElement(result) as JsonResult;
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddToCart([FromQuery] int nomenclatureId, [FromQuery] int amount, CancellationToken cancellationToken = default)
        {
            IActionResult result = null;
            if (amount < 1)
                return BadRequest();
            Nomenclature nomenclature = await repository.GetByIdAsync<Nomenclature>(nomenclatureId, cancellationToken);
            if (nomenclature != null)
            {
                cart.AddLine(nomenclature, amount);
                result = Ok();
            }
            else
                return BadRequest("Nomenclature was not found!");
            return result;
        }

        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> RemoveLineFromCart([FromQuery] int nomenclatureId, CancellationToken cancellationToken = default)
        {
            IActionResult result = null;
            Nomenclature nomenclature = await repository.GetByIdAsync<Nomenclature>(nomenclatureId, cancellationToken);
            if (nomenclature != null)
            {
                cart.RemoveLine(nomenclature);
                result = Ok();  
            }
            else
                return BadRequest("Nomenclature was not found!");
            return result;
        }
    }
}
