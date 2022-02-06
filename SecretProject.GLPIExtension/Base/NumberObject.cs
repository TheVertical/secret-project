using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace SecretProject.GLPIExtension.Base
{
    [XmlType(TypeName = "Number")]
    public class NumberObject : RangeObject
    {
        [XmlAttribute("isRange")]
        [JsonPropertyName("isRange")]
        public bool IsRange { get; set; }
    }
}