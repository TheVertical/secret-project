using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using SecretProject.GLPIExtension.Control;

namespace SecretProject.GLPIExtension.Base
{
    public class Category
    {
        public string Name { get; set; }
    }

    public enum ScenarioType
    {
        [XmlEnum("incident")]
        Incident,
        [XmlEnum("request")]
        Request
    }

    public class Scenario
    {
        // [XmlElement]
        // [XmlAttribute(typeof())]
        [JsonPropertyName("type")]
        public ScenarioType ScenarioType;

        [XmlElement]
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [XmlArray]
        [
            XmlArrayItem(typeof(RequestControl)),
            XmlArrayItem(typeof(AnswerControl)),
        ]
        public ControlObject[] Children { get; set; }
    }
}