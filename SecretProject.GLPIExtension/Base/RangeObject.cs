using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace SecretProject.GLPIExtension.Base
{
    public abstract class RangeObject : DataObject
    {
        [XmlAttribute("max")]
        [JsonPropertyName("max")]
        public int Max;

        [XmlAttribute("min")]
        [JsonPropertyName("min")]
        public int Min;
    }
}