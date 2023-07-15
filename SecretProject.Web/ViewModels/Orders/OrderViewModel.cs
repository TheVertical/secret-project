using System.Collections.Generic;
using SecretProject.BusinessProject.Models.Order;

namespace SecretProject.Web.ViewModels.Orders
{
    public class OrderViewModel
    {
        public Info Info { get; set; }
        public OrderState Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public List<OrderViewModelItem> OrderItems { get; set; }
        public float FullCost { get; set; }
    }
}
