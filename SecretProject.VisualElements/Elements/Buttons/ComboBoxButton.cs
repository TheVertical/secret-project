﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class ComboBoxButton : Button, IVisualElement
    {
        public IList<ComboBoxButton> Children { get; set; } = new List<ComboBoxButton>();
    }
}
