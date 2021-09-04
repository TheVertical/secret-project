using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SecretProject.BusinessProject.Models.Other;

namespace SecretProject.BusinessProject.DataAccess
{
    public interface ILocalizationRepository : IAsyncDisposable
    {
        Task<IEnumerable<LocalizedString>> GetLiteralsAsync<TEnum>(Guid languageId, CancellationToken cancellationToken)
            where TEnum : Enum;

        Task<LocalizedString> GetLiteralAsync(Guid languageId, string key, CancellationToken cancellationToken);
    }
}
