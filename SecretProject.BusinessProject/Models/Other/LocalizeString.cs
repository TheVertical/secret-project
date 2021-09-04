using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecretProject.BusinessProject.Models.Other
{
    public class LocalizedString : IDomainObject
    {
        public Guid Id { get; set; }

        public byte[] Timestamp { get; set; }

        public Guid LanguageId { get; set; }

        [NotMapped]
        public LocalizationKey Key => Enum.Parse<LocalizationKey>(KeyString);

        public string KeyString { get; set; }

        public string Value { get; set; }

    }
}
