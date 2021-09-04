using SecretProject.BusinessProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretProject.WebApi.ViewModels
{
    public class ManufacturerViewModel
    {
        public ManufacturerViewModel(Manufacturer domain)
        {
            //TODO: move to Guid
            //Id = domain.Id;
            Name = domain.Name;
        }

        public int Id { get; set; }
        public string Type => this.GetType().Name;
        public string Name { get; set; }
    }
}
