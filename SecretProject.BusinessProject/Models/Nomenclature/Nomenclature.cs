using SecretProject.BusinessProject.Measurements;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.BusinessProject.Models.Good
{
    public enum VisibleStatus
    {
        Visible,Hidden
    }

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
        [StringLength(100)]
        public virtual string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name = "Описание")]
        public virtual string Description { get; set; }
        public virtual int? NomenclatureGroupId { get; set; }
        /// <summary>
        /// Группа номенклатуры
        /// </summary>
        [Display(Name = "Группа номенклатуры")]
        [ForeignKey(nameof(NomenclatureGroupId))]
        public virtual NomenclatureGroup NomenclatureGroup { get; set; }
        /// <summary>
        /// Url картинки
        /// </summary>
        [Display(Name = "Url картинки")]
        public virtual string ImageUrl { get; set; }
        public virtual int? ManufacturerId { get; set; }
        /// <summary>
        /// Производитель
        /// </summary>
        [Display(Name = "Производитель")]
        [ForeignKey(nameof(ManufacturerId))]
        public virtual Manufacturer Manufacturer { get; set; }
        /// <summary>
        /// Свойства номенклатуры
        /// </summary>
        [Display(Name = "Свойства номенклатуры")]
        public virtual List<NomenclatureProperty> Properties { get; set; }
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
                if (CostPolicy != null && CostPolicy.Variation != CostVariations.None)
                {
                    //TODO Mock скидки
                    //Discount(CostPolicy.CorrelateByProcentMock());
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
        /// <summary>
        /// Цена со скидкой
        /// </summary>
        [Display(Name = "Цена со скидкой")]
        public virtual float DiscountedCost { get; set; }
        [NotMapped]
        //QUESTION Может ценовую политику перенести в заказ?
        /// <summary>
        /// Ценовая политика номенклатуры
        /// </summary>
        [Display(Name = "Ценовая политика номенклатуры")]
        public CostPolicy CostPolicy { get; set; }
        [NotMapped]
        public bool IsDiscounted { get; set; }
        /// <summary>
        /// Статус видимости
        /// </summary>
        [Display(Name = "Статус видимости")]
        public VisibleStatus Status { get; set; }
        #endregion

        #region Foreign Keys
        

        #endregion

        #region Class Methods
        /// <summary>
        /// Уменьшает цену
        /// </summary>
        /// <param name="cost">определённая цена</param>
        //TODO Убрать методы уценения, сейчас это сделано для объекта Promotion, который с помошьюе этого метода уценяет номеклатуру
        public void Discount(float sum)
        {
            IsDiscounted = true;
            DiscountedCost =  Cost - sum;
        }
        /// <summary>
        /// Уменьшает цену
        /// </summary>
        /// <param name="percent">определенный процент</param>
        //TODO Убрать методы уценения, сейчас это сделано для объекта Promotion, который с помошьюе этого метода уценяет номеклатуру 
        public void Discount(int percent)
        {
            IsDiscounted = true;
            DiscountedCost =  Cost - Cost * percent / 100;
        }

        public override string ToString()
        {
            return $"Nomenclature:\n" +
                $"\tName:" + Name + "\n" +
                "\tCost:" + Cost + "\n" +
                "\tAmount:" + Amount;
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
