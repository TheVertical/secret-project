using SecretProject.BusinessProject.Models.Order;
using System.Collections.Generic;

namespace SecretProject.WebApi.ViewModels
{
    public class OrderViewModel
    {
        public int? UserId { get; set; }
        public Info Info { get; set; }
        public OrderState Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public List<OrderViewModelItem> OrderItems { get; set; }
        public float FullCost { get; set; }
    }
    public class Info
    {
        public string FirstNameCustomer { get; set; }
        public string LastNameCustomer { get; set; }
        public bool IsWithDelivery { get; set; }
        public string PhoneNumber { get; set; }
        public string AdditionalNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int BuildNumber { get; set; }
        public string BuildLiteral { get; set; }
        public byte Entrance { get; set; }
        public byte Floor { get; set; }
        public int AppartmentNumber { get; set; }
    }

    public class OrderViewModelItem
    {
        public int NomenclatureId { get; set; }
        public int ActualCount { get; set; }
    }
}
