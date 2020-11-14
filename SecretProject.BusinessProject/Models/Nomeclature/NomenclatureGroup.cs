using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.BusinessProject.Models
{
    public class NomenclatureGroup : DomainObject
    {
        #region Base Property
        /// <summary>
        /// Название группы номенклатуры
        /// <summary>
        [Display(Name = "Название группы номенклатуры")]
        public virtual string Name { get; set; }
        /// <summary>
        /// Родительская группа
        /// <summary>
        [Display(Name = "Родительская группа")]
        public virtual NomenclatureGroup Parent { get; set; }
        /// <summary>
        /// Дочерние группы
        /// <summary>
        [Display(Name = "Дочерние группы")]
        public virtual IList<NomenclatureGroup> Childs { get; set; }
        //Базовые св-ва сущности

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
