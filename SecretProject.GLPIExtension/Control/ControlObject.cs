using SecretProject.GLPIExtension.Base;
using SecretProject.VisualElements.Elements.Base;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace SecretProject.GLPIExtension.Control
{
    public abstract class ControlObject
    {
        [XmlAttribute("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [XmlAttribute("order")]
        [JsonPropertyName("order")]
        public int Order { get; set; }

        [XmlArray]
        [
            XmlArrayItem(typeof(TextObject)),
            XmlArrayItem(typeof(ImageObject))
        ]
        [JsonPropertyName("children")]
        public DataObject[] Children { get; set; }

        [XmlArray]
        [
            XmlArrayItem(Type = typeof(RequestControl)),
            XmlArrayItem(Type = typeof(AnswerControl))
        ]
        public ControlObject[] ControlChildren { get; set; }
    }
}