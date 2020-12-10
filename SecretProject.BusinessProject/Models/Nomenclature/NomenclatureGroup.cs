using SecretProject.BusinessProject.Models.Good;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.BusinessProject.Models
{
    public class NomenclatureGroup : IDomainObject
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
        /// Название группы номенклатуры
        /// </summary>
        [Display(Name = "Название группы номенклатуры")]
        public virtual string Name { get; set; }
        /// <summary>
        /// Родительская группа
        /// </summary>
        [Display(Name = "Родительская группа")]
        public virtual NomenclatureGroup Parent { get; set; }
        /// <summary>
        /// Дочерние группы
        /// </summary>
        [Display(Name = "Дочерние группы")]
        public virtual IList<NomenclatureGroup> Childs { get; set; }
        /// <summary>
        /// Статус видимости
        /// </summary>
        [Display(Name = "Статус видимости")]
        public VisibleStatus Status { get; set; }
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
