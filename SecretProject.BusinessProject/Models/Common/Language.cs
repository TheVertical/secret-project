using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretProject.BusinessProject.Models.Common
{
    public class Language : IDomainObject
    {
        public Guid Id { get; set; }

        public byte[] Timestamp { get; set; }

        public string LanguageCode { get; set; }

        public string CommonName { get; set; }

        public string SelfName { get; set; }
    }
}
