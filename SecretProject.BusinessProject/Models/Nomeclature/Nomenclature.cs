using SecretProject.BusinessProject.Measurements;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.BusinessProject.Models
{
    public class Nomenclature : DomainObject
    {
        #region Base Properties
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
        /// Название номенклатуры
        /// <summary>
        [Display(Name = "Название номенклатуры")]
        [StringLength(50)]
        public virtual string Name { get; set; }
        /// <summary>
        /// Описание
        /// <summary>
        [Display(Name = "Описание")]
        public virtual string Description { get; set; }
        /// <summary>
        /// Группа номенклатуры
        /// <summary>
        [Display(Name = "Группа номенклатуры")]
        public virtual NomenclatureGroup NomenclatureGroup { get; set; }
        /// <summary>
        /// Производитель
        /// <summary>
        [Display(Name = "Производитель")]
        public virtual Manufacturer Manufacturer { get; set; }
        /// <summary>
        /// Свойства номенклатуры
        /// <summary>
        [Display(Name = "Свойства номенклатуры")]
        public virtual ICollection<NomenclatureProperty> Properties { get; set; } = new HashSet<NomenclatureProperty>();
        /// <summary>
        /// Измерение номенклатуры (количество, еденица измерения и т.д.)
        /// <summary>
        [Display(Name = "Измерение номенклатуры (количество, еденица измерения и т.д.)")]
        public virtual Measurement Measurement { get; set; }
        /// <summary>
        /// Количество
        /// <summary>
        [Display(Name = "Количество")]
        public virtual int Amount { get; set; }

        #endregion

        #region Special Properties
        ///// <summary>
        ///// Связанный 1с объект
        ///// <summary>
        //[Display(Name = "1с guid"),]
        //public virtual Guid OcObject { get; set; }

        #endregion

    }
}
