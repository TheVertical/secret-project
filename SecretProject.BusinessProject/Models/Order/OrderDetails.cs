using SecretProject.BusinessProject.Models.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.BusinessProject.Models.Order
{
    /// <summary>
    /// Класс описывает детали заказа (пользователя, адресс доставки, и т.д.)
    /// </summary>
    [Table("Orders.Details")]
    public class OrderDetails : IDomainObject
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

        [ForeignKey(nameof(Id))]
        public Order Order { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        [Display(Name = "Имя")]
        public string FirstNameCustomer { get; set; }
        [Display(Name = "Фамилия")]
        public string LastNameCustomer { get; set; }

        public string PhoneNumber { get => MainPhone.PhoneDigits; set => MainPhone.PhoneNumber = value; }
        [NotMapped]
        public Phone MainPhone = new Phone();
        /// <summary>
        /// Дополнительный номер телефона в цифромов формате, ИСПОЛЬЗУЙТЕ поле AdditionalPhone
        /// </summary>
        public string AdditionalNumber { get => AdditionalPhone.PhoneDigits; set => AdditionalPhone.PhoneNumber = value; }
        [NotMapped]
        public Phone AdditionalPhone = new Phone();




        #endregion


        #region Foreign keys
        public int? UserId { get; set; }
        #endregion
    }
}
