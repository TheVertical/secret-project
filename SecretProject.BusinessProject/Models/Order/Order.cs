using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SecretProject.BusinessProject.Models.UserData;

namespace SecretProject.BusinessProject.Models.Order
{
   
    [Table("Orders")]
    public class Order : IDomainObject
    {
        #region Base Property
        [Key]
        [Display(Name = "Ид")]
        public virtual int Id { get; set; }
        /// <summary>
        /// Специальный байтовый код для параллельных запросов к бд
        /// <summary>
        [Timestamp]
        public virtual byte[] Timestamp { get; set; }
        /// <summary>
        /// Детали заказа
        /// </summary>
        public OrderDetails OrderDetails { get; set; }

        /// <summary>
        /// Позиции заказа
        /// </summary>
        public IEnumerable<OrderItem> OrderItems { get; set; }
        #endregion

        #region Foreign keys
        #endregion

        #region Special Property

        #endregion
    }
    public enum OrderState
    {
        Confirmed,
        Payed,
        Canceled,
        //На будущее, доставлен
        Delivered
    }
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
