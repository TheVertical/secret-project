﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class ComboBoxButton : IButton, IVisualElement
    {
        [Key]
        public Guid Id { get; set; }
        [NotMapped]
        public string Type => this.GetType().Name;
        [StringLength(20)]
        public string Title { get; set; }
        public IVisualGroup Children { get; set; }

    }
}
