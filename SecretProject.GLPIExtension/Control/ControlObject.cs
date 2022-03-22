using SecretProject.GLPIExtension.Base;
using SecretProject.VisualElements.Elements.Base;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace SecretProject.GLPIExtension.Control
{
    public abstract class ControlObject
    {
        [XmlElement]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [XmlElement]
        [JsonPropertyName("order")]
        public int Order { get; set; }

        [XmlArray]
        [
            XmlArrayItem(typeof(TextObject)),
            XmlArrayItem(typeof(ImageObject)),
        ]
        public DataObject[] Children { get; set; }
    }
}