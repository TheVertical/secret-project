using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace SecretProject.GLPIExtension.Base
{

    [XmlType(TypeName = "Image")]
    public class ImageObject : FileObject
    {
        /// <summary>
        /// path to image
        /// </summary>
        [XmlAttribute("path")]
        [JsonPropertyName("path")]
        public string Path;
    }
}
