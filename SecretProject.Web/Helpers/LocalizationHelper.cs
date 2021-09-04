using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Unicode;
using SecretProject.BusinessProject;
using SecretProject.BusinessProject.Models.Other;

namespace SecretProject.Web.Helpers
{
    public class LocalizationHelper
    {
        public static Guid GetCurrentLanguageId() => Constants.LanguageCodeIds["RU"];
    }
}
