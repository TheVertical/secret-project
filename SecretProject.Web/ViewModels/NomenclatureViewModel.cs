using System;
using SecretProject.BusinessProject.Models;
using SecretProject.BusinessProject.Models.Good;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecretProject.WebApi.ViewModels
{
    public class NomenclatureViewModel : IViewModel
    {
        public NomenclatureViewModel(Nomenclature domain)
        {
            //TODO: move to GUID
            Id = 0;
            Title = domain.Name;
            Description = domain.Description;
            if(domain.Manufacturer != null)
                Manufacturer = new ManufacturerViewModel(domain.Manufacturer);
            OriginalPrice = domain.Cost;
            ImageUrl = domain.ImageUrl;
            if (domain.IsDiscounted)
            {
                DiscountedPrice = domain.DiscountedCost;
                IsDiscouted = domain.IsDiscounted;
            }
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
        public ManufacturerViewModel Manufacturer { get; set; }
        public float OriginalPrice { get; set; }
        public float DiscountedPrice { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDiscouted { get; set; }
        public bool IsNew { get; set; }
        public bool IsPopular { get; set; }
        public bool IsInStock { get; set; }
    }
}
