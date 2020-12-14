using SecretProject.VisualElements.Elements.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class Banner : VisualElement, IVisualElement,IColumnable
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string ImageSource { get; set; }

    }
}
