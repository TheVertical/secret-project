using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecretProject.BusinessProject.Models
{
    public class Nomenclature : DomainObject
    {
        #region Base Properties

        /// <summary>
        /// Название номенклатуры
        /// <summary>
        [Display(Name = "Название номенклатуры")]
        [StringLength(50)]
        public virtual string Name { get; set; }
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

        #endregion
        #region Special Properties
            /// <summary>
            /// Связанный 1с объект
            /// <summary>
            [Display(Name = "Связанный 1с объект")]
            public virtual ocObject OcObject { get; set; }
        #endregion

    }
}
