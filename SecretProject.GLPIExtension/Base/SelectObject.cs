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
    public class SelectObject<T> : DataObject<SelectObjectItem<T>>
    {
        [XmlEnum("type")]
        [JsonPropertyName("type")]
        public int Type;

        [XmlArray]
        [JsonPropertyName("children")]
        public List<SelectObjectItem<T>> Children;
    }

    [XmlType(TypeName = "SelectItem")]
    public class SelectObjectItem<T> : DataObject<T>
    {
    }
}