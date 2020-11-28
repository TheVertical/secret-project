using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.BusinessProject.Models.UserData
{
    [Table("Users.DeliveryAdresses")]
    public class Adress : IDomainObject
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
        [ForeignKey(nameof(UserId))]
        [Required]
        public  User User { get; set; }
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
        /// <summary>
        /// Широта в градусах
        /// </summary>
        public virtual float Latitude { get; set; }
        /// <summary>
        /// Долгота в градусах
        /// </summary>
        public virtual float Longitude { get; set; }
        #endregion

        #region Foreign keys
        public int UserId { get; set; }
        #endregion

        #region Special Property
        #endregion
    }
}
