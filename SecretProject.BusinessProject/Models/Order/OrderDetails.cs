using SecretProject.BusinessProject.Models.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SecretProject.BusinessProject.Models.Order
{
    /// <summary>
    /// Класс описывает детали заказа (пользователь, адресс доставки, и т.д.)
    /// </summary>
    [Table("Orders.Details")]
    public class OrderDetails : IDomainObject
    {
        #region Model

        #region Base Property

        [Key]
        [Display(Name = "Ид")]
        public virtual int Id { get; set; }
        /// <summary>
        /// Специальный байтовый код для параллельных запросов к бд
        /// </summary>
        [Timestamp]
        public virtual byte[] Timestamp { get; set; }
        private User user;
        [ForeignKey(nameof(UserId))]
        public User User
        {
            get => user;
            set
            {
                GetInfoDataByUser(value);
                user = value;
            }
        }
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
        public bool IsWithDelivery { get; set; }
        public virtual string Country { get; set; }
        public virtual string City { get; set; }
        public virtual string District { get; set; }
        public virtual string Street { get; set; }
        public virtual int BuildNumber { get; set; }
        /// <summary>
        /// Подъезд
        /// </summary>
        public virtual byte Entrance { get; set; }
        /// <summary>
        /// Этаж
        /// </summary>
        public virtual byte Floor { get; set; }
        public virtual int AppartmentNumber { get; set; }
        public virtual string BuildLiteral { get; set; }
        public virtual int BuildCorps { get; set; }

        #endregion


        #region Foreign keys
        public int? UserId { get; set; }
        #endregion



        #endregion
        #region Class Methods
        public void GetInfoDataByUser(User user)
        {
            Adress defaultAdress = user.DeliveryAdresses.Where(a => a.Id == user.DefaultDeliveryAdressId).FirstOrDefault() ?? user.DeliveryAdresses.FirstOrDefault() ?? throw new Exception("User haven't any adress!");

            FirstNameCustomer = user.FirstName;
            LastNameCustomer = user.LastName;
            Country = defaultAdress.Country;
            City = defaultAdress.City;
            District = defaultAdress.District;
            Street = defaultAdress.Street;
            BuildNumber = defaultAdress.BuildNumber;
            Entrance = defaultAdress.Entrance;
            Floor = defaultAdress.Floor;
            AppartmentNumber = defaultAdress.AppartmentNumber;
            MainPhone = user.MainPhone;
            AdditionalPhone = user.AdditionalPhone;
        }

        private void GetUserFromInfoData()
        {

        }
        #endregion

    }
}
