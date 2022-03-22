using System;
using System.IO;
using System.Xml.Serialization;
using SecretProject.GLPIExtension.Base;

namespace SecretProject.GLPIExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new XmlSerializer(typeof(Scenario));

            using (var createdScenarioFile = File.Create("CreatedScenario.xml"))
            {
                serializer.Serialize(createdScenarioFile, Mock.Scenario);
            }

            var scenarioFile = new FileInfo("./CreatedScenario.xml");
            using (var fileStream = scenarioFile.OpenRead())
            {
                var scenario = serializer.Deserialize(fileStream);
                Console.WriteLine(scenario);
            }

        }
    }
}