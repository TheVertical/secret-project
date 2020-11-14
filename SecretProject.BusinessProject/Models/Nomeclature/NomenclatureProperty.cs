using SecretProject.BusinessProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SecretProject.BusinessProject.Models
{
    public class NomenclatureProperty : DomainObject
    {
        #region Base Property
        /// <summary>
        /// Название свойства номенклатуры
        /// <summary>
        [Display(Name = "Название свойства номенклатуры")]
        public virtual string Name { get; set; }

        /// <summary>
        /// Тип свойства номенклатуры
        /// <summary>
        [Display(Name = "Тип свойства номенклатуры")]
        public virtual string Type { get; set; }

        /// <summary>
        /// Значение свойства номенклатуры
        /// <summary>
        [Display(Name = "Значение свойства номенклатуры")]
        public virtual string Value { get; set; }

        #region Foreign keys
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
