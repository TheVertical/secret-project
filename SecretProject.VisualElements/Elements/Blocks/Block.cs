using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SecretProject.VisualElements.Elements
{
    public class Block
    {
        //public string Parametrs { get; set; }
        public ArrayList VisualElements { get; set; } = new ArrayList();
        public void AddVisualElement(object element)
        {
            VisualElements.Add(element);
        }
    }
}
