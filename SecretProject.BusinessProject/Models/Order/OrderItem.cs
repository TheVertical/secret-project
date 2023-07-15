using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SecretProject.BusinessProject.Models.Common;

namespace SecretProject.BusinessProject.Models.Order
{
    /// <summary>
    /// Класс описывает позицию в заказе
    /// </summary>
    [Table("Orders.Items")]
    public class OrderItem : IDomainObject
    {
        public OrderItem()
        {
        }
        public OrderItem(Nomenclature.Nomenclature nomenclature,int actualCount)
        {
            Nomenclature = nomenclature;
            ActualCount = actualCount;
        }
        #region Base Property
        [Key]
        [Display(Name = "Ид")]
        public virtual Guid Id { get; set; }
        /// <summary>
        /// Специальный байтовый код для параллельных запросов к бд
        /// </summary>
        [Timestamp]
        public virtual byte[] Timestamp { get; set; }
        private Nomenclature.Nomenclature nomenclature;
        /// <summary>
        /// Связанная номенклатура
        /// </summary>
        [Display(Name = "Связанная номенклатура")]
        [Required]
        public virtual Nomenclature.Nomenclature Nomenclature
        {
            get => nomenclature;
            set
            {
                NomenclatureId = value.Id;
                nomenclature = value;
                Cost = value.Cost;
            }
        }
        /// <summary>
        /// Количество заказанное пользователем товара
        /// </summary>
        public int ActualCount { get; set; }
        /// <summary>
        /// Конечная цена продукта
        /// </summary>
        [Display(Name = "Конечная цена за 1-цу товара")]
        public float Cost { get; set; }
        [NotMapped]
        public float FullCostItem => Cost * ActualCount;
        #endregion
        #region Foreign keys
        public virtual int OrderId { get; set; }
        public virtual Guid NomenclatureId { get; set; }
        #endregion
        #region Special Property
        #endregion
    }
}
