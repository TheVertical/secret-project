using SecretProject.BusinessProject.Models.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.BusinessProject.Models.Common
{
    public class Company : IDomainObject
    {

        #region Base Property
        /// <summary>
        /// Ид
        /// </summary>
        [Display(Name = "Ид")]
        public virtual int Id { get; set; }
        /// <summary>
        /// Специальный байтовый код для параллельных запросов к бд
        /// <summary>
        [Timestamp]
        public virtual byte[] Timestamp { get; set; }
        /// <summary>
        /// Название компании
        /// </summary>
        [Display(Name = "Название компании")]
        public string Name { get; set; }
        /// <summary>
        /// Часы работы компании
        /// </summary>
        [Display(Name = "Часы работы компании")]
        public virtual string WorkHours { get; set; }
        public string PhoneNumber { 
            get => WorkPhone.PhoneDigits;
            set
            {
                WorkPhone.PhoneNumber = value;
            }
        }
        /// <summary>
        /// Телефон горячей линии
        /// </summary>
        [Display(Name = "Телефон горячей линии")]
        [NotMapped]
        public Phone WorkPhone = new Phone();
        #endregion

        #region Foreign keys
        //Внешние ключи
        #endregion

        #region Special Property
        #endregion
    }
}
