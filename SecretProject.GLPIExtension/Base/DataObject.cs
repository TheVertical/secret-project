using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace SecretProject.GLPIExtension.Base
{
    public abstract class DataObject
    {
        [XmlAttribute("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [XmlAttribute("title")]
        [JsonPropertyName("title")]
        public string Title;
    }
}