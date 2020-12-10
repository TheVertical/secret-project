using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        /// Дата и время создания заказа
        /// <summary>
        [Display(Name = "Дата и время создания заказа")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual DateTime? DateCreated { get; set; } = DateTime.Now;
        /// <summary>
        /// Детали заказа (пользователь, адресс доставки, и т.д.)
        /// </summary>
        [ForeignKey(nameof(OrderDetailsId))]
        public OrderDetails OrderDetails { get; set; }
        /// <summary>
        /// Позиции заказа
        /// </summary>
        public List<OrderItem> OrderItems { get; set; }

        private double fullCost;
        /// <summary>
        /// Полная стоимость заказа
        /// </summary>
        public double FullCost 
        {
            get
            {
                return fullCost;
            }
            
            set
            {
                fullCost = value;
            }
        }

        [Display(Name = "Статус заказа")]
        public OrderState Status { get; set; }
        /// <summary>
        /// Метод оплаты
        /// </summary>
        [Display(Name = "Метод оплаты")]
        public PaymentMethod PaymentMethod { get; set; }
        #endregion

        #region Foreign keys
        public int OrderDetailsId { get; set; }
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
