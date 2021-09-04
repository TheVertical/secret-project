using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SecretProject.BusinessProject.Models;
using SecretProject.BusinessProject.Models.Other;

namespace SecretProject.Web.Services.Interfaces
{
    public interface ILocalizationService
    {
        Task<string> LocalizeAsync(LocalizationKey key, CancellationToken cancellationToken);
        Task<Guid> GetDefaultLanguageAsync(Guid? userId, CancellationToken cancellationToken);

        Task<IDictionary<string, string>> GetLiterals<TEnum>(Guid languageId, CancellationToken cancellationToken)
            where TEnum : Enum;
    }
}