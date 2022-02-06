using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace SecretProject.GLPIExtension.Base
{
    [XmlType(TypeName = "File")]
    public class FileObject : DataObject
    {
        /// <summary>
        /// max size in MB
        /// </summary>
        [XmlAttribute("maxSize")]
        [JsonPropertyName("maxSize")]
        public int MaxSize;

        /// <summary>
        /// min size in MB
        /// </summary>
        [XmlAttribute("minSize")]
        [JsonPropertyName("minSize")]
        public int MinSize;
    }
}