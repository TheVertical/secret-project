using System;
using System.Collections.Generic;

namespace SecretProject.BusinessProject
{
    public static class Constants
    {
        public static readonly string DEFAULT_EXTRA_INFORMARTION_TITLE = "SecretProject";

        public static Dictionary<string, string> ClaimTypesIds = new Dictionary<string, string>()
        {
            {"FullAccess",  "62AAEBF4-B9DF-40EC-A3D7-3F289EB484AB"},
            {"BasicAccess", "DE73C77A-7E0F-4761-8876-431BADD59142" }
        };

        public static Dictionary<string, Guid> LanguageCodeIds = new Dictionary<string, Guid>()
        {
            {"EN", Guid.Parse("8AD8D0ED-752A-4CA2-8559-8BAE32B225A8")},
            {"RU", Guid.Parse("38C104DC-6A5D-4D8D-8819-5EC2CCAAA425")}
        };
    }
}

