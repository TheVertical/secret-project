using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class LinksMenu : IVisualElement
    {
        [Key]
        public Guid Id { get; set; }
        [NotMapped]
        public string Type => this.GetType().Name;
        public IEnumerable<LinkItem> Links { get; set; }
        public LinksMenu()
        {
        }
        public LinksMenu(IEnumerable<LinkItem> links)
        {
            Links = links;
        }
    }

    public class LinkItem
    {
        public LinkItem(Guid id, string title, string link)
        {
            Id = id;
            Title = title;
            Link = link;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }

    }
}
