using System.Collections.Generic;
using CommandLine;

namespace SecretProject.DevTools
{
    [Verb("update", isDefault: true, HelpText = "Update strings in db")]
    internal class UpdateOptions
    {
        [Option(shortName:'t', longName:"languages", Default = "ru", Separator = ':', HelpText = "Set what language strings will be updated", Hidden = false)]
        public IEnumerable<string> Languages { get; set; }
    }
}