using System.Collections.Generic;

namespace SecretProject.Web.ViewModels
{
    public class CartResult
    {
        public float FullCost { get; set; }
        public IEnumerable<CartLineViewModel> Lines { get; set; }
    }
}
