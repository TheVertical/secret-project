using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class CheckBoxButton : Button, IVisualElement
    {
        public bool IsCheck { get; set; }
        public IVisualGroup Group { get; set; }

    }
}
