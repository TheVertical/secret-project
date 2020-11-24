using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretProject.ViewModels
{
    public class GoodViewModel
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDiscouted { get; set; }
        public bool IsNew { get; set; }
        public bool IsPopular { get; set; }
        public bool IsALot { get; set; }
        public bool IsInStock { get; set; }
    }
}
