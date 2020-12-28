using SecretProject.WebApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretProject.WebApi.ViewModels
{
    public class CartResult
    {
        public float FullCost { get; set; }
        public IEnumerable<CartLineViewModel> Lines { get; set; }
    }
}
