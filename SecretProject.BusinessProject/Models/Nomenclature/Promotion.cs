using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SecretProject.BusinessProject.Models.Good
{
    public class Promotion : IDomainObject
    {

        #region Base Property
        /// <summary>
        /// Ид
        /// </summary>
        [Display(Name = "Ид")]
        public virtual int Id { get; set; }
        /// <summary>
        /// Специальный байтовый код для параллельных запросов к бд
        /// </summary>
        [Timestamp]
        public virtual byte[] Timestamp { get; set; }
        /// <summary>
        /// Рабочее название акции
        /// </summary>
        [Display(Name = "Рабочее название акции")]
        public virtual string WorkTitle { get; set; }
        /// <summary>
        /// Официальное название акции, которые выводится пользователю
        /// </summary>
        [Display(Name = "Официальное название")]
        public virtual string OfficialTitle { get; set; }
        /// <summary>
        /// Номенклатуры входящие в акцию
        /// </summary>
        [Display(Name = "Номенклатуры входящие в акцию")]
        public virtual List<Nomenclature> DiscountedNomenclatures { get; set; }
        #endregion

        public void DiscountNomenclature(Nomenclature nomenclature,int percent)
        {
            nomenclature.Discount(percent);
            DiscountedNomenclatures.Add(nomenclature);
        }

        public void DiscountNomenclature(IEnumerable<Nomenclature> nomenclatures, int percent)
        {
            nomenclatures.ToList().ForEach(nom => nom.Discount(percent));
            DiscountedNomenclatures.AddRange(nomenclatures);
        }
        public void DiscountNomenclature(Nomenclature nomenclature, float sum)
        {
            nomenclature.Discount(sum);
            DiscountedNomenclatures.Add(nomenclature);
        }
        #region Foreign keys
        //Внешние ключи
        #endregion

        #region Special Property
        #endregion
    }
}
