using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecretProject.BusinessProject.Models.User
{
    public class User : DomainObject
    {

        #region Base Property

        /// <summary>
        /// Ид
        /// <summary>
        [Display(Name = "Ид")]
        public virtual int Id { get; set; }
        /// <summary>
        /// Специальный байтовый код для параллельных запросов к бд
        /// <summary>
        [Display(Name = "Специальный байтовый код для параллельных запросов к бд")]
        public virtual byte[] Timestamp { get; set; }

        public virtual string Login { get; set; }

        #endregion

        #region Foreign keys
        //Внешние ключи
        #endregion

        #region Special Property
        #endregion
    }
}
