using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecretProject.BusinessProject.Models.Nomeclature
{
    public class Promotion : IDomainObject
    {

        #region Base Property
        /// <summary>
        /// Ид
        /// </summary>
        [Display(Name = "Ид")]
        public virtual int Id { get; set; }
        /// <summary>
        /// Специальный байтовый код для параллельных запросов к бд
        /// </summary>
        [Timestamp]
        public virtual byte[] Timestamp { get; set; }
        /// <summary>
        /// Рабочее название акции
        /// </summary>
        [Display(Name = "Рабочее название акции")]
        public virtual string WorkTitle { get; set; }
        /// <summary>
        /// Официальное название
        /// </summary>
        [Display(Name = "Официальное название")]
        public virtual string OfficialTitle { get; set; }

        public List<Nomenclature> DiscountedProducts { get; set; }
        #endregion


        #region Foreign keys
        //Внешние ключи
        #endregion

        #region Special Property
        #endregion
    }
}
