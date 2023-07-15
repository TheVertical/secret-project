namespace SecretProject.Web.ViewModels.Orders
{
    public class Info
    {
        public string FirstNameCustomer { get; set; }
        public string LastNameCustomer { get; set; }
        public bool IsWithDelivery { get; set; }
        public string PhoneNumber { get; set; }
        public string AdditionalNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        //Дом
        public int Building { get; set; }
        //Строение
        public int Structure { get; set; }
        //Корпус
        public int Housing { get; set; }
        public string BuildLiteral { get; set; }
        public byte Entrance { get; set; }
        public byte Floor { get; set; }
        public int AppartmentNumber { get; set; }
    }
}