using SecretProject.BusinessProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecretProject.WebApi.ViewModels
{
    public class NomenclatureGroupViewModel : IViewModel
    {
        public NomenclatureGroupViewModel(NomenclatureGroup domain)
        {
            Id = domain.Id;
            Name = domain.Name;
            Parent = domain.Parent;
            Childs = domain.Childs;
        }
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public string Type => this.GetType().Name;
        [Display(Name = "Название группы номенклатуры")]
        public virtual string Name { get; set; }
        /// <summary>
        /// Родительская группа
        /// </summary>
        [Display(Name = "Родительская группа")]
        public virtual NomenclatureGroup Parent { get; set; }
        /// <summary>
        /// Дочерние группы
        /// </summary>
        [Display(Name = "Дочерние группы")]
        public virtual IList<NomenclatureGroup> Childs { get; set; }

    }
}
