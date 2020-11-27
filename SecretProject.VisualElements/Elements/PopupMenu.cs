using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class PopupMenu : IVisualElement
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public string Type => this.GetType().Name;
        //TODO Убрать mock данные
        public List<PopupMenuItem> Items { get; set; } = new List<PopupMenuItem>() {
            new PopupMenuItem { Title = "Title",Route = "Route",
            Items = new List<PopupMenuItem>() { new PopupMenuItem { Title = "Title", Route = "Route"} }
            },
            new PopupMenuItem { Title = "Title",Route = "Route",
            Items = new List<PopupMenuItem>() { new PopupMenuItem { Title = "Title", Route = "Route"} }
            },
            new PopupMenuItem { Title = "Title",Route = "Route",
            Items = new List<PopupMenuItem>() { new PopupMenuItem { Title = "Title", Route = "Route"} }
            },
        };
    }

    public class PopupMenuItem
    {
        public string Title { get; set; }
        public string Route { get; set; }
        public List<PopupMenuItem> Items { get; set; } = new List<PopupMenuItem>();

    }

}
