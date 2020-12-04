using SecretProject.VisualElements.Elements.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class Group<TButton> : VisualElement,IVisualElement
        where TButton : IButton
    {
        [StringLength(20)]
        public string Title { get; set; }
        public List<TButton> Items { get; set; } = new List<TButton>();

    }
}
