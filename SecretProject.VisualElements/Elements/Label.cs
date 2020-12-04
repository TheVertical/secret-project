using SecretProject.VisualElements.Elements.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class Label : VisualElement, IVisualElement
    {
        public string Text { get; set; }
    }
}
