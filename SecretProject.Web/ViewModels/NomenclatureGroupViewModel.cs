using System;
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
            //TODO: move to Guid
            //Id = domain.Id;
            Name = domain.Name;
            Parent = domain.Parent;
            Childs = domain.Childs;
        }
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public string Type => this.GetType().Name;
        public virtual string Name { get; set; }
        /// <summary>
        /// Parent Group
        /// </summary>
        public virtual NomenclatureGroup Parent { get; set; }
        /// <summary>
        /// Nomenclature Childs
        /// </summary>
        public virtual IList<NomenclatureGroup> Childs { get; set; }

    }
}
