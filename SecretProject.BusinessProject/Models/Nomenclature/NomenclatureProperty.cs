﻿using System;
using System.ComponentModel.DataAnnotations;
using SecretProject.BusinessProject.Models.Common;

namespace SecretProject.BusinessProject.Models.Nomenclature
{
    public class NomenclatureProperty : IDomainObject
    {
        #region Base Property

        /// <summary>
        /// Ид
        /// </summary>
        [Display(Name = "Ид")]
        [Key]
        public virtual Guid Id { get; set; }
        /// <summary>
        /// Специальный байтовый код для параллельных запросов к бд
        /// </summary>
        [Timestamp]
        public virtual byte[] Timestamp { get; set; }

        /// <summary>
        /// Название свойства номенклатуры
        /// </summary>
        [Display(Name = "Название свойства номенклатуры")]
        public virtual string Name { get; set; }

        /// <summary>
        /// Тип свойства номенклатуры
        /// </summary>
        [Display(Name = "Тип свойства номенклатуры")]
        public virtual string Type { get; set; }

        /// <summary>
        /// Значение свойства номенклатуры
        /// </summary>
        [Display(Name = "Значение свойства номенклатуры")]
        public virtual string Value { get; set; }

        #endregion

        #region Foreign keys
        #endregion

        #region Special Property
        ///// <summary>
        ///// Связанный 1с объект
        ///// <summary>
        //[Display(Name = "1с guid")]
        //public virtual Guid OcObject { get; set; }
        #endregion
    }
}
