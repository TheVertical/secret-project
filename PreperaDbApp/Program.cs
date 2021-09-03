using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace SecretProject.DevTools
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = new JsonConfigurationSource {Path = "user.connection.strings.json"};
            IConfigurationProvider provider = new JsonConfigurationProvider(source);
            var providers = new List<IConfigurationProvider> {provider};
            IConfiguration configuration = new ConfigurationRoot(providers);

            string localizationString = configuration.GetConnectionString("SecretDb.LocalizeDb");
        }
    }

    public class CommandParser
    {
        public void ParseCommand(string commandLine)
        {
        }
    }

}
