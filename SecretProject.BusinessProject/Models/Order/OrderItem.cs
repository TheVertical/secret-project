using SecretProject.BusinessProject.Models.Nomeclature;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.BusinessProject.Models.Order
{
    /// <summary>
    /// Класс описывает позицию в заказе
    /// </summary>
    [Table("Orders.Items")]
    public class OrderItem : IDomainObject
    {
        #region Base Property
        [Key]
        [Display(Name = "Ид")]
        public virtual int Id { get; set; }
        /// <summary>
        /// Специальный байтовый код для параллельных запросов к бд
        /// <summary>
        [Timestamp]
        public virtual byte[] Timestamp { get; set; }

        /// <summary>
        /// Связанная номенклатура
        /// <summary>
        [Display(Name = "Связанная номенклатура")]
        [Required]
        public virtual Nomenclature Nomenclature { get; set; }

        /// <summary>
        /// Заказ
        /// </summary>
        [ForeignKey(nameof(OrderId))]
        [Required]
        public virtual Order Order { get; set; }

        /// <summary>
        /// Количество заказанное пользователем
        /// <summary>
        [Display(Name = "Количество заказанное пользователем")]
        [Required]
        public int actualCount { get; set; }

        /// <summary>
        /// Конечная цена продукта
        /// <summary>
        [Display(Name = "Конечная цена продукта")]
        public float Cost { get; set; }

        #endregion

        #region Foreign keys
        public virtual int OrderId { get; set; }
        public virtual int NomenclatureId { get; set; }
        #endregion
        #region Special Property
        #endregion
    }
}
