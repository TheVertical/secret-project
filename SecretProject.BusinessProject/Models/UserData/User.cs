 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.BusinessProject.Models.UserData
{
    public enum UserStatus
    {
        Active,Block,Disable,NonActive
    }
    public class User : IDomainObject
    {

        #region Base Property

        /// <summary>
        /// Ид
        /// </summary>
        [Key,Display(Name = "Ид")]
        public virtual int Id { get; set; }
        /// <summary>
        /// Специальный байтовый код для параллельных запросов к бд
        /// </summary>
        [Timestamp]
        public virtual byte[] Timestamp { get; set; }
        public virtual UserStatus Status { get; set; }
        #region Authorization
        /// <summary>
        /// Логин
        /// </summary>
        [Display(Name = "Логин")]
        [Required]
        public virtual string Login { get; set; }
        private string password;
        /// <summary>
        /// Пароль "засоленный"
        /// </summary>
        [Display(Name = "Пароль")]
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100,ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]
        public virtual string Password
        {
            get => password; set
            {
                //TODO Здесь должно происходить 'засаливание' пароля
                password = value;
            }
        }
        [NotMapped]
        public virtual string Salt { get; set; }
        #endregion

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Display(Name = "Имя пользователя")]
        public virtual string FirstName { get; set; }
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        [Display(Name = "Фамилия пользователя")]
        public virtual string LastName { get; set; }
        /// <summary>
        /// Электронная почта
        /// </summary>
        [Display(Name = "Электронная почта")]
        public virtual string Email { get; set; }
        /// <summary>
        /// Основной номер телефона в цифромов формате, ИСПОЛЬЗУЙТЕ поле MainPhone
        /// </summary>
        public string PhoneNumber { get => MainPhone.PhoneDigits; set => MainPhone.PhoneNumber = value; }
        [NotMapped]
        public Phone MainPhone = new Phone();
        /// <summary>
        /// Дополнительный номер телефона в цифромов формате, ИСПОЛЬЗУЙТЕ поле AdditionalPhone
        /// </summary>
        public string AdditionalNumber { get => AdditionalPhone.PhoneDigits; set => AdditionalPhone.PhoneNumber = value; }
        [NotMapped]
        public Phone AdditionalPhone = new Phone();
        public int DefaultDeliveryAdressId { get; set; }
        /// <summary>
        /// Адреса доставки
        /// </summary>
        [Display(Name = "Адреса доставки")]
        public List<Adress> DeliveryAdresses { get; set; }


        #endregion

        #region Foreign keys
        //Внешние ключи
        #endregion

        #region Special Property
        #endregion
    }
}
