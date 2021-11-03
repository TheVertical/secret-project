using SecretProject.WebApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecretProject.Web.ViewModels;

namespace SecretProject.WebApi.ViewModels
{
    public class CartLineViewModel
    {
        public CartLineViewModel(NomenclatureViewModel model,int amount)
        {
            Model = model;
            Amount = amount;
        }
        public NomenclatureViewModel Model { get; set; }
        public int Amount { get; set; }
    }
}
