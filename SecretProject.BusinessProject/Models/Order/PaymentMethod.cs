namespace SecretProject.BusinessProject.Models.Order
{
    public enum PaymentMethod
    {
        Cash,
        Card,
        /// <summary>
        /// Выставленный счёт для оплаты
        /// </summary>
        Bill
    }
}