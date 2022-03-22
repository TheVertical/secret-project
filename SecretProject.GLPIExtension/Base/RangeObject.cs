using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace SecretProject.GLPIExtension.Base
{
    public abstract class RangeObject<T> : DataObject<T>
    {
        [XmlElement]
        [JsonPropertyName("max")]
        public T Max;

        [XmlElement]
        [JsonPropertyName("min")]
        public T Min;

        [XmlElement]
        public bool? IsRange { get; set; }

        public virtual bool IsValueOutOfRange { get => throw new NotImplementedException(); }
    }
}