using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class Button : IVisualElement, IButton
    {
        [Key]
        public Guid Id { get; set; }
        [NotMapped]
        public string Type => this.GetType().Name;
        [StringLength(20)]
        public string Title { get; set; }
        public string ForwardingLink { get; set; }
    }
}
