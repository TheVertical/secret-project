using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SecretProject.BusinessProject.DataAccess;
using SecretProject.BusinessProject.Models.Other;
using SecretProject.DAL.Contexts;

namespace SecretProject.DAL.DataAccess.Repository
{
    public class LocalizationRepository : BaseRepository, ILocalizationRepository
    {
        public LocalizationRepository(ILogger logger, LocalizationContext context) : base(logger, context)
        {
        }

        public async Task<IEnumerable<LocalizedString>> GetLiteralsAsync<TEnum>(Guid languageId,
            CancellationToken cancellationToken) where TEnum : Enum
        {
            var keys = Enum.GetNames(typeof(TEnum));

            return await Context.Set<LocalizedString>()
                .Where(s => s.LanguageId == languageId && keys.Contains(s.KeyString)).ToListAsync(cancellationToken);
        }

        public async Task<LocalizedString> GetLiteralAsync(Guid languageId, string key, CancellationToken cancellationToken)
        {
            return (await GetAsync<LocalizedString>(l => l.KeyString == key && l.LanguageId == languageId, cancellationToken)).FirstOrDefault();
        }
    }
}
