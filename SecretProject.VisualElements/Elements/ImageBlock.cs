using SecretProject.VisualElements.Elements.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class ImageBlock : VisualElement,IVisualElement, IColumnable
    {
        public string Alt { get; set; }
        public string Source { get; set; }
    }
}
