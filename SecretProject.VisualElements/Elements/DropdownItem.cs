using System.Collections.Generic;

namespace SecretProject.VisualElements.Elements
{
    public class DropdownItem
    {
        public string Title { get; set; }
        public string Route { get; set; }
        public List<DropdownItem> Items { get; set; } = new List<DropdownItem>();

    }
}