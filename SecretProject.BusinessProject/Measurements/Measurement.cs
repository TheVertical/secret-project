using SecretProject.BusinessProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.BusinessProject.Measurements
{
    public class Measurement : IDomainObject
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

        /// <summary>
        /// Полное имя единицы измерения
        /// <summary>
        [Display(Name = "Полное имя единицы измерения")]
        public virtual string Name { get; set; }

        /// <summary>
        /// Международное сокращение
        /// <summary>
        [Display(Name = "Международное сокращение")]
        public virtual string InternationalName { get; set; }

        /// <summary>
        /// Идентификационный код
        /// <summary>
        [Display(Name = "Идентификационный код")]
        public virtual int ocCode { get; set; }

        /// <summary>
        /// Коэффициент
        /// <summary>
        [Display(Name = "Коэффициент")]
        public virtual float Coefficient { get; set; }

        #endregion

        #region Special Property
        #endregion
    }
}
