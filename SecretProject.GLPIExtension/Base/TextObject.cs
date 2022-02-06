using System;
using System.Xml.Serialization;
using SecretProject.GLPIExtension.Base;

namespace SecretProject.VisualElements.Elements.Base
{
    [Serializable]
    public class TextObject : RangeObject
    {
        [XmlElement]
        public string Value;
    }
}