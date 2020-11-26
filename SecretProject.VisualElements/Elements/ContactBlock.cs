using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class ContactBlock : IVisualElement
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public string Type => this.GetType().Name;
        public string Phone { get; set; }
        public string OpeningHours { get; set; }
    }
}
