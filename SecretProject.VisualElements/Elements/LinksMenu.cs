﻿using SecretProject.VisualElements.Elements.Common;
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
        public List<LinkItem> Links { get; set; } = new List<LinkItem>();
        public LinksMenu()
        {
        }
        public LinksMenu(IEnumerable<LinkItem> links)
        {
            Links = new List<LinkItem>();
            Links.AddRange(links);
        }
    }
}
