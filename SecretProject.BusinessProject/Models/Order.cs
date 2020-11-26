using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecretProject.BusinessProject.Models
{
    public class Order : IDomainObject
    {

        #region Base Property
        [Display(Name = "Ид")]
        public virtual int Id { get; set; }
        /// <summary>
        /// Специальный байтовый код для параллельных запросов к бд
        /// <summary>
        [Display(Name = "Специальный байтовый код для параллельных запросов к бд")]
        public virtual byte[] Timestamp { get; set; }

        //public Nomenclature 
        #endregion

        #region Foreign keys
        //Внешние ключи
        #endregion

        #region Special Property

        #endregion
    }
}
