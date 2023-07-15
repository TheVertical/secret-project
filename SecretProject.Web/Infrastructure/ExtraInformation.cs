using System;
using SecretProject.BusinessProject;

namespace SecretProject.Web.Infrastructure
{
    [Serializable]
    public class ExtraInformation
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public ExtraInformationType Type { get; set; }

        public object Data { get; set; }

        public ExtraInformation()
        {
            Title = Constants.DEFAULT_EXTRA_INFORMARTION_TITLE;
        }

        public ExtraInformation(object data, string title = null, string message = null, ExtraInformationType type = ExtraInformationType.Info)
        {
            Title = title;
            Message = message;
            Type = type;
            Data = data;
        }
    }
}
