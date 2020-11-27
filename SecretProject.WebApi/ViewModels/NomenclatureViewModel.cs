using SecretProject.BusinessProject.Models.Nomeclature;
using SecretProject.VisualElements.Elements;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecretProject.WebApi.ViewModels
{
    public class NomenclatureViewModel : IVisualElement
    {
        public NomenclatureViewModel(Nomenclature domain)
        {
            Title = domain.Name;
            Description = domain.Description;
            Price = domain.Cost;
            IsDiscouted = domain.IsDiscounted;
            IsInStock = domain.Amount > 0;
            //TODO Можно у номенклатуры добавить поля популярности и даты добавления в каталог
            IsNew = false;
            IsPopular = true;
        }
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public string Type => this.GetType().Name;

        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDiscouted { get; set; }
        public bool IsNew { get; set; }
        public bool IsPopular { get; set; }
        public bool IsInStock { get; set; }
    }
}
