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
        public virtual Guid Id { get; set; }
        /// <summary>
        /// Специальный байтовый код для параллельных запросов к бд
        /// <summary>
        [Timestamp]
        public virtual byte[] Timestamp { get; set; }
        /// <summary>
        /// Название номенклатуры
        /// </summary>
        [StringLength(100)]
        public virtual string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual string Description { get; set; }
        public virtual Guid NomenclatureGroupId { get; set; }
        /// <summary>
        /// Группа номенклатуры
        /// </summary>
        [ForeignKey(nameof(NomenclatureGroupId))]
        public virtual NomenclatureGroup NomenclatureGroup { get; set; }
        /// <summary>
        /// Url картинки
        /// </summary>
        public virtual string ImageUrl { get; set; }
        public virtual Guid ManufacturerId { get; set; }
        /// <summary>
        /// Производитель
        /// </summary>
        [ForeignKey(nameof(ManufacturerId))]
        public virtual Manufacturer Manufacturer { get; set; }
        /// <summary>
        /// Свойства номенклатуры
        /// </summary>
        public virtual List<NomenclatureProperty> Properties { get; set; }
        /// <summary>
        /// Измерение номенклатуры (еденица измерения и т.д.)
        /// </summary>
        public virtual Measurement Measurement { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public virtual int Amount { get; set; }
        private float cost;
        /// <summary>
        /// Оригинальная цена по номенклатуре
        /// </summary>
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
        public virtual float DiscountedCost { get; set; }
        [NotMapped]
        //QUESTION Может ценовую политику перенести в заказ?
        /// <summary>
        /// Ценовая политика номенклатуры
        /// </summary>
        public CostPolicy CostPolicy { get; set; }
        [NotMapped]
        public bool IsDiscounted { get; set; }
        /// <summary>
        /// Статус видимости
        /// </summary>
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
        //public virtual Guid OcObject { get; set; }

        #endregion

    }
}
