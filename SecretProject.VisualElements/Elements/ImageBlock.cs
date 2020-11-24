using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class ImageBlock : IVisualElement
    {
        [Key]
        public Guid Id { get; set; }
        [NotMapped]
        public string Type => this.GetType().Name;
        public string Alt { get; set; }
        public string Source { get; set; }
    }
}
