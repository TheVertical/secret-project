using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace SecretProject.GLPIExtension.Base
{
    [XmlType(TypeName = "DateTime")]
    public class DateTimeObject : RangeObject<DateTime>
    {
    }
}