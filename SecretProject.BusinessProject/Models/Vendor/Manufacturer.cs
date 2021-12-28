using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecretProject.BusinessProject.Models
{
    [Table("Manufacturers")]
    public class Manufacturer : IDomainObject
    {
        #region Base Property

        /// <summary>
        /// Ид
        /// </summary>
        public virtual Guid Id { get; set; }
        /// <summary>
        /// Специальный байтовый код для параллельных запросов к бд
        /// </summary>
        [Timestamp]
        public virtual byte[] Timestamp { get; set; }

        /// <summary>
        /// Название произовдителя
        /// </summary>
        [StringLength(50)]
        public virtual string Name { get; set; }
        /// <summary>
        /// Описание производителя
        /// </summary>
        [StringLength(50)]
        public virtual string Description { get; set; }

        #region Foreign keys

        #endregion
        #endregion

        #region Special Property
        #endregion

    }
}
