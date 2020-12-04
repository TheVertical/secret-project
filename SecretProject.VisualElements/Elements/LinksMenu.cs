using SecretProject.VisualElements.Elements.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class LinksMenu : VisualElement,IVisualElement, IColumnable
    {
        public string MainTitle { get; set; }
        public bool IsHorizontal { get; set; }
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
        public LinkItem()
        {

        }
        public LinkItem(int id, string title, string link)
        {
            Id = id;
            Title = title;
            Link = link;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }

    }
}
