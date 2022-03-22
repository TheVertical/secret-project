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
        [XmlElement]
        [JsonPropertyName("maxSize")]
        public int MaxSize;

        /// <summary>
        /// min size in MB
        /// </summary>
        [XmlElement]
        [JsonPropertyName("minSize")]
        public int MinSize;
    }
}