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
        /// <summary>
        /// Связанный 1с объект
        /// <summary>
        [Display(Name = "Связанный 1с объект")]
        public virtual ocObject OcObject { get; set; }

        #endregion

    }
}
