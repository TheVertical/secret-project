using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.BusinessProject.Models
{
    [Table("Manufacturers")]
    public class Manufacturer : DomainObject
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
        /// Название произовдителя
        /// <summary>
        [Display(Name = "Название произовдителя")]
        [StringLength(50)]
        public virtual string Name { get; set; }
        /// <summary>
        /// Описание производителя
        /// <summary>
        [Display(Name = "Описание производителя")]
        [StringLength(50)]
        public virtual string Description { get; set; }

        #region Foreign keys
        public virtual int NomenclatureId { get; set; }
        [ForeignKey(nameof(NomenclatureId))]
        public virtual Nomenclature Nomenclature { get; set; }
        #endregion
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
