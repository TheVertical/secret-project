using SecretProject.BusinessProject.Measurements;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.BusinessProject.Models.Nomeclature
{
    public class Nomenclature : IDomainObject
    {
        #region Base Properties
        /// <summary>
        /// Ид
        /// </summary>
        [Display(Name = "Ид")]
        public virtual int Id { get; set; }
        /// <summary>
        /// Специальный байтовый код для параллельных запросов к бд
        /// <summary>
        [Timestamp]
        public virtual byte[] Timestamp { get; set; }
        /// <summary>
        /// Название номенклатуры
        /// </summary>
        [Display(Name = "Название номенклатуры")]
        [StringLength(50)]
        public virtual string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name = "Описание")]
        public virtual string Description { get; set; }
        /// <summary>
        /// Группа номенклатуры
        /// </summary>
        [Display(Name = "Группа номенклатуры")]
        public virtual NomenclatureGroup NomenclatureGroup { get; set; }
        /// <summary>
        /// Производитель
        /// </summary>
        [Display(Name = "Производитель")]
        public virtual Manufacturer Manufacturer { get; set; }
        /// <summary>
        /// Свойства номенклатуры
        /// </summary>
        [Display(Name = "Свойства номенклатуры")]
        public virtual ICollection<NomenclatureProperty> Properties { get; set; } = new HashSet<NomenclatureProperty>();
        /// <summary>
        /// Измерение номенклатуры (еденица измерения и т.д.)
        /// </summary>
        [Display(Name = "Измерение номенклатуры (еденица измерения и т.д.)")]
        public virtual Measurement Measurement { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        [Display(Name = "Количество")]
        public virtual int Amount { get; set; }
        private float cost;
        /// <summary>
        /// Оригинальная цена по номенклатуре
        /// </summary>
        [Display(Name = "Оригинальная цена по номенклатуре")]
        public virtual float Cost
        {
            get
            {
                if (CostPolicy.Variation != CostVariations.None)
                {
                    //TODO Mock скидки
                    Discount(CostPolicy.CorrelateByProcentMock());
                    IsDiscounted = true;
                }

                return cost;
            }
            set
            {
                IsDiscounted = false;
                cost = value;
            }
        }
        [NotMapped]
        //QUESTION Может ценовую политику перенести в заказ?
        /// <summary>
        /// Ценовая политика номенклатуры
        /// </summary>
        [Display(Name = "Ценовая политика номенклатуры")]
        public CostPolicy CostPolicy { get; set; }
        [NotMapped]
        public bool IsDiscounted { get; set; }
        #endregion

        #region Foreign Keys
        public virtual int PromotionId { get; set; }
        /// <summary>
        /// Акция
        /// </summary>
        [ForeignKey(nameof(PromotionId))]
        public virtual Promotion Promotion { get; set; }

    #endregion

    #region Class Methods
    /// <summary>
    /// Уменьшает цену
    /// </summary>
    /// <param name="cost">определённая цена</param>
    private void Discount(float sum)
        {
            Cost = Cost - sum;
        }
        /// <summary>
        /// Уменьшает цену
        /// </summary>
        /// <param name="percent">определенный процент</param>
        private void Discount(int percent)
        {
            Cost = Cost - Cost * percent / 100;
        }
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
