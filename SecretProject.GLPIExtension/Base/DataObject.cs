using System;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace SecretProject.GLPIExtension.Base
{
    public abstract class DataObject
    {
        [XmlElement]
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [XmlElement]
        [JsonPropertyName("title")]
        public string Title;

        [XmlIgnore]
        public object Value { get; set; }
    }

    public abstract class DataObject<T> : DataObject
    {
        [XmlElement]
        public T Value { get; set; }
    }
}