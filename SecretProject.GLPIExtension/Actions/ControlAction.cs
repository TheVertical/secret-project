using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace SecretProject.GLPIExtension.Actions
{
    public class ControlAction
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MyProperty { get; set; }
    }
}