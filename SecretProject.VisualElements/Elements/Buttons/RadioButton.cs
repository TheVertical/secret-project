using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    class RadioButton : Button, IVisualElement
    {
        public List<RadioButton> Group { get; set; }
    }
}
