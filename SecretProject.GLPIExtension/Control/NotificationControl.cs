using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

public enum Frequency
{
    [XmlEnum("default")]
    Default,
    [XmlEnum("increasing")]
    Increasing,
    [XmlEnum("decreasing")]
    Decreasing
}

namespace SecretProject.GLPIExtension.Control
{
    [XmlType(TypeName = "Notification")]
    public class NotificationControl : ControlObject
    {
        public DateTime Timeout { get; set; }

        public Frequency Frequency { get; set; }

        // public  MyProperty { get; set; }
    }
}