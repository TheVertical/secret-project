using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace SecretProject.GLPIExtension.Base
{
    public enum SelectType
    {
        Default,
        Radio,
        Checkbox
    }

    [XmlType(TypeName = "Select")]
    public class SelectObject : DataObject
    {
        [XmlEnum("type")]
        [JsonPropertyName("type")]
        public int Type;

        [XmlArray]
        [JsonPropertyName("children")]
        public List<SelectObjectItem> Children;
    }

    [XmlType(TypeName = "SelectItem")]
    public class SelectObjectItem
    {
        [XmlArray]
        public List<DataObject> Children;
    }
}