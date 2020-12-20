using SecretProject.VisualElements.Elements.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class ContactBlock : VisualElement,IVisualElement, IColumnable
    {
        public string Phone { get; set; }
        public string OpeningHours { get; set; }
        public string Image { get; set; }
    }
}
