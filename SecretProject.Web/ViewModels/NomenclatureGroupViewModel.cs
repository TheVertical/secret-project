using SecretProject.BusinessProject.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecretProject.WebApi.ViewModels
{
    public class NomenclatureGroupViewModel : IViewModel
    {
        public NomenclatureGroupViewModel(NomenclatureGroup domain)
        {
            if (domain != null)
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
