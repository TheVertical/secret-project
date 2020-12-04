using SecretProject.VisualElements.Elements.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class DropdownMenu : VisualElement,IVisualElement
    {
        //TODO Убрать mock данные
        public List<DropdownItem> Items { get; set; } = new List<DropdownItem>() {
            new DropdownItem { Title = "Title",Route = "Route",
            Items = new List<DropdownItem>() { new DropdownItem { Title = "Title", Route = "Route"} }
            },
            new DropdownItem { Title = "Title",Route = "Route",
            Items = new List<DropdownItem>() { new DropdownItem { Title = "Title", Route = "Route"} }
            },
            new DropdownItem { Title = "Title",Route = "Route",
            Items = new List<DropdownItem>() { new DropdownItem { Title = "Title", Route = "Route"} }
            },
        };
    }

    public class DropdownItem
    {
        public string Title { get; set; }
        public string Route { get; set; }
        public List<DropdownItem> Items { get; set; } = new List<DropdownItem>();

    }

}
