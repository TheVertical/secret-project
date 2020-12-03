using SecretProject.VisualElements.Elements.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class ComboBoxButton : Button, IVisualElement
    {
        public IList<ComboBoxButton> Items { get; set; } = new List<ComboBoxButton>();
    }
}
