using SecretProject.VisualElements.Elements;
using SecretProject.VisualElements.Elements.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class MiniProductCard : VisualElement,IVisualElement, IColumnable
    {
        public object Model { get; set; }
    }
}
